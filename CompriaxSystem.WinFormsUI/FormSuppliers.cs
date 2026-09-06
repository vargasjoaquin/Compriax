using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormSuppliers : Form
    {
        private readonly ISupplyChainService _supplyChainService;
        private readonly IDocumentService _documentService;
        private int _selectedSupplierId = 0;
        private bool _isFormattingCuit = false;

        public FormSuppliers(ISupplyChainService supplyChainService, IDocumentService documentService)
        {
            _supplyChainService = supplyChainService;
            _documentService = documentService;
            InitializeComponent();

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnSave.Click += async (s, e) => await ExecuteSaveAction();
            this.btnEdit.Click += async (s, e) => await ExecuteEditAction();
            this.btnDelete.Click += async (s, e) => await ExecuteDeleteAction();
            this.btnExportPdf.Click += async (s, e) => await ExecuteExportPdfAction();

            this.txtTaxId.TextChanged += OnCuitTextChanged;
            this.dgvSuppliers.CellFormatting += DgvSuppliers_CellFormatting;
        }

        public async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                await RefreshGridAsync();
                UIHelper.AttachManagedSelection(this, dgvSuppliers, SyncEntityToFields, ResetUI);
            }
        }

        private async Task RefreshGridAsync()
        {
            var suppliers = await _supplyChainService.GetSuppliersAsync();
            dgvSuppliers.DataSource = null;
            dgvSuppliers.DataSource = suppliers.ToList();
            UIHelper.FormatGrid(dgvSuppliers);
        }

        private void OnCuitTextChanged(object? sender, EventArgs e)
        {
            if (_isFormattingCuit) 
                return;

            string raw = new string(txtTaxId.Text.Where(char.IsDigit).ToArray());
            
            if (raw.Length > 11) 
                raw = raw.Substring(0, 11);

            string formatted = raw;
            
            if (raw.Length > 2 && raw.Length <= 10)
                formatted = raw.Insert(2, "-");
            else if (raw.Length > 10)
                formatted = raw.Insert(2, "-").Insert(11, "-");

            _isFormattingCuit = true;

            int selectionStart = txtTaxId.SelectionStart;
            int oldLength = txtTaxId.Text.Length;
            
            txtTaxId.Text = formatted;
            
            if (txtTaxId.Text.Length > oldLength)
                selectionStart++;
            
            txtTaxId.SelectionStart = Math.Max(0, Math.Min(selectionStart, txtTaxId.Text.Length));
            _isFormattingCuit = false;
        }

        private void DgvSuppliers_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSuppliers.Rows[e.RowIndex].DataBoundItem is SupplierDto dto)
            {
                if (!dto.IsActive)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                }
            }
        }

        private void SyncEntityToFields()
        {
            if (dgvSuppliers.CurrentRow == null)
                return;

            var dto = (SupplierDto)dgvSuppliers.CurrentRow.DataBoundItem;

            _selectedSupplierId = dto.Id;
            txtTaxId.Text = dto.CUIT;
            txtCompanyName.Text = dto.CompanyName;
            txtContact.Text = dto.ContactName;
            txtEmail.Text = dto.Email;
            txtPhone.Text = dto.Phone;
            txtAddress.Text = dto.Address;

            SetButtonState(isEditing: true);
            txtTaxId.ReadOnly = true;
        }

        private async Task ExecuteSaveAction()
        {
            var dto = MapFieldsToDto(0);
            var result = await _supplyChainService.UpsertSupplierAsync(dto);

            UIHelper.ShowResult(result, "Gestión de Proveedores", async () =>
            {
                await RefreshGridAsync();
                ResetUI();
            });
        }

        private async Task ExecuteEditAction()
        {
            if (_selectedSupplierId == 0)
                return;

            var dto = MapFieldsToDto(_selectedSupplierId);
            var result = await _supplyChainService.UpsertSupplierAsync(dto);

            UIHelper.ShowResult(result, "Gestión de Proveedores", async () =>
            {
                await RefreshGridAsync();
                ResetUI();
            });
        }

        private async Task ExecuteDeleteAction()
        {
            if (_selectedSupplierId == 0)
                return;

            if (UIHelper.ConfirmMessage("¿Desea eliminar este proveedor?"))
            {
                var result = await _supplyChainService.DeleteSupplierAsync(_selectedSupplierId);
                UIHelper.ShowResult(result, "Gestión de Proveedores", async () =>
                {
                    await RefreshGridAsync();
                    ResetUI();
                });
            }
        }

        private void ResetUI()
        {
            _selectedSupplierId = 0;
            UIHelper.CleanControls(groupBoxData);
            SetButtonState(isEditing: false);
            txtTaxId.ReadOnly = false;
        }

        private void SetButtonState(bool isEditing)
        {
            btnSave.Enabled = !isEditing;
            btnEdit.Enabled = isEditing;
            btnDelete.Enabled = isEditing;
        }

        private SupplierDto MapFieldsToDto(int id)
        {
            return new SupplierDto
            {
                Id = id,
                CUIT = txtTaxId.Text.Trim(),
                CompanyName = txtCompanyName.Text.Trim(),
                ContactName = txtContact.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                IsActive = true
            };
        }

        public async Task ExecuteExportPdfAction()
        {
            if (dgvSuppliers.DataSource is not List<SupplierDto> suppliers || !suppliers.Any())
            {
                MessageBox.Show("No hay proveedores disponibles para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] pdfBytes = await _documentService.GenerateSuppliersReportAsync(suppliers);
                string fileName = $"Reporte_Proveedores_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                await FileExportHelper.SaveAndOpenPdfAsync(this, pdfBytes, fileName, "Exportar Reporte de Proveedores");
            }
        }
    }
}
