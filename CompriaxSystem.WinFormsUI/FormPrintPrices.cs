using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormPrintPrices : Form
    {
        private readonly IProductService _productService;
        private readonly IBarcodeService _barcodeService;
        private ProductDto? _selectedProduct;
        private Bitmap? _generatedLabel;

        public FormPrintPrices(IProductService productService, IBarcodeService barcodeService)
        {
            _productService = productService;
            _barcodeService = barcodeService;
            InitializeComponent();

            this.Load += async (s, e) => await InitializeFormAsync();
            this.dgvProducts.CellClick += (s, e) => SyncEntityToFields();
            this.btnGenerate.Click += (s, e) => ExecuteGenerateLabelAction();
            this.btnPrint.Click += (s, e) => ExecutePrintAction();
            this.btnDownload.Click += (s, e) => ExecuteDownloadImageAction();
        }

        public async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var data = await _productService.GetProductListAsync();
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = data.ToList();
                CustomizeGridColumns();

                UIHelper.AttachManagedSelection(this, dgvProducts, SyncEntityToFields, ResetUI);
                ResetUI();
            }
        }

        private void SyncEntityToFields()
        {
            if (dgvProducts.CurrentRow == null)
                return;

            _selectedProduct = (ProductDto)dgvProducts.CurrentRow.DataBoundItem;

            lblSelectedProductName.Text = $"SELECCIONADO: {_selectedProduct.Name} ({_selectedProduct.Barcode})";
        }

        private void ExecuteGenerateLabelAction()
        {
            if (_selectedProduct == null)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un producto de la tabla para generar su etiqueta de precio.", "Selección Requerida");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                int labelWidth = 500;
                int labelHeight = 240;

                _generatedLabel?.Dispose();
                _generatedLabel = new Bitmap(labelWidth, labelHeight);

                using (Graphics g = Graphics.FromImage(_generatedLabel))
                {
                    g.Clear(Color.White);
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (Pen borderPen = new Pen(Color.FromArgb(200, 200, 200), 2))
                    {
                        g.DrawRectangle(borderPen, 1, 1, labelWidth - 3, labelHeight - 3);
                    }

                    string productName = _selectedProduct.Name.Trim();
                    if (productName.Length > 32) productName = productName.Substring(0, 32) + "...";

                    using (Font titleFont = new Font("Segoe UI", 12, FontStyle.Bold))
                    using (StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center })
                    {
                        Rectangle titleRect = new Rectangle(10, 15, labelWidth - 20, 30);
                        g.DrawString(productName.ToUpper(), titleFont, Brushes.Black, titleRect, sfCenter);
                    }

                    int barcodeWidth = 380;
                    int barcodeHeight = 90;
                    using (Image barcodeImg = _barcodeService.GenerateBarcode(_selectedProduct.Barcode, barcodeWidth, barcodeHeight))
                    {
                        int barcodeX = (labelWidth - barcodeWidth) / 2;
                        int barcodeY = 55;
                        g.DrawImage(barcodeImg, barcodeX, barcodeY, barcodeWidth, barcodeHeight);
                    }

                    using (Font priceFont = new Font("Segoe UI", 28, FontStyle.Bold))
                    using (StringFormat sfPrice = new StringFormat { Alignment = StringAlignment.Center })
                    {
                        Rectangle priceRect = new Rectangle(10, 160, labelWidth - 20, 50);
                        string priceText = _selectedProduct.SellPrice.ToString("C2");
                        g.DrawString(priceText, priceFont, Brushes.DarkBlue, priceRect, sfPrice);
                    }

                    using (Font tagFont = new Font("Segoe UI", 7, FontStyle.Italic))
                    {
                        g.DrawString("Compriax", tagFont, Brushes.Gray, 15, labelHeight - 20);
                    }
                }

                ImageHelper.Clear(picBarcodePreview);
                picBarcodePreview.Image = (Bitmap)_generatedLabel.Clone();
            }
        }

        private void ExecutePrintAction()
        {
            if (_generatedLabel == null)
            {
                UIHelper.WarnMessage(this, "No hay ninguna etiqueta generada en pantalla para imprimir.", "Etiqueta Requerida");
                return;
            }

            PrintDocument pd = new PrintDocument();

            pd.PrintPage += (s, ev) =>
            {
                if (_generatedLabel != null && ev.Graphics != null)
                {
                    ev.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    ev.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                    int printWidth = _generatedLabel.Width;
                    int printHeight = _generatedLabel.Height;
                    int posX = (ev.PageBounds.Width - printWidth) / 2;
                    int posY = 50;

                    ev.Graphics.DrawImage(_generatedLabel, posX, posY, printWidth, printHeight);
                }
            };

            using PrintDialog diag = new PrintDialog { Document = pd };

            if (diag.ShowDialog() == DialogResult.OK)
                pd.Print();
        }

        private async void ExecuteDownloadImageAction()
        {
            if (_generatedLabel == null)
            {
                UIHelper.WarnMessage(this, "No hay ninguna etiqueta generada para guardar como imagen.", "Etiqueta Requerida");
                return;
            }

            using var ms = new MemoryStream();
            _generatedLabel.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageBytes = ms.ToArray();

            string defaultFileName = $"Etiqueta_{_selectedProduct?.Barcode ?? "Codigo"}.png";

            await FileExportHelper.SaveAndOpenFileAsync(this, imageBytes, defaultFileName, "Imagen PNG (*.png)|*.png|Imagen JPG (*.jpg)|*.jpg", "Guardar Etiqueta de Precio");
        }

        private void CustomizeGridColumns()
        {
            UIHelper.FormatGrid(dgvProducts);

            string[] columnsToHide = { "CurrentStock", "MinimumStock", "StockStatus", "BuyPrice" };
            foreach (var col in columnsToHide)
            {
                if (dgvProducts.Columns.Contains(col))
                    dgvProducts.Columns[col].Visible = false;
            }
        }

        private void ResetUI()
        {
            _selectedProduct = null;
            _generatedLabel?.Dispose();
            _generatedLabel = null;

            if (picBarcodePreview.Image != null)
            {
                picBarcodePreview.Image.Dispose();
                picBarcodePreview.Image = null;
            }

            lblSelectedProductName.Text = "Ningún producto seleccionado";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
