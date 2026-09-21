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
            
            ButtonIconOverlayHelper.BindEvents(this.buttonGenerateLabel, this.picIconGenerateLabel);
            ButtonIconOverlayHelper.BindEvents(this.buttonPrintLabel, this.picIconPrintLabel);
            ButtonIconOverlayHelper.BindEvents(this.buttonSaveLabelImage, this.picIconSaveLabelImage);
            

            this.Load += async (s, e) => await InitializePriceLabelsCatalogAsync();
            this.dataGridViewProducts.CellClick += (s, e) => SynchronizeSelectedProductToLabelFields();
            this.buttonGenerateLabel.Click += (s, e) => ExecuteGenerateProductShelfLabel();
            this.buttonPrintLabel.Click += (s, e) => ExecutePrintShelfLabel();
            this.buttonSaveLabelImage.Click += (s, e) => ExecuteSaveShelfLabelAsImageAsync();
        }
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializePriceLabelsCatalogAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var productsCatalogList = await _productService.GetProductListAsync();
                dataGridViewProducts.DataSource = null;
                dataGridViewProducts.DataSource = productsCatalogList.ToList();
                ConfigureProductsGridColumns();

                UIHelper.AttachManagedSelection(this, dataGridViewProducts, SynchronizeSelectedProductToLabelFields, ResetLabelGeneratorFields);
                ResetLabelGeneratorFields();
            }
        }
        /// <summary>
        /// Sincroniza la entidad SelectedProductToLabelFields seleccionada con los campos de entrada de la interfaz.
        /// </summary>

        private void SynchronizeSelectedProductToLabelFields()
        {
            if (dataGridViewProducts.CurrentRow == null)
                return;

            _selectedProduct = (ProductDto)dataGridViewProducts.CurrentRow.DataBoundItem;
            labelSelectedProductName.Text = $"SELECCIONADO: {_selectedProduct.Name} ({_selectedProduct.Barcode})";
        }

        private void ExecuteGenerateProductShelfLabel()
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

                    string truncatedProductName = _selectedProduct.Name.Trim();

                    if (truncatedProductName.Length > 32)
                        truncatedProductName = truncatedProductName.Substring(0, 32) + "...";

                    using (Font titleFont = new Font("Segoe UI", 12, FontStyle.Bold))
                    using (StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center })
                    {
                        Rectangle titleRect = new Rectangle(10, 15, labelWidth - 20, 30);
                        g.DrawString(truncatedProductName.ToUpper(), titleFont, Brushes.Black, titleRect, sfCenter);
                    }

                    int barcodeWidth = 380;
                    int barcodeHeight = 90;
                    using (Image generatedBarcodeImage = _barcodeService.GenerateBarcode(_selectedProduct.Barcode, barcodeWidth, barcodeHeight))
                    {
                        int barcodeX = (labelWidth - barcodeWidth) / 2;
                        int barcodeY = 55;
                        g.DrawImage(generatedBarcodeImage, barcodeX, barcodeY, barcodeWidth, barcodeHeight);
                    }

                    using (Font priceFont = new Font("Segoe UI", 28, FontStyle.Bold))
                    using (StringFormat sfPrice = new StringFormat { Alignment = StringAlignment.Center })
                    {
                        Rectangle priceRect = new Rectangle(10, 160, labelWidth - 20, 50);
                        string formattedPriceText = _selectedProduct.SellPrice.ToString("C2");
                        g.DrawString(formattedPriceText, priceFont, Brushes.DarkBlue, priceRect, sfPrice);
                    }

                    using (Font tagFont = new Font("Segoe UI", 7, FontStyle.Italic))
                    {
                        g.DrawString("Compriax", tagFont, Brushes.Gray, 15, labelHeight - 20);
                    }
                }

                ImageHelper.Clear(pictureBoxBarcodePreview);
                pictureBoxBarcodePreview.Image = (Bitmap)_generatedLabel.Clone();
            }
        }

        private void ExecutePrintShelfLabel()
        {
            if (_generatedLabel == null)
            {
                UIHelper.WarnMessage(this, "No hay ninguna etiqueta generada en pantalla para imprimir.", "Etiqueta Requerida");
                return;
            }

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, ev) =>
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

            using PrintDialog printDialog = new PrintDialog { Document = printDocument };
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDocument.Print();
        }

        private async void ExecuteSaveShelfLabelAsImageAsync()
        {
            if (_generatedLabel == null)
            {
                UIHelper.WarnMessage(this, "No hay ninguna etiqueta generada para guardar como imagen.", "Etiqueta Requerida");
                return;
            }

            using var ms = new MemoryStream();
            _generatedLabel.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] encodedPngBytes = ms.ToArray();

            string defaultFileName = $"Etiqueta_{_selectedProduct?.Barcode ?? "Codigo"}.png";
            await FileExportHelper.SaveAndOpenFileAsync(this, encodedPngBytes, defaultFileName, "Imagen PNG (*.png)|*.png|Imagen JPG (*.jpg)|*.jpg", "Guardar Etiqueta de Precio");
        }

        private void ConfigureProductsGridColumns()
        {
            UIHelper.FormatGrid(dataGridViewProducts);

            string[] columnsToHide = { "CurrentStock", "MinimumStock", "StockStatus", "BuyPrice" };
            foreach (var col in columnsToHide)
            {
                if (dataGridViewProducts.Columns.Contains(col))
                    dataGridViewProducts.Columns[col].Visible = false;
            }
        }

        private void ResetLabelGeneratorFields()
        {
            _selectedProduct = null;
            _generatedLabel?.Dispose();
            _generatedLabel = null;

            ImageHelper.Clear(pictureBoxBarcodePreview);
            labelSelectedProductName.Text = "Ningún producto seleccionado";
        }
    }
}










