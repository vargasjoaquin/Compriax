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
        private int _selectedCustomerId = 0;

        public FormCustomers(ICustomerService customerService, ILookupService lookupService, IDocumentService documentService)
        {
            _customerService = customerService;
            _lookupService = lookupService;
            _documentService = documentService;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(groupBox1);
            ApplyIcons();

            txtDni.MaxLength = 8;
            txtCuil.MaxLength = 13;

            this.txtCuil.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(txtCuil);

            this.txtDni.KeyPress += (s, e) => {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            this.dgvCustomers.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dgvCustomers, e);

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnSave.Click += async (s, e) => await ExecuteSaveAction();
            this.btnEdit.Click += async (s, e) => await ExecuteEditAction();
            this.btnDelete.Click += async (s, e) => await ExecuteDeleteAction();
            this.btnExportPdf.Click += async (s, e) => await ExecuteExportPdfAction();
        }

        private void ApplyIcons()
        {
            btnSave.Image = UIIconHelper.Guardar;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnEdit.Image = UIIconHelper.Editar;
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnDelete.Image = UIIconHelper.Eliminar;
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnExportPdf.Image = UIIconHelper.ExportarPdf;
            btnExportPdf.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportPdf.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        private async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var taxConditions = (await _lookupService.GetTaxConditionsAsync()).ToList();
                cboTaxCondition.DataSource = taxConditions;
                cboTaxCondition.DisplayMember = "Name";
                cboTaxCondition.ValueMember = "Id";
                cboTaxCondition.SelectedIndex = -1;

                await RefreshGridAsync();
                UIHelper.AttachManagedSelection(this, dgvCustomers, SyncEntityToFields, ResetUI);
            }
        }

        private async Task RefreshGridAsync()
        {
            var data = await _customerService.GetAllActiveAsync();
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = data.ToList();
            DataGridViewHelper.ApplyStyle(dgvCustomers);
        }

        private void SyncEntityToFields()
        {
            if (dgvCustomers.CurrentRow == null)
                return;

            var dto = (CustomerDto)dgvCustomers.CurrentRow.DataBoundItem;
            _selectedCustomerId = dto.Id;
            txtDni.Text = dto.DocumentNumber;
            txtCuil.Text = dto.Cuil;
            txtName.Text = dto.FirstName;
            txtLastName.Text = dto.LastName;
            txtEmail.Text = dto.Email;
            txtPhone.Text = dto.Phone;
            txtAddress.Text = dto.Address;
            txtCity.Text = dto.City;
            cboTaxCondition.SelectedValue = dto.TaxConditionId ?? -1;

            SetButtonState(true);
            txtDni.ReadOnly = true;
            txtCuil.ReadOnly = true;
        }

        private void ResetUI()
        {
            _selectedCustomerId = 0;

            UIHelper.CleanControls(groupBox1);
            cboTaxCondition.SelectedIndex = -1;

            SetButtonState(isEditing: false);
            txtDni.ReadOnly = false;
            txtCuil.ReadOnly = false;
        }

        private void SetButtonState(bool isEditing)
        {
            btnSave.Enabled = !isEditing;
            btnEdit.Enabled = isEditing;
            btnDelete.Enabled = isEditing;
        }

        private async Task ExecuteSaveAction() => await ProcessAction(0);
        private async Task ExecuteEditAction() => await ProcessAction(_selectedCustomerId);

        private async Task ProcessAction(int id)
        {
            var dto = new CustomerDto
            {
                Id = id,
                DocumentNumber = txtDni.Text.Trim(),
                Cuil = txtCuil.Text.Trim(),
                FirstName = txtName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                City = txtCity.Text.Trim(),
                TaxConditionId = cboTaxCondition.SelectedValue is int tId && tId > 0 ? tId : null,
                IsActive = true
            };

            var result = await _customerService.RegisterCustomerAsync(dto);
            UIHelper.ShowResult(result, "Clientes", async () =>
            {
                await RefreshGridAsync();
                ResetUI();
            });
        }

        private async Task ExecuteDeleteAction()
        {
            if (_selectedCustomerId == 0)
                return;

            if (UIHelper.ConfirmMessage("¿Desea eliminar a este cliente del sistema?"))
            {
                var result = await _customerService.DeleteCustomerAsync(_selectedCustomerId);
                UIHelper.ShowResult(result, "Gestión de Clientes", async () =>
                {
                    await RefreshGridAsync();
                    ResetUI();
                });
            }
        }

        public async Task ExecuteExportPdfAction()
        {
            if (dgvCustomers.DataSource is not List<CustomerDto> customers || !customers.Any())
            {
                MessageBox.Show("No hay clientes disponibles para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] pdfBytes = await _documentService.GenerateCustomersReportAsync(customers);
                await FileExportHelper.SaveAndOpenPdfAsync(this, pdfBytes, "Clientes.pdf");
            }
        }
    }
}