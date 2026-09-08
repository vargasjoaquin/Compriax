using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Busca un usuario por su id.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <returns>La entidad del usuario.</returns>
        Task<User?> GetByIdAsync(int id);

        /// <summary>
        /// Busca un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <returns>La entidad del usuario o null si no se encuentra.</returns>
        Task<User?> GetByUsernameAsync(string username);

        /// <summary>
        /// Obtiene todos los usuarios activos.
        /// </summary>
        /// <returns>Colección de usuarios.</returns>
        Task<IEnumerable<User>> GetAllAsync();

        /// <summary>
        /// Registra un nuevo usuario.
        /// </summary>
        /// <param name="user">Entidad del usuario.</param>
        Task AddAsync(User user);

        /// <summary>
        /// Actualiza la información de un usuario.
        /// </summary>
        /// <param name="user">Entidad con datos actualizados.</param>
        void Update(User user);

        /// <summary>
        /// Guarda los cambios en el repositorio de usuarios.
        /// </summary>
        /// <returns>Éxito de la operación.</returns>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// Obtiene los usuarios que han sido eliminados.
        /// </summary>
        /// <returns>Colección de usuarios borrados.</returns>
        Task<IEnumerable<User>> GetAllDeletedAsync();

        /// <summary>
        /// Busca un usuario eliminado por su id.
        /// </summary>
        /// <param name="id">ID del usuario borrado.</param>
        /// <returns>La entidad del usuario.</returns>
        Task<User?> GetDeletedByIdAsync(int id);
    }
}
