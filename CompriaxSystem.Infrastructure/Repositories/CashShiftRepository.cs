using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class CashShiftRepository(ApplicationDbContext context) : ICashShiftRepository
    {
        /// <summary>
        /// Busca el turno abierto actualmente para un cajero específico.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <returns>El turno activo con sus movimientos y ventas.</returns>
        public async Task<CashShift?> GetActiveShiftByUserIdAsync(int userId)
        {
            return await context.CashShifts
                .Include(cs => cs.User)
                .Include(cs => cs.CashMovements)
                .Include(cs => cs.Sales)
                .ThenInclude(s => s.PaymentMethod)
                .FirstOrDefaultAsync(cs => cs.UserId == userId && cs.Status == CashShiftStatusesConstants.OPEN);
        }

        /// <summary>
        /// Recupera el turno abierto para una terminal de cobro específica.
        /// </summary>
        /// <param name="registerId">Id de la caja.</param>
        /// <returns>El turno activo asociado a la caja.</returns>
        public async Task<CashShift?> GetActiveShiftByRegisterIdAsync(int registerId)
        {
            return await context.CashShifts
                .Include(cs => cs.User)
                .Include(cs => cs.CashRegister)
                .FirstOrDefaultAsync(cs => cs.CashRegisterId == registerId && cs.Status == CashShiftStatusesConstants.OPEN);
        }

        /// <summary>
        /// Obtiene un turno por id cargando sus movimientos, ventas y métodos de pago.
        /// </summary>
        /// <param name="id">Id del turno.</param>
        /// <returns>La entidad del turno detallada.</returns>
        public async Task<CashShift?> GetByIdWithDetailsAsync(int id)
        {
            return await context.CashShifts
                .Include(cs => cs.User)
                .Include(cs => cs.CashMovements)
                .Include(cs => cs.Sales)
                .ThenInclude(s => s.PaymentMethod)
                .FirstOrDefaultAsync(cs => cs.Id == id);
        }

        /// <summary>
        /// Recupera el historial de turnos en un rango de fechas.
        /// </summary>
        /// <param name="start">Fecha de inicio.</param>
        /// <param name="end">Fecha de fin.</param>
        /// <returns>Colección de turnos históricos.</returns>
        public async Task<IEnumerable<CashShift>> GetHistoryAsync(DateTime start, DateTime end)
        {
            return await context.CashShifts
                .AsNoTracking()
                .Include(cs => cs.User)
                .Where(cs => cs.OpeningDate.Date >= start.Date && cs.OpeningDate.Date <= end.Date)
                .OrderByDescending(cs => cs.OpeningDate)
                .ToListAsync();
        }

        /// <summary>
        /// Lista todos los movimientos de efectivo (ingresos/egresos) de un turno.
        /// </summary>
        /// <param name="shiftId">ID del turno.</param>
        /// <returns>Colección de movimientos ordenados por fecha.</returns>
        public async Task<IEnumerable<CashMovement>> GetMovementsByShiftIdAsync(int shiftId)
        {
            return await context.CashMovements
                .AsNoTracking()
                .Include(cm => cm.User)
                .Where(cm => cm.CashShiftId == shiftId)
                .OrderByDescending(cm => cm.CreatedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Crea un nuevo turno de caja.
        /// </summary>
        /// <param name="shift">Entidad del turno.</param>
        public async Task AddAsync(CashShift shift) =>
            await context.CashShifts.AddAsync(shift);

        /// <summary>
        /// Actualiza el estado o saldos de un turno.
        /// </summary>
        /// <param name="shift">Entidad del turno.</param>
        public void Update(CashShift shift) =>
            context.CashShifts.Update(shift);

        /// <summary>
        /// Registra un nuevo movimiento de efectivo manual en un turno.
        /// </summary>
        /// <param name="movement">Entidad del movimiento.</param>
        public async Task AddMovementAsync(CashMovement movement) =>
            await context.CashMovements.AddAsync(movement);
    }
}