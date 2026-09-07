using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormCategories : Form
    {
        private readonly ICatalogService _catalogService;
        private int? _selectedCategoryId = null;

        public FormCategories(ICatalogService catalogService)
        {
            _catalogService = catalogService;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(pnlCard);

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnSave.Click += async (s, e) => await ExecuteSaveAction();
            this.btnDelete.Click += async (s, e) => await ExecuteDeleteAction();
            this.btnCancel.Click += (s, e) => ResetUI();

            this.dgvCategories.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dgvCategories, e);
        }

        public async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                await RefreshGridAsync();
                UIHelper.AttachManagedSelection(this, dgvCategories, SyncEntityToFields, ResetUI);
            }
        }

        private async Task RefreshGridAsync()
        {
            var categories = await _catalogService.GetActiveCategoriesAsync();
            dgvCategories.DataSource = null;
            dgvCategories.DataSource = categories.ToList();
            DataGridViewHelper.ApplyStyle(dgvCategories);
        }

        private async Task ExecuteSaveAction()
        {
            var dto = new CategoryDto
            {
                Id = _selectedCategoryId ?? 0,
                Name = txtName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                IsActive = true
            };

            var result = dto.Id == 0
                ? await _catalogService.CreateCategoryAsync(dto)
                : await _catalogService.UpdateCategoryAsync(dto);

            UIHelper.ShowResult(result, "Categorías", async () =>
            {
                await RefreshGridAsync();
                ResetUI();
            });
        }

        private async Task ExecuteDeleteAction()
        {
            if (_selectedCategoryId == null)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una categoría de la lista para poder eliminarla.", "Selección Requerida");
                return;
            }

            if (UIHelper.ConfirmMessage("¿Desea eliminar esta categoría? El sistema verificará que no tenga productos activos asociados.", "Eliminar Categoría"))
            {
                var result = await _catalogService.DeleteCategoryAsync(_selectedCategoryId.Value);
                UIHelper.ShowResult(result, "Gestión de Categorías", async () =>
                {
                    await RefreshGridAsync();
                    ResetUI();
                });
            }
        }

        private void SyncEntityToFields()
        {
            if (dgvCategories.CurrentRow == null)
                return;

            var category = (CategoryDto)dgvCategories.CurrentRow.DataBoundItem;

            _selectedCategoryId = category.Id;
            txtName.Text = category.Name;
            txtDescription.Text = category.Description ?? string.Empty;
            btnDelete.Visible = true;
            btnSave.Text = "ACTUALIZAR";
        }

        private void ResetUI()
        {
            _selectedCategoryId = null;
            UIHelper.CleanControls(pnlCard);
            btnDelete.Visible = false;
            btnSave.Text = "💾 GUARDAR";
            txtName.Focus();
        }
    }
}