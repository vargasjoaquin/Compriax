using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class EmployeeRepository(ApplicationDbContext context) : IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await context.Employees
                .Include(e => e.Position)
                .Include(e => e.Gender)
                .Include(e => e.CivilStatus)
                .AsNoTracking()
                .OrderBy(e => e.LastName)
                .ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id) =>
            await context.Employees.FirstOrDefaultAsync(e => e.Id == id);

        public async Task<Employee?> GetDeletedByIdAsync(int id) =>
            await context.Employees
                .IgnoreQueryFilters()
                .Include(e => e.Position)
                .Include(e => e.Gender)
                .Include(e => e.CivilStatus)
                .FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted);

        public async Task<IEnumerable<Employee>> GetAllDeletedAsync() =>
            await context.Employees
                .IgnoreQueryFilters()
                .Include(e => e.Position)
                .Include(e => e.Gender)
                .Include(e => e.CivilStatus)
                .Where(e => e.IsDeleted)
                .ToListAsync();

        public async Task AddAsync(Employee employee) =>
            await context.Employees.AddAsync(employee);

        public void Update(Employee employee) =>
            context.Employees.Update(employee);

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}