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

        private readonly List<ProductLabelDto> _labelQueue = new();
        private ProductDto? _selectedProduct;
        private StoreSettingsDto? _storeSettings;
        private Bitmap? _previewBitmap;

        private const int ColumnsPerPage = 3;
        private const int RowsPerPage = 8;
        private const int LabelsPerPage = ColumnsPerPage * RowsPerPage;
        private int _currentPreviewPage = 0;
        private int _printPageIndex = 0;

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
            UIThemeHelper.ApplyCardStyle(panelLeftConfiguration);
            UIThemeHelper.ApplyCardStyle(panelRightPreviewCard);

            this.Load += async (s, e) => await InitializeProductLabelsSheetFormAsync();
            this.buttonAddLabelToQueue.Click += async (s, e) => await ExecuteAddProductLabelToSheetQueueAsync();
            this.buttonRemoveSelectedFromQueue.Click += (s, e) => ExecuteRemoveSelectedLabelFromQueue();
            this.buttonClearQueue.Click += (s, e) => ExecuteClearAllLabelsQueue();
            this.buttonPrintSheet.Click += (s, e) => ExecutePrintA4LabelsSheet();
            this.buttonExportSheetPng.Click += async (s, e) => await ExecuteExportSheetPreviewAsPngAsync();

            this.buttonPreviousPage.Click += (s, e) => ChangeCurrentPreviewPage(-1);
            this.buttonNextPage.Click += (s, e) => ChangeCurrentPreviewPage(1);

            this.quickSearchBox.ProductSelected += (s, product) => SelectProductForLabelConfiguration(product);
            this.dataGridViewLabelQueue.CellDoubleClick += (s, e) => ExecuteRemoveSelectedLabelFromQueue();
        }
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializeProductLabelsSheetFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                try
                {
                    _storeSettings = await _storeService.GetStoreProfileAsync();
                    var activeProductsList = await _productService.GetProductListAsync();
                    quickSearchBox.SetProductsSource(activeProductsList.Where(p => p.IsActive));

                    DataGridViewHelper.ApplyStyle(dataGridViewLabelQueue);
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"Error al inicializar módulo de etiquetas:\n{ex.Message}", "Etiquetas");
                }
                finally
                {
                    ResetFormInputFields();
                    UpdateQueueGridAndRenderPreviewSheet();
                }
            }
        }

        /// <summary>
        /// Precarga un producto directamente desde otro formulario (ej: FormProducts).
        /// </summary>
        public void PreloadProductToShelfLabelsQueue(ProductDto product, int quantity = 1)
        {
            SelectProductForLabelConfiguration(product);
            numericUpDownQuantity.Value = Math.Clamp(quantity, 1, 1000);
            _ = ExecuteAddProductLabelToSheetQueueAsync();
        }

        private void SelectProductForLabelConfiguration(ProductDto product)
        {
            _selectedProduct = product;
            labelSelectedProductInfo.Text = $"SELECCIONADO: [{product.Barcode}] {product.Name}";
            labelSelectedProductInfo.ForeColor = UIThemeHelper.PrimaryDark;

            textBoxShortDescription.Text = product.Name.Length > 45 ? product.Name.Substring(0, 45) : product.Name;
            numericUpDownPrice.Value = product.SellPrice;
            numericUpDownQuantity.Value = 1;
            numericUpDownQuantity.Focus();
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de AddProductLabelToSheetQueue.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteAddProductLabelToSheetQueueAsync()
        {
            if (_selectedProduct == null)
            {
                UIHelper.WarnMessage(this, "Debe buscar y seleccionar un producto antes de agregarlo a la plancha.", "Producto Requerido");
                quickSearchBox.FocusInput();
                return;
            }

            var productLabel = new ProductLabelDto
            {
                ProductId = _selectedProduct.Id,
                Barcode = _selectedProduct.Barcode,
                ProductName = _selectedProduct.Name,
                LabelDescription = textBoxShortDescription.Text.Trim(),
                Price = numericUpDownPrice.Value,
                Quantity = (int)numericUpDownQuantity.Value,
                CategoryName = _selectedProduct.CategoryName,
                BrandName = _selectedProduct.BrandName,
                StoreName = _storeSettings?.Name,
                GeneratedAt = DateTime.Now
            };

            var validationResult = await _labelValidator.ValidateAsync(productLabel);
            
            if (!validationResult.IsValid)
            {
                UIHelper.ShowResult(validationResult.ToResult(), "Validación de Etiqueta");
                return;
            }

            var existing = _labelQueue.FirstOrDefault(x => x.ProductId == productLabel.ProductId &&
                                                           x.LabelDescription == productLabel.LabelDescription &&
                                                           x.Price == productLabel.Price);
            if (existing != null)
            {
                existing.Quantity += productLabel.Quantity;
            }
            else
            {
                _labelQueue.Add(productLabel);
            }

            ResetFormInputFields();
            UpdateQueueGridAndRenderPreviewSheet();
        }

        private void ExecuteRemoveSelectedLabelFromQueue()
        {
            if (dataGridViewLabelQueue.CurrentRow?.DataBoundItem is ProductLabelDto selectedItem)
            {
                _labelQueue.Remove(selectedItem);
                UpdateQueueGridAndRenderPreviewSheet();
            }
            else
            {
                UIHelper.WarnMessage(this, "Seleccione una fila de la lista para quitarla de la plancha.", "Aviso");
            }
        }

        private void ExecuteClearAllLabelsQueue()
        {
            if (_labelQueue.Any() && UIHelper.ConfirmMessage("¿Desea vaciar toda la lista de etiquetas pendientes?", "Limpiar Plancha"))
            {
                _labelQueue.Clear();
                UpdateQueueGridAndRenderPreviewSheet();
            }
        }

        private void ResetFormInputFields()
        {
            _selectedProduct = null;
            labelSelectedProductInfo.Text = "Ningún producto seleccionado";
            labelSelectedProductInfo.ForeColor = UIThemeHelper.TextMuted;
            textBoxShortDescription.Clear();
            numericUpDownPrice.Value = 0;
            numericUpDownQuantity.Value = 1;
            quickSearchBox.Clear();
            quickSearchBox.FocusInput();
        }

        private void UpdateQueueGridAndRenderPreviewSheet()
        {
            dataGridViewLabelQueue.DataSource = null;
            dataGridViewLabelQueue.DataSource = _labelQueue.ToList();
            DataGridViewHelper.ApplyStyle(dataGridViewLabelQueue);

            // Ocultamos columnas que no aportan a la lista de impresión
            string[] hideCols = { "ProductId", "ProductName", "CategoryName", "BrandName", "StoreName", "GeneratedAt", "FormattedPrice" };
            
            foreach (var col in hideCols)
            {
                if (dataGridViewLabelQueue.Columns.Contains(col))
                    dataGridViewLabelQueue.Columns[col].Visible = false;
            }

            if (dataGridViewLabelQueue.Columns.Contains("Barcode"))
                dataGridViewLabelQueue.Columns["Barcode"].HeaderText = "Código de Barras";
            
            if (dataGridViewLabelQueue.Columns.Contains("LabelDescription"))
                dataGridViewLabelQueue.Columns["LabelDescription"].HeaderText = "Descripción en Etiqueta";
            
            if (dataGridViewLabelQueue.Columns.Contains("Price"))
                dataGridViewLabelQueue.Columns["Price"].HeaderText = "Precio Unitario";
            
            if (dataGridViewLabelQueue.Columns.Contains("Quantity"))
                dataGridViewLabelQueue.Columns["Quantity"].HeaderText = "Cant. Etiquetas";

            int totalLabels = _labelQueue.Sum(x => x.Quantity);
            int calculatedTotalPages = (int)Math.Ceiling(totalLabels / (double)LabelsPerPage);
            
            if (calculatedTotalPages == 0) 
                calculatedTotalPages = 1;

            labelTotalSummary.Text = $"Productos: {_labelQueue.Count}  |  Total Etiquetas: {totalLabels}  ({calculatedTotalPages} hoja/s A4)";

            _currentPreviewPage = Math.Clamp(_currentPreviewPage, 0, Math.Max(0, calculatedTotalPages - 1));
            RenderA4LabelsSheetPreviewBitmap();
        }

        private void ChangeCurrentPreviewPage(int delta)
        {
            int totalLabels = _labelQueue.Sum(x => x.Quantity);
            int calculatedTotalPages = Math.Max(1, (int)Math.Ceiling(totalLabels / (double)LabelsPerPage));

            _currentPreviewPage = Math.Clamp(_currentPreviewPage + delta, 0, calculatedTotalPages - 1);
            RenderA4LabelsSheetPreviewBitmap();
        }

        /// <summary>
        /// Genera la lista consecutiva plana de todas las etiquetas solicitadas
        /// </summary>
        private List<ProductLabelDto> GetFlattenedLabelsList()
        {
            return _labelQueue
                .SelectMany(item => Enumerable.Repeat(item, item.Quantity))
                .ToList();
        }

        /// <summary>
        /// Renderiza la vista previa WYSIWYG de una página A4 completa con la grilla de etiquetas
        /// </summary>
        private void RenderA4LabelsSheetPreviewBitmap()
        {
            var flattenedLabelsSequence = GetFlattenedLabelsList();
            int calculatedTotalPages = Math.Max(1, (int)Math.Ceiling(flattenedLabelsSequence.Count / (double)LabelsPerPage));

            labelPageIndicator.Text = $"Página {_currentPreviewPage + 1} de {calculatedTotalPages}";
            buttonPreviousPage.Enabled = _currentPreviewPage > 0;
            buttonNextPage.Enabled = _currentPreviewPage < calculatedTotalPages - 1;

            // Dimensiones proporcionales a una hoja A4 vertical
            int sheetWidth = 820;
            int sheetHeight = 1160;

            var bmp = new Bitmap(sheetWidth, sheetHeight);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // Borde de la hoja A4
                using (var pageBorderPen = new Pen(Color.FromArgb(203, 213, 225), 1))
                {
                    g.DrawRectangle(pageBorderPen, 0, 0, sheetWidth - 1, sheetHeight - 1);
                }

                // Márgenes de la hoja A4 (en píxeles)
                int marginX = 25;
                int marginY = 30;
                int availableWidth = sheetWidth - (marginX * 2);
                int availableHeight = sheetHeight - (marginY * 2);

                int cellWidth = availableWidth / ColumnsPerPage;
                int cellHeight = availableHeight / RowsPerPage;

                int startIndex = _currentPreviewPage * LabelsPerPage;
                int endIndex = Math.Min(startIndex + LabelsPerPage, flattenedLabelsSequence.Count);

                for (int i = startIndex; i < endIndex; i++)
                {
                    int pagePosition = i - startIndex;
                    int col = pagePosition % ColumnsPerPage;
                    int row = pagePosition / ColumnsPerPage;

                    int x = marginX + (col * cellWidth);
                    int y = marginY + (row * cellHeight);

                    var cellRect = new Rectangle(x, y, cellWidth, cellHeight);
                    DrawSingleProductLabel(g, cellRect, flattenedLabelsSequence[i]);
                }
            }

            _previewBitmap?.Dispose();
            _previewBitmap = bmp;
            ImageHelper.Clear(pictureBoxSheetPreview);
            pictureBoxSheetPreview.Image = (Bitmap)_previewBitmap.Clone();
        }

        /// <summary>
        /// Dibuja una etiqueta individual respetando el formato visual de la referencia
        /// </summary>
        private void DrawSingleProductLabel(Graphics g, Rectangle cellRect, ProductLabelDto label)
        {
            // Margen interior de cada etiqueta
            var labelRect = new Rectangle(cellRect.X + 3, cellRect.Y + 3, cellRect.Width - 6, cellRect.Height - 6);

            // 1. Recuadro con borde sutil
            using (var borderPen = new Pen(Color.FromArgb(148, 163, 184), 1))
            {
                g.DrawRectangle(borderPen, labelRect);
            }

            // 2. Descripción breve / Nombre del producto (Arriba centrado)
            var titleRect = new Rectangle(labelRect.X + 4, labelRect.Y + 6, labelRect.Width - 8, 28);
            using (var fontTitle = new Font("Segoe UI", 8F, FontStyle.Bold))
            using (var brushTitle = new SolidBrush(Color.FromArgb(15, 23, 42)))
            using (var sfTitle = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter })
            {
                g.DrawString(label.LabelDescription.ToUpper(), fontTitle, brushTitle, titleRect, sfTitle);
            }

            // 3. Precio Gigante y Destacado en violeta/azul (Centro)
            var priceRect = new Rectangle(labelRect.X + 4, labelRect.Y + 34, labelRect.Width - 8, 54);
            using (var fontPrice = new Font("Segoe UI", 20F, FontStyle.Bold))
            using (var brushPrice = new SolidBrush(Color.FromArgb(109, 40, 217))) // Tono violeta institucional de referencia
            using (var sfPrice = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.DrawString(label.FormattedPrice, fontPrice, brushPrice, priceRect, sfPrice);
            }

            // 4. Pie de Etiqueta: Código de barras / SKU (Izquierda) + Fecha (Derecha)
            var footerRect = new Rectangle(labelRect.X + 6, labelRect.Bottom - 20, labelRect.Width - 12, 16);
            using (var fontFooter = new Font("Segoe UI", 7F, FontStyle.Regular))
            using (var brushFooter = new SolidBrush(Color.FromArgb(100, 116, 139)))
            using (var sfLeft = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center })
            using (var sfRight = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center })
            {
                g.DrawString(label.Barcode, fontFooter, brushFooter, footerRect, sfLeft);
                g.DrawString(label.GeneratedAt.ToString("dd/MM/yyyy"), fontFooter, brushFooter, footerRect, sfRight);
            }
        }

        private void ExecutePrintA4LabelsSheet()
        {
            var flattenedLabelsSequence = GetFlattenedLabelsList();

            if (!flattenedLabelsSequence.Any())
            {
                UIHelper.WarnMessage(this, "La lista de etiquetas está vacía. Agregue productos a la plancha antes de imprimir.", "Plancha Vacía");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                try
                {
                    _printPageIndex = 0;
                    int calculatedTotalPages = (int)Math.Ceiling(flattenedLabelsSequence.Count / (double)LabelsPerPage);

                    var pd = new PrintDocument();
                    pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                    pd.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);

                    pd.PrintPage += (s, ev) =>
                    {
                        if (ev.Graphics == null)
                            return;

                        ev.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                        ev.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        ev.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        var bounds = ev.MarginBounds;
                        int cellW = bounds.Width / ColumnsPerPage;
                        int cellH = bounds.Height / RowsPerPage;

                        int startIdx = _printPageIndex * LabelsPerPage;
                        int endIdx = Math.Min(startIdx + LabelsPerPage, flattenedLabelsSequence.Count);

                        for (int i = startIdx; i < endIdx; i++)
                        {
                            int pos = i - startIdx;
                            int c = pos % ColumnsPerPage;
                            int r = pos / ColumnsPerPage;

                            int x = bounds.Left + (c * cellW);
                            int y = bounds.Top + (r * cellH);

                            var cellRect = new Rectangle(x, y, cellW, cellH);
                            DrawSingleProductLabel(ev.Graphics, cellRect, flattenedLabelsSequence[i]);
                        }

                        _printPageIndex++;
                        ev.HasMorePages = _printPageIndex < calculatedTotalPages;
                    };

                    using var printDlg = new PrintDialog { Document = pd, AllowSomePages = true };
                    if (printDlg.ShowDialog(this) == DialogResult.OK)
                    {
                        pd.Print();
                        UIHelper.InfoMessage(this, $"Se enviaron {flattenedLabelsSequence.Count} etiquetas ({calculatedTotalPages} plancha/s A4) a la impresora.", "Impresión Exitosa");
                    }
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"Error durante la impresión:\n{ex.Message}", "Fallo de Impresión");
                }
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de ExportSheetPreviewAsPng.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteExportSheetPreviewAsPngAsync()
        {
            if (_previewBitmap == null || !_labelQueue.Any())
            {
                UIHelper.WarnMessage(this, "No hay etiquetas para exportar como imagen.", "Aviso");
                return;
            }

            using var ms = new MemoryStream();
            _previewBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] bytes = ms.ToArray();

            string fileName = $"Plancha_Etiquetas_{DateTime.Now:yyyyMMdd_HHmm}.png";
            await FileExportHelper.SaveAndOpenFileAsync(this, bytes, fileName, "Imagen PNG (*.png)|*.png", "Guardar Plancha A4");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _previewBitmap?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}