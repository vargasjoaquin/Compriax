using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormEmployees : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILookupService _lookupService;
        private int _selectedEmployeeId = 0;
        private byte[]? _imageBuffer = null;

        public FormEmployees(IEmployeeService employeeService, ILookupService lookupService)
        {
            _employeeService = employeeService;
            _lookupService = lookupService;

            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(gbData);

            this.txtCuil.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(txtCuil);
            this.dgvEmployees.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dgvEmployees, e);

            txtDni.MaxLength = 8;
            txtCuil.MaxLength = 13;

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnSave.Click += async (s, e) => await ExecuteSaveAction();
            this.btnEdit.Click += async (s, e) => await ExecuteEditAction();
            this.btnDelete.Click += async (s, e) => await ExecuteDeleteAction();
            this.btnExportPdf.Click += async (s, e) => await ExecuteExportPdfAction();
            this.btnBrowse.Click += (s, e) => HandlePhotoSelection();
        }

        private async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var positions = (await _lookupService.GetPositionsAsync()).ToList();
                cboPosition.DataSource = positions;
                cboPosition.DisplayMember = "Name";
                cboPosition.ValueMember = "Id";
                cboPosition.SelectedIndex = -1;

                var genders = (await _lookupService.GetGendersAsync()).ToList();
                cboGender.DataSource = genders;
                cboGender.DisplayMember = "Name";
                cboGender.ValueMember = "Id";
                cboGender.SelectedIndex = -1;

                var civilStatuses = (await _lookupService.GetCivilStatusesAsync()).ToList();
                cboCivilStatus.DataSource = civilStatuses;
                cboCivilStatus.DisplayMember = "Name";
                cboCivilStatus.ValueMember = "Id";
                cboCivilStatus.SelectedIndex = -1;

                await RefreshGridAsync();
                UIHelper.AttachManagedSelection(this, dgvEmployees, SyncEntityToFields, ResetUI);
            }
        }

        private async Task RefreshGridAsync()
        {
            var data = await _employeeService.GetEmployeesAsync();
            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = data.ToList();
            
            DataGridViewHelper.ApplyStyle(dgvEmployees);
        }

        private void SyncEntityToFields()
        {
            if (dgvEmployees.CurrentRow == null) 
                return;
            
            var emp = (EmployeeDto)dgvEmployees.CurrentRow.DataBoundItem;

            _selectedEmployeeId = emp.Id;
            txtCode.Text = emp.EmployeeCode;
            txtDni.Text = emp.DocumentNumber;
            txtCuil.Text = emp.Cuil;
            txtFirstName.Text = emp.FirstName;
            txtLastName.Text = emp.LastName;
            txtEmail.Text = emp.Email;
            txtPhone.Text = emp.Phone;
            txtAddress.Text = emp.Address;

            cboPosition.SelectedValue = emp.PositionId ?? -1;
            cboGender.SelectedValue = emp.GenderId ?? -1;
            cboCivilStatus.SelectedValue = emp.CivilStatusId ?? -1;
            numChildren.Value = emp.ChildrenCount;

            picPhoto.Image?.Dispose();
            picPhoto.Image = ImageHelper.LoadFromBytes(emp.Photo);
            _imageBuffer = emp.Photo;

            SetButtonState(true);
            
            txtCode.ReadOnly = true;
            txtDni.ReadOnly = true;
            txtCuil.ReadOnly = true;
        }

        private void ResetUI()
        {
            _selectedEmployeeId = 0;
            _imageBuffer = null;

            
            UIHelper.CleanControls(gbData);
            cboPosition.SelectedIndex = -1;
            cboGender.SelectedIndex = -1;
            cboCivilStatus.SelectedIndex = -1;
            numChildren.Value = 0;
            
            picPhoto.Image?.Dispose();
            picPhoto.Image = null;

            SetButtonState(false);
            
            txtCode.ReadOnly = false;
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
        private async Task ExecuteEditAction()
        {
            if (_selectedEmployeeId == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un empleado de la lista para poder editarlo.", "Selección Requerida");
                return;
            }

            await ProcessAction(_selectedEmployeeId);
        }

        private async Task ProcessAction(int id)
        {
            var dto = new EmployeeDto
            {
                Id = id,
                EmployeeCode = txtCode.Text.Trim(),
                DocumentNumber = txtDni.Text.Trim(),
                Cuil = txtCuil.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                PositionId = cboPosition.SelectedValue as int? ?? 0,
                GenderId = cboGender.SelectedValue as int? ?? 0,
                CivilStatusId = cboCivilStatus.SelectedValue as int? ?? 0,
                ChildrenCount = (int)numChildren.Value,
                Photo = _imageBuffer,
                IsActive = true
            };

            var result = await _employeeService.UpsertEmployeeAsync(dto);
            UIHelper.ShowResult(result, "Gestión de Personal", async () =>
            {
                await RefreshGridAsync();
                ResetUI();
            });
        }

        private void HandlePhotoSelection()
        {
            if (ImageHelper.SelectImage(out byte[]? imageBytes, out Image? displayImage, out string? errorMessage))
            {
                picPhoto.Image?.Dispose();
                _imageBuffer = imageBytes;
                picPhoto.Image = displayImage;
            }
            else if (!string.IsNullOrEmpty(errorMessage))
            {
                UIHelper.WarnMessage(this, errorMessage, "Imagen");
            }
        }

        private async Task ExecuteDeleteAction()
        {
            if (_selectedEmployeeId == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un empleado de la lista para eliminarlo.", "Selección Requerida");
                return;
            }

            if (UIHelper.ConfirmMessage("¿Desactivar este registro de personal?"))
            {
                var result = await _employeeService.DeleteEmployeeAsync(_selectedEmployeeId);
                UIHelper.ShowResult(result, "Personal", async () =>
                {
                    await RefreshGridAsync();
                    ResetUI(); 
                });
            }
        }

        public async Task ExecuteExportPdfAction()
        {
            if (dgvEmployees.DataSource is not List<EmployeeDto> employees || !employees.Any())
            {
                UIHelper.WarnMessage(this, "No hay empleados registrados para exportar a PDF.", "Sin Registros");
                return;
            }

            // Exportación utilizando FileExportHelper
            using (new WaitCursorHelper(this))
            {
                string fileName = $"Nomina_Empleados_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                UIHelper.InfoMessage(this, "Generando reporte de nómina de personal...", "Exportar Personal");
            }
        }
    }
}