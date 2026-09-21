using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormEmployees : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILookupService _lookupService;
        private int _selectedEmployeeIdentifier = 0;
        private byte[]? _employeePhotoBuffer = null;

        public FormEmployees(IEmployeeService employeeService, ILookupService lookupService)
        {
            _employeeService = employeeService;
            _lookupService = lookupService;

            InitializeComponent();
            
            ButtonIconOverlayHelper.BindEvents(this.buttonExportPdf, this.picIconExportPdf);
            ButtonIconOverlayHelper.BindEvents(this.buttonBrowsePhoto, this.picIconBrowsePhoto);
            ButtonIconOverlayHelper.BindEvents(this.buttonSave, this.picIconSave);
            ButtonIconOverlayHelper.BindEvents(this.buttonEdit, this.picIconEdit);
            ButtonIconOverlayHelper.BindEvents(this.buttonDelete, this.picIconDelete);
            

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelEmployeeForm);

            this.textBoxTaxCode.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(textBoxTaxCode);
            this.dataGridViewEmployees.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dataGridViewEmployees, e);

            textBoxDocumentNumber.MaxLength = 8;
            textBoxTaxCode.MaxLength = 13;

            this.Load += async (s, e) => await InitializeEmployeesFormAsync();
            this.buttonSave.Click += async (s, e) => await ExecuteSaveEmployeeAsync();
            this.buttonEdit.Click += async (s, e) => await ExecuteEditEmployeeAsync();
            this.buttonDelete.Click += async (s, e) => await ExecuteDeactivateEmployeeAsync();
            this.buttonExportPdf.Click += async (s, e) => await ExecuteExportEmployeesReportToPdfAsync();
            this.buttonBrowsePhoto.Click += (s, e) => HandleEmployeePhotoSelection();
        }

        private async Task InitializeEmployeesFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var positionsList = (await _lookupService.GetPositionsAsync()).ToList();
                comboBoxPosition.DataSource = positionsList;
                comboBoxPosition.DisplayMember = "Name";
                comboBoxPosition.ValueMember = "Id";
                comboBoxPosition.SelectedIndex = -1;

                var gendersList = (await _lookupService.GetGendersAsync()).ToList();
                comboBoxGender.DataSource = gendersList;
                comboBoxGender.DisplayMember = "Name";
                comboBoxGender.ValueMember = "Id";
                comboBoxGender.SelectedIndex = -1;

                var civilStatusesList = (await _lookupService.GetCivilStatusesAsync()).ToList();
                comboBoxCivilStatus.DataSource = civilStatusesList;
                comboBoxCivilStatus.DisplayMember = "Name";
                comboBoxCivilStatus.ValueMember = "Id";
                comboBoxCivilStatus.SelectedIndex = -1;

                await RefreshEmployeesGridAsync();
                UIHelper.AttachManagedSelection(this, dataGridViewEmployees, SynchronizeSelectedEmployeeToFormFields, ResetFormInputFields);
            }
        }

        private async Task RefreshEmployeesGridAsync()
        {
            var employeesList = await _employeeService.GetEmployeesAsync();
            dataGridViewEmployees.DataSource = null;
            dataGridViewEmployees.DataSource = employeesList.ToList();
            
            DataGridViewHelper.ApplyStyle(dataGridViewEmployees);
        }
        /// <summary>
        /// Sincroniza la entidad SelectedEmployeeToFormFields seleccionada con los campos de entrada de la interfaz.
        /// </summary>

        private void SynchronizeSelectedEmployeeToFormFields()
        {
            if (dataGridViewEmployees.CurrentRow == null) 
                return;
            
            var selectedEmployee = (EmployeeDto)dataGridViewEmployees.CurrentRow.DataBoundItem;

            _selectedEmployeeIdentifier = selectedEmployee.Id;
            textBoxEmployeeCode.Text = selectedEmployee.EmployeeCode;
            textBoxDocumentNumber.Text = selectedEmployee.DocumentNumber;
            textBoxTaxCode.Text = selectedEmployee.Cuil;
            textBoxFirstName.Text = selectedEmployee.FirstName;
            textBoxLastName.Text = selectedEmployee.LastName;
            textBoxEmail.Text = selectedEmployee.Email;
            textBoxPhone.Text = selectedEmployee.Phone;
            textBoxAddress.Text = selectedEmployee.Address;

            comboBoxPosition.SelectedValue = selectedEmployee.PositionId ?? -1;
            comboBoxGender.SelectedValue = selectedEmployee.GenderId ?? -1;
            comboBoxCivilStatus.SelectedValue = selectedEmployee.CivilStatusId ?? -1;
            numericUpDownChildrenCount.Value = selectedEmployee.ChildrenCount;

            pictureBoxPhoto.Image?.Dispose();
            pictureBoxPhoto.Image = ImageHelper.LoadFromBytes(selectedEmployee.Photo);
            _employeePhotoBuffer = selectedEmployee.Photo;

            UpdateButtonStates(true);
            
            textBoxEmployeeCode.ReadOnly = true;
            textBoxDocumentNumber.ReadOnly = true;
            textBoxTaxCode.ReadOnly = true;
        }

        private void ResetFormInputFields()
        {
            _selectedEmployeeIdentifier = 0;
            _employeePhotoBuffer = null;

            
            UIHelper.CleanControls(panelEmployeeForm);
            comboBoxPosition.SelectedIndex = -1;
            comboBoxGender.SelectedIndex = -1;
            comboBoxCivilStatus.SelectedIndex = -1;
            numericUpDownChildrenCount.Value = 0;
            
            pictureBoxPhoto.Image?.Dispose();
            pictureBoxPhoto.Image = null;

            UpdateButtonStates(false);
            
            textBoxEmployeeCode.ReadOnly = false;
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
        /// Ejecuta de manera asincrona la accion de SaveEmployee.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSaveEmployeeAsync() => await ProcessSaveOrUpdateEmployeeAsync(0);
        /// <summary>
        /// Ejecuta de manera asincrona la accion de EditEmployee.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>
        private async Task ExecuteEditEmployeeAsync()
        {
            if (_selectedEmployeeIdentifier == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un empleado de la lista para poder editarlo.", "Selección Requerida");
                return;
            }

            await ProcessSaveOrUpdateEmployeeAsync(_selectedEmployeeIdentifier);
        }

        private async Task ProcessSaveOrUpdateEmployeeAsync(int id)
        {
            var employee = new EmployeeDto
            {
                Id = id,
                EmployeeCode = textBoxEmployeeCode.Text.Trim(),
                DocumentNumber = textBoxDocumentNumber.Text.Trim(),
                Cuil = textBoxTaxCode.Text.Trim(),
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                Phone = textBoxPhone.Text.Trim(),
                Address = textBoxAddress.Text.Trim(),
                PositionId = comboBoxPosition.SelectedValue as int? ?? 0,
                GenderId = comboBoxGender.SelectedValue as int? ?? 0,
                CivilStatusId = comboBoxCivilStatus.SelectedValue as int? ?? 0,
                ChildrenCount = (int)numericUpDownChildrenCount.Value,
                Photo = _employeePhotoBuffer,
                IsActive = true
            };

            var result = await _employeeService.UpsertEmployeeAsync(employee);
            UIHelper.ShowResult(result, "Gestión de Personal", async () =>
            {
                await RefreshEmployeesGridAsync();
                ResetFormInputFields();
            });
        }

        private void HandleEmployeePhotoSelection()
        {
            if (ImageHelper.SelectImage(out byte[]? selectedPhotoBytes, out Image? selectedDisplayBitmap, out string? photoErrorMessage))
            {
                pictureBoxPhoto.Image?.Dispose();
                _employeePhotoBuffer = selectedPhotoBytes;
                pictureBoxPhoto.Image = selectedDisplayBitmap;
            }
            else if (!string.IsNullOrEmpty(photoErrorMessage))
            {
                UIHelper.WarnMessage(this, photoErrorMessage, "Imagen");
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de DeactivateEmployee.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteDeactivateEmployeeAsync()
        {
            if (_selectedEmployeeIdentifier == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un empleado de la lista para eliminarlo.", "Selección Requerida");
                return;
            }

            if (UIHelper.ConfirmMessage("¿Desactivar este registro de personal?"))
            {
                var result = await _employeeService.DeleteEmployeeAsync(_selectedEmployeeIdentifier);
                UIHelper.ShowResult(result, "Personal", async () =>
                {
                    await RefreshEmployeesGridAsync();
                    ResetFormInputFields(); 
                });
            }
        }

        public async Task ExecuteExportEmployeesReportToPdfAsync()
        {
            if (dataGridViewEmployees.DataSource is not List<EmployeeDto> employeesReportList || !employeesReportList.Any())
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










