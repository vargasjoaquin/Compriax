using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormRecoverPassword : Form
    {
        private readonly IAuthService _authService;

        public FormRecoverPassword(IAuthService authService)
        {
            _authService = authService;
            InitializeComponent();

            this.BackColor = UIThemeHelper.SidebarBackground;
            UIThemeHelper.ApplyCardStyle(pnlCard);
            lblMainTitle.ForeColor = UIThemeHelper.Primary;

            this.btnSend.Click += async (s, e) => await ExecuteSendRecoveryAsync();
            this.btnCancel.Click += (s, e) => this.Close();
            this.btnCloseX.Click += (s, e) => this.Close();
            this.txtIdentity.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) await ExecuteSendRecoveryAsync();
            };
        }

        private async Task ExecuteSendRecoveryAsync()
        {
            string identity = txtIdentity.Text.Trim();
            if (string.IsNullOrWhiteSpace(identity))
            {
                UIHelper.WarnMessage(this, "Por favor, ingrese su nombre de usuario o correo electrónico.", "Campo Requerido");
                txtIdentity.Focus();
                return;
            }

            btnSend.Enabled = false;
            btnSend.Text = "VERIFICANDO...";
            lblResult.Text = string.Empty;

            using (new WaitCursorHelper(this))
            {
                var result = await _authService.SendPasswordResetAsync(identity);
                if (result.Success)
                {
                    lblResult.Text = result.Message;
                    lblResult.ImageAlign = ContentAlignment.MiddleLeft;
                    lblResult.ForeColor = UIThemeHelper.Success;
                    UIHelper.InfoMessage(this, result.Message, "Recuperación de Contraseña");
                }
                else
                {
                    lblResult.Text = result.Message;
                    lblResult.ImageAlign = ContentAlignment.MiddleLeft;
                    lblResult.ForeColor = UIThemeHelper.Danger;
                    UIHelper.WarnMessage(this, result.Message, "Cuenta No Encontrada");
                }
            }

            btnSend.Enabled = true;
            btnSend.Text = "ENVIAR";
        }
    }
}