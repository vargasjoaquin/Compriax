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

            this.BackColor = UIThemeHelper.SidebarBackground;
            UIThemeHelper.ApplyCardStyle(pnlCard);

            this.btnLogin.Click += async (s, e) => await ExecuteLoginAction();
            this.linkPass.LinkClicked += (s, e) => OpenPasswordRecovery();
            this.txtPass.KeyDown += async (s, e) => { if (e.KeyCode == Keys.Enter) await ExecuteLoginAction(); };
            this.txtUsuario.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) txtPass.Focus(); };
            this.btnClose.Click += (s, e) => System.Windows.Forms.Application.Exit();
        }

        private async Task ExecuteLoginAction()
        {
            lblErrorMessage.Visible = false;

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                ShowError("Por favor ingrese su nombre de usuario.");
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                ShowError("Por favor ingrese su contraseña.");
                txtPass.Focus();
                return;
            }

            using (new WaitCursorHelper(this))
            {
                try
                {
                    var result = await _authService.LoginAsync(txtUsuario.Text.Trim(), txtPass.Text);

                    if (result.Success)
                    {
                        var user = _currentUserService.CurrentUser;
                        bool isAdmin = user != null && user.RoleName.Equals("Administrador", StringComparison.OrdinalIgnoreCase);

                        if (!isAdmin)
                        {
                            var selectRegisterForm = _serviceProvider.GetRequiredService<FormSelectCashRegister>();
                            if (selectRegisterForm.ShowDialog(this) != DialogResult.OK)
                            {
                                return;
                            }
                        }

                        this.Hide();
                        var panelControl = _serviceProvider.GetRequiredService<FormPanelControl>();
                        panelControl.Show();
                    }
                    else
                    {
                        ShowError(result.Message);
                        txtPass.SelectAll();
                        txtPass.Focus();
                    }
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"Error de conexión con la base de datos:\n{ex.Message}", "Fallo de Inicio de Sesión");
                }
            }
        }

        private void OpenPasswordRecovery()
        {
            var recoverForm = _serviceProvider.GetRequiredService<FormRecoverPassword>();
            recoverForm.ShowDialog(this);
        }

        private void ShowError(string msg)
        {
            lblErrorMessage.Text = msg;
            lblErrorMessage.ImageAlign = ContentAlignment.MiddleLeft;
            lblErrorMessage.ForeColor = UIThemeHelper.Danger;
            lblErrorMessage.Visible = true;
        }
    }
}