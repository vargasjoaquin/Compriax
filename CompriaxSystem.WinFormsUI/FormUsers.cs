using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormUsers : Form
    {
        private readonly IUserService _userService;
        private readonly IDocumentService _documentService;
        private readonly IPasswordHasher _passwordHasher;
        private int _selectedUserIdentifier = 0;
        private byte[]? _userPhotoBuffer = null;
        private bool _isPasswordVisible = false;

        public FormUsers(IUserService userService, IDocumentService documentService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _documentService = documentService;
            _passwordHasher = passwordHasher;
            InitializeComponent();
            
            ButtonIconOverlayHelper.BindEvents(this.buttonExportPdf, this.picIconExportPdf);
            ButtonIconOverlayHelper.BindEvents(this.buttonBrowsePhoto, this.picIconBrowsePhoto);
            //ButtonIconOverlayHelper.BindEvents(this.buttonClearPhoto, this.picIconClearPhoto);
            ButtonIconOverlayHelper.BindEvents(this.buttonSave, this.picIconSave);
            ButtonIconOverlayHelper.BindEvents(this.buttonEdit, this.picIconEdit);
            ButtonIconOverlayHelper.BindEvents(this.buttonDelete, this.picIconDelete);
            

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelUserForm);

            this.dataGridViewUsers.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dataGridViewUsers, e);

            this.Load += async (s, e) => await InitializeUsersManagementFormAsync();
            this.buttonSave.Click += async (s, e) => await ExecuteSaveUserAsync();
            this.buttonEdit.Click += async (s, e) => await ExecuteUpdateUserAsync();
            this.buttonDelete.Click += async (s, e) => await ExecuteToggleUserActiveStatusAsync();
            this.buttonExportPdf.Click += async (s, e) => await ExecuteExportUsersReportToPdfAsync();
            this.buttonBrowsePhoto.Click += (s, e) => HandleUserPhotoSelection();
            this.buttonClearPhoto.Click += (s, e) => HandleUserPhotoRemoval();
            this.buttonTogglePasswordVisibility.Click += (s, e) => TogglePasswordVisibilityChar();
        }
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializeUsersManagementFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                comboBoxRole.DataSource = (await _userService.GetRolesAsync()).ToList();
                comboBoxRole.DisplayMember = "Name";
                comboBoxRole.ValueMember = "Id";

                await RefreshUsersGridAsync();
                UIHelper.AttachManagedSelection(this, dataGridViewUsers, SynchronizeSelectedUserToFormFields, ResetFormInputFields);
                ResetFormInputFields();
            }
        }

        private async Task RefreshUsersGridAsync()
        {
            var usersList = await _userService.GetUserListAsync();
            dataGridViewUsers.DataSource = null;
            dataGridViewUsers.DataSource = usersList.ToList();
            DataGridViewHelper.ApplyStyle(dataGridViewUsers);
        }
        /// <summary>
        /// Sincroniza la entidad SelectedUserToFormFields seleccionada con los campos de entrada de la interfaz.
        /// </summary>

        private void SynchronizeSelectedUserToFormFields()
        {
            if (dataGridViewUsers.CurrentRow == null)
                return;

            var selectedUser = (UserDto)dataGridViewUsers.CurrentRow.DataBoundItem;

            _selectedUserIdentifier = selectedUser.Id;
            textBoxUsername.Text = selectedUser.Username;
            textBoxFirstName.Text = selectedUser.FirstName;
            textBoxLastName.Text = selectedUser.LastName;
            textBoxEmail.Text = selectedUser.Email;
            comboBoxRole.SelectedValue = selectedUser.RoleId;

            if (selectedUser is UserCreateDto user)
                textBoxPassword.Text = user.Password;

            _userPhotoBuffer = selectedUser.Photo;
            ImageHelper.Clear(pictureBoxUserPhoto);
            pictureBoxUserPhoto.Image = ImageHelper.LoadFromBytes(selectedUser.Photo);

            UpdateButtonStates(isEditing: true);
            textBoxUsername.ReadOnly = true;

            bool isAdmin = selectedUser.Username.Equals(RoleConstants.DEFAULT_ADMIN_USERNAME, StringComparison.OrdinalIgnoreCase) ||
                           selectedUser.RoleName.Equals(RoleConstants.ADMINISTRATOR, StringComparison.OrdinalIgnoreCase);
            buttonDelete.Enabled = !isAdmin;
            comboBoxRole.Enabled = !isAdmin;
        }

        private void ResetFormInputFields()
        {
            _selectedUserIdentifier = 0;
            _userPhotoBuffer = null;
            ImageHelper.Clear(pictureBoxUserPhoto);

            UIHelper.CleanControls(panelUserForm);

            comboBoxRole.SelectedIndex = -1;
            comboBoxRole.Enabled = true;
            textBoxUsername.ReadOnly = false;
            textBoxPassword.Clear();

            _isPasswordVisible = false;
            textBoxPassword.PasswordChar = '●';

            UpdateButtonStates(isEditing: false);
            textBoxUsername.Focus();
        }

        private void UpdateButtonStates(bool isEditing)
        {
            buttonSave.Enabled = !isEditing;
            buttonEdit.Enabled = isEditing;
            buttonDelete.Enabled = isEditing;
        }

        private void TogglePasswordVisibilityChar()
        {
            _isPasswordVisible = !_isPasswordVisible;
            textBoxPassword.PasswordChar = _isPasswordVisible ? '\0' : '●';
            textBoxPassword.Focus();
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SaveUser.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSaveUserAsync() => await ProcessSaveOrUpdateUserAsync(0);
        /// <summary>
        /// Ejecuta de manera asincrona la accion de UpdateUser.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteUpdateUserAsync()
        {
            if (_selectedUserIdentifier == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un usuario de la lista para poder editarlo.", "Selección Requerida");
                return;
            }

            await ProcessSaveOrUpdateUserAsync(_selectedUserIdentifier);
        }

        private async Task ProcessSaveOrUpdateUserAsync(int id)
        {
            var user = new UserCreateDto
            {
                Id = id,
                Username = textBoxUsername.Text.Trim(),
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                RoleId = (int)(comboBoxRole.SelectedValue),
                Password = textBoxPassword.Text,
                Photo = _userPhotoBuffer,
                IsActive = true
            };

            using (new WaitCursorHelper(this))
            {
                var operationResult = await _userService.UpsertUserAsync(user);
                UIHelper.ShowResult(operationResult, "Gestión de Usuarios", async () =>
                {
                    await RefreshUsersGridAsync();
                    ResetFormInputFields();
                });
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de ToggleUserActiveStatus.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteToggleUserActiveStatusAsync()
        {
            if (_selectedUserIdentifier == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un usuario de la lista para cambiar su estado.", "Selección Requerida");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                var operationResult = await _userService.ToggleUserStatusAsync(_selectedUserIdentifier);
                UIHelper.ShowResult(operationResult, "Seguridad de Usuarios", async () =>
                {
                    await RefreshUsersGridAsync();
                    ResetFormInputFields();
                });
            }
        }

        public async Task ExecuteExportUsersReportToPdfAsync()
        {
            if (dataGridViewUsers.DataSource is not List<UserDto> usersList || !usersList.Any())
            {
                UIHelper.WarnMessage(this, "No hay usuarios registrados para exportar a PDF.", "Sin Registros");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] usersReportPdfBytes = await _documentService.GenerateUsersReportAsync(usersList);
                string reportPdfFileName = $"Reporte_Usuarios_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                await FileExportHelper.SaveAndOpenPdfAsync(this, usersReportPdfBytes, reportPdfFileName, "Exportar Reporte de Usuarios");
            }
        }

        private void HandleUserPhotoSelection()
        {
            if (ImageHelper.SelectImage(out byte[]? selectedImageBytes, out Image? selectedDisplayImage, out string? photoValidationErrorMessage))
            {
                ImageHelper.Clear(pictureBoxUserPhoto);
                _userPhotoBuffer = selectedImageBytes;
                pictureBoxUserPhoto.Image = selectedDisplayImage;
            }
            else if (!string.IsNullOrEmpty(photoValidationErrorMessage))
            {
                UIHelper.WarnMessage(this, photoValidationErrorMessage, "Validación de Fotografía");
            }
        }

        private void HandleUserPhotoRemoval()
        {
            _userPhotoBuffer = null;
            ImageHelper.Clear(pictureBoxUserPhoto);
        }
    }
}










