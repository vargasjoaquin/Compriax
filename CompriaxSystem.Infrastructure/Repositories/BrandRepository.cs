using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class BrandRepository(ApplicationDbContext context) : IBrandRepository
    {
        /// <summary>
        /// Recupera todas las marcas.
        /// </summary>
        /// <returns>Una colección de marcas.</returns>
        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await context.Brands
                .OrderBy(b => b.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Busca una marca por su id.
        /// </summary>
        /// <param name="id">Id de la marca.</param>
        /// <returns>La marca encontrada o null.</returns>
        public async Task<Brand?> GetByIdAsync(int id) =>
            await context.Brands.FindAsync(id);

        /// <summary>
        /// Agrega una nueva marca.
        /// </summary>
        /// <param name="brand">Entidad de la marca.</param>
        public async Task AddAsync(Brand brand) =>
            await context.Brands.AddAsync(brand);

        /// <summary>
        /// Actualiza una marca.
        /// </summary>
        /// <param name="brand">Entidad de la marca con cambios.</param>
        public void Update(Brand brand) =>
            context.Brands.Update(brand);

        /// <summary>
        /// Guarda los cambios realizados en las marcas.
        /// </summary>
        /// <returns>Verdadero si se guardó correctamente.</returns>
        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}