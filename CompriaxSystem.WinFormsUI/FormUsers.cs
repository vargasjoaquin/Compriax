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
        private int _selectedUserId = 0;
        private byte[]? _imageBuffer = null;
        private bool _isPasswordVisible = false;

        public FormUsers(IUserService userService, IDocumentService documentService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _documentService = documentService;
            _passwordHasher = passwordHasher;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(groupBoxData);

            this.dgvUsers.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dgvUsers, e);

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnSave.Click += async (s, e) => await ExecuteSaveAction();
            this.btnEdit.Click += async (s, e) => await ExecuteEditAction();
            this.btnDelete.Click += async (s, e) => await ExecuteToggleStatusAction();
            this.btnExportPdf.Click += async (s, e) => await ExecuteExportPdfAction();
            this.btnBrowsePhoto.Click += (s, e) => HandlePhotoSelection();
            this.btnClearPhoto.Click += (s, e) => HandlePhotoRemoval();
            this.btnTogglePassword.Click += (s, e) => TogglePasswordVisibility();
        }

        public async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                cboRole.DataSource = (await _userService.GetRolesAsync()).ToList();
                cboRole.DisplayMember = "Name";
                cboRole.ValueMember = "Id";

                await RefreshGridAsync();
                UIHelper.AttachManagedSelection(this, dgvUsers, SyncEntityToFields, ResetUI);
                ResetUI();
            }
        }

        private async Task RefreshGridAsync()
        {
            var users = await _userService.GetUserListAsync();
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = users.ToList();
            DataGridViewHelper.ApplyStyle(dgvUsers);
        }

        private void SyncEntityToFields()
        {
            if (dgvUsers.CurrentRow == null)
                return;

            var u = (UserDto)dgvUsers.CurrentRow.DataBoundItem;

            _selectedUserId = u.Id;
            txtUsername.Text = u.Username;
            txtFirstName.Text = u.FirstName;
            txtLastName.Text = u.LastName;
            txtEmail.Text = u.Email;
            cboRole.SelectedValue = u.RoleId;

            if (u is UserCreateDto createDto)
                txtPassword.Text = createDto.Password;

            _imageBuffer = u.Photo;
            ImageHelper.Clear(picPhoto);
            picPhoto.Image = ImageHelper.LoadFromBytes(u.Photo);

            SetButtonState(isEditing: true);
            txtUsername.ReadOnly = true;

            bool isAdmin = u.Username.Equals(RoleConstants.DEFAULT_ADMIN_USERNAME, StringComparison.OrdinalIgnoreCase) ||
                           u.RoleName.Equals(RoleConstants.ADMINISTRATOR, StringComparison.OrdinalIgnoreCase);
            btnDelete.Enabled = !isAdmin;
            cboRole.Enabled = !isAdmin;
        }

        private void ResetUI()
        {
            _selectedUserId = 0;
            _imageBuffer = null;
            ImageHelper.Clear(picPhoto);

            UIHelper.CleanControls(groupBoxData);

            cboRole.SelectedIndex = -1;
            cboRole.Enabled = true;
            txtUsername.ReadOnly = false;
            txtPassword.Clear();

            _isPasswordVisible = false;
            txtPassword.PasswordChar = '●';

            SetButtonState(isEditing: false);
            txtUsername.Focus();
        }

        private void SetButtonState(bool isEditing)
        {
            btnSave.Enabled = !isEditing;
            btnEdit.Enabled = isEditing;
            btnDelete.Enabled = isEditing;
        }

        private void TogglePasswordVisibility()
        {
            _isPasswordVisible = !_isPasswordVisible;
            txtPassword.PasswordChar = _isPasswordVisible ? '\0' : '●';
            txtPassword.Focus();
        }

        private async Task ExecuteSaveAction() => await ProcessAction(0);

        private async Task ExecuteEditAction()
        {
            if (_selectedUserId == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un usuario de la lista para poder editarlo.", "Selección Requerida");
                return;
            }

            await ProcessAction(_selectedUserId);
        }

        private async Task ProcessAction(int id)
        {
            var dto = new UserCreateDto
            {
                Id = id,
                Username = txtUsername.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                RoleId = (int)(cboRole.SelectedValue),
                Password = txtPassword.Text,
                Photo = _imageBuffer,
                IsActive = true
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _userService.UpsertUserAsync(dto);
                UIHelper.ShowResult(result, "Gestión de Usuarios", async () =>
                {
                    await RefreshGridAsync();
                    ResetUI();
                });
            }
        }

        private async Task ExecuteToggleStatusAction()
        {
            if (_selectedUserId == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un usuario de la lista para cambiar su estado.", "Selección Requerida");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                var result = await _userService.ToggleUserStatusAsync(_selectedUserId);
                UIHelper.ShowResult(result, "Seguridad de Usuarios", async () =>
                {
                    await RefreshGridAsync();
                    ResetUI();
                });
            }
        }

        public async Task ExecuteExportPdfAction()
        {
            if (dgvUsers.DataSource is not List<UserDto> users || !users.Any())
            {
                UIHelper.WarnMessage(this, "No hay usuarios registrados para exportar a PDF.", "Sin Registros");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] pdfBytes = await _documentService.GenerateUsersReportAsync(users);
                string fileName = $"Reporte_Usuarios_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                await FileExportHelper.SaveAndOpenPdfAsync(this, pdfBytes, fileName, "Exportar Reporte de Usuarios");
            }
        }

        private void HandlePhotoSelection()
        {
            if (ImageHelper.SelectImage(out byte[]? imageBytes, out Image? displayImage, out string? errorMessage))
            {
                ImageHelper.Clear(picPhoto);
                _imageBuffer = imageBytes;
                picPhoto.Image = displayImage;
            }
            else if (!string.IsNullOrEmpty(errorMessage))
            {
                UIHelper.WarnMessage(this, errorMessage, "Validación de Fotografía");
            }
        }

        private void HandlePhotoRemoval()
        {
            _imageBuffer = null;
            ImageHelper.Clear(picPhoto);
        }
    }
}