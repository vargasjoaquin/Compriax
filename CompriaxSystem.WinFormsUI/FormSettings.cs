using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormSettings : Form
    {
        private readonly IStoreService _storeService;
        private byte[]? _logoBytes;

        public FormSettings(IStoreService storeService)
        {
            _storeService = storeService;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(groupBoxStore);

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnSave.Click += async (s, e) => await ExecuteSaveAction();
            this.btnBrowse.Click += (s, e) => ExecuteBrowseLogoAction();
            this.txtTaxId.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(txtTaxId);
        }

        public async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var settings = await _storeService.GetStoreProfileAsync();
                txtName.Text = settings.Name;
                txtTaxId.Text = settings.CUIT;
                txtAddress.Text = settings.Address;
                txtPhone.Text = settings.Phone;
                txtEmail.Text = settings.Email;

                if (settings.Logo != null && settings.Logo.Length > 8)
                {
                    try
                    {
                        using var ms = new MemoryStream(settings.Logo);
                        picLogo.Image = new Bitmap(Image.FromStream(ms));
                    }
                    catch
                    {
                        picLogo.Image = null;
                    }
                }
            }
        }

        private async Task ExecuteSaveAction()
        {
            var dto = new StoreSettingsDto
            {
                Name = txtName.Text.Trim(),
                CUIT = txtTaxId.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Logo = _logoBytes
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _storeService.UpdateStoreProfileAsync(dto);

                if (result.Success)
                {
                    var mainForm = System.Windows.Forms.Application.OpenForms.OfType<FormPanelControl>().FirstOrDefault();
                    if (mainForm != null)
                    {
                        await mainForm.SetupAppearanceAsync();
                    }

                    UIHelper.InfoMessage(this, "¡Configuración guardada y actualizada!", "Ajustes Actualizados");
                }
                else
                {
                    UIHelper.ShowResult(result, "Configuración del Sistema");
                }
            }
        }

        private void ExecuteBrowseLogoAction()
        {
            if (ImageHelper.SelectImage(out byte[]? imageBytes, out Image? displayImage, out string? errorMessage))
            {
                picLogo.Image?.Dispose();
                _logoBytes = imageBytes;
                picLogo.Image = displayImage;
            }
            else if (!string.IsNullOrEmpty(errorMessage))
            {
                UIHelper.WarnMessage(this, errorMessage, "Validación de Logo");
            }
        }

        private void FormSettings_Load(object sender, EventArgs e) { }
        private void btnSave_Click(object sender, EventArgs e) { }
        private void btnBrowse_Click(object sender, EventArgs e) { }
    }
}
