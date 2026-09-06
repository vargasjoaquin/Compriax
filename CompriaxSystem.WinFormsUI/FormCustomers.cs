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
        private bool _isFormattingCuit = false;

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

            this.txtCuil.TextChanged += OnCuitTextChanged;
            this.txtDni.KeyPress += OnOnlyNumbersKeyPress;
            this.dgvCustomers.CellFormatting += DgvCustomers_CellFormatting;
        }

        private async Task InitializeFormAsync()
        {
            txtDni.MaxLength = 8;
            txtCuil.MaxLength = 13;

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

        private void DgvCustomers_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCustomers.Rows[e.RowIndex].DataBoundItem is CustomerDto dto)
            {
                if (!dto.IsActive)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                }
            }
        }

        private void OnOnlyNumbersKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void OnCuitTextChanged(object? sender, EventArgs e)
        {
            if (_isFormattingCuit) 
                return;

            string raw = new string(txtCuil.Text.Where(char.IsDigit).ToArray());
            
            if (raw.Length > 11) 
                raw = raw.Substring(0, 11);

            string formatted = raw;

            if (raw.Length > 2 && raw.Length <= 10)
                formatted = raw.Insert(2, "-");
            else if (raw.Length > 10)
                formatted = raw.Insert(2, "-").Insert(11, "-");

            _isFormattingCuit = true;
            int selectionStart = txtCuil.SelectionStart;
            int oldLength = txtCuil.Text.Length;

            txtCuil.Text = formatted;

            // Ajustar posición del cursor
            if (txtCuil.Text.Length > oldLength)
                selectionStart++;
            
            txtCuil.SelectionStart = Math.Max(0, Math.Min(selectionStart, txtCuil.Text.Length));

            _isFormattingCuit = false;
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