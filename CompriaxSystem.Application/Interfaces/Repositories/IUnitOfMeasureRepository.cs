using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IUnitOfMeasureRepository
    {
        /// <summary>
        /// Obtiene todas las unidades de medida registradas.
        /// </summary>
        /// <returns>Colección de unidades de medida.</returns>
        Task<IEnumerable<UnitsOfMeasure>> GetAllAsync();

        /// <summary>
        /// Busca una unidad de medida por su id.
        /// </summary>
        /// <param name="id">ID de la unidad.</param>
        /// <returns>La entidad de la unidad de medida.</returns>
        Task<UnitsOfMeasure?> GetByIdAsync(int id);

        /// <summary>
        /// Agrega una nueva unidad de medida.
        /// </summary>
        /// <param name="unit">Entidad de la unidad de medida.</param>
        Task AddAsync(UnitsOfMeasure unit);

        /// <summary>
        /// Guarda los cambios en las unidades de medida.
        /// </summary>
        /// <returns>Éxito del guardado.</returns>
        Task<bool> SaveChangesAsync();
    }
}
