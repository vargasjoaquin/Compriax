using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormLicenseActivation : Form
    {
        private readonly ILicenseManagerService _licenseService;
        private readonly string? _statusReasonMessage;

        public FormLicenseActivation(ILicenseManagerService licenseService, string? statusReasonMessage = null)
        {
            _licenseService = licenseService;
            _statusReasonMessage = statusReasonMessage;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelCard);

            this.Load += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(_statusReasonMessage))
                    labelReason.Text = _statusReasonMessage;

                textBoxCuit.Focus();
            };

            this.textBoxCuit.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(textBoxCuit);
            this.buttonActivate.Click += async (s, e) => await ExecuteOnlineActivationAsync();
            this.buttonExit.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private async Task ExecuteOnlineActivationAsync()
        {
            string cuit = textBoxCuit.Text.Trim();
            string key = textBoxLicenseKey.Text.Trim();

            if (string.IsNullOrWhiteSpace(cuit) || string.IsNullOrWhiteSpace(key))
            {
                UIHelper.WarnMessage(this, "Debe ingresar el CUIT y la Clave de Licencia.", "Campos Requeridos");
                return;
            }

            buttonActivate.Enabled = false;
            buttonActivate.Text = "VALIDANDO CON SERVIDOR...";
            labelStatus.Text = "Conectando con el servidor de licencias...";
            labelStatus.ForeColor = Color.FromArgb(2, 132, 199);

            try
            {
                var result = await _licenseService.ActivateOnlineAsync(cuit, key);

                if (result.Success)
                {
                    UIHelper.InfoMessage(this, "¡Sistema activado y autorizado exitosamente!", "Activación Exitosa");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    labelStatus.Text = result.Message;
                    labelStatus.ForeColor = Color.FromArgb(239, 68, 68);
                    UIHelper.WarnMessage(this, result.Message, "Activación Rechazada");
                }
            }
            catch (Exception ex)
            {
                UIHelper.ErrorMessage(this, $"Error al comunicar con el servidor:\n{ex.Message}", "Fallo de Red");
            }
            finally
            {
                buttonActivate.Enabled = true;
                buttonActivate.Text = "ACTIVAR / RENOVAR EN LÍNEA";
            }
        }
    }
}