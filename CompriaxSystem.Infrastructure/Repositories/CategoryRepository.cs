using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
    {
        /// <summary>
        /// Obtiene todas las categorías.
        /// </summary>
        /// <returns>Una colección de entidades de categoría.</returns>
        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await context.Categories.ToListAsync();

        /// <summary>
        /// Obtiene una categoría por su id.
        /// </summary>
        /// <param name="id">Id de la categoría a consultar.</param>
        /// <returns>La entidad de la categoría o null si no se encuentra.</returns>
        public async Task<Category?> GetByIdAsync(int id) =>
            await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        /// <summary>
        /// Obtiene una categoría que ha sido eliminada mediante su id.
        /// </summary>
        /// <param name="id">Id de la categoría borrada.</param>
        /// <returns>La entidad de la categoría eliminada.</returns>

        public async Task<Category?> GetDeletedByIdAsync(int id) =>
            await context.Categories
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted);

        /// <summary>
        /// Obtiene el listado de todas las categorías que se encuentran en la papelera.
        /// </summary>
        /// <returns>Una colección de categorías eliminadas.</returns>
        public async Task<IEnumerable<Category>> GetAllDeletedAsync() =>
            await context.Categories
                .IgnoreQueryFilters()
                .Where(c => c.IsDeleted)
                .ToListAsync();

        /// <summary>
        /// Registra una nueva categoría.
        /// </summary>
        /// <param name="category">Entidad de la categoría a agregar.</param>
        public async Task AddAsync(Category category) =>
            await context.Categories.AddAsync(category);

        /// <summary>
        /// Actualza una categoría.
        /// </summary>
        /// <param name="category">Entidad de la categoría modificada.</param>
        public void Update(Category category) =>
            context.Categories.Update(category);

        /// <summary>
        /// Guarda todos los cambios realizados en el repositorio de categorías.
        /// </summary>
        /// <returns>Verdadero si se guardó correctamente.</returns>
        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}