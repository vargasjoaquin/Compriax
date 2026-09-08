using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Obtiene todos los roles de usuario definidos en el sistema.
        /// </summary>
        /// <returns>Colección de roles.</returns>
        Task<IEnumerable<Role>> GetAllAsync();

        /// <summary>
        /// Busca un rol específico por su id.
        /// </summary>
        /// <param name="id">ID del rol.</param>
        /// <returns>La entidad del rol.</returns>
        Task<Role?> GetByIdAsync(int id);
    }
}
