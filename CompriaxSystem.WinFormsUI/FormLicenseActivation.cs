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

            this.textBoxKey1.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(textBoxKey1, textBoxKey2, textBoxKey1, textBoxKey2, textBoxKey3, textBoxKey4);
            this.textBoxKey2.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(textBoxKey2, textBoxKey3, textBoxKey1, textBoxKey2, textBoxKey3, textBoxKey4);
            this.textBoxKey3.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(textBoxKey3, textBoxKey4, textBoxKey1, textBoxKey2, textBoxKey3, textBoxKey4);
            this.textBoxKey4.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(textBoxKey4, null, textBoxKey1, textBoxKey2, textBoxKey3, textBoxKey4);

            this.textBoxKey2.KeyDown += (s, e) => FormatterHelper.HandleLicenseKeyBackspace(textBoxKey2, textBoxKey1, e);
            this.textBoxKey3.KeyDown += (s, e) => FormatterHelper.HandleLicenseKeyBackspace(textBoxKey3, textBoxKey2, e);
            this.textBoxKey4.KeyDown += (s, e) => FormatterHelper.HandleLicenseKeyBackspace(textBoxKey4, textBoxKey3, e);

            this.buttonActivate.Click += async (s, e) => await ExecuteOnlineActivationAsync();
            this.buttonExit.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private async Task ExecuteOnlineActivationAsync()
        {
            string cuit = textBoxCuit.Text.Trim();
            string cleanCuitDigits = new string(cuit.Where(char.IsDigit).ToArray());

            string key1 = textBoxKey1.Text.Trim().ToUpper();
            string key2 = textBoxKey2.Text.Trim().ToUpper();
            string key3 = textBoxKey3.Text.Trim().ToUpper();
            string key4 = textBoxKey4.Text.Trim().ToUpper();

            string fullKey = $"{key1}-{key2}-{key3}-{key4}";
            string cleanKeyChars = $"{key1}{key2}{key3}{key4}";

            if (cleanCuitDigits.Length < 11)
            {
                UIHelper.WarnMessage(this, "El CUIT ingresado debe tener 11 dígitos numéricos completos (ej. 30-12345678-9).", "CUIT Inválido");
                textBoxCuit.Focus();
                return;
            }

            if (cleanKeyChars.Length < 16)
            {
                UIHelper.WarnMessage(this, "La clave de licencia debe tener 16 caracteres completos (4 casillas de 4 caracteres).", "Clave Incompleta");
                
                if (key1.Length < 4)
                    textBoxKey1.Focus();
                else if (key2.Length < 4) 
                    textBoxKey2.Focus();
                else if (key3.Length < 4) 
                    textBoxKey3.Focus();
                else textBoxKey4.Focus();

                return;
            }

            buttonActivate.Enabled = false;
            buttonActivate.Text = "VALIDANDO CON SERVIDOR...";
            labelStatus.Text = "Conectando con el servidor de licencias...";
            labelStatus.ForeColor = Color.FromArgb(2, 132, 199);

            try
            {
                var result = await _licenseService.ActivateOnlineAsync(cuit, fullKey);

                if (result.Success)
                {
                    UIHelper.InfoMessage(this, "¡Licencia validada y autorizada exitosamente!", "Activación Exitosa");
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