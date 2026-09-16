using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormPriceCheck : Form
    {
        private readonly IProductService _productService;
        private List<ProductDto> _cachedProducts = new();

        public FormPriceCheck(IProductService productService)
        {
            _productService = productService;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelSearchCard);
            UIThemeHelper.ApplyCardStyle(panelDetailsCard);

            this.KeyPreview = true;
            this.Load += async (sender, eventArgs) => await InitializePriceCheckFormAsync();
            this.buttonCloseDialog.Click += (sender, eventArgs) => this.Close();
            this.buttonClearSearch.Click += (sender, eventArgs) => ResetPriceCheckDisplayFields();

            // Atajos de teclado dentro de la ventana de consulta
            this.KeyDown += (sender, eventArgs) =>
            {
                if (eventArgs.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                else if (eventArgs.KeyCode == Keys.F2 || eventArgs.KeyCode == Keys.F6)
                {
                    quickSearchBox.FocusInput();
                }
            };

            // Conexión del evento de selección del buscador predictivo
            quickSearchBox.ProductSelected += (sender, selectedProduct) => DisplayProductPriceAndStockDetails(selectedProduct);
        }
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializePriceCheckFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                try
                {
                    var activeProductsList = await _productService.GetProductListAsync();

                    _cachedProducts = activeProductsList
                        .Where(product => product.IsActive)
                        .ToList();

                    quickSearchBox.SetProductsSource(_cachedProducts);
                }
                catch (Exception exception)
                {
                    UIHelper.ErrorMessage(this, $"Error al cargar catálogo de precios:\n{exception.Message}", "Ver Precio");
                }
                finally
                {
                    ResetPriceCheckDisplayFields();
                    quickSearchBox.FocusInput();
                }
            }
        }

        public void DisplayProductPriceAndStockDetails(ProductDto product)
        {
            if (product == null)
            {
                return;
            }

            labelProductName.Text = product.Name.ToUpper();
            labelPriceValue.Text = product.SellPrice.ToString("C2");

            labelBarcodeValue.Text = product.Barcode;
            labelCategoryValue.Text = product.CategoryName;
            labelBrandValue.Text = product.BrandName;

            labelStockValue.Text = $"{product.CurrentStock:N0} unidades";

            bool isStockBelowThreshold = product.CurrentStock <= product.MinimumStock;

            labelStockValue.ForeColor = isStockBelowThreshold ? UIThemeHelper.Danger : UIThemeHelper.Success;
            labelStockBadge.Text = isStockBelowThreshold ? "STOCK BAJO" : "STOCK DISPONIBLE";
            labelStockBadge.ForeColor = isStockBelowThreshold ? UIThemeHelper.Danger : UIThemeHelper.Success;

            // Imagen del producto si está disponible
            pictureBoxProduct.Image?.Dispose();
            pictureBoxProduct.Image = ImageHelper.LoadFromBytes(product.Image);

            panelDetailsCard.Visible = true;
            quickSearchBox.FocusInput();
        }

        private void ResetPriceCheckDisplayFields()
        {
            labelProductName.Text = "ESCANEE UN CÓDIGO O ESCRIBA UN NOMBRE";
            labelPriceValue.Text = "$ 0,00";
            labelBarcodeValue.Text = "-";
            labelCategoryValue.Text = "-";
            labelBrandValue.Text = "-";
            labelStockValue.Text = "-";
            labelStockBadge.Text = string.Empty;

            pictureBoxProduct.Image?.Dispose();
            pictureBoxProduct.Image = null;

            quickSearchBox.Clear();
            quickSearchBox.FocusInput();
        }
    }
}