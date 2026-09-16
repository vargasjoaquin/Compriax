using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormCategories : Form
    {
        private readonly ICatalogService _catalogService;
        private int? _selectedCategoryIdentifier = null;

        public FormCategories(ICatalogService catalogService)
        {
            _catalogService = catalogService;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelCard);

            this.Load += async (s, e) => await InitializeCategoriesFormAsync();
            this.buttonSave.Click += async (s, e) => await ExecuteSaveCategoryAsync();
            this.buttonDelete.Click += async (s, e) => await ExecuteDeleteCategoryAsync();
            this.buttonCancel.Click += (s, e) => ResetFormInputFields();

            this.dataGridViewCategories.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dataGridViewCategories, e);
        }
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializeCategoriesFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                await RefreshCategoriesGridAsync();
                UIHelper.AttachManagedSelection(this, dataGridViewCategories, SynchronizeSelectedCategoryToFormFields, ResetFormInputFields);
            }
        }

        private async Task RefreshCategoriesGridAsync()
        {
            var activeCategories = await _catalogService.GetActiveCategoriesAsync();
            dataGridViewCategories.DataSource = null;
            dataGridViewCategories.DataSource = activeCategories.ToList();
            DataGridViewHelper.ApplyStyle(dataGridViewCategories);
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SaveCategory.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSaveCategoryAsync()
        {
            var category = new CategoryDto
            {
                Id = _selectedCategoryIdentifier ?? 0,
                Name = textBoxCategoryName.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),
                IsActive = true
            };

            var operationResult = category.Id == 0
                ? await _catalogService.CreateCategoryAsync(category)
                : await _catalogService.UpdateCategoryAsync(category);

            UIHelper.ShowResult(operationResult, "Categorías", async () =>
            {
                await RefreshCategoriesGridAsync();
                ResetFormInputFields();
            });
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de DeleteCategory.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteDeleteCategoryAsync()
        {
            if (_selectedCategoryIdentifier == null)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una categoría de la lista para poder eliminarla.", "Selección Requerida");
                return;
            }

            if (UIHelper.ConfirmMessage("¿Desea eliminar esta categoría? El sistema verificará que no tenga productos activos asociados.", "Eliminar Categoría"))
            {
                var operationResult = await _catalogService.DeleteCategoryAsync(_selectedCategoryIdentifier.Value);
                UIHelper.ShowResult(operationResult, "Gestión de Categorías", async () =>
                {
                    await RefreshCategoriesGridAsync();
                    ResetFormInputFields();
                });
            }
        }
        /// <summary>
        /// Sincroniza la entidad SelectedCategoryToFormFields seleccionada con los campos de entrada de la interfaz.
        /// </summary>

        private void SynchronizeSelectedCategoryToFormFields()
        {
            if (dataGridViewCategories.CurrentRow == null)
                return;

            var selectedCategory = (CategoryDto)dataGridViewCategories.CurrentRow.DataBoundItem;

            _selectedCategoryIdentifier = selectedCategory.Id;
            textBoxCategoryName.Text = selectedCategory.Name;
            textBoxDescription.Text = selectedCategory.Description ?? string.Empty;
            buttonDelete.Visible = true;
            buttonSave.Text = "ACTUALIZAR";
        }

        private void ResetFormInputFields()
        {
            _selectedCategoryIdentifier = null;
            UIHelper.CleanControls(panelCard);
            buttonDelete.Visible = false;
            buttonSave.Text = "GUARDAR";
            textBoxCategoryName.Focus();
        }
    }
}