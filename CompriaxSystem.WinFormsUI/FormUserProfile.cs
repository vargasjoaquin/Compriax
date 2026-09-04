using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormUserProfile : Form
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public FormUserProfile(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
            InitializeComponent();

            this.Load += (s, e) => LoadProfileData();
            this.btnSave.Click += async (s, e) => await ExecuteSaveProfileAsync();
        }

        private void LoadProfileData()
        {
            var user = _currentUserService.CurrentUser;
            if (user == null)
            {
                UIHelper.ErrorMessage(this, "No se pudo recuperar la información de la sesión activa del usuario.", "Sesión Inválida");
                return;
            }

            lblNameVal.Text = $"{user.FirstName} {user.LastName}".Trim();
            lblRoleVal.Text = user.RoleName.ToUpper();
            lblUserVal.Text = $"Usuario: {user.Username}";
            lblEmailVal.Text = user.Email;

            ImageHelper.Clear(picAvatar);
            if (user.Photo != null && user.Photo.Length > 0)
            {
                picAvatar.Image = ImageHelper.LoadFromBytes(user.Photo);
            }
            
            txtEditFirstName.Text = user.FirstName;
            txtEditLastName.Text = user.LastName;
            txtEditEmail.Text = user.Email;

            txtEditCurrentPass.Clear();
            txtEditPassword.Clear();
            txtEditConfirmPass.Clear();
        }

        private async Task ExecuteSaveProfileAsync()
        {
            if (string.IsNullOrWhiteSpace(txtEditFirstName.Text))
            {
                UIHelper.WarnMessage(this, "Debe ingresar su nombre.", "Campo Obligatorio");
                txtEditFirstName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEditLastName.Text))
            {
                UIHelper.WarnMessage(this, "Debe ingresar su apellido.", "Campo Obligatorio");
                txtEditLastName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEditEmail.Text))
            {
                UIHelper.WarnMessage(this, "Debe ingresar su correo electrónico.", "Campo Obligatorio");
                txtEditEmail.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtEditPassword.Text) && txtEditPassword.Text != txtEditConfirmPass.Text)
            {
                UIHelper.WarnMessage(this, "La nueva contraseña y su confirmación no coinciden.", "Contraseña Inválida");
                txtEditConfirmPass.SelectAll();
                txtEditConfirmPass.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtEditPassword.Text) && string.IsNullOrWhiteSpace(txtEditCurrentPass.Text))
            {
                UIHelper.WarnMessage(this, "Para cambiar la contraseña, debe ingresar su contraseña actual.", "Verificación Requerida");
                txtEditCurrentPass.Focus();
                return;
            }

            var dto = new UserProfileUpdateDto
            {
                UserId = _currentUserService.CurrentUser!.UserId,
                FirstName = txtEditFirstName.Text.Trim(),
                LastName = txtEditLastName.Text.Trim(),
                Email = txtEditEmail.Text.Trim(),
                CurrentPassword = txtEditCurrentPass.Text,
                NewPassword = txtEditPassword.Text
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _userService.UpdateProfileAsync(dto);

                if (result.Success)
                {
                    _currentUserService.CurrentUser.FirstName = dto.FirstName;
                    _currentUserService.CurrentUser.LastName = dto.LastName;
                    _currentUserService.CurrentUser.FullName = $"{dto.FirstName} {dto.LastName}".Trim();
                    _currentUserService.CurrentUser.Email = dto.Email;

                    UIHelper.ShowResult(result, "Perfil Actualizado");
                    LoadProfileData();
                }
                else
                {
                    UIHelper.WarnMessage(this, result.Message, "Error al Actualizar");
                }
            }
        }
    }
}