using Microsoft.Extensions.DependencyInjection;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.WinFormsUI.Helpers;
using System.Media;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormSales : Form
    {
        private readonly ISaleService _saleService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly IDocumentService _documentService;
        private readonly ICurrentUserService _currentUser;
        private readonly ILookupService _lookupService;
        private readonly IWhatsappService _whatsappService;
        private readonly IFileStorageService _storageService;
        private readonly ICameraService _cameraService;
        private readonly IBarcodeService _barcodeService;
        private readonly IPromotionService _promotionService;
        private readonly ICashShiftService _cashShiftService;
        private readonly IServiceProvider _serviceProvider;

        private readonly List<SaleItemDto> _cart = new();
        private CustomerDto? _selectedCustomer;
        private List<PaymentMethod> _paymentMethods = new();
        private SaleCalculationResultDto _currentCalculation = new();

        private bool _isCameraActive = false;
        private string _lastScannedBarcode = string.Empty;
        private DateTime _lastScanTime = DateTime.MinValue;

        public FormSales(
            ISaleService saleService,
            IProductService productService,
            ICustomerService customerService,
            IDocumentService documentService,
            ICurrentUserService currentUser,
            ILookupService lookupService,
            IWhatsappService whatsappService,
            IFileStorageService storageService,
            ICameraService cameraService,
            IBarcodeService barcodeService,
            IPromotionService promotionService,
            ICashShiftService cashShiftService,
            IServiceProvider serviceProvider)
        {
            _saleService = saleService;
            _productService = productService;
            _customerService = customerService;
            _documentService = documentService;
            _currentUser = currentUser;
            _lookupService = lookupService;
            _whatsappService = whatsappService;
            _storageService = storageService;
            _cameraService = cameraService;
            _barcodeService = barcodeService;
            _promotionService = promotionService;
            _cashShiftService = cashShiftService;
            _serviceProvider = serviceProvider;

            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(pnlBarcodeBar);
            UIThemeHelper.ApplyCardStyle(pnlRightSummary);
            ApplyIcons();

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnAdd.Click += async (s, e) => await AddFromInputAsync();
            this.btnRemove.Click += (s, e) => RemoveSelectedItem();
            this.btnSelectCustomer.Click += async (s, e) => await PromptSelectCustomerAsync();
            this.btnRegister.Click += async (s, e) => await ExecuteCheckoutAsync();
            this.btnToggleCam.Click += (s, e) => ToggleCamera();
            this.FormClosing += (s, e) => StopCamera();

            // Atajos de Teclado Globales en POS
            this.KeyDown += async (s, e) =>
            {
                switch (e.KeyCode)
                {
                    case UIThemeHelper.Shortcuts.SearchProduct:
                        txtProductCode.Focus();
                        txtProductCode.SelectAll();
                        break;

                    case UIThemeHelper.Shortcuts.SelectCustomer:
                        await PromptSelectCustomerAsync();
                        break;

                    case UIThemeHelper.Shortcuts.ChangeQuantity:
                        numQuantity.Focus();
                        numQuantity.Select(0, numQuantity.Text.Length);
                        break;

                    case UIThemeHelper.Shortcuts.Checkout:
                        await ExecuteCheckoutAsync();
                        break;

                    case UIThemeHelper.Shortcuts.DeleteItem:
                        RemoveSelectedItem();
                        break;

                    case UIThemeHelper.Shortcuts.ClearOrCancel:
                        ResetInputBar();
                        break;
                }
            };

            this.txtProductCode.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    await ProcessScannedBarcodeAsync(txtProductCode.Text.Trim(), (int)numQuantity.Value);
                }
            };

            this.dgvCart.CellDoubleClick += (s, e) => RemoveSelectedItem();
        }

        private void ApplyIcons()
        {
            lblScanIcon.Text = string.Empty;
            lblScanIcon.Image = UIIconHelper.Buscar;

            btnAdd.Image = UIIconHelper.IngresoManual;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnRemove.Image = UIIconHelper.Eliminar;
            btnRemove.ImageAlign = ContentAlignment.MiddleLeft;
            btnRemove.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnToggleCam.Image = UIIconHelper.CamaraEncender;
            btnToggleCam.ImageAlign = ContentAlignment.MiddleLeft;
            btnToggleCam.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        public async Task InitializeFormAsync()
        {
            var user = _currentUser.CurrentUser;
            bool isAdmin = user != null && user.RoleName.Equals("Administrador", StringComparison.OrdinalIgnoreCase);

            if (!isAdmin && !_currentUser.HasRegisterAssigned)
            {
                var selectForm = _serviceProvider.GetRequiredService<FormSelectCashRegister>();
                if (selectForm.ShowDialog(this) != DialogResult.OK)
                {
                    UIHelper.WarnMessage(this, "Debe seleccionar una caja para poder operar en la terminal de ventas.", "Caja Requerida");
                    this.BeginInvoke(new Action(this.Close));
                    return;
                }
            }

            using (new WaitCursorHelper(this))
            {
                string regName = _currentUser.OperationalContext?.CashRegisterName ?? "Caja";
                lblCashierBadge.Text = $"Cajero: {user?.FullName} ({regName})";

                var activeShift = await _cashShiftService.GetCurrentActiveShiftAsync();
                if (activeShift != null)
                {
                    DateTime localOpening = activeShift.OpeningDate.Kind == DateTimeKind.Utc
                        ? activeShift.OpeningDate.ToLocalTime()
                        : activeShift.OpeningDate;

                    lblShiftBadge.Text = $"TURNO #{activeShift.Id} ACTIVO ({localOpening:HH:mm})";
                    lblShiftBadge.Image = UIIconHelper.EstadoActivo;
                    lblShiftBadge.ImageAlign = ContentAlignment.MiddleLeft;
                    lblShiftBadge.ForeColor = UIThemeHelper.Success;
                }
                else
                {
                    lblShiftBadge.Text = "SIN TURNO DE CAJA";
                    lblShiftBadge.Image = UIIconHelper.EstadoInactivo;
                    lblShiftBadge.ImageAlign = ContentAlignment.MiddleLeft;
                    lblShiftBadge.ForeColor = UIThemeHelper.Danger;
                }

                var docTypes = (await _lookupService.GetDocumentTypesAsync()).OrderBy(d => d.Id).ToList();
                cboDocType.DataSource = docTypes;
                cboDocType.DisplayMember = "Name";
                cboDocType.ValueMember = "Id";

                if (docTypes.Any())
                    cboDocType.SelectedIndex = 0;

                _paymentMethods = (await _lookupService.GetPaymentMethodsAsync()).ToList();

                DataGridViewHelper.ApplyStyle(dgvCart);
                ResetSaleSession();
            }
        }

        private void ResetSaleSession()
        {
            _cart.Clear();
            _selectedCustomer = null;
            lblCustomerInfo.Text = "Cliente: Consumidor Final";
            ResetInputBar();
            RefreshCartUI();
        }

        private void ResetInputBar()
        {
            txtProductCode.Clear();
            numQuantity.Value = 1;
            txtProductCode.Focus();
        }

        private async Task AddFromInputAsync()
        {
            string code = txtProductCode.Text.Trim();
            int qty = (int)numQuantity.Value;

            if (string.IsNullOrWhiteSpace(code))
            {
                txtProductCode.Focus();
                return;
            }

            await ProcessScannedBarcodeAsync(code, qty);
        }

        private async Task ProcessScannedBarcodeAsync(string barcode, int quantity)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return;

            var product = await _productService.GetByBarcodeAsync(barcode);

            if (product == null)
            {
                SystemSounds.Asterisk.Play();
                UIHelper.WarnMessage(this, $"No se encontró ningún producto con código: '{barcode}'", "Artículo No Registrado");
                txtProductCode.SelectAll();
                txtProductCode.Focus();
                return;
            }

            if (!product.IsActive)
            {
                UIHelper.WarnMessage(this, $"El producto '{product.Name}' se encuentra inactivo.", "Producto No Disponible");
                ResetInputBar();
                return;
            }

            var existing = _cart.FirstOrDefault(x => x.ProductId == product.Id);
            int newTotalQty = (existing?.Quantity ?? 0) + quantity;

            var stockCheck = await _saleService.ValidateStockAsync(product.Id, newTotalQty);
            if (!stockCheck.Success)
            {
                SystemSounds.Hand.Play();
                UIHelper.ShowResult(stockCheck, "Validación de Stock");
                ResetInputBar();
                return;
            }

            SystemSounds.Beep.Play();

            if (existing != null)
            {
                existing.Quantity = newTotalQty;
            }
            else
            {
                _cart.Add(new SaleItemDto
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    CategoryId = product.CategoryId,
                    UnitPrice = product.SellPrice,
                    Quantity = quantity,
                    DiscountAmount = 0
                });
            }

            ResetInputBar();
            RefreshCartUI();
        }

        private async void RefreshCartUI()
        {
            _currentCalculation = await _promotionService.CalculateSaleDiscountsAsync(_cart, DateTime.Now);

            dgvCart.DataSource = null;
            dgvCart.DataSource = _currentCalculation.CalculatedItems.ToList();
            DataGridViewHelper.ApplyStyle(dgvCart);

            lblSubTotal.Text = $"Subtotal: {_currentCalculation.SubTotal:C2}";
            lblDiscount.Text = $"Descuentos: -{_currentCalculation.TotalDiscount:C2}";
            lblTotalDisplay.Text = _currentCalculation.FinalTotal.ToString("C2");
            btnRegister.Text = $"COBRAR {_currentCalculation.FinalTotal:C2} (F8)";
        }

        private void RemoveSelectedItem()
        {
            if (dgvCart.CurrentRow == null || dgvCart.CurrentRow.DataBoundItem is not SaleItemDto item)
            {
                UIHelper.WarnMessage(this, "Seleccione un producto de la grilla para quitarlo.", "Aviso");
                return;
            }

            _cart.RemoveAll(x => x.ProductId == item.ProductId);
            RefreshCartUI();
            ResetInputBar();
        }

        private async Task PromptSelectCustomerAsync()
        {
            using var searchDialog = new FormSearchCustomerDialog();

            if (searchDialog.ShowDialog(this) == DialogResult.OK)
            {
                string queryDni = searchDialog.EnteredDocument;

                var customers = await _customerService.GetAllActiveAsync();
                var found = customers.FirstOrDefault(c => c.DocumentNumber.Trim() == queryDni);

                if (found != null)
                {
                    _selectedCustomer = found;
                    lblCustomerInfo.Text = $"Cliente: {found.FirstName} {found.LastName} (DNI: {found.DocumentNumber})";
                }
                else
                {
                    UIHelper.WarnMessage(this, $"No se encontró ningún cliente activo con el DNI '{queryDni}'.", "Búsqueda de Cliente");
                }
            }
            txtProductCode.Focus();
        }

        private async Task ExecuteCheckoutAsync()
        {
            if (!_cart.Any())
            {
                UIHelper.WarnMessage(this, "El carrito de ventas está vacío. Escanee al menos un producto.", "Carrito Vacío");
                txtProductCode.Focus();
                return;
            }

            using var payDialog = new FormPaymentDialog(_currentCalculation.FinalTotal, _paymentMethods);
            if (payDialog.ShowDialog(this) != DialogResult.OK)
            {
                txtProductCode.Focus();
                return;
            }

            using (new WaitCursorHelper(this))
            {
                string customerName = _selectedCustomer != null
                    ? $"{_selectedCustomer.FirstName} {_selectedCustomer.LastName}".Trim()
                    : "Consumidor Final";

                string customerDoc = _selectedCustomer?.DocumentNumber;

                var saleDto = new SaleDto
                {
                    DocumentTypeId = (int)(cboDocType.SelectedValue ?? 1),
                    DocumentTypeName = cboDocType.Text,
                    PaymentMethodId = payDialog.SelectedPaymentMethodId,
                    PaymentMethodName = payDialog.SelectedPaymentMethodName,
                    CustomerId = _selectedCustomer?.Id,
                    CustomerDoc = customerDoc,
                    CustomerName = customerName,
                    CashierName = _currentUser.CurrentUser!.FullName,
                    SubTotal = _currentCalculation.SubTotal,
                    DiscountAmount = _currentCalculation.TotalDiscount,
                    TotalAmount = _currentCalculation.FinalTotal,
                    PaymentReceived = payDialog.AmountPaid,
                    Items = _currentCalculation.CalculatedItems,
                    AppliedDiscounts = _currentCalculation.Discounts,
                    Date = DateTime.Now
                };

                var result = await _saleService.ProcessSaleAsync(saleDto);

                if (result.Success)
                {
                    string docNo = result.Message.Contains(':')
                        ? result.Message.Split(':').Last().Trim()
                        : "00000001";

                    saleDto.DocumentNumber = docNo;

                    var ticketViewer = new FormTicketPreview(_documentService, _whatsappService, _storageService);
                    _ = ticketViewer.LoadSaleTicketAsync(
                        saleDto, docNo, saleDto.CashierName, _selectedCustomer?.Phone, _selectedCustomer?.FirstName);
                    ticketViewer.Show();

                    ResetSaleSession();
                }
                else
                {
                    UIHelper.ShowResult(result, "Error en Venta");
                }
            }
        }

        private void ToggleCamera()
        {
            if (!_isCameraActive)
            {
                _cameraService.StartStreaming(0, OnFrameCaptured);
                _isCameraActive = true;
                btnToggleCam.Text = "APAGAR ESCÁNER";
                btnToggleCam.Image = UIIconHelper.CamaraEncender;
                btnToggleCam.BackColor = UIThemeHelper.Danger;
                btnToggleCam.ForeColor = Color.White;
            }
            else
            {
                StopCamera();
            }
        }

        private void StopCamera()
        {
            if (_isCameraActive)
            {
                _cameraService.StopStreaming();
                _isCameraActive = false;
                picWebcam.Image?.Dispose();
                picWebcam.Image = null;
                btnToggleCam.Text = "CÁMARA ESCÁNER";
                btnToggleCam.Image = UIIconHelper.CamaraEncender;
                btnToggleCam.BackColor = UIThemeHelper.Surface;
                btnToggleCam.ForeColor = UIThemeHelper.TextMain;
            }
        }

        private void OnFrameCaptured(Bitmap frame)
        {
            if (!this.IsDisposed && picWebcam.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    picWebcam.Image?.Dispose();
                    picWebcam.Image = (Bitmap)frame.Clone();
                }));
            }

            string? decodedText = _barcodeService.DecodeBarcode(frame);
            if (!string.IsNullOrEmpty(decodedText))
            {
                if (decodedText == _lastScannedBarcode && (DateTime.Now - _lastScanTime).TotalSeconds < 2.5)
                {
                    frame.Dispose();
                    return;
                }

                _lastScannedBarcode = decodedText;
                _lastScanTime = DateTime.Now;

                if (!this.IsDisposed)
                {
                    this.Invoke(new Action(async () =>
                    {
                        await ProcessScannedBarcodeAsync(decodedText, 1);
                    }));
                }
            }

            frame.Dispose();
        }
    }
}