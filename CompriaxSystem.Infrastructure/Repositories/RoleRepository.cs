using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class RoleRepository(ApplicationDbContext context) : IRoleRepository
    {
        /// <summary>
        /// Obtiene el listado de todos los roles de usuario.
        /// </summary>
        /// <returns>Colección de roles.</returns>
        public async Task<IEnumerable<Role>> GetAllAsync() =>
            await context.Roles.ToListAsync();

        /// <summary>
        /// Busca un rol mediante id.
        /// </summary>
        /// <param name="id">Id del rol.</param>
        /// <returns>La entidad del rol.</returns>
        public async Task<Role?> GetByIdAsync(int id) =>
            await context.Roles.FindAsync(id);
    }
}