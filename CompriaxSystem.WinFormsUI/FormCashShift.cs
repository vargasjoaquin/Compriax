using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Enums;
using CompriaxSystem.WinFormsUI.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormCashShift : Form
    {
        private readonly ICashShiftService _cashShiftService;
        private readonly IDocumentService _documentService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICurrentUserService _currentUserService;
        private CashShiftDto? _currentShift;

        public FormCashShift(
            ICashShiftService cashShiftService,
            IDocumentService documentService,
            IServiceProvider serviceProvider,
            ICurrentUserService currentUserService)
        {
            _cashShiftService = cashShiftService;
            _documentService = documentService;
            _serviceProvider = serviceProvider;
            _currentUserService = currentUserService;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelOpenShift);
            UIThemeHelper.ApplyCardStyle(panelActiveShift);

            this.Load += async (s, e) => await InitializeCashShiftFormAsync();
            this.buttonOpenShift.Click += async (s, e) => await ExecuteOpenCashShiftAsync();
            this.buttonRegisterCashIn.Click += async (s, e) => await ExecuteRegisterManualCashMovementAsync(CashMovementType.CashIn);
            this.buttonRegisterCashOut.Click += async (s, e) => await ExecuteRegisterManualCashMovementAsync(CashMovementType.CashOut);
            this.buttonPrintPartialCloseX.Click += async (s, e) => await ExecutePrintCashShiftTicketAsync(isZClose: false);
            this.buttonCloseShiftZ.Click += async (s, e) => await ExecuteCloseShiftAndBlindCountAsync();
            this.dataGridViewMovements.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dataGridViewMovements, e);
        }
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializeCashShiftFormAsync()
        {
            numericUpDownInitialCash.Minimum = -100000000m;

            if (!_currentUserService.HasRegisterAssigned)
            {
                var selectForm = _serviceProvider.GetRequiredService<FormSelectCashRegister>();

                if (selectForm.ShowDialog(this) != DialogResult.OK)
                {
                    UIHelper.WarnMessage(this, "Debe seleccionar una caja para poder gestionar o consultar turnos.", "Caja Requerida");
                    this.BeginInvoke(new Action(this.Close));
                    return;
                }
            }

            DataGridViewHelper.ApplyStyle(dataGridViewMovements);
            await RefreshActiveShiftDataAsync();
        }

        private async Task RefreshActiveShiftDataAsync()
        {
            using (new WaitCursorHelper(this))
            {
                _currentShift = await _cashShiftService.GetCurrentActiveShiftAsync();

                if (_currentShift == null)
                {
                    panelOpenShift.Visible = true;
                    panelActiveShift.Visible = false;
                    dataGridViewMovements.DataSource = null;
                    numericUpDownInitialCash.Value = 0;
                    numericUpDownInitialCash.Focus();
                }
                else
                {
                    panelOpenShift.Visible = false;
                    panelActiveShift.Visible = true;

                    DateTime openingDateTime = _currentShift.OpeningDate.Kind == DateTimeKind.Utc
                        ? _currentShift.OpeningDate.ToLocalTime()
                        : _currentShift.OpeningDate;

                    labelShiftStatus.Text = $"TURNO ABIERTO #{_currentShift.Id} ({openingDateTime:dd/MM/yyyy HH:mm}) - {_currentShift.UserName}";
                    labelShiftStatus.ImageAlign = ContentAlignment.MiddleLeft;

                    labelInitialCashValue.Text = $"Fondo Inicial: {_currentShift.InitialCash:C2}";
                    labelCashSalesValue.Text = $"Ventas en Efectivo: {_currentShift.TotalCashSales:C2}";

                    decimal totalDigitalSales = _currentShift.TotalDebitSales + _currentShift.TotalCreditSales + _currentShift.TotalTransferSales + _currentShift.TotalQrSales;
                    labelCardSalesValue.Text = $"Tarjetas / QR / Transf: {totalDigitalSales:C2}";
                    labelTotalTurnoverValue.Text = $"Total Facturado en Turno: {_currentShift.TotalTurnover:C2}";
                    labelExpectedCashValue.Text = $"EFECTIVO EN GAVETA: {_currentShift.CurrentSystemCash:C2}";

                    var shiftMovementsList = await _cashShiftService.GetCurrentShiftMovementsAsync();
                    dataGridViewMovements.DataSource = null;
                    dataGridViewMovements.DataSource = shiftMovementsList.ToList();
                    DataGridViewHelper.ApplyStyle(dataGridViewMovements);
                }
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de OpenCashShift.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteOpenCashShiftAsync()
        {
            if (numericUpDownInitialCash.Value < 0)
            {
                UIHelper.WarnMessage(this, "El fondo inicial de caja no puede ser negativo.", "Monto Inválido");
                numericUpDownInitialCash.Select(0, numericUpDownInitialCash.Text.Length);
                numericUpDownInitialCash.Focus();
                return;
            }

            var dto = new CashShiftOpenDto { InitialCash = numericUpDownInitialCash.Value };

            using (new WaitCursorHelper(this))
            {
                var result = await _cashShiftService.OpenShiftAsync(dto);
                UIHelper.ShowResult(result, "Apertura de Caja", async () =>
                {
                    await RefreshActiveShiftDataAsync();
                });
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de RegisterManualCashMovement.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteRegisterManualCashMovementAsync(CashMovementType type)
        {
            string dialogTitle = type == CashMovementType.CashIn ? "Ingreso Manual de Dinero" : "Retiro / Egreso de Dinero";
            string dialogPromptMessage = type == CashMovementType.CashIn
                ? "Ingrese el monto a incorporar en la caja:"
                : "Ingrese el monto a retirar de la caja:";

            using var promptDialog = new FormBlindCashCountDialog.FormPromptDialog(dialogTitle, dialogPromptMessage);

            if (promptDialog.ShowDialog(this) == DialogResult.OK)
            {
                var dto = new CashMovementCreateDto
                {
                    MovementType = type,
                    Amount = promptDialog.EnteredAmount,
                    Description = promptDialog.EnteredDescription
                };

                using (new WaitCursorHelper(this))
                {
                    var result = await _cashShiftService.RegisterMovementAsync(dto);
                    UIHelper.ShowResult(result, dialogTitle, async () =>
                    {
                        await RefreshActiveShiftDataAsync();
                    });
                }
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de PrintCashShiftTicket.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecutePrintCashShiftTicketAsync(bool isZClose)
        {
            if (_currentShift == null)
            {
                UIHelper.WarnMessage(this, "No hay ningún turno de caja abierto para emitir el informe.", "Aviso");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                var cashShiftSummary = await _cashShiftService.GetCurrentShiftSummaryAsync();
                byte[] generatedTicketPdfBytes = await _documentService.GenerateCashShiftTicketAsync(cashShiftSummary, isZClose);

                string documentPdfTitle = isZClose ? $"Cierre_Z_Turno_{cashShiftSummary.ShiftId}.pdf" : $"Cierre_X_Turno_{cashShiftSummary.ShiftId}.pdf";
                await FileExportHelper.SaveAndOpenPdfAsync(this, generatedTicketPdfBytes, documentPdfTitle, "Informe de Caja");
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de CloseShiftAndBlindCount.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteCloseShiftAndBlindCountAsync()
        {
            if (_currentShift == null)
                return;

            var cashShiftSummary = await _cashShiftService.GetCurrentShiftSummaryAsync();

            using var blindCountDialog = new FormBlindCashCountDialog(cashShiftSummary.ExpectedCashInDrawer);

            if (blindCountDialog.ShowDialog(this) == DialogResult.OK)
            {
                var cashShiftCloseDto = new CashShiftCloseDto
                {
                    ShiftId = _currentShift.Id,
                    RealCash = blindCountDialog.CountedCash,
                    ClosingNotes = blindCountDialog.Notes
                };

                using (new WaitCursorHelper(this))
                {
                    var result = await _cashShiftService.CloseShiftAsync(cashShiftCloseDto);

                    if (result.Success)
                    {
                        cashShiftSummary.RealCashCounted = blindCountDialog.CountedCash;

                        try
                        {
                            byte[] generatedTicketPdfBytes = await _documentService.GenerateCashShiftTicketAsync(cashShiftSummary, isZClose: true);
                            await FileExportHelper.SaveAndOpenPdfAsync(this, generatedTicketPdfBytes, $"Cierre_Z_Turno_{cashShiftSummary.ShiftId}.pdf", "Ticket de Cierre Z");
                        }
                        catch { }

                        UIHelper.ShowResult(result, "Cierre de Caja Finalizado", async () =>
                        {
                            await RefreshActiveShiftDataAsync();
                        });
                    }
                    else
                    {
                        UIHelper.ShowResult(result, "Error en Cierre de Caja");
                    }
                }
            }
        }
    }
}