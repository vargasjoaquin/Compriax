using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class CustomerRepository(ApplicationDbContext context) : ICustomerRepository
    {
        public async Task<Customer?> GetByIdAsync(int id) =>
            await context.Customers.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Customer?> GetDeletedByIdAsync(int id) =>
            await context.Customers
                .IgnoreQueryFilters()
                .Include(c => c.TaxCondition)
                .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted);

        public async Task<IEnumerable<Customer>> GetAllDeletedAsync() =>
            await context.Customers
                .IgnoreQueryFilters()
                .Include(c => c.TaxCondition)
                .Where(c => c.IsDeleted)
                .ToListAsync();

        public async Task<Customer?> GetByDocumentAsync(string documentNumber) =>
            await context.Customers.FirstOrDefaultAsync(c => c.DocumentNumber == documentNumber);

        public async Task<IEnumerable<Customer>> GetAllActiveAsync()
        {
            return await context.Customers
                .Include(c => c.TaxCondition)
                .AsNoTracking()
                .OrderBy(c => c.LastName)
                .ToListAsync();
        }

        public async Task AddAsync(Customer customer) =>
            await context.Customers.AddAsync(customer);

        public void Update(Customer customer) =>
            context.Entry(customer).State = EntityState.Modified;

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}