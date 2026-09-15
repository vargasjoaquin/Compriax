using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Application.Services
{
    public class CashShiftService(IUnitOfWork unitOfWork, ICurrentUserService currentUser) : ICashShiftService
    {
        /// <summary>
        /// Recupera el turno activo correspondiente a la caja configurada en el contexto actual.
        /// </summary>
        /// <returns>Datos del turno abierto o null.</returns>
        public async Task<CashShiftDto?> GetCurrentActiveShiftAsync()
        {
            int cashRegisterId = currentUser.OperationalContext!.CashRegisterId;
            
            var cashShift = await unitOfWork.CashShifts.GetActiveShiftByRegisterIdAsync(cashRegisterId);

            if (cashShift == null)
                return null;
            
            return await BuildShiftDtoAsync(cashShift);
        }

        /// <summary>
        /// Registra la apertura de un turno de caja validando que no exista ya un turno abierto en la terminal.
        /// </summary>
        /// <param name="dto">Datos de apertura y saldo inicial.</param>
        /// <returns>Resultado del proceso de apertura.</returns>
        public async Task<OperationResult> OpenShiftAsync(CashShiftOpenDto dto)
        {
            if (dto.InitialCash < 0)
                return OperationResult.Failure("El fondo inicial de caja no puede ser negativo.");

            int currentUserId = currentUser.CurrentUser!.UserId;
            int cashRegisterId = currentUser.OperationalContext!.CashRegisterId;

            var existingCashShift = await unitOfWork.CashShifts.GetActiveShiftByRegisterIdAsync(cashRegisterId);
            
            if (existingCashShift != null)
                return OperationResult.Failure($"La caja actual ya tiene un turno abierto por el cajero '{existingCashShift.User?.Username}'. Debe cerrarlo antes de abrir uno nuevo.");

            var newCashShift = new CashShift
            {
                UserId = currentUserId,
                CashRegisterId = cashRegisterId,
                OpeningDate = DateTime.UtcNow,
                InitialCash = dto.InitialCash,
                Status = CashShiftStatuses.OPEN
            };

            await unitOfWork.CashShifts.AddAsync(newCashShift);
           
            bool operationSucceeded = await unitOfWork.CompleteAsync();

            if (operationSucceeded && currentUser.OperationalContext != null)
                currentUser.OperationalContext.ActiveShiftId = newCashShift.Id;

            return operationSucceeded
                ? OperationResult.Ok($"Turno de caja #{newCashShift.Id} abierto exitosamente con fondo de {dto.InitialCash:C2}.")
                : OperationResult.Failure("Error al registrar la apertura de caja.");
        }

        /// <summary>
        /// Registra un ingreso o egreso manual de efectivo en el turno de caja vigente.
        /// </summary>
        /// <param name="dto">Datos del movimiento de efectivo.</param>
        /// <returns>Resultado del registro del movimiento.</returns>
        public async Task<OperationResult> RegisterMovementAsync(CashMovementCreateDto dto)
        {
            if (dto.Amount <= 0)
                return OperationResult.Failure("El monto del movimiento debe ser mayor a $ 0.00.");

            if (string.IsNullOrWhiteSpace(dto.Description))
                return OperationResult.Failure("Debe ingresar una descripción para el movimiento.");

            int currentUserId = currentUser.CurrentUser!.UserId;
            int cashRegisterId = currentUser.OperationalContext!.CashRegisterId;

            var activeCashShift = await unitOfWork.CashShifts.GetActiveShiftByRegisterIdAsync(cashRegisterId);
            
            if (activeCashShift == null)
                return OperationResult.Failure("No hay ningún turno de caja abierto en esta terminal para registrar movimientos.");

            var cashMovement = new CashMovement
            {
                CashShiftId = activeCashShift.Id,
                UserId = currentUserId,
                MovementType = dto.MovementType,
                Amount = dto.Amount,
                Description = dto.Description.Trim(),
                CreatedAt = DateTime.UtcNow
            };

            await unitOfWork.CashShifts.AddMovementAsync(cashMovement);
            
            bool operationSucceeded = await unitOfWork.CompleteAsync();

            string movementTypeName = dto.MovementType == CashMovementType.CashIn ? "Ingreso de efectivo" : "Retiro de efectivo";
            
            return operationSucceeded
                ? OperationResult.Ok($"{movementTypeName} por {dto.Amount:C2} registrado con éxito.")
                : OperationResult.Failure("Error al registrar el movimiento.");
        }

        /// <summary>
        /// Calcula y consolida los totales de ventas y movimientos del turno activo para el arqueo.
        /// </summary>
        /// <returns>Un resumen detallado con el estado financiero actual de la caja.</returns>
        public async Task<CashShiftSummaryDto> GetCurrentShiftSummaryAsync()
        {
            int registerId = currentUser.OperationalContext?.CashRegisterId ?? 1;
            
            var cashShift = await unitOfWork.CashShifts.GetActiveShiftByRegisterIdAsync(registerId);

            if (cashShift == null)
            {
                return new CashShiftSummaryDto 
                {
                    CashierName = currentUser.CurrentUser!.FullName
                };
            }

            var cashMovements = (await unitOfWork.CashShifts.GetMovementsByShiftIdAsync(cashShift.Id)).ToList();
            var shiftSales = cashShift.Sales ?? new List<Sale>();

            decimal totalCashSales = shiftSales.Where(s => s.PaymentMethodId == 1).Sum(s => s.TotalAmount);
            decimal totalDebitSales = shiftSales.Where(s => s.PaymentMethodId == 2).Sum(s => s.TotalAmount);
            decimal totalCreditSales = shiftSales.Where(s => s.PaymentMethodId == 3).Sum(s => s.TotalAmount);
            decimal totalTransferSales = shiftSales.Where(s => s.PaymentMethodId == 4).Sum(s => s.TotalAmount);
            decimal totalQrSales = shiftSales.Where(s => s.PaymentMethodId == 5).Sum(s => s.TotalAmount);

            decimal totalManualCashIn = cashMovements.Where(m => m.MovementType == CashMovementType.CashIn).Sum(m => m.Amount);
            decimal totalManualCashOut = cashMovements.Where(m => m.MovementType == CashMovementType.CashOut).Sum(m => m.Amount);

            return new CashShiftSummaryDto
            {
                ShiftId = cashShift.Id,
                CashierName = $"{cashShift.User.LastName} {cashShift.User.FirstName}".Trim(),
                OpeningDate = cashShift.OpeningDate,
                CurrentDate = DateTime.Now,
                InitialCash = cashShift.InitialCash,
                TotalCashSales = totalCashSales,
                TotalDebitSales = totalDebitSales,
                TotalCreditSales = totalCreditSales,
                TotalTransferSales = totalTransferSales,
                TotalQrSales = totalQrSales,
                TotalManualCashIn = totalManualCashIn,
                TotalManualCashOut = totalManualCashOut,
                SalesCount = shiftSales.Count
            };
        }

        /// <summary>
        /// Cierra el turno de caja, calcula diferencias entre saldo esperado y real, y persiste el balance final.
        /// </summary>
        /// <param name="dto">Datos de cierre y efectivo contado.</param>
        /// <returns>Resultado del cierre del turno.</returns>
        public async Task<OperationResult> CloseShiftAsync(CashShiftCloseDto dto)
        {
            if (dto.RealCash < 0)
                return OperationResult.Failure("El monto contado en caja no puede ser negativo.");

            var cashShift = await unitOfWork.CashShifts.GetByIdWithDetailsAsync(dto.ShiftId);
            
            if (cashShift == null || cashShift.Status != "Abierta")
                return OperationResult.Failure("El turno especificado no existe o ya fue cerrado.");

            var shiftSales = new List<Sale>();
            
            var cashMovements = (await unitOfWork.CashShifts.GetMovementsByShiftIdAsync(cashShift.Id)).ToList();

            var summary = await GetCurrentShiftSummaryAsync();

            decimal totalCashSales = shiftSales.Where(s => s.PaymentMethodId == 1).Sum(s => s.TotalAmount);
            decimal totalDebitSales = shiftSales.Where(s => s.PaymentMethodId == 2).Sum(s => s.TotalAmount);
            decimal totalCreditSales = shiftSales.Where(s => s.PaymentMethodId == 3).Sum(s => s.TotalAmount);
            decimal totalTransferSales = shiftSales.Where(s => s.PaymentMethodId == 4).Sum(s => s.TotalAmount);
            decimal totalQrSales = shiftSales.Where(s => s.PaymentMethodId == 5).Sum(s => s.TotalAmount);

            decimal totalManualCashIn = cashMovements.Where(m => m.MovementType == CashMovementType.CashIn).Sum(m => m.Amount);
            decimal totalManualCashOut = cashMovements.Where(m => m.MovementType == CashMovementType.CashOut).Sum(m => m.Amount);

            decimal expectedCash = cashShift.InitialCash + totalCashSales + totalManualCashIn - totalManualCashOut;

            cashShift.ClosingDate = DateTime.UtcNow;
            cashShift.RealCash = dto.RealCash;
            cashShift.ExpectedCash = expectedCash;
            cashShift.Difference = dto.RealCash - expectedCash;
            cashShift.TotalCashSales = totalCashSales;
            cashShift.TotalDebitSales = totalDebitSales;
            cashShift.TotalCreditSales = totalCreditSales;
            cashShift.TotalTransferSales = totalTransferSales;
            cashShift.TotalQrSales = totalQrSales;
            cashShift.TotalManualCashIn = totalManualCashIn;
            cashShift.TotalManualCashOut = totalManualCashOut;
            cashShift.Status = CashShiftStatuses.CLOSED;
            cashShift.ClosingNotes = dto.ClosingNotes?.Trim();

            unitOfWork.CashShifts.Update(cashShift);

            bool operationSucceeded = await unitOfWork.CompleteAsync();

            if (operationSucceeded && currentUser.OperationalContext?.ActiveShiftId == cashShift.Id)
                currentUser.OperationalContext.ActiveShiftId = null;

            string differenceMessage;

            if (cashShift.Difference == 0)
            {
                differenceMessage = "Caja Cuadrada";
            }
            else if (cashShift.Difference > 0)
            {
                differenceMessage = $"Sobrante: +{cashShift.Difference:C2}";
            }
            else
            {
                differenceMessage = $"Faltante: {cashShift.Difference:C2}";
            }

            return operationSucceeded
                ? OperationResult.Ok($"Turno de caja cerrado exitosamente. Balance: {differenceMessage}.")
                : OperationResult.Failure("Error al persistir el cierre de caja.");
        }

        /// <summary>
        /// Obtiene el historial de turnos de caja cerrados entre dos fechas.
        /// </summary>
        /// <param name="start">Fecha de inicio.</param>
        /// <param name="end">Fecha de fin.</param>
        /// <returns>Colección de turnos históricos.</returns>
        public async Task<IEnumerable<CashShiftDto>> GetShiftHistoryAsync(DateTime startDate, DateTime endDate)
        {
            var shifts = await unitOfWork.CashShifts.GetHistoryAsync(startDate, endDate);
            
            var shiftHistory = new List<CashShiftDto>();

            foreach (var cashShift in shifts)
                shiftHistory.Add(await BuildShiftDtoAsync(cashShift));

            return shiftHistory;
        }

        /// <summary>
        /// Lista todos los movimientos de caja realizados en el turno actualmente abierto.
        /// </summary>
        /// <returns>Colección de movimientos (ingresos/egresos).</returns>
        public async Task<IEnumerable<CashMovementDto>> GetCurrentShiftMovementsAsync()
        {
            int registerId = currentUser.OperationalContext!.CashRegisterId;
            
            var activeCashShift = await unitOfWork.CashShifts.GetActiveShiftByRegisterIdAsync(registerId);

            if (activeCashShift == null)
                return Enumerable.Empty<CashMovementDto>();

            var cashMovements = await unitOfWork.CashShifts.GetMovementsByShiftIdAsync(activeCashShift.Id);

            return cashMovements.Select(cashMovement => new CashMovementDto
            {
                Id = cashMovement.Id,
                CashShiftId = cashMovement.CashShiftId,
                MovementType = cashMovement.MovementType,
                Amount = cashMovement.Amount,
                Description = cashMovement.Description,
                CreatedAt = cashMovement.CreatedAt,
                UserName = cashMovement.User!.Username
            });
        }

        /// <summary>
        /// Construye un DTO con la información detallada del turno de caja,
        /// incluyendo ventas, movimientos de efectivo y datos del cierre.
        /// </summary>
        /// <param name="cashShift">Turno de caja que se utilizará para construir el DTO.</param>
        /// <returns>DTO con la información detallada y los totales del turno de caja.</returns>
        private async Task<CashShiftDto> BuildShiftDtoAsync(CashShift cashShift)
        {
            var shiftWithDetails = await unitOfWork.CashShifts
                .GetByIdWithDetailsAsync(cashShift.Id) ?? cashShift;

            var shiftSales = shiftWithDetails.Sales ?? new List<Sale>();

            var cashMovements = (await unitOfWork.CashShifts
                .GetMovementsByShiftIdAsync(cashShift.Id)).ToList();

            bool isCashShiftClosed = cashShift.Status == CashShiftStatuses.CLOSED;

            return new CashShiftDto
            {
                Id = cashShift.Id,
                UserId = cashShift.UserId,
                UserName = $"{cashShift.User.LastName} {cashShift.User.FirstName}".Trim(),
                OpeningDate = cashShift.OpeningDate,
                ClosingDate = cashShift.ClosingDate,
                InitialCash = cashShift.InitialCash,
                RealCash = cashShift.RealCash,
                ExpectedCash = cashShift.ExpectedCash,
                Difference = cashShift.Difference,
                TotalCashSales = isCashShiftClosed ? cashShift.TotalCashSales : shiftSales.Where(s => s.PaymentMethodId == 1).Sum(s => s.TotalAmount),
                TotalDebitSales = isCashShiftClosed ? cashShift.TotalDebitSales : shiftSales.Where(s => s.PaymentMethodId == 2).Sum(s => s.TotalAmount),
                TotalCreditSales = isCashShiftClosed ? cashShift.TotalCreditSales : shiftSales.Where(s => s.PaymentMethodId == 3).Sum(s => s.TotalAmount),
                TotalTransferSales = isCashShiftClosed ? cashShift.TotalTransferSales : shiftSales.Where(s => s.PaymentMethodId == 4).Sum(s => s.TotalAmount),
                TotalQrSales = isCashShiftClosed ? cashShift.TotalQrSales : shiftSales.Where(s => s.PaymentMethodId == 5).Sum(s => s.TotalAmount),
                TotalManualCashIn = isCashShiftClosed ? cashShift.TotalManualCashIn : cashMovements.Where(m => m.MovementType == CashMovementType.CashIn).Sum(m => m.Amount),
                TotalManualCashOut = isCashShiftClosed ? cashShift.TotalManualCashOut : cashMovements.Where(m => m.MovementType == CashMovementType.CashOut).Sum(m => m.Amount),
                Status = cashShift.Status,
                ClosingNotes = cashShift.ClosingNotes
            };
        }
    }
}