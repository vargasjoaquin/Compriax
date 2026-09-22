using Microsoft.Extensions.DependencyInjection;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormLogin : Form
    {
        private readonly IAuthService _authService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICurrentUserService _currentUserService;

        public FormLogin(IAuthService authService, IServiceProvider serviceProvider, ICurrentUserService currentUserService)
        {
            _authService = authService;
            _serviceProvider = serviceProvider;
            _currentUserService = currentUserService;
            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            
            ButtonIconOverlayHelper.BindEvents(this.buttonLogin, this.picIconLogin);
            

            this.BackColor = UIThemeHelper.SidebarBackground;
            UIThemeHelper.ApplyCardStyle(panelLoginCard);

            this.buttonLogin.Click += async (s, e) => await ExecuteUserAuthenticationAsync();
            this.linkLabelForgotPassword.LinkClicked += (s, e) => OpenPasswordRecoveryDialog();
            this.textBoxPassword.KeyDown += async (s, e) => { if (e.KeyCode == Keys.Enter) await ExecuteUserAuthenticationAsync(); };
            this.textBoxUsername.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) textBoxPassword.Focus(); };
            this.buttonCloseApplication.Click += (s, e) => System.Windows.Forms.Application.Exit();
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de UserAuthentication.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteUserAuthenticationAsync()
        {
            labelErrorMessage.Visible = false;

            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                DisplayAuthenticationErrorMessage("Por favor ingrese su nombre de usuario.");
                textBoxUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                DisplayAuthenticationErrorMessage("Por favor ingrese su contraseña.");
                textBoxPassword.Focus();
                return;
            }

            using (new WaitCursorHelper(this))
            {
                try
                {
                    var result = await _authService.LoginAsync(textBoxUsername.Text.Trim(), textBoxPassword.Text);

                    if (result.Success)
                    {
                        var authenticatedUser = _currentUserService.CurrentUser;
                        bool isAdministratorRole = authenticatedUser != null && authenticatedUser.RoleName.Equals("Administrador", StringComparison.OrdinalIgnoreCase);

                        if (!isAdministratorRole)
                        {
                            var selectCashRegisterDialog = _serviceProvider.GetRequiredService<FormSelectCashRegister>();
                            if (selectCashRegisterDialog.ShowDialog(this) != DialogResult.OK)
                            {
                                return;
                            }
                        }

                        this.Hide();
                        var mainControlPanelForm = _serviceProvider.GetRequiredService<FormPanelControl>();
                        mainControlPanelForm.Show();
                    }
                    else
                    {
                        DisplayAuthenticationErrorMessage(result.Message);
                        textBoxPassword.SelectAll();
                        textBoxPassword.Focus();
                    }
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"Error de conexión con la base de datos:\n{ex.Message}", "Fallo de Inicio de Sesión");
                }
            }
        }

        private void OpenPasswordRecoveryDialog()
        {
            var passwordRecoveryDialog = _serviceProvider.GetRequiredService<FormRecoverPassword>();
            passwordRecoveryDialog.ShowDialog(this);
        }

        private void DisplayAuthenticationErrorMessage(string msg)
        {
            labelErrorMessage.Text = msg;
            labelErrorMessage.ImageAlign = ContentAlignment.MiddleLeft;
            labelErrorMessage.ForeColor = UIThemeHelper.Danger;
            labelErrorMessage.Visible = true;
        }
    }
}











