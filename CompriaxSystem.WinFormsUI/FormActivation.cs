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
            UIThemeHelper.ApplyCardStyle(pnlCard);
            pnlHeader.BackColor = UIThemeHelper.SidebarBackground;

            this.txtCuit.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(txtCuit);

            this.txtKey1.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(txtKey1, txtKey2, txtKey1, txtKey2, txtKey3, txtKey4);
            this.txtKey2.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(txtKey2, txtKey3, txtKey1, txtKey2, txtKey3, txtKey4);
            this.txtKey3.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(txtKey3, txtKey4, txtKey1, txtKey2, txtKey3, txtKey4);
            this.txtKey4.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(txtKey4, null, txtKey1, txtKey2, txtKey3, txtKey4);

            this.txtKey2.KeyDown += (s, e) => FormatterHelper.HandleLicenseKeyBackspace(txtKey2, txtKey1, e);
            this.txtKey3.KeyDown += (s, e) => FormatterHelper.HandleLicenseKeyBackspace(txtKey3, txtKey2, e);
            this.txtKey4.KeyDown += (s, e) => FormatterHelper.HandleLicenseKeyBackspace(txtKey4, txtKey3, e);

            this.btnActivate.Click += async (s, e) => await ExecuteActivationAsync();
            this.btnExit.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
        }

        private async Task ExecuteActivationAsync()
        {
            string cuitKey = new string(txtCuit.Text.Where(char.IsDigit).ToArray());
            string licenseKey = new string($"{txtKey1.Text}{txtKey2.Text}{txtKey3.Text}{txtKey4.Text}".Where(char.IsLetterOrDigit).ToArray()).ToUpper();

            if (string.IsNullOrWhiteSpace(txtCuit.Text) ||
                string.IsNullOrWhiteSpace(txtKey1.Text) ||
                string.IsNullOrWhiteSpace(txtKey2.Text) ||
                string.IsNullOrWhiteSpace(txtKey3.Text) ||
                string.IsNullOrWhiteSpace(txtKey4.Text))
            {
                UIHelper.WarnMessage(this, "Por favor, complete todos los campos de CUIT y License Key.", "Validación");
                return;
            }

            btnActivate.Enabled = false;
            btnActivate.Text = "ACTIVANDO...";
            lblStatusMessage.Visible = false;

            using (new WaitCursorHelper(this))
            {
                var result = await _licenseService.ActivateOnlineAsync(cuitKey, licenseKey);

                if (result.Success)
                {
                    UIHelper.InfoMessage(this, $"¡Sistema activado con éxito!\n\nComercio: {_licenseService.CurrentLicense?.BusinessName}", "Activación Exitosa");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblStatusMessage.Text = result.Message;
                    lblStatusMessage.ForeColor = UIThemeHelper.Danger;
                    lblStatusMessage.Visible = true;
                    btnActivate.Enabled = true;
                    btnActivate.Text = "ACTIVAR SISTEMA";
                }
            }
        }
    }
}