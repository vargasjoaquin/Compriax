using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormCashRegisters : Form
    {
        private readonly ICashRegisterService _registerService;
        private int _selectedCashRegisterId = 0;

        public FormCashRegisters(ICashRegisterService registerService)
        {
            _registerService = registerService;
            InitializeComponent();

            this.Load += async (s, e) => await RefreshCashRegistersGridAsync();
            this.buttonSave.Click += async (s, e) => await ExecuteSaveCashRegisterAsync();
            this.buttonToggleStatus.Click += async (s, e) => await ExecuteToggleCashRegisterStatusAsync();
            this.buttonCancel.Click += (s, e) => ResetFormInputFields();
            this.dataGridViewRegisters.CellClick += (s, e) => SynchronizeSelectedRegisterToFormFields();
        }

        private async Task RefreshCashRegistersGridAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var cashRegisters = await _registerService.GetAllRegistersAsync();
                dataGridViewRegisters.DataSource = null;
                dataGridViewRegisters.DataSource = cashRegisters.ToList();
                UIHelper.FormatGrid(dataGridViewRegisters);
            }
        }
        /// <summary>
        /// Sincroniza la entidad SelectedRegisterToFormFields seleccionada con los campos de entrada de la interfaz.
        /// </summary>

        private void SynchronizeSelectedRegisterToFormFields()
        {
            if (dataGridViewRegisters.CurrentRow == null)
                return;

            var selectedCashRegister = (CashRegisterDto)dataGridViewRegisters.CurrentRow.DataBoundItem;
            _selectedCashRegisterId = selectedCashRegister.Id;
            numericUpDownRegisterNumber.Value = selectedCashRegister.Number;
            textBoxRegisterName.Text = selectedCashRegister.Name;
            textBoxDescription.Text = selectedCashRegister.Description ?? string.Empty;

            buttonSave.Text = "ACTUALIZAR";
            buttonToggleStatus.Enabled = true;
        }

        private void ResetFormInputFields()
        {
            _selectedCashRegisterId = 0;
            numericUpDownRegisterNumber.Value = 1;
            textBoxRegisterName.Clear();
            textBoxDescription.Clear();

            buttonSave.Text = "GUARDAR";
            buttonToggleStatus.Enabled = false;
            textBoxRegisterName.Focus();
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SaveCashRegister.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSaveCashRegisterAsync()
        {
            var cashRegister = new CashRegisterDto
            {
                Id = _selectedCashRegisterId,
                Number = (int)numericUpDownRegisterNumber.Value,
                Name = textBoxRegisterName.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),
                IsActive = true
            };

            using (new WaitCursorHelper(this))
            {
                var operationResult = await _registerService.UpsertCashRegisterAsync(cashRegister);
                UIHelper.ShowResult(operationResult, "Gestión de Cajas", async () =>
                {
                    ResetFormInputFields();
                    await RefreshCashRegistersGridAsync();
                });
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de ToggleCashRegisterStatus.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteToggleCashRegisterStatusAsync()
        {
            if (_selectedCashRegisterId == 0) 
                return;

            using (new WaitCursorHelper(this))
            {
                var operationResult = await _registerService.ToggleRegisterStatusAsync(_selectedCashRegisterId);
                UIHelper.ShowResult(operationResult, "Cajas", async () =>
                {
                    ResetFormInputFields();
                    await RefreshCashRegistersGridAsync();
                });
            }
        }
    }
}