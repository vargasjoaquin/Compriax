using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class SaleRepository(ApplicationDbContext context) : ISaleRepository
    {
        public async Task AddAsync(Sale sale) => await context.Sales.AddAsync(sale);

        public async Task<string> GetLastDocumentNumberAsync(int documentTypeId)
        {
            var last = await context.Sales
                .FromSqlRaw(@"SELECT TOP 1 * FROM Sales WITH (UPDLOCK, HOLDLOCK) 
                              WHERE DocumentTypeId = {0} 
                              ORDER BY Id DESC", documentTypeId)
                .AsNoTracking()
                .Select(s => s.DocumentNumber)
                .FirstOrDefaultAsync();

            return last ?? "00000000";
        }

        public async Task<bool> SaveChangesAsync() => await context.SaveChangesAsync() > 0;

        public async Task<IEnumerable<Sale>> GetHistoryAsync(DateTime start, DateTime end, int? cashRegisterId = null)
        {
            var query = context.Sales
                .AsNoTracking()
                .Include(s => s.CashRegister)
                .Include(s => s.DocumentType)
                .Include(s => s.Customer)
                .Include(s => s.User)
                .Include(s => s.SaleItems)
                    .ThenInclude(si => si.Product)
                        .ThenInclude(p => p.Category)
                .Where(s => s.CreatedAt >= start && s.CreatedAt < end);

            if (cashRegisterId.HasValue && cashRegisterId.Value > 0)
                query = query.Where(s => s.CashRegisterId == cashRegisterId.Value);

            return await query.OrderByDescending(s => s.CreatedAt).ToListAsync();
        }

        public async Task<Sale?> GetByIdWithDetailsAsync(int id)
        {
            return await context.Sales
                .AsNoTracking()
                .Include(s => s.CashRegister)
                .Include(s => s.DocumentType)
                .Include(s => s.Customer)
                .Include(s => s.User)
                .Include(s => s.PaymentMethod)
                .Include(s => s.SaleItems)
                    .ThenInclude(si => si.Product)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Sale?> GetByDocumentNumberAsync(string documentNumber)
        {
            return await context.Sales
                .AsNoTracking()
                .Include(s => s.CashRegister)
                .Include(s => s.DocumentType)
                .Include(s => s.Customer)
                .Include(s => s.User)
                .Include(s => s.PaymentMethod)
                .Include(s => s.SaleItems)
                    .ThenInclude(si => si.Product)
                .FirstOrDefaultAsync(s => s.DocumentNumber == documentNumber);
        }
    }
}