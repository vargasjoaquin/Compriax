using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Obtiene todas las categorías.
        /// </summary>
        /// <returns>Una colección de todas las categorías.</returns>
        Task<IEnumerable<Category>> GetAllAsync();

        /// <summary>
        /// Busca una categoría por su id.
        /// </summary>
        /// <param name="id">ID de la categoría a consultar.</param>
        /// <returns>La categoría encontrada o null si no existe.</returns>
        Task<Category?> GetByIdAsync(int id);

        /// <summary>
        /// Registra una nueva categoría.
        /// </summary>
        /// <param name="category">Entidad de la categoría a agregar.</param>
        Task AddAsync(Category category);

        /// <summary>
        /// Actualiza una categoría existente.
        /// </summary>
        /// <param name="category">Entidad de la categoría con los datos actualizados.</param>
        void Update(Category category);

        /// <summary>
        /// Guarda todos los cambios realizados en el repositorio de categorías.
        /// </summary>
        /// <returns>Verdadero si los cambios se guardaron correctamente, falso en caso contrario.</returns>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// Recupera todas las categorías que han sido marcadas como eliminadas.
        /// </summary>
        /// <returns>Una colección de categorías eliminadas.</returns>
        Task<IEnumerable<Category>> GetAllDeletedAsync();

        /// <summary>
        /// Busca una categoría eliminada específicamente por su id.
        /// </summary>
        /// <param name="id">ID de la categoría eliminada.</param>
        /// <returns>La categoría eliminada o null si no se encuentra.</returns>
        Task<Category?> GetDeletedByIdAsync(int id);
    }
}
