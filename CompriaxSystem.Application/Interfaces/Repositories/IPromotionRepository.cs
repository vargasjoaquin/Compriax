using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IPromotionRepository
    {
        /// <summary>
        /// Obtiene todas las promociones.
        /// </summary>
        /// <returns>Colección de promociones.</returns>
        Task<IEnumerable<Promotion>> GetAllAsync();

        /// <summary>
        /// Obtiene las promociones que se encuentran vigentes en una fecha específica.
        /// </summary>
        /// <param name="date">Fecha a consultar vigencia.</param>
        /// <returns>Colección de promociones activas.</returns>
        Task<IEnumerable<Promotion>> GetActivePromotionsAsync(DateTime date);

        /// <summary>
        /// Busca una promoción por su id.
        /// </summary>
        /// <param name="id">ID de la promoción.</param>
        /// <returns>La entidad de la promoción.</returns>
        Task<Promotion?> GetByIdAsync(int id);

        /// <summary>
        /// Crea una nueva promoción.
        /// </summary>
        /// <param name="promotion">Entidad de la promoción.</param>
        Task AddAsync(Promotion promotion);

        /// <summary>
        /// Actualiza los datos de una promoción.
        /// </summary>
        /// <param name="promotion">Entidad actualizada.</param>
        void Update(Promotion promotion);
    }
}
