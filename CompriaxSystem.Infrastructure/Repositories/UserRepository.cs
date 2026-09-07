using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        public async Task<User?> GetByIdAsync(int id)
        {
            return await context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetDeletedByIdAsync(int id)
        {
            return await context.Users
                .IgnoreQueryFilters()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id && u.IsDeleted);
        }

        public async Task<IEnumerable<User>> GetAllDeletedAsync()
        {
            return await context.Users
                .IgnoreQueryFilters()
                .Include(u => u.Role)
                .Where(u => u.IsDeleted)
                .ToListAsync();
        }

        public async Task<User?> GetByUsernameAsync(string username) =>
            await context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == username);

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await context.Users.Include(u => u.Role).ToListAsync();

        public async Task AddAsync(User user) =>
            await context.Users.AddAsync(user);

        public void Update(User user) =>
            context.Entry(user).State = EntityState.Modified;

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}