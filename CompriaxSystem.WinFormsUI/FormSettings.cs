using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormSettings : Form
    {
        private readonly IStoreService _storeService;

        public FormSettings(IStoreService storeService)
        {
            _storeService = storeService;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelStoreProfileForm);

            this.Load += async (s, e) => await InitializeStoreSettingsFormAsync();
            this.buttonSaveSettings.Click += async (s, e) => await ExecuteSaveStoreProfileSettingsAsync();
            this.textBoxTaxId.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(textBoxTaxId);
        }
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializeStoreSettingsFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var currentStoreSettings = await _storeService.GetStoreProfileAsync();
                textBoxCompanyName.Text = currentStoreSettings.Name;
                textBoxTaxId.Text = currentStoreSettings.CUIT;
                textBoxAddress.Text = currentStoreSettings.Address;
                textBoxPhone.Text = currentStoreSettings.Phone;
                textBoxEmail.Text = currentStoreSettings.Email;

                pictureBoxStoreLogo.Image = Resources.logo_compriax;
                pictureBoxStoreLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SaveStoreProfileSettings.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSaveStoreProfileSettingsAsync()
        {
            var updatedStoreSettings = new StoreSettingsDto
            {
                Name = textBoxCompanyName.Text.Trim(),
                CUIT = textBoxTaxId.Text.Trim(),
                Address = textBoxAddress.Text.Trim(),
                Phone = textBoxPhone.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                Logo = null
            };

            using (new WaitCursorHelper(this))
            {
                var operationResult = await _storeService.UpdateStoreProfileAsync(updatedStoreSettings);

                if (operationResult.Success)
                {
                    var activePanelControlForm = System.Windows.Forms.Application.OpenForms.OfType<FormPanelControl>().FirstOrDefault();
                    if (activePanelControlForm != null)
                    {
                        await activePanelControlForm.ConfigureApplicationAppearanceAndBrandingAsync();
                    }

                    UIHelper.InfoMessage(this, "¡Configuración guardada y actualizada!", "Ajustes Actualizados");
                }
                else
                {
                    UIHelper.ShowResult(operationResult, "Configuración del Sistema");
                }
            }
        }
    }
}