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

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(gbSaleInfo);
            UIThemeHelper.ApplyCardStyle(pnlScannerBar);
            UIThemeHelper.ApplyCardStyle(pnlRightSummary);

            _cameraController = new CameraScannerController(
               cameraService,
               barcodeService,
               picWebcam,
               btnToggleCam,
               barcode => _ = ProcessScannedBarcodeAsync(barcode));

            this.txtSupplierDoc.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(txtSupplierDoc);
            this.cboDocType.SelectedIndexChanged += async (s, e) => await UpdateNextInvoiceNumber();

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnSearchSupplier.Click += async (s, e) => await ExecuteSearchSupplierAction();
            this.btnSearchProduct.Click += async (s, e) => await ExecuteProductSearchAction();
            this.btnAddItem.Click += (s, e) => ExecuteAddManualItemAction();
            this.btnRemoveItem.Click += (s, e) => ExecuteRemoveFromCartAction();
            this.btnRegister.Click += async (s, e) => await ExecuteRegisterPurchaseAction();
            this.dgvCart.CellDoubleClick += (s, e) => ExecuteRemoveFromCartAction();
            this.btnToggleCam.Click += (s, e) => ToggleCamera();
            this.FormClosing += (s, e) => StopCamera();

            this.txtProductCode.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    await ProcessScannedBarcodeAsync(txtProductCode.Text.Trim());
                }
            };

            this.dgvCart.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    ExecuteRemoveFromCartAction();
                }
            };
        }

        public async Task InitializeFormAsync()
        {
            _isInitializing = true;
            txtInvoiceNumber.ReadOnly = true;

            using (new WaitCursorHelper(this))
            {
                var docTypes = (await _lookupService.GetDocumentTypesAsync()).OrderBy(d => d.Id).ToList();
                var paymentMethods = (await _lookupService.GetPaymentMethodsAsync()).ToList();

                cboDocType.DisplayMember = "Name";
                cboDocType.ValueMember = "Id";
                cboDocType.DataSource = docTypes;

                cboPaymentMethod.DisplayMember = "Name";
                cboPaymentMethod.ValueMember = "Id";
                cboPaymentMethod.DataSource = paymentMethods;

                if (paymentMethods.Any())
                {
                    cboPaymentMethod.SelectedIndex = 0;
                }

                _isInitializing = false;

                await ResetUI();
            }
        }

        private async Task UpdateNextInvoiceNumber()
        {
            if (_isInitializing || _isUpdatingInvoiceNumber)
                return;

            _isUpdatingInvoiceNumber = true;

            try
            {
                if (cboDocType.SelectedValue is int id && id >= 0)
                {
                    txtInvoiceNumber.Text = await _supplyService.GetNextPurchaseNumberAsync(id);
                }
            }
            finally
            {
                _isUpdatingInvoiceNumber = false;
            }
        }

        private async Task ResetUI()
        {
            _items.Clear();
            _foundProduct = null;
            UIHelper.CleanControls(this);
            txtIdProveedor.Clear();
            txtSupplierDoc.Clear();
            txtSupplierName.Clear();
            ClearProductArea();

            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTotalPay.Text = "$ 0,00";

            if (cboDocType.Items.Count > 0 && cboDocType.SelectedIndex == -1)
            {
                cboDocType.SelectedIndex = 0;
            }

            await UpdateNextInvoiceNumber();
            RefreshGrid();
            txtProductCode.Focus();
        }

        private async Task ExecuteRegisterPurchaseAction()
        {
            if (!_items.Any())
            {
                UIHelper.WarnMessage(this, "El listado de compra está vacío. Agregue al menos un producto.", "Compra Vacía");
                txtProductCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIdProveedor.Text) || !int.TryParse(txtIdProveedor.Text, out int supplierId) || supplierId <= 0)
            {
                UIHelper.WarnMessage(this, "Debe buscar y seleccionar el proveedor mediante su CUIT.", "Proveedor Requerido");
                txtSupplierDoc.Focus();
                return;
            }

            int paymentMethodId = 1;
            string paymentMethodName = PaymentMethodConstants.CASH;

            if (cboPaymentMethod.SelectedValue is int pId && pId > 0)
            {
                paymentMethodId = pId;
                paymentMethodName = cboPaymentMethod.Text;
            }
            else if (cboPaymentMethod.SelectedItem is PaymentMethod pm && pm.Id > 0)
            {
                paymentMethodId = pm.Id;
                paymentMethodName = pm.Name;
            }

            btnRegister.Enabled = false;

            try
            {
                using (new WaitCursorHelper(this))
                {
                    string supplierName = txtSupplierName.Text.Trim();
                    string supplierCuit = txtSupplierDoc.Text.Trim();
                    string registeredBy = _currentUser.CurrentUser?.FullName ?? RoleConstants.DEFAULT_ADMIN_USERNAME;

                    var dto = new PurchaseCreateDto
                    {
                        SupplierId = supplierId,
                        DocumentTypeId = (int)(cboDocType.SelectedValue ?? 1),
                        DocumentTypeName = cboDocType.Text,
                        PaymentMethodId = paymentMethodId,
                        PaymentMethodName = paymentMethodName,
                        DocumentNumber = txtInvoiceNumber.Text.Trim(),
                        TotalAmount = _items.Sum(x => x.SubTotal),
                        Items = _items.ToList()
                    };

                    var result = await _supplyService.ProcessPurchaseAsync(dto);

                    if (result.Success)
                    {
                        try
                        {
                            byte[] pdfBytes = await _documentService.GeneratePurchaseReceiptAsync(
                                dto, supplierName, supplierCuit, registeredBy);

                            string fileName = $"FacturaCompra_{dto.DocumentNumber.Replace('/', '-')}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                            await FileExportHelper.SaveAndOpenPdfAsync(this, pdfBytes, fileName, "Comprobante de Compra");
                        }
                        catch { }

                        await ResetUI();
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
                btnRegister.Enabled = true;
            }
        }

        private async Task ProcessScannedBarcodeAsync(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return;

            var product = await _productService.GetByBarcodeAsync(barcode);

            if (product == null)
            {
                SystemSounds.Asterisk.Play();
                UIHelper.WarnMessage(this, $"El código '{barcode}' no corresponde a ningún producto.", "No Encontrado");
                txtProductCode.SelectAll();
                txtProductCode.Focus();
                return;
            }

            SystemSounds.Beep.Play();
            _foundProduct = product;
            txtProductName.Text = product.Name;
            txtPriceBuy.Text = product.BuyPrice.ToString("N2");

            AddProductToPurchaseList(product, product.BuyPrice, 1, isIncremental: true);
            ClearProductArea();
        }

        private void AddProductToPurchaseList(ProductDto product, decimal buyPrice, int quantity, bool isIncremental)
        {
            if (product == null) return;

            if (quantity <= 0)
            {
                UIHelper.WarnMessage(this, "La cantidad a comprar debe ser mayor a 0.", "Cantidad Inválida");
                numQuantity.Focus();
                return;
            }

            if (buyPrice <= 0)
            {
                UIHelper.WarnMessage(this, "El precio de costo debe ser mayor a $ 0.00.", "Precio Inválido");
                txtPriceBuy.Focus();
                return;
            }

            var existing = _items.FirstOrDefault(x => x.ProductId == product.Id);

            if (existing != null)
            {
                existing.Quantity = isIncremental ? (existing.Quantity + quantity) : quantity;
                existing.BuyPrice = buyPrice;
            }
            else
            {
                _items.Add(new PurchaseItemCreateDto
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    BuyPrice = buyPrice,
                    Quantity = quantity
                });
            }

            RefreshGrid();
        }

        private async Task ExecuteProductSearchAction()
        {
            if (string.IsNullOrWhiteSpace(txtProductCode.Text))
                return;

            using (new WaitCursorHelper(this))
            {
                _foundProduct = await _productService.GetByBarcodeAsync(txtProductCode.Text.Trim());

                if (_foundProduct != null)
                {
                    txtProductName.Text = _foundProduct.Name;
                    txtPriceBuy.Text = _foundProduct.BuyPrice.ToString("N2");
                    txtPriceBuy.Focus();
                    txtPriceBuy.SelectAll();
                }
                else
                {
                    UIHelper.WarnMessage(this, $"No se encontró ningún producto con el código '{txtProductCode.Text.Trim()}'.", "Producto No Encontrado");
                    txtProductCode.SelectAll();
                    txtProductCode.Focus();
                }
            }
        }

        private async Task ExecuteSearchSupplierAction()
        {
            if (string.IsNullOrWhiteSpace(txtSupplierDoc.Text))
            {
                UIHelper.WarnMessage(this, "Por favor, ingrese el número de CUIT del proveedor a buscar.", "Campo Requerido");
                txtSupplierDoc.Focus();
                return;
            }

            using (new WaitCursorHelper(this))
            {
                var list = await _supplyService.GetSuppliersAsync();
                var supplier = list.FirstOrDefault(x => x.CUIT == txtSupplierDoc.Text.Trim());

                if (supplier != null)
                {
                    txtIdProveedor.Text = supplier.Id.ToString();
                    txtSupplierName.Text = supplier.CompanyName;
                    txtProductCode.Focus();
                }
                else
                {
                    UIHelper.WarnMessage(this, $"No se encontró ningún proveedor registrado con el CUIT '{txtSupplierDoc.Text.Trim()}'.", "Proveedor No Encontrado");
                    txtSupplierDoc.SelectAll();
                    txtSupplierDoc.Focus();
                }
            }
        }

        private void ExecuteAddManualItemAction()
        {
            if (_foundProduct == null)
            {
                UIHelper.WarnMessage(this, "Primero debe buscar o escanear un producto antes de agregarlo.", "Producto Requerido");
                txtProductCode.Focus();
                return;
            }

            if (!decimal.TryParse(txtPriceBuy.Text.Replace("$", "").Trim(), out decimal buyPrice) || buyPrice <= 0)
            {
                UIHelper.WarnMessage(this, "Debe ingresar un precio de costo válido y mayor a $ 0.00.", "Precio Inválido");
                txtPriceBuy.SelectAll();
                txtPriceBuy.Focus();
                return;
            }

            if (numQuantity.Value <= 0)
            {
                UIHelper.WarnMessage(this, "La cantidad comprada debe ser mayor a 0.", "Cantidad Inválida");
                numQuantity.Focus();
                return;
            }

            AddProductToPurchaseList(_foundProduct, buyPrice, (int)numQuantity.Value, isIncremental: true);
            ClearProductArea();
        }

        private void ExecuteRemoveFromCartAction()
        {
            PurchaseItemCreateDto? itemToRemove = null;

            if (dgvCart.CurrentRow != null && dgvCart.CurrentRow.DataBoundItem is PurchaseItemCreateDto selectedFromGrid)
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
                RefreshGrid();
                ClearProductArea();
                txtProductCode.Focus();
            }
        }

        private void RefreshGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _items.ToList();
            DataGridViewHelper.ApplyStyle(dgvCart);
            txtTotalPay.Text = _items.Sum(x => x.SubTotal).ToString("C2");
        }

        private void ClearProductArea()
        {
            _foundProduct = null;
            txtProductCode.Clear();
            txtProductName.Clear();
            txtPriceBuy.Clear();
            numQuantity.Value = 1;
            txtProductCode.Focus();
        }

        private void ToggleCamera()
        {
            if (!_isCameraActive)
            {
                _cameraService.StartStreaming(0, OnFrameCaptured);
                _isCameraActive = true;
                btnToggleCam.Text = "APAGAR CÁMARA";
                btnToggleCam.BackColor = Color.Firebrick;
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
                if (picWebcam.Image != null)
                {
                    picWebcam.Image.Dispose();
                    picWebcam.Image = null;
                }

                btnToggleCam.Text = "CÁMARA";
                btnToggleCam.BackColor = Color.Navy;
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
                        await ProcessScannedBarcodeAsync(decodedText);
                    }));
                }
            }

            frame.Dispose();
        }
    }
}