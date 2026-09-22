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
            UIThemeHelper.ApplyFormStyle(this);
            
            ButtonIconOverlayHelper.BindEvents(this.buttonRestoreRecord, this.picIconRestoreRecord);
            

            this.Load += async (s, e) => await InitializeRestoreRecordsFormAsync();
            this.comboBoxEntityType.SelectedIndexChanged += async (s, e) =>
            {
                if (!_isInitializing)
                    await LoadDeletedRecordsByEntityTypeAsync();
            };

            this.buttonRestoreRecord.Click += async (s, e) => await ExecuteRestoreSelectedEntityAsync();
            this.textBoxSearch.TextChanged += (s, e) => FilterDeletedRecordsList();
        }

        private async Task InitializeRestoreRecordsFormAsync()
        {
            _isInitializing = true;
            try
            {
                comboBoxEntityType.Items.Clear();
                comboBoxEntityType.Items.AddRange(new object[] { "Productos", "Clientes", "Proveedores", "Usuarios", "Empleados", "Categorías" });
                comboBoxEntityType.SelectedIndex = 0;

                UIHelper.FormatGrid(dataGridViewDeletedRecords);
                UIHelper.AttachManagedSelection(this, dataGridViewDeletedRecords, SynchronizeSelectedDeletedRecordToDetails, ResetSelectedRecordFields);
            }
            finally
            {
                _isInitializing = false;
            }

            await LoadDeletedRecordsByEntityTypeAsync();
        }

        private async Task LoadDeletedRecordsByEntityTypeAsync()
        {
            if (comboBoxEntityType.SelectedItem == null || _isLoadingData)
                return;

            _isLoadingData = true;
            string selectedEntityTypeName = comboBoxEntityType.SelectedItem.ToString()!;
            labelRecordCount.Text = "Cargando registros...";

            using (new WaitCursorHelper(this))
            {
                try
                {
                    var deletedItemsDataList = await _restoreService.GetDeletedEntitiesAsync(selectedEntityTypeName);
                    _deletedItems = deletedItemsDataList.ToList();

                    FilterDeletedRecordsList();
                    ResetSelectedRecordFields();
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"Error al consultar los registros eliminados de {selectedEntityTypeName}:\n{ex.Message}", "Fallo de Consulta");
                }
                finally
                {
                    _isLoadingData = false;
                }
            }
        }

        private void FilterDeletedRecordsList()
        {
            string searchQueryText = textBoxSearch.Text.Trim().ToLower();

            var filteredDeletedItemsList = _deletedItems.Where(x =>
                x.Identifier.ToLower().Contains(searchQueryText) ||
                x.Name.ToLower().Contains(searchQueryText) ||
                (x.AdditionalInfo != null && x.AdditionalInfo.ToLower().Contains(searchQueryText)) ||
                (x.DeletedBy != null && x.DeletedBy.ToLower().Contains(searchQueryText))
            ).ToList();

            dataGridViewDeletedRecords.DataSource = null;
            dataGridViewDeletedRecords.DataSource = filteredDeletedItemsList;
            UIHelper.FormatGrid(dataGridViewDeletedRecords);

            labelRecordCount.Text = $"Registros eliminados: {filteredDeletedItemsList.Count}";
        }
        /// <summary>
        /// Sincroniza la entidad SelectedDeletedRecordToDetails seleccionada con los campos de entrada de la interfaz.
        /// </summary>

        private void SynchronizeSelectedDeletedRecordToDetails()
        {
            if (dataGridViewDeletedRecords.CurrentRow == null)
                return;

            _selectedItem = (DeletedItemDto)dataGridViewDeletedRecords.CurrentRow.DataBoundItem;
            labelSelectedItemInfo.Text = $"SELECCIONADO: [{_selectedItem.Identifier}] {_selectedItem.Name}";
            buttonRestoreRecord.Enabled = true;
        }

        private void ResetSelectedRecordFields()
        {
            _selectedItem = null;
            labelSelectedItemInfo.Text = "Ningún registro seleccionado";
            buttonRestoreRecord.Enabled = false;
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de RestoreSelectedEntity.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteRestoreSelectedEntityAsync()
        {
            if (_selectedItem == null)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un registro de la grilla para poder restaurarlo.", "Selección Requerida");
                return;
            }

            string confirmationPromptMessage = $"¿Está seguro que desea restaurar el registro:\n\n" +
                         $"Tipo: {_selectedItem.EntityType}\n" +
                         $"Identificador: {_selectedItem.Identifier}\n" +
                         $"Nombre: {_selectedItem.Name}?\n\n" +
                         $"El registro volverá a estar disponible con su ID original {_selectedItem.Id}.";

            if (UIHelper.ConfirmMessage(confirmationPromptMessage, "Confirmar Restauración"))
            {
                using (new WaitCursorHelper(this))
                {
                    var restoreOperationResult = await _restoreService.RestoreEntityAsync(_selectedItem.EntityType, _selectedItem.Id);
                    UIHelper.ShowResult(restoreOperationResult, "Papelera y Restauración", async () =>
                    {
                        await LoadDeletedRecordsByEntityTypeAsync();
                    });
                }
            }
        }
    }
}











