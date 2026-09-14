using CompriaxSystem.Application.DTOs;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;

namespace CompriaxSystem.WinFormsUI.Controls
{
    public class QuickSearchProductBox : UserControl
    {
        private readonly TextBox _txtInput;
        private readonly ListBox _lstMatches;

        private List<ProductDto> _productsSource = new();
        private List<ProductDto> _filteredMatches = new();
        private ProductDto? _topSuggestion;
        private bool _isInternalUpdating = false;

        public event EventHandler<ProductDto>? ProductSelected;

        [Category("Appearance")]
        [Description("Texto de marcador de posición mostrado cuando la caja está vacía.")]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PlaceholderText
        {
            get => _txtInput.PlaceholderText;
            set => _txtInput.PlaceholderText = value;
        }

        public QuickSearchProductBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            Height = 42;
            BackColor = Color.White;

            // 1. Campo de texto principal
            _txtInput = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(12, 10),
                Width = Width - 24,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(15, 23, 42),
                PlaceholderText = "Buscar por nombre, código de barras o descripción [F2]..."
            };

            Controls.Add(_txtInput);

            // 2. Lista de resultados integrada
            _lstMatches = new ListBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                DrawMode = DrawMode.OwnerDrawFixed,
                IntegralHeight = false,
                ItemHeight = 46,
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionMode = SelectionMode.One,
                Cursor = Cursors.Hand,
                Visible = false
            };

            _lstMatches.DrawItem += OnListBoxDrawItem;
            _lstMatches.MouseDown += (sender, e) =>
            {
                int index = _lstMatches.IndexFromPoint(e.Location);
                if (index >= 0 && index < _filteredMatches.Count)
                {
                    _lstMatches.SelectedIndex = index;
                    ConfirmSelectionFromList();
                }
            };

            _txtInput.TextChanged += OnInputTextChanged;
            _txtInput.KeyDown += OnInputKeyDown;
            _txtInput.LostFocus += (sender, eventArgs) =>
            {
                if (!_lstMatches.Focused)
                {
                    HidePopup();
                }
            };

            Resize += (sender, eventArgs) =>
            {
                _txtInput.Width = Width - 24;
                if (_lstMatches.Visible)
                {
                    RepositionPopup();
                }
            };
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            AttachListToParentForm();
        }

        private void AttachListToParentForm()
        {
            var parentForm = this.FindForm();
            if (parentForm != null && !_lstMatches.IsDisposed)
            {
                if (!parentForm.Controls.Contains(_lstMatches))
                {
                    parentForm.Controls.Add(_lstMatches);
                }

                parentForm.LocationChanged += (s, ev) => HidePopup();
                parentForm.Resize += (s, ev) => HidePopup();
                parentForm.Deactivate += (s, ev) => HidePopup();
            }
        }

        public void SetProductsSource(IEnumerable<ProductDto> products)
        {
            // Solo productos activos y con stock disponible mayor a 0
            _productsSource = products
                .Where(product => product.IsActive && product.CurrentStock > 0)
                .ToList();
        }

        public void FocusInput()
        {
            _txtInput.Focus();
            _txtInput.SelectAll();
        }

        public void Clear()
        {
            _isInternalUpdating = true;

            _txtInput.Clear();
            _filteredMatches.Clear();
            _topSuggestion = null;

            _isInternalUpdating = false;

            HidePopup();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using var borderPen = new Pen(_txtInput.Focused ? Color.FromArgb(2, 132, 199) : Color.LightGray, 1.5f);
            var borderRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            e.Graphics.DrawRectangle(borderPen, borderRectangle);
        }

        private void OnInputTextChanged(object? sender, EventArgs e)
        {
            if (_isInternalUpdating)
            {
                return;
            }

            string searchQuery = _txtInput.Text;

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                _filteredMatches.Clear();
                _topSuggestion = null;
                HidePopup();
                return;
            }

            string normalizedQuery = NormalizeString(searchQuery.Trim());

            // Filtrado estricto: solo productos con stock > 0
            _filteredMatches = _productsSource
                .Where(product =>
                    product.CurrentStock > 0 &&
                    (NormalizeString(product.Name).Contains(normalizedQuery) ||
                     NormalizeString(product.Barcode).Contains(normalizedQuery) ||
                     (!string.IsNullOrEmpty(product.Description) && NormalizeString(product.Description).Contains(normalizedQuery))))
                .Take(8)
                .ToList();

            if (_filteredMatches.Any())
            {
                _topSuggestion = _filteredMatches.First();
                ShowPopupMatches();
            }
            else
            {
                _topSuggestion = null;
                HidePopup();
            }
        }

        private void OnInputKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (_lstMatches.Visible && _lstMatches.Items.Count > 0)
                {
                    int nextIndex = _lstMatches.SelectedIndex + 1;
                    if (nextIndex < _lstMatches.Items.Count)
                    {
                        _lstMatches.SelectedIndex = nextIndex;
                    }
                    else
                    {
                        _lstMatches.SelectedIndex = 0;
                    }

                    _lstMatches.Invalidate();
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (_lstMatches.Visible && _lstMatches.Items.Count > 0)
                {
                    int prevIndex = _lstMatches.SelectedIndex - 1;
                    if (prevIndex >= 0)
                    {
                        _lstMatches.SelectedIndex = prevIndex;
                    }
                    else
                    {
                        _lstMatches.SelectedIndex = _lstMatches.Items.Count - 1;
                    }

                    _lstMatches.Invalidate();
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (_lstMatches.Visible && _lstMatches.SelectedIndex >= 0 && _lstMatches.SelectedIndex < _filteredMatches.Count)
                {
                    var selected = _filteredMatches[_lstMatches.SelectedIndex];
                    _isInternalUpdating = true;
                    _txtInput.Text = selected.Name;
                    _txtInput.SelectionStart = _txtInput.Text.Length;
                    _isInternalUpdating = false;
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                string rawQuery = _txtInput.Text.Trim();

                // 1. Coincidencia exacta de código de barras
                var matchingProductByBarcode = _productsSource.FirstOrDefault(product =>
                    product.CurrentStock > 0 &&
                    product.Barcode.Equals(rawQuery, StringComparison.OrdinalIgnoreCase));

                if (matchingProductByBarcode != null)
                {
                    SelectProduct(matchingProductByBarcode);
                    return;
                }

                // 2. Selección de la lista resaltada
                if (_lstMatches.Visible && _lstMatches.SelectedIndex >= 0 && _lstMatches.SelectedIndex < _filteredMatches.Count)
                {
                    SelectProduct(_filteredMatches[_lstMatches.SelectedIndex]);
                    return;
                }

                // 3. Primera sugerencia disponible con stock
                if (_topSuggestion != null && _topSuggestion.CurrentStock > 0)
                {
                    SelectProduct(_topSuggestion);
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Clear();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ShowPopupMatches()
        {
            var parentForm = this.FindForm();
            if (parentForm == null || !_filteredMatches.Any())
            {
                HidePopup();
                return;
            }

            if (!parentForm.Controls.Contains(_lstMatches))
            {
                parentForm.Controls.Add(_lstMatches);
            }

            _lstMatches.BeginUpdate();
            _lstMatches.Items.Clear();

            foreach (var product in _filteredMatches)
            {
                _lstMatches.Items.Add(product);
            }

            _lstMatches.SelectedIndex = 0;
            _lstMatches.EndUpdate();

            RepositionPopup();

            _lstMatches.BringToFront();
            _lstMatches.Visible = true;
        }

        private void RepositionPopup()
        {
            var parentForm = this.FindForm();
            if (parentForm == null) return;

            Point screenPoint = this.PointToScreen(new Point(0, Height + 2));
            Point formPoint = parentForm.PointToClient(screenPoint);

            int popupHeight = Math.Min(_filteredMatches.Count * 46 + 2, 280);
            _lstMatches.Location = formPoint;
            _lstMatches.Size = new Size(Width, popupHeight);
        }

        private void HidePopup()
        {
            if (_lstMatches.Visible)
            {
                _lstMatches.Visible = false;
            }
        }

        private void ConfirmSelectionFromList()
        {
            if (_lstMatches.SelectedIndex >= 0 && _lstMatches.SelectedIndex < _filteredMatches.Count)
            {
                SelectProduct(_filteredMatches[_lstMatches.SelectedIndex]);
            }
        }

        private void SelectProduct(ProductDto product)
        {
            if (product.CurrentStock <= 0)
            {
                return;
            }

            HidePopup();
            Clear();
            ProductSelected?.Invoke(this, product);
        }

        private void OnListBoxDrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= _filteredMatches.Count)
            {
                return;
            }

            var product = _filteredMatches[e.Index];
            bool isItemSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using var backgroundBrush = new SolidBrush(isItemSelected ? Color.FromArgb(224, 242, 254) : Color.White);
            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);

            using var separatorPen = new Pen(Color.FromArgb(241, 245, 249));
            e.Graphics.DrawLine(separatorPen, e.Bounds.Left + 8, e.Bounds.Bottom - 1, e.Bounds.Right - 8, e.Bounds.Bottom - 1);

            // 1. Nombre del producto
            using var productNameFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            using var productNameBrush = new SolidBrush(isItemSelected ? Color.FromArgb(3, 105, 161) : Color.FromArgb(15, 23, 42));
            e.Graphics.DrawString(product.Name, productNameFont, productNameBrush, e.Bounds.Left + 10, e.Bounds.Top + 4);

            // 2. Precio alineado a la derecha
            string priceText = product.SellPrice.ToString("C2");
            using var priceFont = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            using var priceBrush = new SolidBrush(isItemSelected ? Color.FromArgb(3, 105, 161) : Color.FromArgb(2, 132, 199));
            SizeF priceTextSize = e.Graphics.MeasureString(priceText, priceFont);
            e.Graphics.DrawString(priceText, priceFont, priceBrush, e.Bounds.Right - priceTextSize.Width - 10, e.Bounds.Top + 4);

            // 3. Código de barras • Categoría • Stock
            string detailsText = $"{product.Barcode}  •  {(string.IsNullOrEmpty(product.CategoryName) ? "General" : product.CategoryName)}  •  Stock: {product.CurrentStock}";
            using var detailsFont = new Font("Segoe UI", 8.5F);
            using var detailsBrush = new SolidBrush(Color.FromArgb(100, 116, 139));
            e.Graphics.DrawString(detailsText, detailsFont, detailsBrush, e.Bounds.Left + 10, e.Bounds.Top + 24);
        }

        private static string NormalizeString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            string normalizedText = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (char character in normalizedText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(character);
                }
            }

            return stringBuilder.ToString().ToLowerInvariant();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_lstMatches != null && !_lstMatches.IsDisposed)
                {
                    _lstMatches.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}