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
        private readonly Label _lblGhost;
        private readonly ToolStripDropDown _popupDropDown;
        private readonly ListBox _lstMatches;
        private readonly ToolStripControlHost _popupHost;

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

            _txtInput = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 11F),
                Location = new Point(12, 10),
                Width = Width - 24,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.White
            };

            _lblGhost = new Label
            {
                AutoSize = false,
                Font = _txtInput.Font,
                Location = new Point(12, 10),
                Height = 22,
                Width = Width - 24,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.White,
                ForeColor = Color.LightGray,
                Visible = false
            };

            Controls.Add(_lblGhost);
            Controls.Add(_txtInput);

            _popupDropDown = new ToolStripDropDown
            {
                AutoSize = false,
                Padding = Padding.Empty,
                Margin = Padding.Empty,
                BackColor = Color.White,
                DropShadowEnabled = true
            };

            _lstMatches = new ListBox
            {
                BorderStyle = BorderStyle.None,
                DrawMode = DrawMode.OwnerDrawFixed,
                IntegralHeight = false,
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionMode = SelectionMode.One
            };

            _lstMatches.DrawItem += OnListBoxDrawItem;
            _lstMatches.MouseClick += (sender, eventArgs) => ConfirmSelectionFromList();

            _popupHost = new ToolStripControlHost(_lstMatches)
            {
                AutoSize = false,
                Padding = Padding.Empty,
                Margin = Padding.Empty
            };

            _popupDropDown.Items.Add(_popupHost);

            _txtInput.TextChanged += OnInputTextChanged;
            _txtInput.KeyDown += OnInputKeyDown;

            Resize += (sender, eventArgs) =>
            {
                _txtInput.Width = Width - 24;
                _lblGhost.Width = Width - 24;
            };
        }

        public void SetProductsSource(IEnumerable<ProductDto> products)
        {
            _productsSource = products.Where(product => product.IsActive).ToList();
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
            _lblGhost.Text = string.Empty;
            _lblGhost.Visible = false;
            _topSuggestion = null;

            _isInternalUpdating = false;

            HidePopup();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using var borderPen = new Pen(Color.LightGray);

            var borderRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            e.Graphics.DrawRectangle(borderPen, borderRectangle);
        }

        private void OnInputTextChanged(object? sender, EventArgs e)
        {
            if (_isInternalUpdating)
            {
                return;
            }

            string searchQuery = _txtInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                _filteredMatches.Clear();
                _topSuggestion = null;

                _lblGhost.Text = string.Empty;
                _lblGhost.Visible = false;

                HidePopup();

                return;
            }

            string normalizedQuery = NormalizeString(searchQuery);

            _filteredMatches = _productsSource
                .Where(product =>
                    NormalizeString(product.Name).Contains(normalizedQuery) ||
                    NormalizeString(product.Barcode).Contains(normalizedQuery) ||
                    (!string.IsNullOrEmpty(product.Description) && NormalizeString(product.Description).Contains(normalizedQuery)))
                .Take(8)
                .ToList();

            if (_filteredMatches.Any())
            {
                _topSuggestion = _filteredMatches.First();

                if (_topSuggestion.Name.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase))
                {
                    _lblGhost.Text = searchQuery + _topSuggestion.Name.Substring(searchQuery.Length);
                    _lblGhost.Visible = true;
                }
                else
                {
                    _lblGhost.Text = string.Empty;
                    _lblGhost.Visible = false;
                }

                ShowPopupMatches();
            }
            else
            {
                _topSuggestion = null;

                _lblGhost.Text = string.Empty;
                _lblGhost.Visible = false;

                HidePopup();
            }
        }

        private void OnInputKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (_filteredMatches.Any())
                {
                    ShowPopupMatches();

                    if (_lstMatches.SelectedIndex < _lstMatches.Items.Count - 1)
                    {
                        _lstMatches.SelectedIndex++;
                    }
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (_filteredMatches.Any())
                {
                    ShowPopupMatches();

                    if (_lstMatches.SelectedIndex > 0)
                    {
                        _lstMatches.SelectedIndex--;
                    }
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (_popupDropDown.Visible && _lstMatches.SelectedIndex >= 0)
                {
                    ConfirmSelectionFromList();

                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    return;
                }

                var matchingProductByBarcode = _productsSource.FirstOrDefault(product => product.Barcode.Equals(_txtInput.Text.Trim(), StringComparison.OrdinalIgnoreCase));

                if (matchingProductByBarcode != null)
                {
                    SelectProduct(matchingProductByBarcode);

                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    return;
                }

                if (_topSuggestion != null)
                {
                    SelectProduct(_topSuggestion);

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                HidePopup();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ShowPopupMatches()
        {
            if (!_filteredMatches.Any())
            {
                HidePopup();
                return;
            }

            _lstMatches.Items.Clear();

            foreach (var product in _filteredMatches)
            {
                _lstMatches.Items.Add(product);
            }

            _lstMatches.Height = Math.Min(_filteredMatches.Count * 46 + 4, 280);
            _lstMatches.Width = Width;

            _popupHost.Size = new Size(Width, _lstMatches.Height);

            if (!_popupDropDown.Visible)
            {
                _popupDropDown.Show(this, new Point(0, Height));
            }
        }

        private void HidePopup()
        {
            if (_popupDropDown.Visible)
            {
                _popupDropDown.Close();
            }
        }

        private void ConfirmSelectionFromList()
        {
            if (_lstMatches.SelectedItem is ProductDto selectedProduct)
            {
                SelectProduct(selectedProduct);
            }
        }

        private void SelectProduct(ProductDto product)
        {
            ProductSelected?.Invoke(this, product);

            _isInternalUpdating = true;

            _txtInput.Text = product.Name;
            _txtInput.SelectionStart = _txtInput.Text.Length;

            _lblGhost.Text = string.Empty;
            _lblGhost.Visible = false;

            _isInternalUpdating = false;

            _topSuggestion = null;

            HidePopup();
        }

        private void OnListBoxDrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= _filteredMatches.Count)
            {
                return;
            }

            var product = _filteredMatches[e.Index];

            bool isItemSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            using var backgroundBrush = new SolidBrush(isItemSelected ? SystemColors.Highlight : Color.White);

            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);

            using var separatorPen = new Pen(Color.Gainsboro);

            e.Graphics.DrawLine(separatorPen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);

            using var productNameFont = new Font("Segoe UI", 10F, FontStyle.Bold);

            using var productNameBrush = new SolidBrush(isItemSelected ? SystemColors.HighlightText : Color.Black);

            e.Graphics.DrawString(product.Name, productNameFont, productNameBrush, e.Bounds.Left + 10, e.Bounds.Top + 5);

            string priceText = product.SellPrice.ToString("C2");

            using var priceFont = new Font("Segoe UI", 10F, FontStyle.Bold);

            using var priceBrush = new SolidBrush(isItemSelected ? SystemColors.HighlightText : Color.DarkGreen);

            SizeF priceTextSize = e.Graphics.MeasureString(priceText, priceFont);

            e.Graphics.DrawString(priceText, priceFont, priceBrush, e.Bounds.Right - priceTextSize.Width - 10, e.Bounds.Top + 5);

            string detailsText = !string.IsNullOrEmpty(product.Barcode) ? product.Barcode : product.Description ?? string.Empty;

            using var detailsFont = new Font("Segoe UI", 8.5F);

            using var detailsBrush = new SolidBrush(isItemSelected ? SystemColors.HighlightText : Color.Gray);

            e.Graphics.DrawString(detailsText, detailsFont, detailsBrush, e.Bounds.Left + 10, e.Bounds.Top + 25);
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
    }
}