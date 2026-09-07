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

        public FormSuppliers(ISupplyChainService supplyChainService, IDocumentService documentService)
        {
            _supplyChainService = supplyChainService;
            _documentService = documentService;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(groupBoxData);

            this.txtTaxId.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(txtTaxId);
            this.dgvSuppliers.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dgvSuppliers, e);

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnSave.Click += async (s, e) => await ExecuteSaveAction();
            this.btnEdit.Click += async (s, e) => await ExecuteEditAction();
            this.btnDelete.Click += async (s, e) => await ExecuteDeleteAction();
            this.btnExportPdf.Click += async (s, e) => await ExecuteExportPdfAction();
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