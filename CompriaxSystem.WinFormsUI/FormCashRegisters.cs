using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormCashRegisters : Form
    {
        private readonly ICashRegisterService _registerService;
        private int _selectedRegisterId = 0;

        public FormCashRegisters(ICashRegisterService registerService)
        {
            _registerService = registerService;
            InitializeComponent();

            ApplyIcons();

            this.Load += async (s, e) => await RefreshGridAsync();
            this.btnSave.Click += async (s, e) => await ExecuteSaveAction();
            this.btnToggle.Click += async (s, e) => await ExecuteToggleAction();
            this.btnCancel.Click += (s, e) => ResetUI();
            this.dgvRegisters.CellClick += (s, e) => SyncSelectedRegister();
        }

        private void ApplyIcons()
        {
            btnSave.Image = UIIconHelper.Guardar;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnToggle.Image = UIIconHelper.EstadoDisponible;
            btnToggle.ImageAlign = ContentAlignment.MiddleLeft;
            btnToggle.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        private async Task RefreshGridAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var registers = await _registerService.GetAllRegistersAsync();
                dgvRegisters.DataSource = null;
                dgvRegisters.DataSource = registers.ToList();
                UIHelper.FormatGrid(dgvRegisters);
            }
        }

        private void SyncSelectedRegister()
        {
            if (dgvRegisters.CurrentRow == null) return;

            var reg = (CashRegisterDto)dgvRegisters.CurrentRow.DataBoundItem;
            _selectedRegisterId = reg.Id;
            numNumber.Value = reg.Number;
            txtName.Text = reg.Name;
            txtDescription.Text = reg.Description ?? string.Empty;

            btnSave.Text = "ACTUALIZAR";
            btnSave.Image = UIIconHelper.Editar;
            btnToggle.Enabled = true;
        }

        private void ResetUI()
        {
            _selectedRegisterId = 0;
            numNumber.Value = 1;
            txtName.Clear();
            txtDescription.Clear();

            btnSave.Text = "GUARDAR";
            btnSave.Image = UIIconHelper.Guardar;
            btnToggle.Enabled = false;
            txtName.Focus();
        }

        private async Task ExecuteSaveAction()
        {
            var dto = new CashRegisterDto
            {
                Id = _selectedRegisterId,
                Number = (int)numNumber.Value,
                Name = txtName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                IsActive = true
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _registerService.UpsertCashRegisterAsync(dto);
                UIHelper.ShowResult(result, "Gestión de Cajas", async () =>
                {
                    ResetUI();
                    await RefreshGridAsync();
                });
            }
        }

        private async Task ExecuteToggleAction()
        {
            if (_selectedRegisterId == 0) return;

            using (new WaitCursorHelper(this))
            {
                var result = await _registerService.ToggleRegisterStatusAsync(_selectedRegisterId);
                UIHelper.ShowResult(result, "Cajas", async () =>
                {
                    ResetUI();
                    await RefreshGridAsync();
                });
            }
        }
    }
}