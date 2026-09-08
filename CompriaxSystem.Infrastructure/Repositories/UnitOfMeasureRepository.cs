using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class UnitOfMeasureRepository(ApplicationDbContext context) : IUnitOfMeasureRepository
    {
        /// <summary>
        /// Obtiene todas las unidades de medida registradas (Unidades, KG, Litros, etc.).
        /// </summary>
        /// <returns>Colección de unidades de medida.</returns>
        public async Task<IEnumerable<UnitsOfMeasure>> GetAllAsync() =>
            await context.UnitsOfMeasure.ToListAsync();

        /// <summary>
        /// Obtiene una unidad de medida por su ID único.
        /// </summary>
        /// <param name="id">ID de la unidad de medida.</param>
        /// <returns>La entidad encontrada o null.</returns>
        public async Task<UnitsOfMeasure?> GetByIdAsync(int id) =>
            await context.UnitsOfMeasure.FindAsync(id);

        /// <summary>
        /// Agrega una nueva unidad de medida al catálogo.
        /// </summary>
        /// <param name="unit">Entidad de la unidad de medida.</param>
        public async Task AddAsync(UnitsOfMeasure unit) =>
            await context.UnitsOfMeasure.AddAsync(unit);

        /// <summary>
        /// Guarda los cambios en el repositorio de unidades de medida.
        /// </summary>
        /// <returns>Verdadero si se guardó correctamente.</returns>
        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}