using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        /// <summary>
        /// Obtiene un usuario mediante su id.
        /// </summary>
        /// <param name="id">Id del usuario.</param>
        /// <returns>El usuario encontrado.</returns>
        public async Task<User?> GetByIdAsync(int id)
        {
            return await context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Obtiene un usuario eliminado por su id.
        /// </summary>
        /// <param name="id">Id del usuario borrado.</param>
        /// <returns>El usuario en estado eliminado.</returns>
        public async Task<User?> GetDeletedByIdAsync(int id)
        {
            return await context.Users
                .IgnoreQueryFilters()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id && u.IsDeleted);
        }

        /// <summary>
        /// Obtiene la lista de todos los usuarios eliminados.
        /// </summary>
        /// <returns>Colección de usuarios eliminados.</returns>
        public async Task<IEnumerable<User>> GetAllDeletedAsync()
        {
            return await context.Users
                .IgnoreQueryFilters()
                .Include(u => u.Role)
                .Where(u => u.IsDeleted)
                .ToListAsync();
        }

        /// <summary>
        /// Busca un usuario por su nombre de inicio de sesión.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <returns>La entidad del usuario.</returns>
        public async Task<User?> GetByUsernameAsync(string username) =>
            await context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == username);

        /// <summary>
        /// Obitiene todos los usuarios.
        /// </summary>
        /// <returns>Colección de usuarios.</returns>
        public async Task<IEnumerable<User>> GetAllAsync() =>
            await context.Users.Include(u => u.Role).ToListAsync();

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="user">Entidad del usuario.</param>
        public async Task AddAsync(User user) =>
            await context.Users.AddAsync(user);

        /// <summary>
        /// Actualiza los datos de un usuario.
        /// </summary>
        /// <param name="user">Entidad modificada.</param>
        public void Update(User user) =>
            context.Entry(user).State = EntityState.Modified;

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}