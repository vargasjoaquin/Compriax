using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class BrandRepository(ApplicationDbContext context) : IBrandRepository
    {
        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await context.Brands
                .OrderBy(b => b.Name)
                .ToListAsync();
        }

        public async Task<Brand?> GetByIdAsync(int id) =>
            await context.Brands.FindAsync(id);

        public async Task AddAsync(Brand brand) =>
            await context.Brands.AddAsync(brand);

        public void Update(Brand brand) =>
            context.Brands.Update(brand);

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}