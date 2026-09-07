using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormProducts : Form
    {
        private readonly IProductService _productService;
        private readonly ICatalogService _catalogService;
        private readonly IDocumentService _documentService;

        private int _selectedProductId = 0;
        private byte[]? _imageBuffer = null;

        public FormProducts(IProductService productService, ICatalogService catalogService, IDocumentService documentService)
        {
            _productService = productService;
            _catalogService = catalogService;
            _documentService = documentService;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(groupEdit);

            this.dgvProducts.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dgvProducts, e);

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnSave.Click += async (s, e) => await ExecuteSaveAction();
            this.btnEdit.Click += async (s, e) => await ExecuteEditAction();
            this.btnDelete.Click += async (s, e) => await ExecuteDeleteAction();
            this.btnPrintStock.Click += async (s, e) => await ExecuteExportPdfAction();
            this.btnBrowseImage.Click += (s, e) => HandleImageSelection();
            this.btnClearImage.Click += (s, e) => HandleImageRemoval();
        }

        public async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                cboCategory.DataSource = (await _catalogService.GetActiveCategoriesAsync()).ToList();
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "Id";
                cboCategory.SelectedIndex = -1;

                cboBrand.DataSource = (await _catalogService.GetBrandsAsync()).ToList();
                cboBrand.DisplayMember = "Name";
                cboBrand.ValueMember = "Id";
                cboBrand.SelectedIndex = -1;

                await RefreshGridAsync();
                UIHelper.AttachManagedSelection(this, dgvProducts, SyncEntityToFields, ResetUI);
            }
        }

        private async Task RefreshGridAsync()
        {
            var data = await _productService.GetProductListAsync();
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = data.ToList();
            DataGridViewHelper.ApplyStyle(dgvProducts);
        }

        private void SyncEntityToFields()
        {
            if (dgvProducts.CurrentRow == null)
                return;

            var p = (ProductDto)dgvProducts.CurrentRow.DataBoundItem;

            _selectedProductId = p.Id;
            txtBarcode.Text = p.Barcode;
            txtName.Text = p.Name;
            txtDescription.Text = p.Description;
            numBuyPrice.Value = p.BuyPrice;
            numSellPrice.Value = p.SellPrice;
            numStock.Value = p.CurrentStock;
            cboCategory.SelectedValue = p.CategoryId;
            cboBrand.SelectedValue = p.BrandId;

            _imageBuffer = p.Image;
            ImageHelper.Clear(picProductImage);
            picProductImage.Image = ImageHelper.LoadFromBytes(p.Image);

            SetButtonState(isEditing: true);
            txtBarcode.ReadOnly = true;
        }

        private void ResetUI()
        {
            _selectedProductId = 0;
            _imageBuffer = null;
            ImageHelper.Clear(picProductImage);

            UIHelper.CleanControls(groupEdit);
            cboCategory.SelectedIndex = -1;
            cboBrand.SelectedIndex = -1;

            SetButtonState(isEditing: false);
            txtBarcode.ReadOnly = false;
        }

        private void SetButtonState(bool isEditing)
        {
            btnSave.Enabled = !isEditing;
            btnEdit.Enabled = isEditing;
            btnDelete.Enabled = isEditing;
        }

        private void HandleImageSelection()
        {
            if (ImageHelper.SelectImage(out byte[]? imageBytes, out Image? displayImage, out string? errorMessage))
            {
                ImageHelper.Clear(picProductImage);
                _imageBuffer = imageBytes;
                picProductImage.Image = displayImage;
            }
            else if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Validación de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HandleImageRemoval()
        {
            _imageBuffer = null;
            ImageHelper.Clear(picProductImage);
        }

        private async Task ExecuteSaveAction()
        {
            var dto = MapFieldsToDto();
            var result = await _productService.CreateProductAsync(dto);

            UIHelper.ShowResult(result, "Gestión de Productos", async () =>
            {
                await RefreshGridAsync();
                ResetUI();
            });
        }

        private async Task ExecuteEditAction()
        {
            if (_selectedProductId == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un producto de la lista para poder editarlo.", "Selección Requerida");
                return;
            }

            var dto = MapFieldsToDto();
            var result = await _productService.UpdateProductAsync(_selectedProductId, dto);

            UIHelper.ShowResult(result, "Gestión de Productos", async () =>
            {
                await RefreshGridAsync();
                ResetUI();
            });
        }

        private async Task ExecuteDeleteAction()
        {
            if (_selectedProductId == 0)
                return;

            if (UIHelper.ConfirmMessage("¿Desea retirar este producto del inventario?"))
            {
                var result = await _productService.DeleteProductAsync(_selectedProductId);
                UIHelper.ShowResult(result, "Gestión de Productos", async () =>
                {
                    await RefreshGridAsync();
                    ResetUI();
                });
            }
        }

        private async Task ExecuteExportPdfAction()
        {
            if (dgvProducts.DataSource is not List<ProductDto> products || !products.Any())
            {
                MessageBox.Show("No hay productos disponibles para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] pdfBytes = await _documentService.GenerateInventoryReportAsync(products);
                string fileName = $"Reporte_Stock_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                await FileExportHelper.SaveAndOpenPdfAsync(this, pdfBytes, fileName, "Exportar Reporte de Stock");
            }
        }

        private ProductCreateDto MapFieldsToDto()
        {
            return new ProductCreateDto
            {
                Barcode = txtBarcode.Text.Trim(),
                Name = txtName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                BuyPrice = numBuyPrice.Value,
                SellPrice = numSellPrice.Value,
                InitialStock = (int)numStock.Value,
                MinimumStock = 0,
                CategoryId = cboCategory.SelectedValue as int? ?? 1,
                BrandId = cboBrand.SelectedValue as int? ?? 1,
                UnitOfMeasureId = 1,
                Image = _imageBuffer
            };
        }
    }
}