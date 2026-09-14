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
            UIThemeHelper.ApplyCardStyle(pnlSearchCard);
            UIThemeHelper.ApplyCardStyle(pnlDetailsCard);

            this.KeyPreview = true;
            this.Load += async (sender, eventArgs) => await InitializeFormAsync();
            this.btnClose.Click += (sender, eventArgs) => this.Close();
            this.btnClear.Click += (sender, eventArgs) => ResetDisplay();

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
            quickSearchBox.ProductSelected += (sender, selectedProduct) => DisplayProductPrice(selectedProduct);
        }

        public async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                try
                {
                    var productList = await _productService.GetProductListAsync();

                    _cachedProducts = productList
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
                    ResetDisplay();
                    quickSearchBox.FocusInput();
                }
            }
        }

        public void DisplayProductPrice(ProductDto product)
        {
            if (product == null)
            {
                return;
            }

            lblProductName.Text = product.Name.ToUpper();
            lblPrice.Text = product.SellPrice.ToString("C2");

            lblBarcodeVal.Text = product.Barcode;
            lblCategoryVal.Text = product.CategoryName;
            lblBrandVal.Text = product.BrandName;

            lblStockVal.Text = $"{product.CurrentStock:N0} unidades";

            bool isLowStock = product.CurrentStock <= product.MinimumStock;

            lblStockVal.ForeColor = isLowStock ? UIThemeHelper.Danger : UIThemeHelper.Success;
            lblStockBadge.Text = isLowStock ? "STOCK BAJO" : "STOCK DISPONIBLE";
            lblStockBadge.ForeColor = isLowStock ? UIThemeHelper.Danger : UIThemeHelper.Success;

            // Imagen del producto si está disponible
            picProduct.Image?.Dispose();
            picProduct.Image = ImageHelper.LoadFromBytes(product.Image);

            pnlDetailsCard.Visible = true;
            quickSearchBox.FocusInput();
        }

        private void ResetDisplay()
        {
            lblProductName.Text = "ESCANEE UN CÓDIGO O ESCRIBA UN NOMBRE";
            lblPrice.Text = "$ 0,00";
            lblBarcodeVal.Text = "-";
            lblCategoryVal.Text = "-";
            lblBrandVal.Text = "-";
            lblStockVal.Text = "-";
            lblStockBadge.Text = string.Empty;

            picProduct.Image?.Dispose();
            picProduct.Image = null;

            quickSearchBox.Clear();
            quickSearchBox.FocusInput();
        }
    }
}