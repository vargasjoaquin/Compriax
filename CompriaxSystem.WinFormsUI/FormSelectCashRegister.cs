using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormSelectCashRegister : Form
    {
        private readonly ICashRegisterService _registerService;
        private readonly ICurrentUserService _currentUserService;

        public FormSelectCashRegister(
            ICashRegisterService registerService,
            ICurrentUserService currentUserService)
        {
            _registerService = registerService;
            _currentUserService = currentUserService;
            InitializeComponent();
            
            ButtonIconOverlayHelper.BindEvents(this.buttonConfirmSelection, this.picIconConfirmSelection);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);
            

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelSelectionCard);
            panelHeader.BackColor = UIThemeHelper.SidebarBackground;

            this.Load += async (s, e) => await LoadActiveCashRegistersListAsync();
            this.comboBoxRegisterSelection.SelectedIndexChanged += (s, e) => UpdateSelectedRegisterStatusDisplay();
            this.buttonConfirmSelection.Click += (s, e) => ExecuteConfirmCashRegisterAssignment();
            this.buttonCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private async Task LoadActiveCashRegistersListAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var activeCashRegistersList = (await _registerService.GetAllRegistersAsync())
                    .Where(r => r.IsActive)
                    .ToList();

                comboBoxRegisterSelection.DataSource = activeCashRegistersList;
                comboBoxRegisterSelection.DisplayMember = "Name";
                comboBoxRegisterSelection.ValueMember = "Id";

                if (activeCashRegistersList.Any())
                    comboBoxRegisterSelection.SelectedIndex = 0;

                UpdateSelectedRegisterStatusDisplay();
            }
        }

        private void UpdateSelectedRegisterStatusDisplay()
        {
            if (comboBoxRegisterSelection.SelectedItem is CashRegisterDto selectedCashRegister)
            {
                string currentSessionUsername = _currentUserService.CurrentUser?.Username ?? string.Empty;

                if (selectedCashRegister.HasOpenShift)
                {
                    bool isCurrentCashierOpenShift = !string.IsNullOrWhiteSpace(selectedCashRegister.CurrentCashierName) &&
                                        selectedCashRegister.CurrentCashierName.Equals(currentSessionUsername, StringComparison.OrdinalIgnoreCase);

                    if (isCurrentCashierOpenShift)
                    {
                        labelRegisterStatusInfo.Text = $" Tu turno sigue abierto (#{selectedCashRegister.CurrentShiftId})";
                        labelRegisterStatusInfo.ImageAlign = ContentAlignment.MiddleLeft;
                        labelRegisterStatusInfo.ForeColor = UIThemeHelper.Success;
                        buttonConfirmSelection.Enabled = true;
                    }
                    else
                    {
                        labelRegisterStatusInfo.Text = $" OCUPADA: Turno #{selectedCashRegister.CurrentShiftId} por '{selectedCashRegister.CurrentCashierName}'";
                        labelRegisterStatusInfo.ImageAlign = ContentAlignment.MiddleLeft;
                        labelRegisterStatusInfo.ForeColor = UIThemeHelper.Danger;
                        buttonConfirmSelection.Enabled = false;
                    }
                }
                else
                {
                    labelRegisterStatusInfo.Text = " Caja disponible (Sin turno abierto)";
                    labelRegisterStatusInfo.ImageAlign = ContentAlignment.MiddleLeft;
                    labelRegisterStatusInfo.ForeColor = UIThemeHelper.Success;
                    buttonConfirmSelection.Enabled = true;
                }
            }
        }

        private void ExecuteConfirmCashRegisterAssignment()
        {
            if (comboBoxRegisterSelection.SelectedItem is not CashRegisterDto selectedRegisterToAssign)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una caja válida.", "Selección Requerida");
                return;
            }

            string currentSessionUsername = _currentUserService.CurrentUser?.Username ?? string.Empty;

            if (selectedRegisterToAssign.HasOpenShift &&
                !string.IsNullOrWhiteSpace(selectedRegisterToAssign.CurrentCashierName) &&
                !selectedRegisterToAssign.CurrentCashierName.Equals(currentSessionUsername, StringComparison.OrdinalIgnoreCase))
            {
                UIHelper.WarnMessage(this,
                    $"La '{selectedRegisterToAssign.Name}' está siendo operada actualmente por '{selectedRegisterToAssign.CurrentCashierName}'.\n\nPor favor, seleccione otra caja disponible.",
                    "Caja Ocupada");
                return;
            }

            _currentUserService.SetCashRegister(selectedRegisterToAssign.Id, selectedRegisterToAssign.Number, selectedRegisterToAssign.Name);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}










