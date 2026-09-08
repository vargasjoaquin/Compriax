using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IBrandRepository
    {
        /// <summary>
        /// Obtiene todas las marcas registradas.
        /// </summary>
        /// <returns>Una colección de todas las entidades Brand.</returns>
        Task<IEnumerable<Brand>> GetAllAsync();

        /// <summary>
        /// Busca una marca específica por su id.
        /// </summary>
        /// <param name="id">El id de la marca a buscar.</param>
        /// <returns>La marca encontrada o null si no existe.</returns>
        Task<Brand?> GetByIdAsync(int id);

        /// <summary>
        /// Registra una nueva marca.
        /// </summary>
        /// <param name="brand">La entidad de la marca a agregar.</param>
        Task AddAsync(Brand brand);

        /// <summary>
        /// Actualiza una marca existente.
        /// </summary>
        /// <param name="brand">La entidad con los datos modificados.</param>
        void Update(Brand brand);

        /// <summary>
        /// Guarda todos los cambios realizados en el contexto de datos.
        /// </summary>
        /// <returns>True si se guardaron los cambios; de lo contrario, False.</returns>
        Task<bool> SaveChangesAsync();
    }
}
