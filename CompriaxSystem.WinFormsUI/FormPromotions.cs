using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Enums;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormPromotions : Form
    {
        private readonly IPromotionService _promotionService;
        private readonly IProductService _productService;
        private readonly ICatalogService _catalogService;

        private int _selectedPromoId = 0;
        private List<PromotionDto> _promotionsList = new();

        public FormPromotions(
            IPromotionService promotionService,
            IProductService productService,
            ICatalogService catalogService)
        {
            _promotionService = promotionService;
            _productService = productService;
            _catalogService = catalogService;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(gbPromo);

            this.dgvPromotions.CellFormatting += DgvPromotions_CellFormatting;

            this.Load += async (s, e) => await InitializeFormAsync();
            this.cboType.SelectedIndexChanged += (s, e) => AdjustFieldsByPromotionType();
            this.btnSave.Click += async (s, e) => await ExecuteSaveAction();
            this.btnEdit.Click += async (s, e) => await ExecuteEditAction();
            this.btnToggle.Click += async (s, e) => await ExecuteToggleAction();
            this.btnDelete.Click += async (s, e) => await ExecuteDeleteAction();
            this.txtSearch.TextChanged += (s, e) => FilterPromotions();
        }

        private void DgvPromotions_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPromotions.Columns[e.ColumnIndex].Name == "StatusSummary" && e.Value != null)
            {
                string status = e.Value.ToString()!;
                if (status.Contains("Inactiva") || status.Contains("Vencida"))
                {
                    e.CellStyle.ForeColor = UIThemeHelper.Danger;
                    e.CellStyle.SelectionForeColor = UIThemeHelper.Danger;
                }
                else
                {
                    e.CellStyle.ForeColor = UIThemeHelper.Success;
                    e.CellStyle.SelectionForeColor = Color.Lime;
                }
            }
        }

        public async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                cboType.DataSource = Enum.GetValues(typeof(PromotionType))
                    .Cast<PromotionType>()
                    .Select(t => new { Id = t, Name = GetPromoTypeName(t) })
                    .ToList();
                cboType.DisplayMember = "Name";
                cboType.ValueMember = "Id";

                var products = (await _productService.GetProductListAsync()).ToList();
                products.Insert(0, new ProductDto { Id = 0, Name = "[ Ninguno / Aplica a otro ]" });
                cboProduct.DataSource = products;
                cboProduct.DisplayMember = "Name";
                cboProduct.ValueMember = "Id";

                var categories = (await _catalogService.GetActiveCategoriesAsync()).ToList();
                categories.Insert(0, new CategoryDto { Id = 0, Name = "[ Ninguna / Aplica a otro ]" });
                cboCategory.DataSource = categories;
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "Id";

                await RefreshGridAsync();
                UIHelper.AttachManagedSelection(this, dgvPromotions, SyncEntityToFields, ResetUI);
            }
        }

        private static string GetPromoTypeName(PromotionType type) => type switch
        {
            PromotionType.PercentageOnProduct => "% Descuento en Producto",
            PromotionType.PercentageOnCategory => "% Descuento en Categoría",
            PromotionType.BuyXPayY => "Lleva N Paga M (NxM)",
            PromotionType.PercentageOnTotal => "% Descuento en Carrito",
            _ => "Otro"
        };

        private async Task RefreshGridAsync()
        {
            var data = await _promotionService.GetAllPromotionsAsync();
            _promotionsList = data.ToList();
            FilterPromotions();
            DataGridViewHelper.ApplyStyle(dgvPromotions);
        }

        private void FilterPromotions()
        {
            string search = txtSearch.Text.Trim().ToLower();

            var filtered = _promotionsList.Where(p =>
                p.Name.ToLower().Contains(search) ||
                (p.ProductName != null && p.ProductName.ToLower().Contains(search)) ||
                (p.CategoryName != null && p.CategoryName.ToLower().Contains(search)) ||
                p.PromotionTypeName.ToLower().Contains(search)
            ).ToList();

            dgvPromotions.DataSource = null;
            dgvPromotions.DataSource = filtered;
            UIHelper.FormatGrid(dgvPromotions);
        }

        private void AdjustFieldsByPromotionType()
        {
            if (cboType.SelectedValue is not PromotionType selectedType)
                return;

            bool isProd = selectedType == PromotionType.PercentageOnProduct || selectedType == PromotionType.BuyXPayY;
            bool isCat = selectedType == PromotionType.PercentageOnCategory;
            bool isNxM = selectedType == PromotionType.BuyXPayY;

            cboProduct.Enabled = isProd;
            cboCategory.Enabled = isCat;
            numDiscount.Enabled = !isNxM;
            numRequired.Enabled = isNxM;
            numPay.Enabled = isNxM;

            if (!isProd)
                cboProduct.SelectedValue = 0;
            
            if (!isCat)
                cboCategory.SelectedValue = 0;
        }

        private void SyncEntityToFields()
        {
            if (dgvPromotions.CurrentRow == null)
                return;

            var p = (PromotionDto)dgvPromotions.CurrentRow.DataBoundItem;
            _selectedPromoId = p.Id;
            txtName.Text = p.Name;

            if (txtDescription != null) 
                txtDescription.Text = p.Description;

            cboType.SelectedValue = p.PromotionType;
            cboProduct.SelectedValue = p.ProductId.HasValue ? p.ProductId.Value : 0;
            cboCategory.SelectedValue = p.CategoryId.HasValue ? p.CategoryId.Value : 0;

            numDiscount.Value = p.DiscountPercentage.HasValue ? p.DiscountPercentage.Value : 0;
            numRequired.Value = p.RequiredQuantity.HasValue ? p.RequiredQuantity.Value : 2;
            numPay.Value = p.PayQuantity.HasValue ? p.PayQuantity.Value : 1;

            dtpStart.Value = p.StartDate;
            dtpEnd.Value = p.EndDate;

            SetButtonState(isEditing: true);
            AdjustFieldsByPromotionType();
        }

        private void ResetUI()
        {
            _selectedPromoId = 0;
            UIHelper.CleanControls(gbPromo);

            cboType.SelectedIndex = 0;
            cboProduct.SelectedValue = 0;
            cboCategory.SelectedValue = 0;
            numDiscount.Value = 0;
            numRequired.Value = 2;
            numPay.Value = 1;
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today.AddMonths(1);

            SetButtonState(isEditing: false);
            AdjustFieldsByPromotionType();
        }

        private void SetButtonState(bool isEditing)
        {
            btnSave.Enabled = !isEditing;
            btnEdit.Enabled = isEditing;
            btnToggle.Enabled = isEditing;
            btnDelete.Enabled = isEditing;
        }

        private async Task ExecuteSaveAction() => await ProcessAction(0);
        private async Task ExecuteEditAction()
        {
            if (_selectedPromoId == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una promoción de la lista para poder editarla.", "Selección Requerida");
                return;
            }
            await ProcessAction(_selectedPromoId);
        }

        private async Task ProcessAction(int id)
        {
            var promotionType = (PromotionType)cboType.SelectedValue!;

            var dto = new PromotionDto
            {
                Id = id,
                Name = txtName.Text.Trim(),
                Description = txtDescription?.Text?.Trim(),
                PromotionType = promotionType,
                ProductId = cboProduct.SelectedValue is int prodId && prodId > 0 ? prodId : null,
                CategoryId = cboCategory.SelectedValue is int catId && catId > 0 ? catId : null,
                DiscountPercentage = promotionType != PromotionType.BuyXPayY ? numDiscount.Value : null,
                RequiredQuantity = promotionType == PromotionType.BuyXPayY ? (int)numRequired.Value : null,
                PayQuantity = promotionType == PromotionType.BuyXPayY ? (int)numPay.Value : null,
                StartDate = dtpStart.Value.Date,
                EndDate = dtpEnd.Value.Date.AddHours(23).AddMinutes(59),
                IsActive = true
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _promotionService.UpsertPromotionAsync(dto);
                UIHelper.ShowResult(result, "Promociones", async () =>
                {
                    await RefreshGridAsync();
                    ResetUI();
                });
            }
        }

        private async Task ExecuteToggleAction()
        {
            if (_selectedPromoId == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una promoción de la lista para cambiar su estado.", "Selección Requerida");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                var result = await _promotionService.ToggleStatusAsync(_selectedPromoId);
                UIHelper.ShowResult(result, "Estado", async () => {
                    await RefreshGridAsync();
                });
            }
        }

        private async Task ExecuteDeleteAction()
        {
            if (_selectedPromoId == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una promoción de la lista para eliminarla.", "Selección Requerida");
                return;
            }

            if (UIHelper.ConfirmMessage("¿Desea eliminar definitivamente esta regla de promoción?", "Eliminar Promoción"))
            {
                using (new WaitCursorHelper(this))
                {
                    var result = await _promotionService.DeletePromotionAsync(_selectedPromoId);
                    UIHelper.ShowResult(result, "Promociones", async () =>
                    {
                        await RefreshGridAsync();
                        ResetUI();
                    });
                }
            }
        }
    }
}