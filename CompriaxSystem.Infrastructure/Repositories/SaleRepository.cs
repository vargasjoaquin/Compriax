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
    }
}