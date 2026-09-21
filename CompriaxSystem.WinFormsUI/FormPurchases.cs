using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.WinFormsUI.Helpers;
using System.Media;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormPurchases : Form
    {
        private readonly ISupplyChainService _supplyService;
        private readonly IProductService _productService;
        private readonly ILookupService _lookupService;
        private readonly ICameraService _cameraService;
        private readonly IBarcodeService _barcodeService;
        private readonly IDocumentService _documentService;
        private readonly ICurrentUserService _currentUser;
        private readonly CameraScannerController _cameraController;

        private List<PurchaseItemCreateDto> _items = new();
        private ProductDto? _foundProduct;

        // Banderas de control de concurrencia
        private bool _isInitializing = false;
        private bool _isUpdatingInvoiceNumber = false;

        public FormPurchases(
            ISupplyChainService supplyService,
            IProductService productService,
            ILookupService lookupService,
            ICameraService cameraService,
            IBarcodeService barcodeService,
            IDocumentService documentService,
            ICurrentUserService currentUser)
        {
            _supplyService = supplyService;
            _productService = productService;
            _lookupService = lookupService;
            _cameraService = cameraService;
            _barcodeService = barcodeService;
            _documentService = documentService;
            _currentUser = currentUser;

            InitializeComponent();
            
            ButtonIconOverlayHelper.BindEvents(this.buttonSearchSupplier, this.picIconSearchSupplier);
            ButtonIconOverlayHelper.BindEvents(this.buttonSearchProduct, this.picIconSearchProduct);
            ButtonIconOverlayHelper.BindEvents(this.buttonAddPurchaseItem, this.picIconAddPurchaseItem);
            ButtonIconOverlayHelper.BindEvents(this.buttonRemovePurchaseItem, this.picIconRemovePurchaseItem);
            ButtonIconOverlayHelper.BindEvents(this.buttonRegisterPurchase, this.picIconRegisterPurchase);
            ButtonIconOverlayHelper.BindEvents(this.buttonToggleScannerCamera, this.picIconToggleScannerCamera);
            

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelPurchaseHeaderInfo);
            UIThemeHelper.ApplyCardStyle(panelScannerItemBar);
            UIThemeHelper.ApplyCardStyle(panelRightSummary);

            _cameraController = new CameraScannerController(
               cameraService,
               barcodeService,
               pictureBoxWebcamPreview,
               buttonToggleScannerCamera,
               barcode => _ = ProcessScannedProductBarcodeAsync(barcode));

            this.textBoxSupplierTaxId.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(textBoxSupplierTaxId);
            this.comboBoxDocumentType.SelectedIndexChanged += async (s, e) => await UpdateNextPurchaseInvoiceNumberAsync();

            this.Load += async (s, e) => await InitializePurchasesFormAsync();
            this.buttonSearchSupplier.Click += async (s, e) => await ExecuteSearchSupplierByCuitAsync();
            this.buttonSearchProduct.Click += async (s, e) => await ExecuteSearchProductByBarcodeAsync();
            this.buttonAddPurchaseItem.Click += (s, e) => ExecuteAddManualItemToPurchaseCart();
            this.buttonRemovePurchaseItem.Click += (s, e) => ExecuteRemoveSelectedItemFromPurchaseCart();
            this.buttonRegisterPurchase.Click += async (s, e) => await ExecuteRegisterPurchaseInvoiceAsync();
            this.dataGridViewPurchaseCart.CellDoubleClick += (s, e) => ExecuteRemoveSelectedItemFromPurchaseCart();

            this.textBoxProductBarcode.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    await ProcessScannedProductBarcodeAsync(textBoxProductBarcode.Text.Trim());
                }
            };

            this.dataGridViewPurchaseCart.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    ExecuteRemoveSelectedItemFromPurchaseCart();
                }
            };
        }
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializePurchasesFormAsync()
        {
            _isInitializing = true;
            textBoxInvoiceNumber.ReadOnly = true;

            using (new WaitCursorHelper(this))
            {
                var documentTypesList = (await _lookupService.GetDocumentTypesAsync()).OrderBy(d => d.Id).ToList();
                var paymentMethodsList = (await _lookupService.GetPaymentMethodsAsync()).ToList();

                comboBoxDocumentType.DisplayMember = "Name";
                comboBoxDocumentType.ValueMember = "Id";
                comboBoxDocumentType.DataSource = documentTypesList;

                comboBoxPaymentMethod.DisplayMember = "Name";
                comboBoxPaymentMethod.ValueMember = "Id";
                comboBoxPaymentMethod.DataSource = paymentMethodsList;

                if (paymentMethodsList.Any())
                {
                    comboBoxPaymentMethod.SelectedIndex = 0;
                }

                _isInitializing = false;

                await ResetPurchaseFormSessionAsync();
            }
        }

        private async Task UpdateNextPurchaseInvoiceNumberAsync()
        {
            if (_isInitializing || _isUpdatingInvoiceNumber)
                return;

            _isUpdatingInvoiceNumber = true;

            try
            {
                if (comboBoxDocumentType.SelectedValue is int id && id >= 0)
                {
                    textBoxInvoiceNumber.Text = await _supplyService.GetNextPurchaseNumberAsync(id);
                }
            }
            finally
            {
                _isUpdatingInvoiceNumber = false;
            }
        }

        private async Task ResetPurchaseFormSessionAsync()
        {
            _items.Clear();
            _foundProduct = null;
            UIHelper.CleanControls(this);
            textBoxSupplierIdHidden.Clear();
            textBoxSupplierTaxId.Clear();
            textBoxSupplierName.Clear();
            ClearProductEntryFields();

            textBoxDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            textBoxTotalAmount.Text = "$ 0,00";

            if (comboBoxDocumentType.Items.Count > 0 && comboBoxDocumentType.SelectedIndex == -1)
            {
                comboBoxDocumentType.SelectedIndex = 0;
            }

            await UpdateNextPurchaseInvoiceNumberAsync();
            RefreshPurchaseCartGridAndTotals();
            textBoxProductBarcode.Focus();
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de RegisterPurchaseInvoice.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteRegisterPurchaseInvoiceAsync()
        {
            if (!_items.Any())
            {
                UIHelper.WarnMessage(this, "El listado de compra está vacío. Agregue al menos un producto.", "Compra Vacía");
                textBoxProductBarcode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxSupplierIdHidden.Text) || !int.TryParse(textBoxSupplierIdHidden.Text, out int supplierId) || supplierId <= 0)
            {
                UIHelper.WarnMessage(this, "Debe buscar y seleccionar el proveedor mediante su CUIT.", "Proveedor Requerido");
                textBoxSupplierTaxId.Focus();
                return;
            }

            int paymentMethodId = 1;
            string paymentMethodName = PaymentMethodConstants.CASH;

            if (comboBoxPaymentMethod.SelectedValue is int pId && pId > 0)
            {
                paymentMethodId = pId;
                paymentMethodName = comboBoxPaymentMethod.Text;
            }
            else if (comboBoxPaymentMethod.SelectedItem is PaymentMethod pm && pm.Id > 0)
            {
                paymentMethodId = pm.Id;
                paymentMethodName = pm.Name;
            }

            buttonRegisterPurchase.Enabled = false;

            try
            {
                using (new WaitCursorHelper(this))
                {
                    string supplierName = textBoxSupplierName.Text.Trim();
                    string supplierCuit = textBoxSupplierTaxId.Text.Trim();
                    string registeredBy = _currentUser.CurrentUser?.FullName ?? RoleConstants.DEFAULT_ADMIN_USERNAME;

                    var product = new PurchaseCreateDto
                    {
                        SupplierId = supplierId,
                        DocumentTypeId = (int)(comboBoxDocumentType.SelectedValue ?? 1),
                        DocumentTypeName = comboBoxDocumentType.Text,
                        PaymentMethodId = paymentMethodId,
                        PaymentMethodName = paymentMethodName,
                        DocumentNumber = textBoxInvoiceNumber.Text.Trim(),
                        TotalAmount = _items.Sum(x => x.SubTotal),
                        Items = _items.ToList()
                    };

                    var result = await _supplyService.ProcessPurchaseAsync(product);

                    if (result.Success)
                    {
                        try
                        {
                            byte[] purchaseReceiptPdfBytes = await _documentService.GeneratePurchaseReceiptAsync(
                                product, supplierName, supplierCuit, registeredBy);

                            string fileName = $"FacturaCompra_{product.DocumentNumber.Replace('/', '-')}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                            await FileExportHelper.SaveAndOpenPdfAsync(this, purchaseReceiptPdfBytes, fileName, "Comprobante de Compra");
                        }
                        catch { }

                        await ResetPurchaseFormSessionAsync();
                        UIHelper.ShowResult(result, "Compra Registrada");
                    }
                    else
                    {
                        UIHelper.ShowResult(result, "Error en Compra");
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.ErrorMessage(this, $"Error inesperado al procesar la compra:\n{ex.Message}", "Error Crítico");
            }
            finally
            {
                buttonRegisterPurchase.Enabled = true;
            }
        }

        private async Task ProcessScannedProductBarcodeAsync(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return;

            var matchedProduct = await _productService.GetByBarcodeAsync(barcode);

            if (matchedProduct == null)
            {
                SystemSounds.Asterisk.Play();
                UIHelper.WarnMessage(this, $"El código '{barcode}' no corresponde a ningún producto.", "No Encontrado");
                textBoxProductBarcode.SelectAll();
                textBoxProductBarcode.Focus();
                return;
            }

            SystemSounds.Beep.Play();
            _foundProduct = matchedProduct;
            textBoxProductName.Text = matchedProduct.Name;
            textBoxBuyPrice.Text = matchedProduct.BuyPrice.ToString("N2");

            AddProductToPurchaseItemsList(matchedProduct, matchedProduct.BuyPrice, 1, isIncremental: true);
            ClearProductEntryFields();
        }

        private void AddProductToPurchaseItemsList(ProductDto matchedProduct, decimal parsedPurchaseBuyPrice, int quantity, bool isIncremental)
        {
            if (matchedProduct == null) return;

            if (quantity <= 0)
            {
                UIHelper.WarnMessage(this, "La cantidad a comprar debe ser mayor a 0.", "Cantidad Inválida");
                numericUpDownQuantity.Focus();
                return;
            }

            if (parsedPurchaseBuyPrice <= 0)
            {
                UIHelper.WarnMessage(this, "El precio de costo debe ser mayor a $ 0.00.", "Precio Inválido");
                textBoxBuyPrice.Focus();
                return;
            }

            var existing = _items.FirstOrDefault(x => x.ProductId == matchedProduct.Id);

            if (existing != null)
            {
                existing.Quantity = isIncremental ? (existing.Quantity + quantity) : quantity;
                existing.BuyPrice = parsedPurchaseBuyPrice;
            }
            else
            {
                _items.Add(new PurchaseItemCreateDto
                {
                    ProductId = matchedProduct.Id,
                    ProductName = matchedProduct.Name,
                    BuyPrice = parsedPurchaseBuyPrice,
                    Quantity = quantity
                });
            }

            RefreshPurchaseCartGridAndTotals();
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SearchProductByBarcode.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSearchProductByBarcodeAsync()
        {
            if (string.IsNullOrWhiteSpace(textBoxProductBarcode.Text))
                return;

            using (new WaitCursorHelper(this))
            {
                _foundProduct = await _productService.GetByBarcodeAsync(textBoxProductBarcode.Text.Trim());

                if (_foundProduct != null)
                {
                    textBoxProductName.Text = _foundProduct.Name;
                    textBoxBuyPrice.Text = _foundProduct.BuyPrice.ToString("N2");
                    textBoxBuyPrice.Focus();
                    textBoxBuyPrice.SelectAll();
                }
                else
                {
                    UIHelper.WarnMessage(this, $"No se encontró ningún producto con el código '{textBoxProductBarcode.Text.Trim()}'.", "Producto No Encontrado");
                    textBoxProductBarcode.SelectAll();
                    textBoxProductBarcode.Focus();
                }
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SearchSupplierByCuit.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSearchSupplierByCuitAsync()
        {
            if (string.IsNullOrWhiteSpace(textBoxSupplierTaxId.Text))
            {
                UIHelper.WarnMessage(this, "Por favor, ingrese el número de CUIT del proveedor a buscar.", "Campo Requerido");
                textBoxSupplierTaxId.Focus();
                return;
            }

            using (new WaitCursorHelper(this))
            {
                var suppliersList = await _supplyService.GetSuppliersAsync();
                var foundSupplier = suppliersList.FirstOrDefault(x => x.CUIT == textBoxSupplierTaxId.Text.Trim());

                if (foundSupplier != null)
                {
                    textBoxSupplierIdHidden.Text = foundSupplier.Id.ToString();
                    textBoxSupplierName.Text = foundSupplier.CompanyName;
                    textBoxProductBarcode.Focus();
                }
                else
                {
                    UIHelper.WarnMessage(this, $"No se encontró ningún proveedor registrado con el CUIT '{textBoxSupplierTaxId.Text.Trim()}'.", "Proveedor No Encontrado");
                    textBoxSupplierTaxId.SelectAll();
                    textBoxSupplierTaxId.Focus();
                }
            }
        }

        private void ExecuteAddManualItemToPurchaseCart()
        {
            if (_foundProduct == null)
            {
                UIHelper.WarnMessage(this, "Primero debe buscar o escanear un producto antes de agregarlo.", "Producto Requerido");
                textBoxProductBarcode.Focus();
                return;
            }

            if (!decimal.TryParse(textBoxBuyPrice.Text.Replace("$", "").Trim(), out decimal parsedPurchaseBuyPrice) || parsedPurchaseBuyPrice <= 0)
            {
                UIHelper.WarnMessage(this, "Debe ingresar un precio de costo válido y mayor a $ 0.00.", "Precio Inválido");
                textBoxBuyPrice.SelectAll();
                textBoxBuyPrice.Focus();
                return;
            }

            if (numericUpDownQuantity.Value <= 0)
            {
                UIHelper.WarnMessage(this, "La cantidad comprada debe ser mayor a 0.", "Cantidad Inválida");
                numericUpDownQuantity.Focus();
                return;
            }

            AddProductToPurchaseItemsList(_foundProduct, parsedPurchaseBuyPrice, (int)numericUpDownQuantity.Value, isIncremental: true);
            ClearProductEntryFields();
        }

        private void ExecuteRemoveSelectedItemFromPurchaseCart()
        {
            PurchaseItemCreateDto? itemToRemove = null;

            if (dataGridViewPurchaseCart.CurrentRow != null && dataGridViewPurchaseCart.CurrentRow.DataBoundItem is PurchaseItemCreateDto selectedFromGrid)
            {
                itemToRemove = selectedFromGrid;
            }
            else if (_foundProduct != null)
            {
                itemToRemove = _items.FirstOrDefault(x => x.ProductId == _foundProduct.Id);
            }

            if (itemToRemove == null)
            {
                UIHelper.WarnMessage(this, "Por favor, seleccione el producto de la lista que desea quitar.", "Selección Requerida");
                return;
            }

            if (UIHelper.ConfirmMessage($"¿Desea quitar '{itemToRemove.ProductName}' de la compra actual?", "Quitar Artículo"))
            {
                _items.Remove(itemToRemove);
                RefreshPurchaseCartGridAndTotals();
                ClearProductEntryFields();
                textBoxProductBarcode.Focus();
            }
        }

        private void RefreshPurchaseCartGridAndTotals()
        {
            dataGridViewPurchaseCart.DataSource = null;
            dataGridViewPurchaseCart.DataSource = _items.ToList();
            DataGridViewHelper.ApplyStyle(dataGridViewPurchaseCart);
            textBoxTotalAmount.Text = _items.Sum(x => x.SubTotal).ToString("C2");
        }

        private void ClearProductEntryFields()
        {
            _foundProduct = null;
            textBoxProductBarcode.Clear();
            textBoxProductName.Clear();
            textBoxBuyPrice.Clear();
            numericUpDownQuantity.Value = 1;
            textBoxProductBarcode.Focus();
        }
    }
}










