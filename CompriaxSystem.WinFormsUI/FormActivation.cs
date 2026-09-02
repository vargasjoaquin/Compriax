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

            this.btnActivate.Click += async (s, e) => await ExecuteActivationAsync();
            this.btnExit.Click += (s, e) => System.Windows.Forms.Application.Exit();
        }

        private async Task ExecuteActivationAsync()
        {
            if (string.IsNullOrWhiteSpace(txtCuit.Text))
            {
                UIHelper.WarnMessage(this, "Debe ingresar el CUIT del comercio titular.", "Campo Obligatorio");
                txtCuit.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLicenseKey.Text))
            {
                UIHelper.WarnMessage(this, "Debe ingresar la License Key suministrada.", "Campo Obligatorio");
                txtLicenseKey.Focus();
                return;
            }

            btnActivate.Enabled = false;
            btnActivate.Text = "ACTIVANDO...";
            lblStatusMessage.Visible = false;

            using (new WaitCursorHelper(this))
            {
                var result = await _licenseService.ActivateOnlineAsync(txtCuit.Text.Trim(), txtLicenseKey.Text.Trim());

                if (result.Success)
                {
                    UIHelper.InfoMessage(this, $"¡Sistema activado con éxito!\n\nComercio: {_licenseService.CurrentLicense?.BusinessName}", "Activación Exitosa");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblStatusMessage.Text = "❌ " + result.Message;
                    lblStatusMessage.Visible = true;
                    btnActivate.Enabled = true;
                    btnActivate.Text = "✓ ACTIVAR SISTEMA";
                }
            }
        }
    }
}