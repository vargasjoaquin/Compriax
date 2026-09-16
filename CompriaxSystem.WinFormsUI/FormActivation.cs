using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormActivation : Form
    {
        private readonly ILicenseManagerService _licenseService;

        public FormActivation(ILicenseManagerService licenseService)
        {
            _licenseService = licenseService;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelCard);
            panelHeader.BackColor = UIThemeHelper.SidebarBackground;

            this.textBoxTaxId.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(textBoxTaxId);

            this.textBoxLicenseKeyPart1.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(textBoxLicenseKeyPart1, textBoxLicenseKeyPart2, textBoxLicenseKeyPart1, textBoxLicenseKeyPart2, textBoxLicenseKeyPart3, textBoxLicenseKeyPart4);
            this.textBoxLicenseKeyPart2.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(textBoxLicenseKeyPart2, textBoxLicenseKeyPart3, textBoxLicenseKeyPart1, textBoxLicenseKeyPart2, textBoxLicenseKeyPart3, textBoxLicenseKeyPart4);
            this.textBoxLicenseKeyPart3.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(textBoxLicenseKeyPart3, textBoxLicenseKeyPart4, textBoxLicenseKeyPart1, textBoxLicenseKeyPart2, textBoxLicenseKeyPart3, textBoxLicenseKeyPart4);
            this.textBoxLicenseKeyPart4.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(textBoxLicenseKeyPart4, null, textBoxLicenseKeyPart1, textBoxLicenseKeyPart2, textBoxLicenseKeyPart3, textBoxLicenseKeyPart4);

            this.textBoxLicenseKeyPart2.KeyDown += (s, e) => FormatterHelper.HandleLicenseKeyBackspace(textBoxLicenseKeyPart2, textBoxLicenseKeyPart1, e);
            this.textBoxLicenseKeyPart3.KeyDown += (s, e) => FormatterHelper.HandleLicenseKeyBackspace(textBoxLicenseKeyPart3, textBoxLicenseKeyPart2, e);
            this.textBoxLicenseKeyPart4.KeyDown += (s, e) => FormatterHelper.HandleLicenseKeyBackspace(textBoxLicenseKeyPart4, textBoxLicenseKeyPart3, e);

            this.buttonActivate.Click += async (s, e) => await ExecuteSystemLicenseActivationAsync();
            this.buttonExit.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SystemLicenseActivation.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSystemLicenseActivationAsync()
        {
            string taxIdentificationNumber = new string(textBoxTaxId.Text.Where(char.IsDigit).ToArray());
            string licenseKey = new string($"{textBoxLicenseKeyPart1.Text}{textBoxLicenseKeyPart2.Text}{textBoxLicenseKeyPart3.Text}{textBoxLicenseKeyPart4.Text}".Where(char.IsLetterOrDigit).ToArray()).ToUpper();

            if (string.IsNullOrWhiteSpace(textBoxTaxId.Text) ||
                string.IsNullOrWhiteSpace(textBoxLicenseKeyPart1.Text) ||
                string.IsNullOrWhiteSpace(textBoxLicenseKeyPart2.Text) ||
                string.IsNullOrWhiteSpace(textBoxLicenseKeyPart3.Text) ||
                string.IsNullOrWhiteSpace(textBoxLicenseKeyPart4.Text))
            {
                UIHelper.WarnMessage(this, "Por favor, complete todos los campos de CUIT y License Key.", "Validación");
                return;
            }

            buttonActivate.Enabled = false;
            buttonActivate.Text = "ACTIVANDO...";
            labelStatusMessage.Visible = false;

            using (new WaitCursorHelper(this))
            {
                var licenseActivationResult = await _licenseService.ActivateOnlineAsync(taxIdentificationNumber, licenseKey);

                if (licenseActivationResult.Success)
                {
                    UIHelper.InfoMessage(this, $"¡Sistema activado con éxito!\n\nComercio: {_licenseService.CurrentLicense?.BusinessName}", "Activación Exitosa");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    labelStatusMessage.Text = licenseActivationResult.Message;
                    labelStatusMessage.ForeColor = UIThemeHelper.Danger;
                    labelStatusMessage.Visible = true;
                    buttonActivate.Enabled = true;
                    buttonActivate.Text = "ACTIVAR SISTEMA";
                }
            }
        }
    }
}