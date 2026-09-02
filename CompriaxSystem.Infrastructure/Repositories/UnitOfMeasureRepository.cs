using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class UnitOfMeasureRepository(ApplicationDbContext context) : IUnitOfMeasureRepository
    {
        public async Task<IEnumerable<UnitsOfMeasure>> GetAllAsync() =>
            await context.UnitsOfMeasure.ToListAsync();

        public async Task<UnitsOfMeasure?> GetByIdAsync(int id) =>
            await context.UnitsOfMeasure.FindAsync(id);

        public async Task AddAsync(UnitsOfMeasure unit) =>
            await context.UnitsOfMeasure.AddAsync(unit);

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}