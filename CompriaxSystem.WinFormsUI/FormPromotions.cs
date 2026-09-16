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

        private int _selectedPromotionIdentifier = 0;
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
            UIThemeHelper.ApplyCardStyle(panelPromotionForm);

            this.dataGridViewPromotions.CellFormatting += DgvPromotions_CellFormatting;

            this.Load += async (s, e) => await InitializePromotionsFormAsync();
            this.comboBoxPromotionType.SelectedIndexChanged += (s, e) => AdjustInputFieldsBasedOnSelectedPromotionType();
            this.buttonSave.Click += async (s, e) => await ExecuteSavePromotionAsync();
            this.buttonEdit.Click += async (s, e) => await ExecuteUpdatePromotionAsync();
            this.buttonToggleStatus.Click += async (s, e) => await ExecuteTogglePromotionStatusAsync();
            this.buttonDelete.Click += async (s, e) => await ExecuteDeletePromotionRuleAsync();
            this.textBoxSearch.TextChanged += (s, e) => FilterPromotionsListBySearchCriteria();
        }

        private void DgvPromotions_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewPromotions.Columns[e.ColumnIndex].Name == "StatusSummary" && e.Value != null)
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
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializePromotionsFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                comboBoxPromotionType.DataSource = Enum.GetValues(typeof(PromotionType))
                    .Cast<PromotionType>()
                    .Select(t => new { Id = t, Name = GetPromotionTypeDisplayName(t) })
                    .ToList();
                comboBoxPromotionType.DisplayMember = "Name";
                comboBoxPromotionType.ValueMember = "Id";

                var availableProductsList = (await _productService.GetProductListAsync()).ToList();
                availableProductsList.Insert(0, new ProductDto { Id = 0, Name = "[ Ninguno / Aplica a otro ]" });
                comboBoxApplicableProduct.DataSource = availableProductsList;
                comboBoxApplicableProduct.DisplayMember = "Name";
                comboBoxApplicableProduct.ValueMember = "Id";

                var availableCategoriesList = (await _catalogService.GetActiveCategoriesAsync()).ToList();
                availableCategoriesList.Insert(0, new CategoryDto { Id = 0, Name = "[ Ninguna / Aplica a otro ]" });
                comboBoxApplicableCategory.DataSource = availableCategoriesList;
                comboBoxApplicableCategory.DisplayMember = "Name";
                comboBoxApplicableCategory.ValueMember = "Id";

                await RefreshPromotionsGridAsync();
                UIHelper.AttachManagedSelection(this, dataGridViewPromotions, SynchronizeSelectedPromotionToFormFields, ResetFormInputFields);
            }
        }

        private static string GetPromotionTypeDisplayName(PromotionType type) => type switch
        {
            PromotionType.PercentageOnProduct => "% Descuento en Producto",
            PromotionType.PercentageOnCategory => "% Descuento en Categoría",
            PromotionType.BuyXPayY => "Lleva N Paga M (NxM)",
            PromotionType.PercentageOnTotal => "% Descuento en Carrito",
            _ => "Otro"
        };

        private async Task RefreshPromotionsGridAsync()
        {
            var allPromotionsList = await _promotionService.GetAllPromotionsAsync();
            _promotionsList = allPromotionsList.ToList();
            FilterPromotionsListBySearchCriteria();
            DataGridViewHelper.ApplyStyle(dataGridViewPromotions);
        }

        private void FilterPromotionsListBySearchCriteria()
        {
            string searchQueryText = textBoxSearch.Text.Trim().ToLower();

            var filteredPromotionsList = _promotionsList.Where(selectedPromotion =>
                selectedPromotion.Name.ToLower().Contains(searchQueryText) ||
                (selectedPromotion.ProductName != null && selectedPromotion.ProductName.ToLower().Contains(searchQueryText)) ||
                (selectedPromotion.CategoryName != null && selectedPromotion.CategoryName.ToLower().Contains(searchQueryText)) ||
                selectedPromotion.PromotionTypeName.ToLower().Contains(searchQueryText)
            ).ToList();

            dataGridViewPromotions.DataSource = null;
            dataGridViewPromotions.DataSource = filteredPromotionsList;
            UIHelper.FormatGrid(dataGridViewPromotions);
        }

        private void AdjustInputFieldsBasedOnSelectedPromotionType()
        {
            if (comboBoxPromotionType.SelectedValue is not PromotionType selectedType)
                return;

            bool isProd = selectedType == PromotionType.PercentageOnProduct || selectedType == PromotionType.BuyXPayY;
            bool isCat = selectedType == PromotionType.PercentageOnCategory;
            bool isNxM = selectedType == PromotionType.BuyXPayY;

            comboBoxApplicableProduct.Enabled = isProd;
            comboBoxApplicableCategory.Enabled = isCat;
            numericUpDownDiscountPercentage.Enabled = !isNxM;
            numericUpDownRequiredQuantity.Enabled = isNxM;
            numericUpDownPayQuantity.Enabled = isNxM;

            if (!isProd)
                comboBoxApplicableProduct.SelectedValue = 0;
            
            if (!isCat)
                comboBoxApplicableCategory.SelectedValue = 0;
        }
        /// <summary>
        /// Sincroniza la entidad SelectedPromotionToFormFields seleccionada con los campos de entrada de la interfaz.
        /// </summary>

        private void SynchronizeSelectedPromotionToFormFields()
        {
            if (dataGridViewPromotions.CurrentRow == null)
                return;

            var selectedPromotion = (PromotionDto)dataGridViewPromotions.CurrentRow.DataBoundItem;
            _selectedPromotionIdentifier = selectedPromotion.Id;
            textBoxPromotionName.Text = selectedPromotion.Name;

            if (textBoxDescription != null) 
                textBoxDescription.Text = selectedPromotion.Description;

            comboBoxPromotionType.SelectedValue = selectedPromotion.PromotionType;
            comboBoxApplicableProduct.SelectedValue = selectedPromotion.ProductId.HasValue ? selectedPromotion.ProductId.Value : 0;
            comboBoxApplicableCategory.SelectedValue = selectedPromotion.CategoryId.HasValue ? selectedPromotion.CategoryId.Value : 0;

            numericUpDownDiscountPercentage.Value = selectedPromotion.DiscountPercentage.HasValue ? selectedPromotion.DiscountPercentage.Value : 0;
            numericUpDownRequiredQuantity.Value = selectedPromotion.RequiredQuantity.HasValue ? selectedPromotion.RequiredQuantity.Value : 2;
            numericUpDownPayQuantity.Value = selectedPromotion.PayQuantity.HasValue ? selectedPromotion.PayQuantity.Value : 1;

            dateTimePickerStartDate.Value = selectedPromotion.StartDate;
            dateTimePickerEndDate.Value = selectedPromotion.EndDate;

            UpdateButtonStates(isEditing: true);
            AdjustInputFieldsBasedOnSelectedPromotionType();
        }

        private void ResetFormInputFields()
        {
            _selectedPromotionIdentifier = 0;
            UIHelper.CleanControls(panelPromotionForm);

            comboBoxPromotionType.SelectedIndex = 0;
            comboBoxApplicableProduct.SelectedValue = 0;
            comboBoxApplicableCategory.SelectedValue = 0;
            numericUpDownDiscountPercentage.Value = 0;
            numericUpDownRequiredQuantity.Value = 2;
            numericUpDownPayQuantity.Value = 1;
            dateTimePickerStartDate.Value = DateTime.Today;
            dateTimePickerEndDate.Value = DateTime.Today.AddMonths(1);

            UpdateButtonStates(isEditing: false);
            AdjustInputFieldsBasedOnSelectedPromotionType();
        }

        private void UpdateButtonStates(bool isEditing)
        {
            buttonSave.Enabled = !isEditing;
            buttonEdit.Enabled = isEditing;
            buttonToggleStatus.Enabled = isEditing;
            buttonDelete.Enabled = isEditing;
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SavePromotion.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSavePromotionAsync() => await ProcessSaveOrUpdatePromotionAsync(0);
        /// <summary>
        /// Ejecuta de manera asincrona la accion de UpdatePromotion.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>
        private async Task ExecuteUpdatePromotionAsync()
        {
            if (_selectedPromotionIdentifier == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una promoción de la lista para poder editarla.", "Selección Requerida");
                return;
            }
            await ProcessSaveOrUpdatePromotionAsync(_selectedPromotionIdentifier);
        }

        private async Task ProcessSaveOrUpdatePromotionAsync(int id)
        {
            var promotionType = (PromotionType)comboBoxPromotionType.SelectedValue!;

            var promotion = new PromotionDto
            {
                Id = id,
                Name = textBoxPromotionName.Text.Trim(),
                Description = textBoxDescription?.Text?.Trim(),
                PromotionType = promotionType,
                ProductId = comboBoxApplicableProduct.SelectedValue is int prodId && prodId > 0 ? prodId : null,
                CategoryId = comboBoxApplicableCategory.SelectedValue is int catId && catId > 0 ? catId : null,
                DiscountPercentage = promotionType != PromotionType.BuyXPayY ? numericUpDownDiscountPercentage.Value : null,
                RequiredQuantity = promotionType == PromotionType.BuyXPayY ? (int)numericUpDownRequiredQuantity.Value : null,
                PayQuantity = promotionType == PromotionType.BuyXPayY ? (int)numericUpDownPayQuantity.Value : null,
                StartDate = dateTimePickerStartDate.Value.Date,
                EndDate = dateTimePickerEndDate.Value.Date.AddHours(23).AddMinutes(59),
                IsActive = true
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _promotionService.UpsertPromotionAsync(promotion);
                UIHelper.ShowResult(result, "Promociones", async () =>
                {
                    await RefreshPromotionsGridAsync();
                    ResetFormInputFields();
                });
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de TogglePromotionStatus.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteTogglePromotionStatusAsync()
        {
            if (_selectedPromotionIdentifier == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una promoción de la lista para cambiar su estado.", "Selección Requerida");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                var result = await _promotionService.ToggleStatusAsync(_selectedPromotionIdentifier);
                UIHelper.ShowResult(result, "Estado", async () => {
                    await RefreshPromotionsGridAsync();
                });
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de DeletePromotionRule.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteDeletePromotionRuleAsync()
        {
            if (_selectedPromotionIdentifier == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una promoción de la lista para eliminarla.", "Selección Requerida");
                return;
            }

            if (UIHelper.ConfirmMessage("¿Desea eliminar definitivamente esta regla de promoción?", "Eliminar Promoción"))
            {
                using (new WaitCursorHelper(this))
                {
                    var result = await _promotionService.DeletePromotionAsync(_selectedPromotionIdentifier);
                    UIHelper.ShowResult(result, "Promociones", async () =>
                    {
                        await RefreshPromotionsGridAsync();
                        ResetFormInputFields();
                    });
                }
            }
        }
    }
}