using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;
using FluentValidation;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormProductLabels : Form
    {
        private readonly IProductService _productService;
        private readonly IBarcodeService _barcodeService;
        private readonly IStoreService _storeService;
        private readonly IValidator<ProductLabelDto> _labelValidator;

        private ProductDto? _selectedProduct;
        private Bitmap? _generatedLabelBitmap;
        private StoreSettingsDto? _storeSettings;
        private int _printedCopiesCount = 0;

        public FormProductLabels(
            IProductService productService,
            IBarcodeService barcodeService,
            IStoreService storeService,
            IValidator<ProductLabelDto> labelValidator)
        {
            _productService = productService;
            _barcodeService = barcodeService;
            _storeService = storeService;
            _labelValidator = labelValidator;

            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(pnlConfigCard);
            UIThemeHelper.ApplyCardStyle(pnlPreviewCard);

            this.Load += async (sender, eventArgs) => await InitializeFormAsync();
            this.btnGenerate.Click += async (sender, eventArgs) => await ExecuteGeneratePreviewAsync();
            this.btnPrint.Click += async (sender, eventArgs) => await ExecutePrintActionAsync();
            this.btnDownload.Click += async (sender, eventArgs) => await ExecuteDownloadActionAsync();
            this.btnClear.Click += (sender, eventArgs) => ResetUI();

            // Sincronización al seleccionar un producto del buscador predictivo
            this.quickSearchBox.ProductSelected += (sender, selectedProduct) =>
            {
                SelectProductForLabel(selectedProduct);
            };

            // Regeneración en tiempo real cuando cambian los campos clave
            this.txtShortDescription.TextChanged += (sender, eventArgs) => { if (_selectedProduct != null) _ = ExecuteGeneratePreviewAsync(); };
            this.numPrice.ValueChanged += (sender, eventArgs) => { if (_selectedProduct != null) _ = ExecuteGeneratePreviewAsync(); };
            this.chkShowStore.CheckedChanged += (sender, eventArgs) => { if (_selectedProduct != null) _ = ExecuteGeneratePreviewAsync(); };
            this.chkShowDate.CheckedChanged += (sender, eventArgs) => { if (_selectedProduct != null) _ = ExecuteGeneratePreviewAsync(); };
        }

        public async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                try
                {
                    _storeSettings = await _storeService.GetStoreProfileAsync();

                    var productList = await _productService.GetProductListAsync();

                    quickSearchBox.SetProductsSource(productList.Where(product => product.IsActive));
                }
                catch (Exception exception)
                {
                    UIHelper.ErrorMessage(this, $"Error al inicializar módulo de etiquetas:\n{exception.Message}", "Etiquetas");
                }
                finally
                {
                    ResetUI();
                }
            }
        }

        /// <summary>
        /// Permite precargar un producto directamente desde otro formulario (ej. FormProducts).
        /// </summary>
        public void PreloadProduct(ProductDto product, int quantity = 1)
        {
            SelectProductForLabel(product);
            numQuantity.Value = Math.Clamp(quantity, 1, 1000);
        }

        private void SelectProductForLabel(ProductDto product)
        {
            _selectedProduct = product;
            lblSelectedInfo.Text = $"PRODUCTO: [{product.Barcode}] {product.Name}";
            lblSelectedInfo.ForeColor = UIThemeHelper.PrimaryDark;

            txtShortDescription.Text = product.Name.Length > 50 ? product.Name.Substring(0, 50) : product.Name;
            numPrice.Value = product.SellPrice;

            _ = ExecuteGeneratePreviewAsync();
        }

        private async Task<ProductLabelDto?> BuildAndValidateDtoAsync()
        {
            if (_selectedProduct == null)
            {
                UIHelper.WarnMessage(this, "Debe buscar y seleccionar un producto para generar su etiqueta.", "Producto Requerido");
                quickSearchBox.FocusInput();
                return null;
            }

            var labelDto = new ProductLabelDto
            {
                ProductId = _selectedProduct.Id,
                Barcode = _selectedProduct.Barcode,
                ProductName = _selectedProduct.Name,
                LabelDescription = txtShortDescription.Text.Trim(),
                Price = numPrice.Value,
                Quantity = (int)numQuantity.Value,
                CategoryName = _selectedProduct.CategoryName,
                BrandName = _selectedProduct.BrandName,
                StoreName = chkShowStore.Checked ? (_storeSettings?.Name) : null,
                GeneratedAt = DateTime.Now
            };

            var validationResult = await _labelValidator.ValidateAsync(labelDto);

            if (!validationResult.IsValid)
            {
                UIHelper.ShowResult(validationResult.ToResult(), "Validación de Etiqueta");
                return null;
            }

            return labelDto;
        }

        private async Task ExecuteGeneratePreviewAsync()
        {
            if (_selectedProduct == null) 
                return;

            var labelDto = new ProductLabelDto
            {
                ProductId = _selectedProduct.Id,
                Barcode = _selectedProduct.Barcode,
                ProductName = _selectedProduct.Name,
                LabelDescription = string.IsNullOrWhiteSpace(txtShortDescription.Text) ? _selectedProduct.Name : txtShortDescription.Text.Trim(),
                Price = numPrice.Value > 0 ? numPrice.Value : _selectedProduct.SellPrice,
                Quantity = (int)numQuantity.Value,
                StoreName = chkShowStore.Checked ? (_storeSettings?.Name) : null,
                GeneratedAt = DateTime.Now
            };

            await Task.Run(() =>
            {
                int labelWidth = 520;
                int labelHeight = 260;

                var labelBitmap = new Bitmap(labelWidth, labelHeight);

                using (var graphics = Graphics.FromImage(labelBitmap))
                {
                    graphics.Clear(Color.White);
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    // Borde de corte de etiqueta
                    using (var borderPen = new Pen(Color.FromArgb(203, 213, 225), 2))
                    {
                        graphics.DrawRectangle(borderPen, 2, 2, labelWidth - 5, labelHeight - 5);
                    }

                    // 1. Encabezado del Comercio (Opcional)
                    if (!string.IsNullOrWhiteSpace(labelDto.StoreName))
                    {
                        using var storeFont = new Font("Segoe UI", 9F, FontStyle.Bold);
                        using var storeBrush = new SolidBrush(Color.FromArgb(100, 116, 139));
                        graphics.DrawString(labelDto.StoreName.ToUpper(), storeFont, storeBrush, 16, 12);
                    }

                    // Fecha de emisión/vigencia (Opcional)
                    if (chkShowDate.Checked)
                    {
                        using var dateFont = new Font("Segoe UI", 8F, FontStyle.Regular);
                        using var dateBrush = new SolidBrush(Color.FromArgb(148, 163, 184));

                        string formattedDate = labelDto.GeneratedAt.ToString("dd/MM/yyyy");
                        var dateTextSize = graphics.MeasureString(formattedDate, dateFont);

                        graphics.DrawString(formattedDate, dateFont, dateBrush, labelWidth - dateTextSize.Width - 16, 12);
                    }

                    // 2. Descripción Breve del Artículo (Grande y destacada)
                    using (var titleFont = new Font("Segoe UI", 12.5F, FontStyle.Bold))
                    using (var titleBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
                    using (var titleStringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        var titleRectangle = new Rectangle(14, 32, labelWidth - 28, 38);

                        graphics.DrawString(labelDto.LabelDescription.ToUpper(), titleFont, titleBrush, titleRectangle, titleStringFormat);
                    }

                    // 3. Código de Barras Renderizado con IBarcodeService
                    int barcodeWidth = 360;
                    int barcodeHeight = 82;

                    try
                    {
                        using var barcodeImage = _barcodeService.GenerateBarcode(labelDto.Barcode, barcodeWidth, barcodeHeight);

                        int barcodeX = (labelWidth - barcodeWidth) / 2;
                        int barcodeY = 74;

                        graphics.DrawImage(barcodeImage, barcodeX, barcodeY, barcodeWidth, barcodeHeight);
                    }
                    catch
                    {
                        // Fallback de texto si falla el renderizador
                        using var barcodeErrorFont = new Font("Segoe UI", 9F, FontStyle.Italic);

                        graphics.DrawString($"[{labelDto.Barcode}]", barcodeErrorFont, Brushes.Gray, (labelWidth - 100) / 2, 95);
                    }

                    // 4. Precio de Venta Gigante y Legible
                    using (var priceFont = new Font("Segoe UI", 28F, FontStyle.Bold))
                    using (var priceBrush = new SolidBrush(Color.FromArgb(2, 132, 199)))
                    using (var priceStringFormat = new StringFormat { Alignment = StringAlignment.Center })
                    {
                        var priceRectangle = new Rectangle(14, 172, labelWidth - 28, 55);

                        graphics.DrawString(labelDto.FormattedPrice, priceFont, priceBrush, priceRectangle, priceStringFormat);
                    }

                    // Pie de etiqueta
                    using (var footerFont = new Font("Segoe UI", 7.5F, FontStyle.Italic))
                    using (var footerBrush = new SolidBrush(Color.FromArgb(148, 163, 184)))
                    {
                        graphics.DrawString("Compriax POS  •  Sistema de Gestión Comercial", footerFont, footerBrush, 16, labelHeight - 20);
                    }
                }

                this.BeginInvoke(new Action(() =>
                {
                    _generatedLabelBitmap?.Dispose();
                    _generatedLabelBitmap = labelBitmap;

                    ImageHelper.Clear(picLabelPreview);
                    picLabelPreview.Image = (Bitmap)_generatedLabelBitmap.Clone();

                    lblPreviewStatus.Text = $"Etiqueta generada para impresión ({labelDto.Quantity} copia/s)";
                }));
            });
        }

        private async Task ExecutePrintActionAsync()
        {
            var labelDto = await BuildAndValidateDtoAsync();

            if (labelDto == null || _generatedLabelBitmap == null)
                return;

            using (new WaitCursorHelper(this))
            {
                try
                {
                    _printedCopiesCount = 0;

                    int totalCopies = labelDto.Quantity;

                    var printDocument = new PrintDocument();
                    printDocument.PrinterSettings.Copies = (short)totalCopies;

                    printDocument.PrintPage += (sender, printPageEventArgs) =>
                    {
                        if (_generatedLabelBitmap != null && printPageEventArgs.Graphics != null)
                        {
                            printPageEventArgs.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            printPageEventArgs.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                            int labelWidth = _generatedLabelBitmap.Width;
                            int labelHeight = _generatedLabelBitmap.Height;

                            // Centrado en la página de impresión
                            int positionX = Math.Max(0, (printPageEventArgs.PageBounds.Width - labelWidth) / 2);
                            int positionY = 20;

                            printPageEventArgs.Graphics.DrawImage(_generatedLabelBitmap, positionX, positionY, labelWidth, labelHeight);
                        }
                    };

                    using var printDialog = new PrintDialog { Document = printDocument };

                    if (printDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        printDocument.Print();

                        UIHelper.InfoMessage(this, $"Se enviaron {totalCopies} etiqueta(s) a la cola de impresión.", "Impresión Exitosa");
                    }
                }
                catch (Exception exception)
                {
                    UIHelper.ErrorMessage(this, $"Error durante el proceso de impresión:\n{exception.Message}", "Fallo de Impresión");
                }
            }
        }

        private async Task ExecuteDownloadActionAsync()
        {
            var labelDto = await BuildAndValidateDtoAsync();

            if (labelDto == null || _generatedLabelBitmap == null)
                return;

            using var memoryStream = new MemoryStream();

            _generatedLabelBitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

            byte[] imageBytes = memoryStream.ToArray();

            string fileName = $"Etiqueta_{labelDto.Barcode}_{DateTime.Now:yyyyMMdd_HHmm}.png";

            await FileExportHelper.SaveAndOpenFileAsync(this, imageBytes, fileName, "Imagen PNG (*.png)|*.png", "Guardar Etiqueta");
        }

        private void ResetUI()
        {
            _selectedProduct = null;

            _generatedLabelBitmap?.Dispose();
            _generatedLabelBitmap = null;

            ImageHelper.Clear(picLabelPreview);

            lblSelectedInfo.Text = "Ningún producto seleccionado";
            lblSelectedInfo.ForeColor = UIThemeHelper.TextMuted;
            lblPreviewStatus.Text = "Seleccione un producto para previsualizar.";

            txtShortDescription.Clear();
            numPrice.Value = 0;
            numQuantity.Value = 1;
            chkShowStore.Checked = true;
            chkShowDate.Checked = false;

            quickSearchBox.Clear();
            quickSearchBox.FocusInput();
        }
    }
}