using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Application.Services
{
    public class CashShiftService(
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser) : ICashShiftService
    {

        /// <summary>
        /// Recupera el turno activo correspondiente a la caja configurada en el contexto actual.
        /// </summary>
        /// <returns>Datos del turno abierto o null.</returns>
        public async Task<CashShiftDto?> GetCurrentActiveShiftAsync()
        {
            int registerId = currentUser.OperationalContext!.CashRegisterId;
            var shift = await unitOfWork.CashShifts.GetActiveShiftByRegisterIdAsync(registerId);

            if (shift == null)
                return null;
            
            return await BuildShiftDtoAsync(shift);
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
            int registerId = currentUser.OperationalContext!.CashRegisterId;

            var existingShift = await unitOfWork.CashShifts.GetActiveShiftByRegisterIdAsync(registerId);
            
            if (existingShift != null)
                return OperationResult.Failure($"La caja actual ya tiene un turno abierto por el cajero '{existingShift.User?.Username}'. Debe cerrarlo antes de abrir uno nuevo.");

            var newShift = new CashShift
            {
                UserId = currentUserId,
                CashRegisterId = registerId,
                OpeningDate = DateTime.UtcNow,
                InitialCash = dto.InitialCash,
                Status = CashShiftStatuses.OPEN
            };

            await unitOfWork.CashShifts.AddAsync(newShift);
            bool success = await unitOfWork.CompleteAsync();

            if (success && currentUser.OperationalContext != null)
                currentUser.OperationalContext.ActiveShiftId = newShift.Id;

            return success
                ? OperationResult.Ok($"Turno de caja #{newShift.Id} abierto exitosamente con fondo de {dto.InitialCash:C2}.")
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
            int registerId = currentUser.OperationalContext!.CashRegisterId;

            var activeShift = await unitOfWork.CashShifts.GetActiveShiftByRegisterIdAsync(registerId);
            
            if (activeShift == null)
                return OperationResult.Failure("No hay ningún turno de caja abierto en esta terminal para registrar movimientos.");

            var movement = new CashMovement
            {
                CashShiftId = activeShift.Id,
                UserId = currentUserId,
                MovementType = dto.MovementType,
                Amount = dto.Amount,
                Description = dto.Description.Trim(),
                CreatedAt = DateTime.UtcNow
            };

            await unitOfWork.CashShifts.AddMovementAsync(movement);
            bool success = await unitOfWork.CompleteAsync();

            string typeName = dto.MovementType == CashMovementType.CashIn ? "Ingreso de efectivo" : "Retiro de efectivo";
            return success
                ? OperationResult.Ok($"{typeName} por {dto.Amount:C2} registrado con éxito.")
                : OperationResult.Failure("Error al registrar el movimiento.");
        }

        /// <summary>
        /// Calcula y consolida los totales de ventas y movimientos del turno activo para el arqueo.
        /// </summary>
        /// <returns>Un resumen detallado con el estado financiero actual de la caja.</returns>
        public async Task<CashShiftSummaryDto> GetCurrentShiftSummaryAsync()
        {
            int registerId = currentUser.OperationalContext?.CashRegisterId ?? 1;
            var shift = await unitOfWork.CashShifts.GetActiveShiftByRegisterIdAsync(registerId);

            if (shift == null)
                return new CashShiftSummaryDto { CashierName = currentUser.CurrentUser!.FullName};

            var movements = (await unitOfWork.CashShifts.GetMovementsByShiftIdAsync(shift.Id)).ToList();
            var sales = shift.Sales ?? new List<Sale>();

            decimal cashSales = sales.Where(s => s.PaymentMethodId == 1).Sum(s => s.TotalAmount);
            decimal debitSales = sales.Where(s => s.PaymentMethodId == 2).Sum(s => s.TotalAmount);
            decimal creditSales = sales.Where(s => s.PaymentMethodId == 3).Sum(s => s.TotalAmount);
            decimal transferSales = sales.Where(s => s.PaymentMethodId == 4).Sum(s => s.TotalAmount);
            decimal qrSales = sales.Where(s => s.PaymentMethodId == 5).Sum(s => s.TotalAmount);

            decimal manualIn = movements.Where(m => m.MovementType == CashMovementType.CashIn).Sum(m => m.Amount);
            decimal manualOut = movements.Where(m => m.MovementType == CashMovementType.CashOut).Sum(m => m.Amount);

            return new CashShiftSummaryDto
            {
                ShiftId = shift.Id,
                CashierName = $"{shift.User.LastName} {shift.User.FirstName}".Trim(),
                OpeningDate = shift.OpeningDate,
                CurrentDate = DateTime.Now,
                InitialCash = shift.InitialCash,
                TotalCashSales = cashSales,
                TotalDebitSales = debitSales,
                TotalCreditSales = creditSales,
                TotalTransferSales = transferSales,
                TotalQrSales = qrSales,
                TotalManualCashIn = manualIn,
                TotalManualCashOut = manualOut,
                SalesCount = sales.Count
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

            var shift = await unitOfWork.CashShifts.GetByIdWithDetailsAsync(dto.ShiftId);
            
            if (shift == null || shift.Status != "Abierta")
                return OperationResult.Failure("El turno especificado no existe o ya fue cerrado.");

            var sales = new List<Sale>();
            var movements = (await unitOfWork.CashShifts.GetMovementsByShiftIdAsync(shift.Id)).ToList();

            var summary = await GetCurrentShiftSummaryAsync();

            decimal cashSales = sales.Where(s => s.PaymentMethodId == 1).Sum(s => s.TotalAmount);
            decimal debitSales = sales.Where(s => s.PaymentMethodId == 2).Sum(s => s.TotalAmount);
            decimal creditSales = sales.Where(s => s.PaymentMethodId == 3).Sum(s => s.TotalAmount);
            decimal transferSales = sales.Where(s => s.PaymentMethodId == 4).Sum(s => s.TotalAmount);
            decimal qrSales = sales.Where(s => s.PaymentMethodId == 5).Sum(s => s.TotalAmount);

            decimal manualIn = movements.Where(m => m.MovementType == CashMovementType.CashIn).Sum(m => m.Amount);
            decimal manualOut = movements.Where(m => m.MovementType == CashMovementType.CashOut).Sum(m => m.Amount);

            decimal expectedCashInDrawer = shift.InitialCash + cashSales + manualIn - manualOut;

            shift.ClosingDate = DateTime.UtcNow;
            shift.RealCash = dto.RealCash;
            shift.ExpectedCash = expectedCashInDrawer;
            shift.Difference = dto.RealCash - expectedCashInDrawer;
            shift.TotalCashSales = cashSales;
            shift.TotalDebitSales = debitSales;
            shift.TotalCreditSales = creditSales;
            shift.TotalTransferSales = transferSales;
            shift.TotalQrSales = qrSales;
            shift.TotalManualCashIn = manualIn;
            shift.TotalManualCashOut = manualOut;
            shift.Status = CashShiftStatuses.CLOSED;
            shift.ClosingNotes = dto.ClosingNotes?.Trim();

            unitOfWork.CashShifts.Update(shift);
            bool success = await unitOfWork.CompleteAsync();

            if (success && currentUser.OperationalContext?.ActiveShiftId == shift.Id)
                currentUser.OperationalContext.ActiveShiftId = null;

            string diffMsg = shift.Difference == 0
                ? "Caja Cuadrada"
                : (shift.Difference > 0 ? $"Sobrante: +{shift.Difference:C2}" : $"Faltante: {shift.Difference:C2}");

            return success
                ? OperationResult.Ok($"Turno de caja cerrado exitosamente. Balance: {diffMsg}.")
                : OperationResult.Failure("Error al persistir el cierre de caja.");
        }

        /// <summary>
        /// Obtiene el historial de turnos de caja cerrados entre dos fechas.
        /// </summary>
        /// <param name="start">Fecha de inicio.</param>
        /// <param name="end">Fecha de fin.</param>
        /// <returns>Colección de turnos históricos.</returns>
        public async Task<IEnumerable<CashShiftDto>> GetShiftHistoryAsync(DateTime start, DateTime end)
        {
            var shifts = await unitOfWork.CashShifts.GetHistoryAsync(start, end);
            var result = new List<CashShiftDto>();

            foreach (var shift in shifts)
                result.Add(await BuildShiftDtoAsync(shift));

            return result;
        }

        /// <summary>
        /// Lista todos los movimientos de caja realizados en el turno actualmente abierto.
        /// </summary>
        /// <returns>Colección de movimientos (ingresos/egresos).</returns>
        public async Task<IEnumerable<CashMovementDto>> GetCurrentShiftMovementsAsync()
        {
            int registerId = currentUser.OperationalContext!.CashRegisterId;
            var shift = await unitOfWork.CashShifts.GetActiveShiftByRegisterIdAsync(registerId);

            if (shift == null)
                return Enumerable.Empty<CashMovementDto>();

            var movements = await unitOfWork.CashShifts.GetMovementsByShiftIdAsync(shift.Id);

            return movements.Select(m => new CashMovementDto
            {
                Id = m.Id,
                CashShiftId = m.CashShiftId,
                MovementType = m.MovementType,
                Amount = m.Amount,
                Description = m.Description,
                CreatedAt = m.CreatedAt,
                UserName = m.User!.Username
            });
        }

        private async Task<CashShiftDto> BuildShiftDtoAsync(CashShift shift)
        {
            var fullShift = await unitOfWork.CashShifts.GetByIdWithDetailsAsync(shift.Id) ?? shift;
            var sales = fullShift.Sales ?? new List<Sale>();
            var movements = (await unitOfWork.CashShifts.GetMovementsByShiftIdAsync(shift.Id)).ToList();

            bool isClosed = shift.Status == CashShiftStatuses.CLOSED;

            return new CashShiftDto
            {
                Id = shift.Id,
                UserId = shift.UserId,
                UserName = $"{shift.User.LastName}{shift.User.FirstName}".Trim(),
                OpeningDate = shift.OpeningDate,
                ClosingDate = shift.ClosingDate,
                InitialCash = shift.InitialCash,
                RealCash = shift.RealCash,
                ExpectedCash = shift.ExpectedCash,
                Difference = shift.Difference,
                TotalCashSales = isClosed ? shift.TotalCashSales : sales.Where(s => s.PaymentMethodId == 1).Sum(s => s.TotalAmount),
                TotalDebitSales = isClosed ? shift.TotalDebitSales : sales.Where(s => s.PaymentMethodId == 2).Sum(s => s.TotalAmount),
                TotalCreditSales = isClosed ? shift.TotalCreditSales : sales.Where(s => s.PaymentMethodId == 3).Sum(s => s.TotalAmount),
                TotalTransferSales = isClosed ? shift.TotalTransferSales : sales.Where(s => s.PaymentMethodId == 4).Sum(s => s.TotalAmount),
                TotalQrSales = isClosed ? shift.TotalQrSales : sales.Where(s => s.PaymentMethodId == 5).Sum(s => s.TotalAmount),
                TotalManualCashIn = isClosed ? shift.TotalManualCashIn : movements.Where(m => m.MovementType == CashMovementType.CashIn).Sum(m => m.Amount),
                TotalManualCashOut = isClosed ? shift.TotalManualCashOut : movements.Where(m => m.MovementType == CashMovementType.CashOut).Sum(m => m.Amount),
                Status = shift.Status,
                ClosingNotes = shift.ClosingNotes
            };
        }
    }
}