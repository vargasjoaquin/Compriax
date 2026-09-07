using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;
using System.Data;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormRestoreRecords : Form
    {
        private readonly IRestoreService _restoreService;
        private List<DeletedItemDto> _deletedItems = new();
        private DeletedItemDto? _selectedItem = null;
        private bool _isInitializing = false;
        private bool _isLoadingData = false;

        public FormRestoreRecords(IRestoreService restoreService)
        {
            _restoreService = restoreService;
            InitializeComponent();

            this.Load += async (s, e) => await InitializeFormAsync();
            this.cboEntityType.SelectedIndexChanged += async (s, e) =>
            {
                if (!_isInitializing)
                    await LoadDeletedRecordsAsync();
            };

            this.btnRestore.Click += async (s, e) => await ExecuteRestoreAction();
            this.txtSearch.TextChanged += (s, e) => FilterRecords();
        }

        private async Task InitializeFormAsync()
        {
            _isInitializing = true;
            try
            {
                cboEntityType.Items.Clear();
                cboEntityType.Items.AddRange(new object[] { "Productos", "Clientes", "Proveedores", "Usuarios", "Empleados", "Categorías" });
                cboEntityType.SelectedIndex = 0;

                UIHelper.FormatGrid(dgvDeletedRecords);
                UIHelper.AttachManagedSelection(this, dgvDeletedRecords, SyncSelectedRecord, ResetSelection);
            }
            finally
            {
                _isInitializing = false;
            }

            await LoadDeletedRecordsAsync();
        }

        private async Task LoadDeletedRecordsAsync()
        {
            if (cboEntityType.SelectedItem == null || _isLoadingData)
                return;

            _isLoadingData = true;
            string entityType = cboEntityType.SelectedItem.ToString()!;
            lblCount.Text = "Cargando registros...";

            using (new WaitCursorHelper(this))
            {
                try
                {
                    var data = await _restoreService.GetDeletedEntitiesAsync(entityType);
                    _deletedItems = data.ToList();

                    FilterRecords();
                    ResetSelection();
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"Error al consultar los registros eliminados de {entityType}:\n{ex.Message}", "Fallo de Consulta");
                }
                finally
                {
                    _isLoadingData = false;
                }
            }
        }

        private void FilterRecords()
        {
            string search = txtSearch.Text.Trim().ToLower();

            var filtered = _deletedItems.Where(x =>
                x.Identifier.ToLower().Contains(search) ||
                x.Name.ToLower().Contains(search) ||
                (x.AdditionalInfo != null && x.AdditionalInfo.ToLower().Contains(search)) ||
                (x.DeletedBy != null && x.DeletedBy.ToLower().Contains(search))
            ).ToList();

            dgvDeletedRecords.DataSource = null;
            dgvDeletedRecords.DataSource = filtered;
            UIHelper.FormatGrid(dgvDeletedRecords);

            lblCount.Text = $"Registros eliminados: {filtered.Count}";
        }

        private void SyncSelectedRecord()
        {
            if (dgvDeletedRecords.CurrentRow == null)
                return;

            _selectedItem = (DeletedItemDto)dgvDeletedRecords.CurrentRow.DataBoundItem;
            lblSelectedItem.Text = $"SELECCIONADO: [{_selectedItem.Identifier}] {_selectedItem.Name}";
            btnRestore.Enabled = true;
        }

        private void ResetSelection()
        {
            _selectedItem = null;
            lblSelectedItem.Text = "Ningún registro seleccionado";
            btnRestore.Enabled = false;
        }

        private async Task ExecuteRestoreAction()
        {
            if (_selectedItem == null)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un registro de la grilla para poder restaurarlo.", "Selección Requerida");
                return;
            }

            string msg = $"¿Está seguro que desea restaurar el registro:\n\n" +
                         $"Tipo: {_selectedItem.EntityType}\n" +
                         $"Identificador: {_selectedItem.Identifier}\n" +
                         $"Nombre: {_selectedItem.Name}?\n\n" +
                         $"El registro volverá a estar disponible con su ID original {_selectedItem.Id}.";

            if (UIHelper.ConfirmMessage(msg, "Confirmar Restauración"))
            {
                using (new WaitCursorHelper(this))
                {
                    var result = await _restoreService.RestoreEntityAsync(_selectedItem.EntityType, _selectedItem.Id);
                    UIHelper.ShowResult(result, "Papelera y Restauración", async () =>
                    {
                        await LoadDeletedRecordsAsync();
                    });
                }
            }
        }
    }
}