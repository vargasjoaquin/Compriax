using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormCustomers : Form
    {
        private readonly ICustomerService _customerService;
        private readonly ILookupService _lookupService;
        private readonly IDocumentService _documentService;
        private int _selectedCustomerIdentifier = 0;

        public FormCustomers(ICustomerService customerService, ILookupService lookupService, IDocumentService documentService)
        {
            _customerService = customerService;
            _lookupService = lookupService;
            _documentService = documentService;
            InitializeComponent();
            
            ButtonIconOverlayHelper.BindEvents(this.buttonExportPdf, this.picIconExportPdf);
            ButtonIconOverlayHelper.BindEvents(this.buttonSave, this.picIconSave);
            ButtonIconOverlayHelper.BindEvents(this.buttonEdit, this.picIconEdit);
            ButtonIconOverlayHelper.BindEvents(this.buttonDelete, this.picIconDelete);
            

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelCustomerForm);

            textBoxDocumentNumber.MaxLength = 8;
            textBoxTaxCode.MaxLength = 13;

            this.textBoxTaxCode.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(textBoxTaxCode);

            this.textBoxDocumentNumber.KeyPress += (s, e) => {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            this.dataGridViewCustomers.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dataGridViewCustomers, e);

            this.Load += async (s, e) => await InitializeCustomersFormAsync();
            this.buttonSave.Click += async (s, e) => await ExecuteSaveCustomerAsync();
            this.buttonEdit.Click += async (s, e) => await ExecuteEditCustomerAsync();
            this.buttonDelete.Click += async (s, e) => await ExecuteDeleteCustomerAsync();
            this.buttonExportPdf.Click += async (s, e) => await ExecuteExportCustomersReportToPdfAsync();
        }

        private async Task InitializeCustomersFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var taxConditionsList = (await _lookupService.GetTaxConditionsAsync()).ToList();
                comboBoxTaxCondition.DataSource = taxConditionsList;
                comboBoxTaxCondition.DisplayMember = "Name";
                comboBoxTaxCondition.ValueMember = "Id";
                comboBoxTaxCondition.SelectedIndex = -1;

                await RefreshCustomersGridAsync();
                UIHelper.AttachManagedSelection(this, dataGridViewCustomers, SynchronizeSelectedCustomerToFormFields, ResetFormInputFields);
            }
        }

        private async Task RefreshCustomersGridAsync()
        {
            var activeCustomers = await _customerService.GetAllActiveAsync();
            dataGridViewCustomers.DataSource = null;
            dataGridViewCustomers.DataSource = activeCustomers.ToList();
            DataGridViewHelper.ApplyStyle(dataGridViewCustomers);
        }
        /// <summary>
        /// Sincroniza la entidad SelectedCustomerToFormFields seleccionada con los campos de entrada de la interfaz.
        /// </summary>

        private void SynchronizeSelectedCustomerToFormFields()
        {
            if (dataGridViewCustomers.CurrentRow == null)
                return;

            var customer = (CustomerDto)dataGridViewCustomers.CurrentRow.DataBoundItem;
            _selectedCustomerIdentifier = customer.Id;
            textBoxDocumentNumber.Text = customer.DocumentNumber;
            textBoxTaxCode.Text = customer.Cuil;
            textBoxFirstName.Text = customer.FirstName;
            textBoxLastName.Text = customer.LastName;
            textBoxEmail.Text = customer.Email;
            textBoxPhone.Text = customer.Phone;
            textBoxAddress.Text = customer.Address;
            textBoxCity.Text = customer.City;
            comboBoxTaxCondition.SelectedValue = customer.TaxConditionId ?? -1;

            UpdateButtonStates(true);
            textBoxDocumentNumber.ReadOnly = true;
            textBoxTaxCode.ReadOnly = true;
        }

        private void ResetFormInputFields()
        {
            _selectedCustomerIdentifier = 0;

            UIHelper.CleanControls(panelCustomerForm);
            comboBoxTaxCondition.SelectedIndex = -1;

            UpdateButtonStates(isEditing: false);
            textBoxDocumentNumber.ReadOnly = false;
            textBoxTaxCode.ReadOnly = false;
        }

        private void UpdateButtonStates(bool isEditing)
        {
            buttonSave.Enabled = !isEditing;
            buttonEdit.Enabled = isEditing;
            buttonDelete.Enabled = isEditing;
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SaveCustomer.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSaveCustomerAsync() => await ProcessSaveOrUpdateCustomerAsync(0);
        /// <summary>
        /// Ejecuta de manera asincrona la accion de EditCustomer.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>
        private async Task ExecuteEditCustomerAsync() => await ProcessSaveOrUpdateCustomerAsync(_selectedCustomerIdentifier);

        private async Task ProcessSaveOrUpdateCustomerAsync(int id)
        {
            var customer = new CustomerDto
            {
                Id = id,
                DocumentNumber = textBoxDocumentNumber.Text.Trim(),
                Cuil = textBoxTaxCode.Text.Trim(),
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                Phone = textBoxPhone.Text.Trim(),
                Address = textBoxAddress.Text.Trim(),
                City = textBoxCity.Text.Trim(),
                TaxConditionId = comboBoxTaxCondition.SelectedValue is int tId && tId > 0 ? tId : null,
                IsActive = true
            };

            var result = await _customerService.RegisterCustomerAsync(customer);
            UIHelper.ShowResult(result, "Clientes", async () =>
            {
                await RefreshCustomersGridAsync();
                ResetFormInputFields();
            });
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de DeleteCustomer.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteDeleteCustomerAsync()
        {
            if (_selectedCustomerIdentifier == 0)
                return;

            if (UIHelper.ConfirmMessage("¿Desea eliminar a este cliente del sistema?"))
            {
                var result = await _customerService.DeleteCustomerAsync(_selectedCustomerIdentifier);
                UIHelper.ShowResult(result, "Gestión de Clientes", async () =>
                {
                    await RefreshCustomersGridAsync();
                    ResetFormInputFields();
                });
            }
        }

        public async Task ExecuteExportCustomersReportToPdfAsync()
        {
            if (dataGridViewCustomers.DataSource is not List<CustomerDto> customersReportList || !customersReportList.Any())
            {
                MessageBox.Show("No hay clientes disponibles para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] customersReportPdfBytes = await _documentService.GenerateCustomersReportAsync(customersReportList);
                await FileExportHelper.SaveAndOpenPdfAsync(this, customersReportPdfBytes, "Clientes.pdf");
            }
        }
    }
}










