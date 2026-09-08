using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class PromotionRepository(ApplicationDbContext context) : IPromotionRepository
    {
        /// <summary>
        /// Obtiene todas las promociones registradas incluyendo productos y categorías asociados.
        /// </summary>
        /// <returns>Colección de promociones ordenadas por id descendente.</returns>
        public async Task<IEnumerable<Promotion>> GetAllAsync()
        {
            return await context.Promotions
                .Include(p => p.Product)
                .Include(p => p.Category)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene las promociones que se encuentran activas y vigentes para una fecha determinada.
        /// </summary>
        /// <param name="date">Fecha de consulta de vigencia.</param>
        /// <returns>Colección de promociones válidas para la fecha.</returns>
        public async Task<IEnumerable<Promotion>> GetActivePromotionsAsync(DateTime date)
        {
            var targetDate = date.Date;

            return await context.Promotions
                .AsNoTracking()
                .Include(p => p.Product)
                .Include(p => p.Category)
                .Where(p => p.IsActive && !p.IsDeleted && p.StartDate.Date <= targetDate && p.EndDate.Date >= targetDate)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene una promoción específica por su id.
        /// </summary>
        /// <param name="id">Id de la promoción.</param>
        /// <returns>La entidad de la promoción con sus detalles.</returns>
        public async Task<Promotion?> GetByIdAsync(int id)
        {
            return await context.Promotions
                .Include(p => p.Product)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Agrega una nueva promoción.
        /// </summary>
        /// <param name="promotion">Entidad de la promoción.</param>
        public async Task AddAsync(Promotion promotion) =>
            await context.Promotions.AddAsync(promotion);

        /// <summary>
        /// Actualiza una promoción existente.
        /// </summary>
        /// <param name="promotion">Entidad de la promoción modificada.</param>
        public void Update(Promotion promotion) =>
            context.Promotions.Update(promotion);
    }
}