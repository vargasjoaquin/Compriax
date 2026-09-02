using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.WinFormsUI.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Media;
using static CompriaxSystem.WinFormsUI.Helpers.FormBlindCashCountDialog;

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
            _serviceProvider = serviceProvider;
            InitializeComponent();

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

            // Escaneo continuo con Enter
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

        private async Task InitializeFormAsync()
        {
            // Si no tiene caja asignada (ej. un Administrador que entra al POS desde el menú), solicitarla
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
                if (isAdmin && !_currentUser.HasRegisterAssigned)
                {
                    lblCashierBadge.Text = $"Operador: {user?.FullName ?? "Administrador"} [Admin POS]";
                }
                else
                {
                    string regName = _currentUser.OperationalContext?.CashRegisterName ?? "Caja 01";
                    lblCashierBadge.Text = $"Cajero: {user?.FullName ?? "Operador"} ({regName})";
                }

                var docTypes = (await _lookupService.GetDocumentTypesAsync()).ToList();
                cboDocType.DataSource = docTypes;
                cboDocType.DisplayMember = "Name";
                cboDocType.ValueMember = "Id";

                _paymentMethods = (await _lookupService.GetPaymentMethodsAsync()).ToList();

                UIHelper.FormatGrid(dgvCart);
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
            if (string.IsNullOrWhiteSpace(barcode)) return;

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
            UIHelper.FormatGrid(dgvCart);

            lblSubTotal.Text = $"Subtotal: {_currentCalculation.SubTotal:C2}";
            lblDiscount.Text = $"Descuentos: -{_currentCalculation.TotalDiscount:C2}";
            lblTotalDisplay.Text = _currentCalculation.FinalTotal.ToString("C2");
            btnRegister.Text = $"💳 COBRAR {_currentCalculation.FinalTotal:C2} (F8)";
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
            using var prompt = new FormPromptDialog("Buscar Cliente", "Ingrese DNI/CUIT del cliente:");
            if (prompt.ShowDialog(this) == DialogResult.OK)
            {
                var customers = await _customerService.GetAllActiveAsync();
                var found = customers.FirstOrDefault(c => c.DocumentNumber == prompt.EnteredDescription);

                if (found != null)
                {
                    _selectedCustomer = found;
                    lblCustomerInfo.Text = $"Cliente: {found.FullName} ({found.DocumentNumber})";
                }
                else
                {
                    UIHelper.WarnMessage(this, "Cliente no encontrado.", "Búsqueda");
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

            // 1. Abrir Pasarela Modal de Cobro
            using var payDialog = new FormPaymentDialog(_currentCalculation.FinalTotal, _paymentMethods);
            if (payDialog.ShowDialog(this) != DialogResult.OK)
            {
                txtProductCode.Focus();
                return;
            }

            // 2. Procesar Venta
            using (new WaitCursorHelper(this))
            {
                var saleDto = new SaleDto
                {
                    DocumentTypeId = (int)(cboDocType.SelectedValue ?? 1),
                    DocumentTypeName = cboDocType.Text,
                    PaymentMethodId = payDialog.SelectedPaymentMethodId,
                    PaymentMethodName = payDialog.SelectedPaymentMethodName,
                    CustomerId = _selectedCustomer?.Id,
                    CustomerDoc = _selectedCustomer?.DocumentNumber ?? "S/D",
                    CustomerName = _selectedCustomer?.FullName ?? "Consumidor Final",
                    CashierName = _currentUser.CurrentUser?.FullName,
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
                btnToggleCam.Text = "🛑 APAGAR ESCÁNER";
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
                btnToggleCam.Text = "📷 CÁMARA ESCÁNER";
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
