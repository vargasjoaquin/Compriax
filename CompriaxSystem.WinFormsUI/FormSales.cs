using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
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
        private readonly IMercadoPagoQrClient _mercadoPagoQrClient;

        private readonly List<SaleItemDto> _cart = new();
        private CustomerDto? _selectedCustomer;
        private List<PaymentMethod> _paymentMethods = new();
        private SaleCalculationResultDto _currentCalculation = new(); 
        private CameraScannerController? _cameraController;
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
            IServiceProvider serviceProvider,
            IMercadoPagoQrClient mercadoPagoQrClient)
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
            _mercadoPagoQrClient = mercadoPagoQrClient;

            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelBarcodeBar);
            UIThemeHelper.ApplyCardStyle(panelVoucherCard);
            UIThemeHelper.ApplyCardStyle(panelRightSummary);

            _cameraController = new CameraScannerController(
                cameraService,
                barcodeService,
                pictureBoxWebcamPreview,
                buttonToggleScannerCamera,
                barcode => _ = ProcessScannedProductBarcodeAsync(barcode, (int)numericUpDownQuantity.Value));

            this.Load += async (s, e) => await InitializePointOfSaleFormAsync();
            this.buttonRemoveItem.Click += (s, e) => RemoveSelectedItemFromSaleCart();
            this.buttonSelectCustomer.Click += async (s, e) => await PromptSelectCustomerDialogAsync();
            this.buttonRegisterSale.Click += async (s, e) => await ExecuteSaleCheckoutAndPaymentAsync();

            // Sincronización dinámica de comprobante y correlativo
            this.comboBoxDocumentType.SelectedIndexChanged += async (s, e) =>
            {
                if (!_isInitializing)
                    await UpdateVoucherContextAndSequenceNumberAsync();
            };

            // Conexión del buscador rápido predictivo
            this.quickSearchBox.ProductSelected += async (s, matchedProduct) =>
            {
                await ProcessScannedProductBarcodeAsync(matchedProduct.Barcode, (int)numericUpDownQuantity.Value);
            };

            this.KeyDown += async (s, e) => await HandleKeyboardShortcutsAsync(e);
            this.dataGridViewCart.CellDoubleClick += (s, e) => RemoveSelectedItemFromSaleCart();
        }
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializePointOfSaleFormAsync()
        {
            _isInitializing = true;
            var currentUser = _currentUser.CurrentUser;
            bool isAdministratorUser = currentUser != null && currentUser.RoleName.Equals(RoleConstants.ADMINISTRATOR, StringComparison.OrdinalIgnoreCase);

            if (!_currentUser.HasRegisterAssigned)
            {
                if (isAdministratorUser)
                {
                    var cashRegisterService = _serviceProvider.GetRequiredService<ICashRegisterService>();
                    var allCashRegistersList = await cashRegisterService.GetAllRegistersAsync();
                    var firstActiveRegister = allCashRegistersList.FirstOrDefault(r => r.IsActive);

                    if (firstActiveRegister != null)
                    {
                        _currentUser.SetCashRegister(firstActiveRegister.Id, firstActiveRegister.Number, firstActiveRegister.Name);
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
                    var selectCashRegisterDialog = _serviceProvider.GetRequiredService<FormSelectCashRegister>();

                    if (selectCashRegisterDialog.ShowDialog(this) != DialogResult.OK)
                    {
                        this.BeginInvoke(new Action(this.Close));
                        return;
                    }
                }
            }

            using (new WaitCursorHelper(this))
            {
                string cashRegisterName = _currentUser.OperationalContext?.CashRegisterName ?? "Caja";
                labelCashierBadge.Text = $"Cajero: {currentUser?.FullName} ({cashRegisterName})";

                var currentActiveCashShiftDto = await _cashShiftService.GetCurrentActiveShiftAsync();
                if (currentActiveCashShiftDto != null)
                {
                    DateTime localOpeningDateTime = currentActiveCashShiftDto.OpeningDate.Kind == DateTimeKind.Utc
                        ? currentActiveCashShiftDto.OpeningDate.ToLocalTime()
                        : currentActiveCashShiftDto.OpeningDate;

                    labelShiftBadge.Text = $"TURNO #{currentActiveCashShiftDto.Id} ACTIVO ({localOpeningDateTime:HH:mm})";
                    labelShiftBadge.ImageAlign = ContentAlignment.MiddleLeft;
                    labelShiftBadge.ForeColor = UIThemeHelper.Success;
                }
                else
                {
                    labelShiftBadge.Text = "SIN TURNO DE CAJA";
                    labelShiftBadge.ImageAlign = ContentAlignment.MiddleLeft;
                    labelShiftBadge.ForeColor = UIThemeHelper.Danger;
                }

                var availableDocumentTypesList = (await _lookupService.GetDocumentTypesAsync()).OrderBy(d => d.Id).ToList();
                comboBoxDocumentType.DataSource = availableDocumentTypesList;
                comboBoxDocumentType.DisplayMember = "Name";
                comboBoxDocumentType.ValueMember = "Id";

                if (availableDocumentTypesList.Any())
                    comboBoxDocumentType.SelectedIndex = 0;

                _paymentMethods = (await _lookupService.GetPaymentMethodsAsync()).ToList();

                // Cargar catálogo en memoria para búsqueda predictiva instantánea
                var activeProductsCatalogList = await _productService.GetProductListAsync();
                quickSearchBox.SetProductsSource(activeProductsCatalogList);

                DataGridViewHelper.ApplyStyle(dataGridViewCart);
                _isInitializing = false;

                await UpdateVoucherContextAndSequenceNumberAsync();
                ResetPointOfSaleSession();
            }
        }

        private async Task HandleKeyboardShortcutsAsync(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case UIThemeHelper.Shortcuts.SearchProduct:
                    quickSearchBox.FocusInput();
                    break;
                case UIThemeHelper.Shortcuts.SelectCustomer:
                    await PromptSelectCustomerDialogAsync();
                    break;
                case UIThemeHelper.Shortcuts.ChangeQuantity:
                    numericUpDownQuantity.Focus();
                    numericUpDownQuantity.Select(0, numericUpDownQuantity.Text.Length);
                    break;
                case UIThemeHelper.Shortcuts.CheckPrice:
                    var priceCheckDialogForm = _serviceProvider.GetRequiredService<FormPriceCheck>();
                    priceCheckDialogForm.ShowDialog(this);
                    break;
                case UIThemeHelper.Shortcuts.Checkout:
                    await ExecuteSaleCheckoutAndPaymentAsync();
                    break;
                case UIThemeHelper.Shortcuts.DeleteItem:
                    RemoveSelectedItemFromSaleCart();
                    break;
                case UIThemeHelper.Shortcuts.ClearOrCancel:
                    ResetProductScannerInputBar();
                    break;
            }
        }

        private async Task UpdateVoucherContextAndSequenceNumberAsync()
        {
            if (comboBoxDocumentType.SelectedItem is not DocumentType selectedDocumentTypeEntity)
                return;

            string normalizedDocumentTypeName = selectedDocumentTypeEntity.Name.ToUpperInvariant();

            string voucherClassificationLetter = VoucherLetterCodes.LETTER_B;

            if (normalizedDocumentTypeName.Contains("FACTURA A") || normalizedDocumentTypeName.Contains("NOTA DE DÉBITO A") || normalizedDocumentTypeName.Contains("NOTA DE CRÉDITO A") || normalizedDocumentTypeName.Contains("RECIBO A") || normalizedDocumentTypeName.Contains("TICKET FACTURA A"))
                voucherClassificationLetter = VoucherLetterCodes.LETTER_A;
            else if (normalizedDocumentTypeName.Contains("FACTURA C") || normalizedDocumentTypeName.Contains("NOTA DE DÉBITO C") || normalizedDocumentTypeName.Contains("NOTA DE CRÉDITO C") || normalizedDocumentTypeName.Contains("RECIBO C"))
                voucherClassificationLetter = VoucherLetterCodes.LETTER_C;
            else if (normalizedDocumentTypeName.Contains("FACTURA M") || normalizedDocumentTypeName.Contains("NOTA DE DÉBITO M") || normalizedDocumentTypeName.Contains("NOTA DE CRÉDITO M"))
                voucherClassificationLetter = VoucherLetterCodes.LETTER_M;
            else if (normalizedDocumentTypeName.Contains("EXPORTACIÓN") || normalizedDocumentTypeName.Contains("EXPORTACION"))
                voucherClassificationLetter = VoucherLetterCodes.LETTER_E;
            else if (normalizedDocumentTypeName.Contains("REMITO R"))
                voucherClassificationLetter = VoucherLetterCodes.LETTER_R;
            else if (normalizedDocumentTypeName.Contains("REMITO X") || normalizedDocumentTypeName.Contains("PRESUPUESTO") || normalizedDocumentTypeName.Contains("COMPROBANTE X"))
                voucherClassificationLetter = VoucherLetterCodes.LETTER_X;

            labelVoucherLetter.Text = voucherClassificationLetter;

            int selectedDocumentTypeId = selectedDocumentTypeEntity.Id;
            
            int assignedPosPointOfSaleNumber = _currentUser.OperationalContext?.CashRegisterNumber ?? 1;

            string nextDocumentSequenceNumber = await _saleService.GetNextDocumentNumberAsync(selectedDocumentTypeId);

            labelVoucherNumber.Text = $"P.V.: {assignedPosPointOfSaleNumber:D4}  -  N.°: {nextDocumentSequenceNumber}";

            if (_selectedCustomer != null)
            {
                labelClientNameValue.Text = $"{_selectedCustomer.LastName}, {_selectedCustomer.FirstName}".Trim();
                labelClientDocValue.Text = $"DOC: {_selectedCustomer.DocumentNumber} (CUIL: {_selectedCustomer.Cuil ?? "-"})";
                labelClientTaxValue.Text = $"IVA: {(_selectedCustomer.TaxConditionName ?? "Consumidor Final")}";

                if (voucherClassificationLetter == VoucherLetterCodes.LETTER_A && (_selectedCustomer.TaxConditionName == null || !_selectedCustomer.TaxConditionName.Contains("Inscripto", StringComparison.OrdinalIgnoreCase)))
                {
                    labelClientTaxValue.Text += "  [Requiere Resp. Inscripto]";
                    labelClientTaxValue.ForeColor = UIThemeHelper.Danger;
                }
                else
                {
                    labelClientTaxValue.ForeColor = Color.FromArgb(100, 116, 139);
                }
            }
            else
            {
                labelClientNameValue.Text = TaxConstants.DEFAULT_TAX_CONDITION_NAME.ToUpper();
                labelClientDocValue.Text = $"DOC: {TaxConstants.FINAL_CONSUMER_DOCUMENT_PLACEHOLDER}";
                labelClientTaxValue.Text = $"IVA: {TaxConstants.DEFAULT_TAX_CONDITION_NAME}";
                labelClientTaxValue.ForeColor = voucherClassificationLetter == VoucherLetterCodes.LETTER_A ? UIThemeHelper.Danger : Color.FromArgb(100, 116, 139);

                if (voucherClassificationLetter == VoucherLetterCodes.LETTER_A)
                    labelClientTaxValue.Text = $"IVA: {TaxConstants.DEFAULT_TAX_CONDITION_NAME} [Requiere Cliente Resp. Inscripto]";
            }
        }

        private void ResetPointOfSaleSession()
        {
            _cart.Clear();
            _selectedCustomer = null;
            ResetProductScannerInputBar();
            _ = UpdateVoucherContextAndSequenceNumberAsync();
            RefreshSaleCartGridAndCalculateDiscountsAsync();
        }

        private void ResetProductScannerInputBar()
        {
            quickSearchBox.Clear();
            numericUpDownQuantity.Value = 1;
            quickSearchBox.FocusInput();
        }

        private async Task ProcessScannedProductBarcodeAsync(string barcode, int quantity)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return;

            var matchedProduct = await _productService.GetByBarcodeAsync(barcode);

            if (matchedProduct == null)
            {
                SystemSounds.Asterisk.Play();
                UIHelper.WarnMessage(this, $"No se encontró ningún producto con código: '{barcode}'", "Artículo No Registrado");
                ResetProductScannerInputBar();
                return;
            }

            if (!matchedProduct.IsActive)
            {
                UIHelper.WarnMessage(this, $"El producto '{matchedProduct.Name}' se encuentra inactivo.", "Producto No Disponible");
                ResetProductScannerInputBar();
                return;
            }

            var existingCartItem = _cart.FirstOrDefault(x => x.ProductId == matchedProduct.Id);
            int calculatedNewTotalQuantity = (existingCartItem?.Quantity ?? 0) + quantity;

            var stockValidationResult = await _saleService.ValidateStockAsync(matchedProduct.Id, calculatedNewTotalQuantity);
            if (!stockValidationResult.Success)
            {
                SystemSounds.Hand.Play();
                UIHelper.ShowResult(stockValidationResult, "Validación de Stock");
                ResetProductScannerInputBar();
                return;
            }

            SystemSounds.Beep.Play();

            if (existingCartItem != null)
            {
                existingCartItem.Quantity = calculatedNewTotalQuantity;
            }
            else
            {
                _cart.Add(new SaleItemDto
                {
                    ProductId = matchedProduct.Id,
                    ProductName = matchedProduct.Name,
                    CategoryId = matchedProduct.CategoryId,
                    UnitPrice = matchedProduct.SellPrice,
                    Quantity = quantity,
                    DiscountAmount = 0
                });
            }

            ResetProductScannerInputBar();
            RefreshSaleCartGridAndCalculateDiscountsAsync();
        }

        private async void RefreshSaleCartGridAndCalculateDiscountsAsync()
        {
            _currentCalculation = await _promotionService.CalculateSaleDiscountsAsync(_cart, DateTime.Now);

            dataGridViewCart.DataSource = null;
            dataGridViewCart.DataSource = _currentCalculation.CalculatedItems.ToList();
            DataGridViewHelper.ApplyStyle(dataGridViewCart);

            labelSubTotalValue.Text = $"Subtotal: {_currentCalculation.SubTotal:C2}";
            labelDiscountValue.Text = $"Descuentos: -{_currentCalculation.TotalDiscount:C2}";
            labelTotalDisplay.Text = _currentCalculation.FinalTotal.ToString("C2");
            buttonRegisterSale.Text = $"COBRAR {_currentCalculation.FinalTotal:C2} (F8)";
        }

        private void RemoveSelectedItemFromSaleCart()
        {
            if (dataGridViewCart.CurrentRow == null || dataGridViewCart.CurrentRow.DataBoundItem is not SaleItemDto item)
            {
                UIHelper.WarnMessage(this, "Seleccione un producto de la grilla para quitarlo.", "Aviso");
                return;
            }

            _cart.RemoveAll(x => x.ProductId == item.ProductId);
            RefreshSaleCartGridAndCalculateDiscountsAsync();
            ResetProductScannerInputBar();
        }

        private async Task PromptSelectCustomerDialogAsync()
        {
            using var customerSearchDialogForm = new FormSearchCustomerDialog();

            if (customerSearchDialogForm.ShowDialog(this) == DialogResult.OK)
            {
                string enteredCustomerDni = customerSearchDialogForm.EnteredDocument;

                var allActiveCustomersList = await _customerService.GetAllActiveAsync();
                var matchedCustomer = allActiveCustomersList.FirstOrDefault(c => c.DocumentNumber.Trim() == enteredCustomerDni);

                if (matchedCustomer != null)
                {
                    _selectedCustomer = matchedCustomer;
                    await UpdateVoucherContextAndSequenceNumberAsync();
                }
                else
                {
                    UIHelper.WarnMessage(this, $"No se encontró ningún cliente activo con el DNI '{enteredCustomerDni}'.", "Búsqueda de Cliente");
                }
            }
            quickSearchBox.FocusInput();
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SaleCheckoutAndPayment.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSaleCheckoutAndPaymentAsync()
        {
            if (!_cart.Any())
            {
                UIHelper.WarnMessage(this, "El carrito de ventas está vacío. Ingrese al menos un producto.", "Carrito Vacío");
                quickSearchBox.FocusInput();
                return;
            }

            using var paymentCheckoutDialogForm = new FormPaymentDialog(_currentCalculation.FinalTotal, _paymentMethods);
            
            if (paymentCheckoutDialogForm.ShowDialog(this) != DialogResult.OK)
            {
                quickSearchBox.FocusInput();
                return;
            }

            string resolvedCustomerFullName = _selectedCustomer != null
                ? $"{_selectedCustomer.FirstName} {_selectedCustomer.LastName}".Trim()
                : "Consumidor Final";

            string resolvedCustomerDocument = _selectedCustomer?.DocumentNumber;

            var saleTransaction = new SaleDto
            {
                DocumentTypeId = (int)(comboBoxDocumentType.SelectedValue ?? 1),
                DocumentTypeName = comboBoxDocumentType.Text,
                PaymentMethodId = paymentCheckoutDialogForm.SelectedPaymentMethodId,
                PaymentMethodName = paymentCheckoutDialogForm.SelectedPaymentMethodName,
                CustomerId = _selectedCustomer?.Id,
                CustomerDoc = resolvedCustomerDocument,
                CustomerName = resolvedCustomerFullName,
                CashierName = _currentUser.CurrentUser!.FullName,
                SubTotal = _currentCalculation.SubTotal,
                DiscountAmount = _currentCalculation.TotalDiscount,
                TotalAmount = _currentCalculation.FinalTotal,
                PaymentReceived = paymentCheckoutDialogForm.AmountPaid,
                Items = _currentCalculation.CalculatedItems,
                AppliedDiscounts = _currentCalculation.Discounts,
                Date = DateTime.Now
            };

            bool isMercadoPagoQrPaymentMethod = paymentCheckoutDialogForm.SelectedPaymentMethodName.Contains("Mercado Pago", StringComparison.OrdinalIgnoreCase) ||
                                   paymentCheckoutDialogForm.SelectedPaymentMethodName.Contains("QR", StringComparison.OrdinalIgnoreCase);

            if (isMercadoPagoQrPaymentMethod)
            {
                bool userConfirmedQrGeneration = UIHelper.ConfirmMessage("¿QUIERES GENERAR EL CÓDIGO QR?", "Mercado Pago QR");

                if (userConfirmedQrGeneration)
                {
                    using (new WaitCursorHelper(this))
                    {
                        try
                        {
                            var saleProcessingResult = await _saleService.ProcessSaleAsync(saleTransaction);

                            if (!saleProcessingResult.Success || !saleProcessingResult.EntityId.HasValue)
                            {
                                UIHelper.ErrorMessage(this, $"No se pudo inicializar la venta:\n{saleProcessingResult.Message}", "Error de Venta");
                                return;
                            }

                            int registeredSaleId = saleProcessingResult.EntityId.Value;

                            var httpClientFactory = _serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient();
                            
                            string idempotencyKey = Guid.NewGuid().ToString();

                            var paymentRequest = new
                            {
                                registeredSaleId = registeredSaleId,
                                amount = _currentCalculation.FinalTotal,
                                description = $"Venta POS #{registeredSaleId}"
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

                            string mercadoPagoOrderId = responseDocument.RootElement.GetProperty("mercadoPagoOrderId").GetString() ?? string.Empty;

                            string mercadoPagoRawQrData = responseDocument.RootElement.GetProperty("mercadoPagoRawQrData").GetString() ?? string.Empty;

                            var barcodeService = _serviceProvider.GetRequiredService<IBarcodeService>();

                            var qrHttpClientFactory = _serviceProvider.GetRequiredService<IHttpClientFactory>();

                            using var mercadoPagoQrPaymentDialog = new FormMercadoPagoQrPayment(barcodeService, qrHttpClientFactory, mercadoPagoOrderId, _currentCalculation.FinalTotal, mercadoPagoRawQrData);

                            if (mercadoPagoQrPaymentDialog.ShowDialog(this) != DialogResult.OK || !mercadoPagoQrPaymentDialog.IsPaymentApproved)
                            {
                                UIHelper.WarnMessage(this, "Operación de Mercado Pago no completada. Venta no finalizada.", "Aviso");
                                return;
                            }

                            string saleDocumentNumber = saleTransaction.DocumentNumber ?? "00000001";

                            var ticketPreviewFormInstance =  new FormTicketPreview(_documentService, _whatsappService, _storageService);
                            
                            _ = ticketPreviewFormInstance.LoadSaleTicketAndRenderPreviewAsync(
                                saleTransaction,
                                saleDocumentNumber,
                                saleTransaction.CashierName,
                                _selectedCustomer?.Phone,
                                _selectedCustomer?.FirstName);

                            ticketPreviewFormInstance.Show();

                            ResetPointOfSaleSession();
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
                var saleProcessingResult = await _saleService.ProcessSaleAsync(saleTransaction);

                if (saleProcessingResult.Success)
                {
                    string saleDocumentNumber = saleTransaction.DocumentNumber ?? "00000001";

                    var ticketPreviewFormInstance = new FormTicketPreview(_documentService, _whatsappService, _storageService);

                    _ = ticketPreviewFormInstance.LoadSaleTicketAndRenderPreviewAsync(
                        saleTransaction,
                        saleDocumentNumber,
                        saleTransaction.CashierName,
                        _selectedCustomer?.Phone,
                        _selectedCustomer?.FirstName);

                    ticketPreviewFormInstance.Show();
                    ResetPointOfSaleSession();
                }
                else
                {
                    UIHelper.ShowResult(saleProcessingResult, "Error en Venta");
                }
            }
        }
    }
}