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

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnSave.Click += async (s, e) => await ExecuteSaveAction();
            this.btnEdit.Click += async (s, e) => await ExecuteEditAction();
            this.btnDelete.Click += async (s, e) => await ExecuteDeleteAction();
            this.btnExportPdf.Click += async (s, e) => await ExecuteExportPdfAction();
            //this.btnCerrar.Click += (s, e) => this.Close();
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
            UIHelper.FormatGrid(dgvCustomers);
        }

        private void SyncEntityToFields()
        {
            if (dgvCustomers.CurrentRow == null)
                return;

            var dto = (CustomerDto)dgvCustomers.CurrentRow.DataBoundItem;

            _selectedCustomerId = dto.Id;
            txtDni.Text = dto.DocumentNumber;
            txtCuil.Text = dto.Cuil ?? string.Empty;
            txtName.Text = dto.FirstName;
            txtLastName.Text = dto.LastName;
            txtEmail.Text = dto.Email ?? string.Empty;
            txtPhone.Text = dto.Phone ?? string.Empty;
            txtAddress.Text = dto.Address ?? string.Empty;
            txtCity.Text = dto.City ?? string.Empty;

            cboTaxCondition.SelectedValue = dto.TaxConditionId.HasValue ? dto.TaxConditionId.Value : -1;

            SetButtonState(isEditing: true);
            txtDni.ReadOnly = true;
        }

        private void ResetUI()
        {
            _selectedCustomerId = 0;
            UIHelper.CleanControls(groupBox1);
            cboTaxCondition.SelectedIndex = -1;

            SetButtonState(isEditing: false);
            txtDni.ReadOnly = false;
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
            // Normalización de cadenas vacías a null para campos opcionales
            string? cuil = string.IsNullOrWhiteSpace(txtCuil.Text) ? null : txtCuil.Text.Trim();
            string? email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
            string? phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim();
            string? address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim();
            string? city = string.IsNullOrWhiteSpace(txtCity.Text) ? null : txtCity.Text.Trim();

            int? taxConditionId = cboTaxCondition.SelectedValue is int tId && tId > 0 ? tId : null;

            var dto = new CustomerDto
            {
                Id = id,
                DocumentNumber = txtDni.Text.Trim(),
                Cuil = cuil,
                FirstName = txtName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = email,
                Phone = phone,
                Address = address,
                City = city,
                TaxConditionId = taxConditionId,
                IsActive = true
            };

            var result = await _customerService.RegisterCustomerAsync(dto);
            UIHelper.ShowResult(result, "Gestión de Clientes", async () =>
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
                string fileName = $"Reporte_Clientes_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                await FileExportHelper.SaveAndOpenPdfAsync(this, pdfBytes, fileName, "Exportar Reporte de Clientes");
            }
        }
    }
}
