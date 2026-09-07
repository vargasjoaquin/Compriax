using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class PurchaseRepository(ApplicationDbContext context) : IPurchaseRepository
    {
        public async Task AddAsync(Purchase purchase) =>
            await context.Purchases.AddAsync(purchase);

        public async Task<Purchase?> GetByIdWithDetailsAsync(int id) =>
            await context.Purchases
                .Include(p => p.Supplier)
                .Include(p => p.PurchaseItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Purchase>> GetHistoryAsync(DateTime start, DateTime end) =>
            await context.Purchases
                .Include(p => p.Supplier)
                .Include(p => p.DocumentType)
                .Include(p => p.User)
                .Where(p => p.CreatedAt >= start && p.CreatedAt <= end)
                .ToListAsync();

        public async Task<string> GetLastDocumentNumberAsync(int documentTypeId)
        {
            var lastNumber = await context.Purchases
                .AsNoTracking()
                .Where(p => p.DocumentTypeId == documentTypeId)
                .OrderByDescending(p => p.Id)
                .Select(p => p.DocumentNumber)
                .FirstOrDefaultAsync();

            return lastNumber;
        }

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}