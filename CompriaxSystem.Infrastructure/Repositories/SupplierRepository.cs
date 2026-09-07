using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class SupplierRepository(ApplicationDbContext context) : ISupplierRepository
    {
        public async Task<IEnumerable<Supplier>> GetAllAsync() =>
            await context.Suppliers.ToListAsync();

        public async Task<Supplier?> GetByIdAsync(int id) =>
            await context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);

        public async Task<Supplier?> GetDeletedByIdAsync(int id) =>
            await context.Suppliers
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted);

        public async Task<IEnumerable<Supplier>> GetAllDeletedAsync() =>
            await context.Suppliers
                .IgnoreQueryFilters()
                .Where(s => s.IsDeleted)
                .ToListAsync();

        public async Task AddAsync(Supplier supplier) =>
            await context.Suppliers.AddAsync(supplier);

        public void Update(Supplier supplier) =>
            context.Suppliers.Update(supplier);

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}