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

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnSave.Click += async (s, e) => await ExecuteSaveAction();
            this.btnBrowse.Click += (s, e) => ExecuteBrowseLogoAction();
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

                if (settings.Logo != null)
                {
                    _logoBytes = settings.Logo;
                    using var ms = new MemoryStream(_logoBytes);
                    picLogo.Image = Image.FromStream(ms);
                }
            }
        }

        private async Task ExecuteSaveAction()
        {
            var dto = new StoreSettingsDto
            {
                Name = txtName.Text,
                CUIT = txtTaxId.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                Logo = _logoBytes
            };

            var result = await _storeService.UpdateStoreProfileAsync(dto);
            UIHelper.ShowResult(result, "Configuración Sistema");
        }

        private void ExecuteBrowseLogoAction()
        {
            using OpenFileDialog ofd = new OpenFileDialog { Filter = "IMAGEN|*.jpg;*.png" };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picLogo.Image = Image.FromFile(ofd.FileName);
                _logoBytes = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void FormSettings_Load(object sender, EventArgs e) { }
        private void btnSave_Click(object sender, EventArgs e) { }
        private void btnBrowse_Click(object sender, EventArgs e) { }
    }
}
