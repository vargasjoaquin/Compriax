using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormProducts : Form
    {
        private readonly IProductService _productService;
        private readonly ICatalogService _catalogService;
        private readonly IDocumentService _documentService;
        private readonly IServiceProvider _serviceProvider;

        private int _selectedProductIdentifier = 0;
        private byte[]? _productImageBuffer = null;
        public FormProducts(IProductService productService, ICatalogService catalogService, IDocumentService documentService, IServiceProvider serviceProvider)
        {
            _productService = productService;
            _catalogService = catalogService;
            _documentService = documentService;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            
            ButtonIconOverlayHelper.BindEvents(this.buttonOpenLabelDesigner, this.picIconOpenLabelDesigner);
            ButtonIconOverlayHelper.BindEvents(this.buttonExportPdf, this.picIconExportPdf);
            ButtonIconOverlayHelper.BindEvents(this.buttonBrowsePhoto, this.picIconBrowsePhoto);
            ButtonIconOverlayHelper.BindEvents(this.buttonClearPhoto, this.picIconClearPhoto);
            ButtonIconOverlayHelper.BindEvents(this.buttonSave, this.picIconSave);
            ButtonIconOverlayHelper.BindEvents(this.buttonEdit, this.picIconEdit);
            ButtonIconOverlayHelper.BindEvents(this.buttonDelete, this.picIconDelete);
            

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelProductForm);

            this.dataGridViewProducts.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dataGridViewProducts, e);

            this.Load += async (s, e) => await InitializeProductsCatalogFormAsync();
            this.buttonSave.Click += async (s, e) => await ExecuteSaveProductAsync();
            this.buttonEdit.Click += async (s, e) => await ExecuteUpdateProductAsync();
            this.buttonDelete.Click += async (s, e) => await ExecuteDeleteProductFromInventoryAsync();
            this.buttonExportPdf.Click += async (s, e) => await ExecuteExportInventoryReportToPdfAsync();
            this.buttonBrowsePhoto.Click += (s, e) => HandleProductImageSelection();
            this.buttonClearPhoto.Click += (s, e) => HandleProductImageRemoval();
            this.buttonOpenLabelDesigner.Click += (s, e) => ExecuteOpenLabelDesignerForSelectedProduct();
        }
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializeProductsCatalogFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                comboBoxCategory.DataSource = (await _catalogService.GetActiveCategoriesAsync()).ToList();
                comboBoxCategory.DisplayMember = "Name";
                comboBoxCategory.ValueMember = "Id";
                comboBoxCategory.SelectedIndex = -1;

                comboBoxBrand.DataSource = (await _catalogService.GetBrandsAsync()).ToList();
                comboBoxBrand.DisplayMember = "Name";
                comboBoxBrand.ValueMember = "Id";
                comboBoxBrand.SelectedIndex = -1;

                await RefreshProductsGridAsync();
                UIHelper.AttachManagedSelection(this, dataGridViewProducts, SynchronizeSelectedProductToFormFields, ResetFormInputFields);
            }
        }

        private async Task RefreshProductsGridAsync()
        {
            var data = await _productService.GetProductListAsync();
            dataGridViewProducts.DataSource = null;
            dataGridViewProducts.DataSource = data.ToList();
            DataGridViewHelper.ApplyStyle(dataGridViewProducts);
        }
        /// <summary>
        /// Sincroniza la entidad SelectedProductToFormFields seleccionada con los campos de entrada de la interfaz.
        /// </summary>

        private void SynchronizeSelectedProductToFormFields()
        {
            if (dataGridViewProducts.CurrentRow == null)
                return;

            var selectedProduct = (ProductDto)dataGridViewProducts.CurrentRow.DataBoundItem;

            _selectedProductIdentifier = selectedProduct.Id;
            textBoxBarcode.Text = selectedProduct.Barcode;
            textBoxProductName.Text = selectedProduct.Name;
            textBoxDescription.Text = selectedProduct.Description;
            numericUpDownBuyPrice.Value = selectedProduct.BuyPrice;
            numericUpDownSellPrice.Value = selectedProduct.SellPrice;
            numericUpDownCurrentStock.Value = selectedProduct.CurrentStock;
            comboBoxCategory.SelectedValue = selectedProduct.CategoryId;
            comboBoxBrand.SelectedValue = selectedProduct.BrandId;

            _productImageBuffer = selectedProduct.Image;
            ImageHelper.Clear(pictureBoxProductPhoto);
            pictureBoxProductPhoto.Image = ImageHelper.LoadFromBytes(selectedProduct.Image);

            UpdateButtonStates(isEditing: true);
            textBoxBarcode.ReadOnly = true;
        }

        private void ResetFormInputFields()
        {
            _selectedProductIdentifier = 0;
            _productImageBuffer = null;
            ImageHelper.Clear(pictureBoxProductPhoto);

            UIHelper.CleanControls(panelProductForm);
            comboBoxCategory.SelectedIndex = -1;
            comboBoxBrand.SelectedIndex = -1;

            UpdateButtonStates(isEditing: false);
            textBoxBarcode.ReadOnly = false;
        }

        private void UpdateButtonStates(bool isEditing)
        {
            buttonSave.Enabled = !isEditing;
            buttonEdit.Enabled = isEditing;
            buttonDelete.Enabled = isEditing;
        }

        private void HandleProductImageSelection()
        {
            if (ImageHelper.SelectImage(out byte[]? imageBytes, out Image? displayImage, out string? errorMessage))
            {
                ImageHelper.Clear(pictureBoxProductPhoto);
                _productImageBuffer = imageBytes;
                pictureBoxProductPhoto.Image = displayImage;
            }
            else if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Validación de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HandleProductImageRemoval()
        {
            _productImageBuffer = null;
            ImageHelper.Clear(pictureBoxProductPhoto);
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SaveProduct.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSaveProductAsync()
        {
            var product = MapFormInputFieldsToProductCreateDto();
            var result = await _productService.CreateProductAsync(product);

            UIHelper.ShowResult(result, "Gestión de Productos", async () =>
            {
                await RefreshProductsGridAsync();
                ResetFormInputFields();
            });
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de UpdateProduct.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteUpdateProductAsync()
        {
            if (_selectedProductIdentifier == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un producto de la lista para poder editarlo.", "Selección Requerida");
                return;
            }

            var product = MapFormInputFieldsToProductCreateDto();
            var result = await _productService.UpdateProductAsync(_selectedProductIdentifier, product);

            UIHelper.ShowResult(result, "Gestión de Productos", async () =>
            {
                await RefreshProductsGridAsync();
                ResetFormInputFields();
            });
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de DeleteProductFromInventory.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteDeleteProductFromInventoryAsync()
        {
            if (_selectedProductIdentifier == 0)
                return;

            if (UIHelper.ConfirmMessage("¿Desea retirar este producto del inventario?"))
            {
                var result = await _productService.DeleteProductAsync(_selectedProductIdentifier);
                UIHelper.ShowResult(result, "Gestión de Productos", async () =>
                {
                    await RefreshProductsGridAsync();
                    ResetFormInputFields();
                });
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de ExportInventoryReportToPdf.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteExportInventoryReportToPdfAsync()
        {
            if (dataGridViewProducts.DataSource is not List<ProductDto> productsReportList || !productsReportList.Any())
            {
                MessageBox.Show("No hay productos disponibles para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] inventoryReportPdfBytes = await _documentService.GenerateInventoryReportAsync(productsReportList);
                string fileName = $"Reporte_Stock_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                await FileExportHelper.SaveAndOpenPdfAsync(this, inventoryReportPdfBytes, fileName, "Exportar Reporte de Stock");
            }
        }

        private void ExecuteOpenLabelDesignerForSelectedProduct()
        {
            if (dataGridViewProducts.CurrentRow?.DataBoundItem is not ProductDto selectedGridProductDto)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un producto de la tabla para generar su etiqueta.", "Selección Requerida");
                return;
            }

            var labelForm = _serviceProvider.GetRequiredService<FormProductLabels>();
            labelForm.PreloadProductToShelfLabelsQueue(selectedGridProductDto, 1);
            labelForm.ShowDialog(this);
        }

        private ProductCreateDto MapFormInputFieldsToProductCreateDto()
        {
            return new ProductCreateDto
            {
                Barcode = textBoxBarcode.Text.Trim(),
                Name = textBoxProductName.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),
                BuyPrice = numericUpDownBuyPrice.Value,
                SellPrice = numericUpDownSellPrice.Value,
                InitialStock = (int)numericUpDownCurrentStock.Value,
                MinimumStock = 0,
                CategoryId = comboBoxCategory.SelectedValue as int? ?? 1,
                BrandId = comboBoxBrand.SelectedValue as int? ?? 1,
                UnitOfMeasureId = 1,
                Image = _productImageBuffer
            };
        }
    }
}










