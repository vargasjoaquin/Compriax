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
            
            ButtonIconOverlayHelper.BindEvents(this.buttonSaveChanges, this.picIconSaveChanges);
            

            this.Load += (s, e) => LoadAuthenticatedUserProfileData();
            this.buttonSaveChanges.Click += async (s, e) => await ExecuteUpdateUserProfileAndCredentialsAsync();
        }

        private void LoadAuthenticatedUserProfileData()
        {
            var currentUser = _currentUserService.CurrentUser;
            if (currentUser == null)
            {
                UIHelper.ErrorMessage(this, "No se pudo recuperar la información de la sesión activa del usuario.", "Sesión Inválida");
                return;
            }

            labelUserFullName.Text = $"{currentUser.FirstName} {currentUser.LastName}".Trim();
            labelUserRole.Text = currentUser.RoleName.ToUpper();
            labelUsername.Text = $"Usuario: {currentUser.Username}";
            labelUserEmail.Text = currentUser.Email;

            ImageHelper.Clear(pictureBoxAvatar);
            if (currentUser.Photo != null && currentUser.Photo.Length > 0)
            {
                pictureBoxAvatar.Image = ImageHelper.LoadFromBytes(currentUser.Photo);
            }

            textBoxFirstName.Text = currentUser.FirstName;
            textBoxLastName.Text = currentUser.LastName;
            textBoxEmail.Text = currentUser.Email;

            textBoxCurrentPassword.Clear();
            textBoxNewPassword.Clear();
            textBoxConfirmPassword.Clear();
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de UpdateUserProfileAndCredentials.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteUpdateUserProfileAndCredentialsAsync()
        {
            var userProfile = new UserProfileUpdateDto
            {
                UserId = _currentUserService.CurrentUser!.UserId,
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                CurrentPassword = textBoxCurrentPassword.Text,
                NewPassword = textBoxNewPassword.Text
            };

            using (new WaitCursorHelper(this))
            {
                var profileUpdateResult = await _userService.UpdateProfileAsync(userProfile);

                if (profileUpdateResult.Success)
                {
                    _currentUserService.CurrentUser.FirstName = userProfile.FirstName;
                    _currentUserService.CurrentUser.LastName = userProfile.LastName;
                    _currentUserService.CurrentUser.FullName = $"{userProfile.FirstName} {userProfile.LastName}".Trim();
                    _currentUserService.CurrentUser.Email = userProfile.Email;

                    UIHelper.ShowResult(profileUpdateResult, "Perfil Actualizado");
                    LoadAuthenticatedUserProfileData();
                }
                else
                {
                    UIHelper.WarnMessage(this, profileUpdateResult.Message, "Error al Actualizar");
                }
            }
        }
    }
}










