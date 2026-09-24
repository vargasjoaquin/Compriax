using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
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
            
            ButtonIconOverlayHelper.BindEvents(this.buttonSaveSettings, this.picIconSaveSettings);
            

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
       private StoreSettingsDto? _currentSettings;

        public async Task InitializeStoreSettingsFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                _currentSettings = await _storeService.GetStoreProfileAsync();
                textBoxCompanyName.Text = _currentSettings.Name;
                textBoxTaxId.Text = _currentSettings.CUIT;
                textBoxAddress.Text = _currentSettings.Address;
                textBoxPhone.Text = _currentSettings.Phone;
                textBoxEmail.Text = _currentSettings.Email;

                if (_currentSettings.Logo != null && _currentSettings.Logo.Length > 0)
                    pictureBoxStoreLogo.Image = ImageHelper.LoadFromBytes(_currentSettings.Logo);
                else
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
                Logo = _currentSettings?.Logo,
                GrossIncomeNumber = _currentSettings?.GrossIncomeNumber,
                ActivityStartDate = _currentSettings?.ActivityStartDate,
                TaxConditionId = _currentSettings?.TaxConditionId,
                PointOfSale = _currentSettings?.PointOfSale ?? TaxConstants.DEFAULT_POINT_OF_SALE,
                TicketFormat = _currentSettings?.TicketFormat ?? ThermalPrinterConstants.FORMAT_80MM,
                TicketFooterMessage = _currentSettings?.TicketFooterMessage ?? ThermalPrinterConstants.DEFAULT_FOOTER_MESSAGE,
                ThermalPrinterName = _currentSettings?.ThermalPrinterName,
                ShowLogoOnTicket = _currentSettings?.ShowLogoOnTicket ?? true,
                ShowBarcodeOnTicket = _currentSettings?.ShowBarcodeOnTicket ?? true,
                AutoPrintTicket = _currentSettings?.AutoPrintTicket ?? false
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