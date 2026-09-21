using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormSuppliers : Form
    {
        private readonly ISupplyChainService _supplyChainService;
        private readonly IDocumentService _documentService;
        private int _selectedSupplierIdentifier = 0;

        public FormSuppliers(ISupplyChainService supplyChainService, IDocumentService documentService)
        {
            _supplyChainService = supplyChainService;
            _documentService = documentService;
            InitializeComponent();
            
            ButtonIconOverlayHelper.BindEvents(this.buttonExportPdf, this.picIconExportPdf);
            ButtonIconOverlayHelper.BindEvents(this.buttonSave, this.picIconSave);
            ButtonIconOverlayHelper.BindEvents(this.buttonEdit, this.picIconEdit);
            ButtonIconOverlayHelper.BindEvents(this.buttonDelete, this.picIconDelete);
            

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelSupplierForm);

            this.textBoxTaxId.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(textBoxTaxId);
            this.dataGridViewSuppliers.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dataGridViewSuppliers, e);

            this.Load += async (s, e) => await InitializeSuppliersFormAsync();
            this.buttonSave.Click += async (s, e) => await ExecuteSaveSupplierAsync();
            this.buttonEdit.Click += async (s, e) => await ExecuteUpdateSupplierAsync();
            this.buttonDelete.Click += async (s, e) => await ExecuteDeleteSupplierAsync();
            this.buttonExportPdf.Click += async (s, e) => await ExecuteExportSuppliersReportToPdfAsync();
        }
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializeSuppliersFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                await RefreshSuppliersGridAsync();
                UIHelper.AttachManagedSelection(this, dataGridViewSuppliers, SynchronizeSelectedSupplierToFormFields, ResetFormInputFields);
            }
        }

        private async Task RefreshSuppliersGridAsync()
        {
            var suppliersList = await _supplyChainService.GetSuppliersAsync();
            dataGridViewSuppliers.DataSource = null;
            dataGridViewSuppliers.DataSource = suppliersList.ToList();
            UIHelper.FormatGrid(dataGridViewSuppliers);
        }
        /// <summary>
        /// Sincroniza la entidad SelectedSupplierToFormFields seleccionada con los campos de entrada de la interfaz.
        /// </summary>

        private void SynchronizeSelectedSupplierToFormFields()
        {
            if (dataGridViewSuppliers.CurrentRow == null)
                return;

            var supplier = (SupplierDto)dataGridViewSuppliers.CurrentRow.DataBoundItem;

            _selectedSupplierIdentifier = supplier.Id;
            textBoxTaxId.Text = supplier.CUIT;
            textBoxCompanyName.Text = supplier.CompanyName;
            textBoxContactName.Text = supplier.ContactName;
            textBoxEmail.Text = supplier.Email;
            textBoxPhone.Text = supplier.Phone;
            textBoxAddress.Text = supplier.Address;

            UpdateButtonStates(isEditing: true);
            textBoxTaxId.ReadOnly = true;
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SaveSupplier.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSaveSupplierAsync()
        {
            var supplier = MapFormInputFieldsToSupplierDto(0);
            var operationResult = await _supplyChainService.UpsertSupplierAsync(supplier);

            UIHelper.ShowResult(operationResult, "Gestión de Proveedores", async () =>
            {
                await RefreshSuppliersGridAsync();
                ResetFormInputFields();
            });
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de UpdateSupplier.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteUpdateSupplierAsync()
        {
            if (_selectedSupplierIdentifier == 0)
                return;

            var supplier = MapFormInputFieldsToSupplierDto(_selectedSupplierIdentifier);
            var operationResult = await _supplyChainService.UpsertSupplierAsync(supplier);

            UIHelper.ShowResult(operationResult, "Gestión de Proveedores", async () =>
            {
                await RefreshSuppliersGridAsync();
                ResetFormInputFields();
            });
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de DeleteSupplier.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteDeleteSupplierAsync()
        {
            if (_selectedSupplierIdentifier == 0)
                return;

            if (UIHelper.ConfirmMessage("¿Desea eliminar este proveedor?"))
            {
                var operationResult = await _supplyChainService.DeleteSupplierAsync(_selectedSupplierIdentifier);
                UIHelper.ShowResult(operationResult, "Gestión de Proveedores", async () =>
                {
                    await RefreshSuppliersGridAsync();
                    ResetFormInputFields();
                });
            }
        }

        private void ResetFormInputFields()
        {
            _selectedSupplierIdentifier = 0;
            UIHelper.CleanControls(panelSupplierForm);
            UpdateButtonStates(isEditing: false);
            textBoxTaxId.ReadOnly = false;
        }

        private void UpdateButtonStates(bool isEditing)
        {
            buttonSave.Enabled = !isEditing;
            buttonEdit.Enabled = isEditing;
            buttonDelete.Enabled = isEditing;
        }

        private SupplierDto MapFormInputFieldsToSupplierDto(int id)
        {
            return new SupplierDto
            {
                Id = id,
                CUIT = textBoxTaxId.Text.Trim(),
                CompanyName = textBoxCompanyName.Text.Trim(),
                ContactName = textBoxContactName.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                Phone = textBoxPhone.Text.Trim(),
                Address = textBoxAddress.Text.Trim(),
                IsActive = true
            };
        }

        public async Task ExecuteExportSuppliersReportToPdfAsync()
        {
            if (dataGridViewSuppliers.DataSource is not List<SupplierDto> suppliersList || !suppliersList.Any())
            {
                MessageBox.Show("No hay proveedores disponibles para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] suppliersReportPdfBytes = await _documentService.GenerateSuppliersReportAsync(suppliersList);
                string reportPdfFileName = $"Reporte_Proveedores_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                await FileExportHelper.SaveAndOpenPdfAsync(this, suppliersReportPdfBytes, reportPdfFileName, "Exportar Reporte de Proveedores");
            }
        }
    }
}










