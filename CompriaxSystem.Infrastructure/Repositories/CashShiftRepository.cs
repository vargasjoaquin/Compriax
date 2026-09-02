using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class CashShiftRepository(ApplicationDbContext context) : ICashShiftRepository
    {
        public async Task<CashShift?> GetActiveShiftByUserIdAsync(int userId)
        {
            return await context.CashShifts
                .Include(cs => cs.User)
                .Include(cs => cs.CashMovements)
                .Include(cs => cs.Sales)
                .ThenInclude(s => s.PaymentMethod)
                .FirstOrDefaultAsync(cs => cs.UserId == userId && cs.Status == "Abierta");
        }

        public async Task<CashShift?> GetActiveShiftByRegisterIdAsync(int registerId)
        {
            return await context.CashShifts
                .Include(cs => cs.User)
                .Include(cs => cs.CashRegister)
                .FirstOrDefaultAsync(cs => cs.CashRegisterId == registerId && cs.Status == "Abierta");
        }

        public async Task<CashShift?> GetByIdWithDetailsAsync(int id)
        {
            return await context.CashShifts
                .Include(cs => cs.User)
                .Include(cs => cs.CashMovements)
                .Include(cs => cs.Sales)
                .ThenInclude(s => s.PaymentMethod)
                .FirstOrDefaultAsync(cs => cs.Id == id);
        }

        public async Task<IEnumerable<CashShift>> GetHistoryAsync(DateTime start, DateTime end)
        {
            return await context.CashShifts
                .AsNoTracking()
                .Include(cs => cs.User)
                .Where(cs => cs.OpeningDate.Date >= start.Date && cs.OpeningDate.Date <= end.Date)
                .OrderByDescending(cs => cs.OpeningDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<CashMovement>> GetMovementsByShiftIdAsync(int shiftId)
        {
            return await context.CashMovements
                .AsNoTracking()
                .Include(cm => cm.User)
                .Where(cm => cm.CashShiftId == shiftId)
                .OrderByDescending(cm => cm.CreatedAt)
                .ToListAsync();
        }

        public async Task AddAsync(CashShift shift) =>
            await context.CashShifts.AddAsync(shift);

        public void Update(CashShift shift) =>
            context.CashShifts.Update(shift);

        public async Task AddMovementAsync(CashMovement movement) =>
            await context.CashMovements.AddAsync(movement);
    }
}