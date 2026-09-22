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
            UIThemeHelper.ApplyFormStyle(this);
            
            ButtonIconOverlayHelper.BindEvents(this.buttonSendRecovery, this.picIconSendRecovery);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);
            

            this.BackColor = UIThemeHelper.SidebarBackground;
            UIThemeHelper.ApplyCardStyle(panelCard);
            labelMainTitle.ForeColor = UIThemeHelper.Primary;

            this.buttonSendRecovery.Click += async (s, e) => await ExecuteSendPasswordRecoveryRequestAsync();
            this.buttonCancel.Click += (s, e) => this.Close();
            this.buttonCloseDialog.Click += (s, e) => this.Close();
            this.textBoxIdentity.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) await ExecuteSendPasswordRecoveryRequestAsync();
            };
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SendPasswordRecoveryRequest.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSendPasswordRecoveryRequestAsync()
        {
            string userIdentifierOrEmail = textBoxIdentity.Text.Trim();
            if (string.IsNullOrWhiteSpace(userIdentifierOrEmail))
            {
                UIHelper.WarnMessage(this, "Por favor, ingrese su nombre de usuario o correo electrónico.", "Campo Requerido");
                textBoxIdentity.Focus();
                return;
            }

            buttonSendRecovery.Enabled = false;
            buttonSendRecovery.Text = "VERIFICANDO...";
            labelResultStatus.Text = string.Empty;

            using (new WaitCursorHelper(this))
            {
                var recoveryOperationResult = await _authService.SendPasswordResetAsync(userIdentifierOrEmail);
                if (recoveryOperationResult.Success)
                {
                    labelResultStatus.Text = recoveryOperationResult.Message;
                    labelResultStatus.ImageAlign = ContentAlignment.MiddleLeft;
                    labelResultStatus.ForeColor = UIThemeHelper.Success;
                    UIHelper.InfoMessage(this, recoveryOperationResult.Message, "Recuperación de Contraseña");
                }
                else
                {
                    labelResultStatus.Text = recoveryOperationResult.Message;
                    labelResultStatus.ImageAlign = ContentAlignment.MiddleLeft;
                    labelResultStatus.ForeColor = UIThemeHelper.Danger;
                    UIHelper.WarnMessage(this, recoveryOperationResult.Message, "Cuenta No Encontrada");
                }
            }

            buttonSendRecovery.Enabled = true;
            buttonSendRecovery.Text = "ENVIAR";
        }
    }
}











