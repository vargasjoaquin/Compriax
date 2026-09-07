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
            ApplyIcons();

            this.btnActivate.Click += async (s, e) => await ExecuteActivationAsync();
            this.btnExit.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
        }

        private void ApplyIcons()
        {
            lblTitle.Image = UIIconHelper.ActivacionSupervisor;
            lblTitle.ImageAlign = ContentAlignment.MiddleLeft;
            lblTitle.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnActivate.Image = UIIconHelper.Exito;
            btnActivate.ImageAlign = ContentAlignment.MiddleLeft;
            btnActivate.TextImageRelation = TextImageRelation.ImageBeforeText;
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
                    lblStatusMessage.Text = result.Message;
                    lblStatusMessage.Image = UIIconHelper.Error;
                    lblStatusMessage.ImageAlign = ContentAlignment.MiddleLeft;
                    lblStatusMessage.ForeColor = UIThemeHelper.Danger;
                    lblStatusMessage.Visible = true;
                    btnActivate.Enabled = true;
                    btnActivate.Text = "ACTIVAR SISTEMA";
                }
            }
        }
    }
}