using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.WinFormsUI.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Media;
using System.Text.Json;

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
        private bool _isInitializing = false;

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
            UIThemeHelper.ApplyCardStyle(pnlVoucherCard);
            UIThemeHelper.ApplyCardStyle(pnlRightSummary);

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnRemove.Click += (s, e) => RemoveSelectedItem();
            this.btnSelectCustomer.Click += async (s, e) => await PromptSelectCustomerAsync();
            this.btnRegister.Click += async (s, e) => await ExecuteCheckoutAsync();
            this.btnToggleCam.Click += (s, e) => ToggleCamera();
            this.FormClosing += (s, e) => StopCamera();

            // Sincronización dinámica de comprobante y correlativo
            this.cboDocType.SelectedIndexChanged += async (s, e) =>
            {
                if (!_isInitializing)
                    await UpdateVoucherContextAsync();
            };

            // Conexión del buscador rápido predictivo
            this.quickSearchBox.ProductSelected += async (s, product) =>
            {
                await ProcessScannedBarcodeAsync(product.Barcode, (int)numQuantity.Value);
            };

            // Atajos de Teclado Globales en POS
            this.KeyDown += async (s, e) =>
            {
                switch (e.KeyCode)
                {
                    case UIThemeHelper.Shortcuts.SearchProduct:
                        quickSearchBox.FocusInput();
                        break;

                    case UIThemeHelper.Shortcuts.SelectCustomer:
                        await PromptSelectCustomerAsync();
                        break;

                    case UIThemeHelper.Shortcuts.ChangeQuantity:
                        numQuantity.Focus();
                        numQuantity.Select(0, numQuantity.Text.Length);
                        break;

                    case UIThemeHelper.Shortcuts.CheckPrice:
                        var priceCheckForm = _serviceProvider.GetRequiredService<FormPriceCheck>();
                        priceCheckForm.ShowDialog(this);
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

            this.dgvCart.CellDoubleClick += (s, e) => RemoveSelectedItem();
        }

        public async Task InitializeFormAsync()
        {
            _isInitializing = true;
            var user = _currentUser.CurrentUser;
            bool isAdmin = user != null && user.RoleName.Equals("Administrador", StringComparison.OrdinalIgnoreCase);

            if (!_currentUser.HasRegisterAssigned)
            {
                if (isAdmin)
                {
                    var registerService = _serviceProvider.GetRequiredService<ICashRegisterService>();
                    var allRegisters = await registerService.GetAllRegistersAsync();
                    var defaultRegister = allRegisters.FirstOrDefault(r => r.IsActive);

                    if (defaultRegister != null)
                    {
                        _currentUser.SetCashRegister(defaultRegister.Id, defaultRegister.Number, defaultRegister.Name);
                    }
                    else
                    {
                        UIHelper.ErrorMessage(this, "No existen cajas activas en el sistema para procesar ventas.", "Configuración");
                        this.BeginInvoke(new Action(this.Close));
                        return;
                    }
                }
                else
                {
                    var selectForm = _serviceProvider.GetRequiredService<FormSelectCashRegister>();

                    if (selectForm.ShowDialog(this) != DialogResult.OK)
                    {
                        this.BeginInvoke(new Action(this.Close));
                        return;
                    }
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
                    lblShiftBadge.ImageAlign = ContentAlignment.MiddleLeft;
                    lblShiftBadge.ForeColor = UIThemeHelper.Success;
                }
                else
                {
                    lblShiftBadge.Text = "SIN TURNO DE CAJA";
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

                // Cargar catálogo en memoria para búsqueda predictiva instantánea
                var catalog = await _productService.GetProductListAsync();
                quickSearchBox.SetProductsSource(catalog);

                DataGridViewHelper.ApplyStyle(dgvCart);
                _isInitializing = false;

                await UpdateVoucherContextAsync();
                ResetSaleSession();
            }
        }

        private async Task UpdateVoucherContextAsync()
        {
            if (cboDocType.SelectedItem is not DocumentType docType)
                return;

            string typeName = docType.Name.ToUpperInvariant();
            string letter = "B";
            if (typeName.Contains("FACTURA A") || typeName.Contains("NOTA DE DÉBITO A") || typeName.Contains("NOTA DE CRÉDITO A") || typeName.Contains("RECIBO A") || typeName.Contains("TICKET FACTURA A"))
                letter = "A";
            else if (typeName.Contains("FACTURA C") || typeName.Contains("NOTA DE DÉBITO C") || typeName.Contains("NOTA DE CRÉDITO C") || typeName.Contains("RECIBO C"))
                letter = "C";
            else if (typeName.Contains("FACTURA M") || typeName.Contains("NOTA DE DÉBITO M") || typeName.Contains("NOTA DE CRÉDITO M"))
                letter = "M";
            else if (typeName.Contains("EXPORTACIÓN") || typeName.Contains("EXPORTACION"))
                letter = "E";
            else if (typeName.Contains("REMITO R"))
                letter = "R";
            else if (typeName.Contains("REMITO X") || typeName.Contains("PRESUPUESTO") || typeName.Contains("COMPROBANTE X"))
                letter = "X";

            lblVoucherLetter.Text = letter;

            int docId = docType.Id;
            
            int posNumber = _currentUser.OperationalContext?.CashRegisterNumber ?? 1;

            string nextNumber = await _saleService.GetNextDocumentNumberAsync(docId);

            lblVoucherNumber.Text = $"P.V.: {posNumber:D4}  -  N.°: {nextNumber}";

            if (_selectedCustomer != null)
            {
                lblClientNameVal.Text = $"{_selectedCustomer.LastName}, {_selectedCustomer.FirstName}".Trim();
                lblClientDocVal.Text = $"DOC: {_selectedCustomer.DocumentNumber} (CUIL: {_selectedCustomer.Cuil ?? "-"})";
                lblClientTaxVal.Text = $"IVA: {(_selectedCustomer.TaxConditionName ?? "Consumidor Final")}";

                if (letter == "A" && (_selectedCustomer.TaxConditionName == null || !_selectedCustomer.TaxConditionName.Contains("Inscripto", StringComparison.OrdinalIgnoreCase)))
                {
                    lblClientTaxVal.Text += "  [Requiere Resp. Inscripto]";
                    lblClientTaxVal.ForeColor = UIThemeHelper.Danger;
                }
                else
                {
                    lblClientTaxVal.ForeColor = Color.FromArgb(100, 116, 139);
                }
            }
            else
            {
                lblClientNameVal.Text = "CONSUMIDOR FINAL";
                lblClientDocVal.Text = "DOC: S/D";
                lblClientTaxVal.Text = "IVA: Consumidor Final";
                lblClientTaxVal.ForeColor = letter == "A" ? UIThemeHelper.Danger : Color.FromArgb(100, 116, 139);

                if (letter == "A")
                    lblClientTaxVal.Text = "IVA: Consumidor Final [Requiere Cliente Resp. Inscripto]";
            }
        }

        private void ResetSaleSession()
        {
            _cart.Clear();
            _selectedCustomer = null;
            ResetInputBar();
            _ = UpdateVoucherContextAsync();
            RefreshCartUI();
        }

        private void ResetInputBar()
        {
            quickSearchBox.Clear();
            numQuantity.Value = 1;
            quickSearchBox.FocusInput();
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
                ResetInputBar();
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
                    await UpdateVoucherContextAsync();
                }
                else
                {
                    UIHelper.WarnMessage(this, $"No se encontró ningún cliente activo con el DNI '{queryDni}'.", "Búsqueda de Cliente");
                }
            }
            quickSearchBox.FocusInput();
        }

        private async Task ExecuteCheckoutAsync()
        {
            if (!_cart.Any())
            {
                UIHelper.WarnMessage(this, "El carrito de ventas está vacío. Ingrese al menos un producto.", "Carrito Vacío");
                quickSearchBox.FocusInput();
                return;
            }

            using var paymentDialog = new FormPaymentDialog(_currentCalculation.FinalTotal, _paymentMethods);
            
            if (paymentDialog.ShowDialog(this) != DialogResult.OK)
            {
                quickSearchBox.FocusInput();
                return;
            }

            string customerName = _selectedCustomer != null
                ? $"{_selectedCustomer.FirstName} {_selectedCustomer.LastName}".Trim()
                : "Consumidor Final";

            string customerDocument = _selectedCustomer?.DocumentNumber;

            var saleDto = new SaleDto
            {
                DocumentTypeId = (int)(cboDocType.SelectedValue ?? 1),
                DocumentTypeName = cboDocType.Text,
                PaymentMethodId = paymentDialog.SelectedPaymentMethodId,
                PaymentMethodName = paymentDialog.SelectedPaymentMethodName,
                CustomerId = _selectedCustomer?.Id,
                CustomerDoc = customerDocument,
                CustomerName = customerName,
                CashierName = _currentUser.CurrentUser!.FullName,
                SubTotal = _currentCalculation.SubTotal,
                DiscountAmount = _currentCalculation.TotalDiscount,
                TotalAmount = _currentCalculation.FinalTotal,
                PaymentReceived = paymentDialog.AmountPaid,
                Items = _currentCalculation.CalculatedItems,
                AppliedDiscounts = _currentCalculation.Discounts,
                Date = DateTime.Now
            };

            bool isMercadoPagoQrPayment = paymentDialog.SelectedPaymentMethodName.Contains("Mercado Pago", StringComparison.OrdinalIgnoreCase) ||
                                   paymentDialog.SelectedPaymentMethodName.Contains("QR", StringComparison.OrdinalIgnoreCase);

            if (isMercadoPagoQrPayment)
            {
                bool shouldGenerateQr = UIHelper.ConfirmMessage("¿QUIERES GENERAR EL CÓDIGO QR?", "Mercado Pago QR");

                if (shouldGenerateQr)
                {
                    using (new WaitCursorHelper(this))
                    {
                        try
                        {
                            var saleResult = await _saleService.ProcessSaleAsync(saleDto);

                            if (!saleResult.Success || !saleResult.EntityId.HasValue)
                            {
                                UIHelper.ErrorMessage(this, $"No se pudo inicializar la venta:\n{saleResult.Message}", "Error de Venta");
                                return;
                            }

                            int saleId = saleResult.EntityId.Value;

                            var httpClientFactory = _serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient();
                            
                            string idempotencyKey = Guid.NewGuid().ToString();

                            var paymentRequest = new
                            {
                                saleId = saleId,
                                amount = _currentCalculation.FinalTotal,
                                description = $"Venta POS #{saleId}"
                            };

                            var paymentRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7133/api/mercadopago/payments")
                            {
                                Content = new StringContent(JsonSerializer.Serialize(paymentRequest), System.Text.Encoding.UTF8, "application/json")
                            };

                            paymentRequestMessage.Headers.Add("X-Idempotency-Key", idempotencyKey);

                            var paymentApiResponse = await httpClientFactory.SendAsync(paymentRequestMessage);

                            if (!paymentApiResponse.IsSuccessStatusCode)
                            {
                                var errorResponseContent = await paymentApiResponse.Content.ReadAsStringAsync();
                                UIHelper.ErrorMessage(this, $"Detalle de error devuelto por la API:\n{errorResponseContent}", "Error");
                                return;
                            }

                            var responseContent = await paymentApiResponse.Content.ReadAsStringAsync();

                            using var responseDocument = JsonDocument.Parse(responseContent);

                            string orderId = responseDocument.RootElement.GetProperty("orderId").GetString() ?? string.Empty;

                            string qrData = responseDocument.RootElement.GetProperty("qrData").GetString() ?? string.Empty;

                            var barcodeService = _serviceProvider.GetRequiredService<IBarcodeService>();

                            var qrHttpClientFactory = _serviceProvider.GetRequiredService<IHttpClientFactory>();

                            using var qrPaymentForm = new FormMercadoPagoQrPayment(barcodeService, qrHttpClientFactory, orderId, _currentCalculation.FinalTotal, qrData);

                            if (qrPaymentForm.ShowDialog(this) != DialogResult.OK || !qrPaymentForm.IsPaymentApproved)
                            {
                                UIHelper.WarnMessage(this, "Operación de Mercado Pago no completada. Venta no finalizada.", "Aviso");
                                return;
                            }

                            string documentNumber = saleDto.DocumentNumber ?? "00000001";

                            var ticketPreviewForm =  new FormTicketPreview(_documentService, _whatsappService, _storageService);
                            
                            _ = ticketPreviewForm.LoadSaleTicketAsync(
                                saleDto,
                                documentNumber,
                                saleDto.CashierName,
                                _selectedCustomer?.Phone,
                                _selectedCustomer?.FirstName);

                            ticketPreviewForm.Show();

                            ResetSaleSession();
                            return;
                        }
                        catch (Exception ex)
                        {
                            UIHelper.ErrorMessage(this, $"Error al procesar el pago QR: {ex.Message}", "Fallo de Integración");
                            return;
                        }
                    }
                }
            }

            using (new WaitCursorHelper(this))
            {
                var saleResult = await _saleService.ProcessSaleAsync(saleDto);

                if (saleResult.Success)
                {
                    string documentNumber = saleDto.DocumentNumber ?? "00000001";

                    var ticketPreviewForm = new FormTicketPreview(_documentService, _whatsappService, _storageService);

                    _ = ticketPreviewForm.LoadSaleTicketAsync(
                        saleDto,
                        documentNumber,
                        saleDto.CashierName,
                        _selectedCustomer?.Phone,
                        _selectedCustomer?.FirstName);

                    ticketPreviewForm.Show();
                    ResetSaleSession();
                }
                else
                {
                    UIHelper.ShowResult(saleResult, "Error en Venta");
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
                        await ProcessScannedBarcodeAsync(decodedText, (int)numQuantity.Value);
                    }));
                }
            }

            frame.Dispose();
        }
    }
}