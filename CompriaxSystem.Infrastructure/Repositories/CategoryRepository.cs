using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
    {
        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await context.Categories.ToListAsync();

        public async Task<Category?> GetByIdAsync(int id) =>
            await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        public async Task AddAsync(Category category) =>
            await context.Categories.AddAsync(category);

        public void Update(Category category) =>
            context.Categories.Update(category);

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}