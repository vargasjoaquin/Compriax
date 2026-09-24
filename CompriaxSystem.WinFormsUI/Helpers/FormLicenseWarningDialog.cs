using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;

namespace CompriaxSystem.WinFormsUI.Helpers
{
    public partial class FormLicenseWarningDialog : Form
    {
        private readonly LicenseInformationDto _licenseInfo;
        private readonly ILicenseManagerService _licenseService;

        public FormLicenseWarningDialog(LicenseInformationDto licenseInfo, ILicenseManagerService licenseService)
        {
            _licenseInfo = licenseInfo;
            _licenseService = licenseService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);

            this.Load += (s, e) => LoadLicenseWarningDetails();
            this.buttonContinue.Click += (s, e) => this.Close();
            this.buttonRenew.Click += (s, e) => OpenLicenseRenewalForm();
        }

        private void LoadLicenseWarningDetails()
        {
            int daysRemaining = _licenseInfo.DaysRemaining ?? 0;

            labelWarningTitle.Text = daysRemaining == 1
                ? "¡ATENCIÓN! Le queda ÚNICAMENTE 1 DÍA de vigencia."
                : $"¡ATENCIÓN! Le quedan {daysRemaining} DÍAS de vigencia.";

            string expirationDate = _licenseInfo.ExpiresAt.HasValue
                ? _licenseInfo.ExpiresAt.Value.ToLocalTime().ToString("dd/MM/yyyy HH:mm")
                : "No especificada";

            labelDetails.Text = $"Comercio: {_licenseInfo.BusinessName}\n" +
                               $"CUIT: {_licenseInfo.Cuit}\n" +
                               $"Fecha de Vencimiento: {expirationDate}\n\n" +
                               "Le sugerimos contactar a su proveedor para renovar su suscripción antes de la fecha límite y evitar interrupciones en su punto de venta.";
        }

        private void OpenLicenseRenewalForm()
        {
            using var activationForm = new FormLicenseActivation(_licenseService, "Renovación anticipada de licencia");
            
            if (activationForm.ShowDialog(this) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
