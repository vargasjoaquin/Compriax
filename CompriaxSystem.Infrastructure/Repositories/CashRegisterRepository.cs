using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class CashRegisterRepository(ApplicationDbContext context) : ICashRegisterRepository
    {
        public async Task<IEnumerable<CashRegister>> GetAllAsync()
        {
            return await context.CashRegisters
                .Include(cr => cr.CashShifts)
                .ThenInclude(cs => cs.User)
                .Where(cr => !cr.IsDeleted)
                .OrderBy(cr => cr.Number)
                .ToListAsync();
        }

        public async Task<CashRegister?> GetByIdAsync(int id)
        {
            return await context.CashRegisters
                .Include(cr => cr.CashShifts)
                .FirstOrDefaultAsync(cr => cr.Id == id);
        }

        public async Task<CashRegister?> GetByNumberAsync(int number)
        {
            return await context.CashRegisters
                .FirstOrDefaultAsync(cr => cr.Number == number && !cr.IsDeleted);
        }

        public async Task<bool> HasOpenShiftAsync(int cashRegisterId)
        {
            return await context.CashShifts
                .AnyAsync(cs => cs.CashRegisterId == cashRegisterId && cs.Status == "Abierta");
        }

        public async Task AddAsync(CashRegister register) =>
            await context.CashRegisters.AddAsync(register);

        public void Update(CashRegister register) =>
            context.CashRegisters.Update(register);

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}