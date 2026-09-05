using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Enums;
using CompriaxSystem.WinFormsUI.Helpers;
using Microsoft.Extensions.DependencyInjection;
using static CompriaxSystem.WinFormsUI.Helpers.FormBlindCashCountDialog;

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

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnOpenShift.Click += async (s, e) => await ExecuteOpenShiftAction();
            this.btnCashIn.Click += async (s, e) => await ExecuteRegisterManualMovementAction(CashMovementType.CashIn);
            this.btnCashOut.Click += async (s, e) => await ExecuteRegisterManualMovementAction(CashMovementType.CashOut);
            this.btnPrintX.Click += async (s, e) => await ExecutePrintShiftTicketAction(isZClose: false);
            this.btnCloseShiftZ.Click += async (s, e) => await ExecuteCloseShiftZAction();
        }

        public async Task InitializeFormAsync()
        {
            numInitialCash.Minimum = -100000000m;

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

            UIHelper.FormatGrid(dgvMovements);
            await RefreshShiftDataAsync();
        }

        private async Task RefreshShiftDataAsync()
        {
            using (new WaitCursorHelper(this))
            {
                _currentShift = await _cashShiftService.GetCurrentActiveShiftAsync();

                if (_currentShift == null)
                {
                    pnlOpenShift.Visible = true;
                    pnlActiveShift.Visible = false;
                    dgvMovements.DataSource = null;
                    numInitialCash.Value = 0;
                    numInitialCash.Focus();
                }
                else
                {
                    pnlOpenShift.Visible = false;
                    pnlActiveShift.Visible = true;

                    DateTime localOpening = _currentShift.OpeningDate.Kind == DateTimeKind.Utc
                        ? _currentShift.OpeningDate.ToLocalTime()
                        : _currentShift.OpeningDate;

                    lblShiftStatus.Text = $"🟢 TURNO ABIERTO #{_currentShift.Id} ({localOpening:dd/MM/yyyy HH:mm}) - {_currentShift.UserName}";
                    lblFondoInicialVal.Text = $"Fondo Inicial: {_currentShift.InitialCash:C2}";
                    lblVentasEfectivoVal.Text = $"Ventas en Efectivo: {_currentShift.TotalCashSales:C2}";

                    decimal digitalSales = _currentShift.TotalDebitSales + _currentShift.TotalCreditSales + _currentShift.TotalTransferSales + _currentShift.TotalQrSales;
                    lblVentasTarjetasVal.Text = $"Tarjetas / QR / Transf: {digitalSales:C2}";
                    lblTotalFacturadoVal.Text = $"Total Facturado en Turno: {_currentShift.TotalTurnover:C2}";
                    lblEfectivoEsperadoVal.Text = $"EFECTIVO EN GAVETA: {_currentShift.CurrentSystemCash:C2}";

                    var movements = await _cashShiftService.GetCurrentShiftMovementsAsync();
                    dgvMovements.DataSource = null;
                    dgvMovements.DataSource = movements.ToList();
                    UIHelper.FormatGrid(dgvMovements);
                }
            }
        }

        private async Task ExecuteOpenShiftAction()
        {
            if (numInitialCash.Value < 0 || numInitialCash.Text.Contains('-'))
            {
                UIHelper.WarnMessage(this, "El fondo inicial de caja no puede ser negativo. Ingrese un valor igual o mayor a $ 0,00.", "Monto Inválido");
                numInitialCash.Select(0, numInitialCash.Text.Length);
                numInitialCash.Focus();
                return;
            }

            var dto = new CashShiftOpenDto { InitialCash = numInitialCash.Value };

            using (new WaitCursorHelper(this))
            {
                var result = await _cashShiftService.OpenShiftAsync(dto);
                UIHelper.ShowResult(result, "Apertura de Caja", async () =>
                {
                    await RefreshShiftDataAsync();
                });
            }
        }

        private async Task ExecuteRegisterManualMovementAction(CashMovementType type)
        {
            string typeTitle = type == CashMovementType.CashIn ? "Ingreso Manual de Dinero" : "Retiro / Egreso de Dinero";
            string prompt = type == CashMovementType.CashIn
                ? "Ingrese el monto a incorporar en la caja:"
                : "Ingrese el monto a retirar de la caja:";

            using var inputForm = new FormPromptDialog(typeTitle, prompt);
            
            if (inputForm.ShowDialog(this) == DialogResult.OK)
            {
                var dto = new CashMovementCreateDto
                {
                    MovementType = type,
                    Amount = inputForm.EnteredAmount,
                    Description = inputForm.EnteredDescription
                };

                using (new WaitCursorHelper(this))
                {
                    var result = await _cashShiftService.RegisterMovementAsync(dto);
                    UIHelper.ShowResult(result, typeTitle, async () =>
                    {
                        await RefreshShiftDataAsync();
                    });
                }
            }
        }

        private async Task ExecutePrintShiftTicketAction(bool isZClose)
        {
            if (_currentShift == null)
            {
                UIHelper.WarnMessage(this, "No hay ningún turno de caja abierto para emitir el informe.", "Aviso");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                var summary = await _cashShiftService.GetCurrentShiftSummaryAsync();
                byte[] ticketBytes = await _documentService.GenerateCashShiftTicketAsync(summary, isZClose);

                string docTitle = isZClose ? $"Cierre_Z_Turno_{summary.ShiftId}.pdf" : $"Cierre_X_Turno_{summary.ShiftId}.pdf";
                await FileExportHelper.SaveAndOpenPdfAsync(this, ticketBytes, docTitle, "Informe de Caja");
            }
        }

        private async Task ExecuteCloseShiftZAction()
        {
            if (_currentShift == null) 
                return;

            var summary = await _cashShiftService.GetCurrentShiftSummaryAsync();

            using var countDialog = new FormBlindCashCountDialog(summary.ExpectedCashInDrawer);
            
            if (countDialog.ShowDialog(this) == DialogResult.OK)
            {
                var closeDto = new CashShiftCloseDto
                {
                    ShiftId = _currentShift.Id,
                    RealCash = countDialog.CountedCash,
                    ClosingNotes = countDialog.Notes
                };

                using (new WaitCursorHelper(this))
                {
                    var result = await _cashShiftService.CloseShiftAsync(closeDto);

                    if (result.Success)
                    {
                        summary.RealCashCounted = countDialog.CountedCash;

                        try
                        {
                            byte[] ticketBytes = await _documentService.GenerateCashShiftTicketAsync(summary, isZClose: true);
                            await FileExportHelper.SaveAndOpenPdfAsync(this, ticketBytes, $"Cierre_Z_Turno_{summary.ShiftId}.pdf", "Ticket de Cierre Z");
                        }
                        catch { }

                        UIHelper.ShowResult(result, "Cierre de Caja Finalizado", async () =>
                        {
                            await RefreshShiftDataAsync();
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