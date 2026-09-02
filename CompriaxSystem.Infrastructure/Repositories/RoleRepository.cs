using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class RoleRepository(ApplicationDbContext context) : IRoleRepository
    {
        public async Task<IEnumerable<Role>> GetAllAsync() =>
            await context.Roles.ToListAsync();

        public async Task<Role?> GetByIdAsync(int id) =>
            await context.Roles.FindAsync(id);
    }
}