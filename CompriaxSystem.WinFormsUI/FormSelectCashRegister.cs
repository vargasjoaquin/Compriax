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

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(pnlCard);
            pnlHeader.BackColor = UIThemeHelper.SidebarBackground;

            this.Load += async (s, e) => await LoadCashRegistersAsync();
            this.cboRegister.SelectedIndexChanged += (s, e) => UpdateRegisterStatusLabel();
            this.btnConfirm.Click += (s, e) => ExecuteConfirm();
            this.btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private async Task LoadCashRegistersAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var registers = (await _registerService.GetAllRegistersAsync())
                    .Where(r => r.IsActive)
                    .ToList();

                cboRegister.DataSource = registers;
                cboRegister.DisplayMember = "Name";
                cboRegister.ValueMember = "Id";

                if (registers.Any())
                    cboRegister.SelectedIndex = 0;

                UpdateRegisterStatusLabel();
            }
        }

        private void UpdateRegisterStatusLabel()
        {
            if (cboRegister.SelectedItem is CashRegisterDto reg)
            {
                string currentUsername = _currentUserService.CurrentUser?.Username ?? string.Empty;

                if (reg.HasOpenShift)
                {
                    bool isMyOwnShift = !string.IsNullOrWhiteSpace(reg.CurrentCashierName) &&
                                        reg.CurrentCashierName.Equals(currentUsername, StringComparison.OrdinalIgnoreCase);

                    if (isMyOwnShift)
                    {
                        lblStatusInfo.Text = $" Tu turno sigue abierto (#{reg.CurrentShiftId})";
                        lblStatusInfo.ImageAlign = ContentAlignment.MiddleLeft;
                        lblStatusInfo.ForeColor = UIThemeHelper.Success;
                        btnConfirm.Enabled = true;
                    }
                    else
                    {
                        lblStatusInfo.Text = $" OCUPADA: Turno #{reg.CurrentShiftId} por '{reg.CurrentCashierName}'";
                        lblStatusInfo.ImageAlign = ContentAlignment.MiddleLeft;
                        lblStatusInfo.ForeColor = UIThemeHelper.Danger;
                        btnConfirm.Enabled = false;
                    }
                }
                else
                {
                    lblStatusInfo.Text = " Caja disponible (Sin turno abierto)";
                    lblStatusInfo.ImageAlign = ContentAlignment.MiddleLeft;
                    lblStatusInfo.ForeColor = UIThemeHelper.Success;
                    btnConfirm.Enabled = true;
                }
            }
        }

        private void ExecuteConfirm()
        {
            if (cboRegister.SelectedItem is not CashRegisterDto register)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una caja válida.", "Selección Requerida");
                return;
            }

            string currentUsername = _currentUserService.CurrentUser?.Username ?? string.Empty;

            if (register.HasOpenShift &&
                !string.IsNullOrWhiteSpace(register.CurrentCashierName) &&
                !register.CurrentCashierName.Equals(currentUsername, StringComparison.OrdinalIgnoreCase))
            {
                UIHelper.WarnMessage(this,
                    $"La '{register.Name}' está siendo operada actualmente por '{register.CurrentCashierName}'.\n\nPor favor, seleccione otra caja disponible.",
                    "Caja Ocupada");
                return;
            }

            _currentUserService.SetCashRegister(register.Id, register.Number, register.Name);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}