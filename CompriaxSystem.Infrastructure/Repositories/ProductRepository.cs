using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class ProductRepository(ApplicationDbContext context) : IProductRepository
    {
        /// <summary>
        /// Obtiene todos los productos con sus relaciones de categoría, marca y unidad de medida.
        /// </summary>
        /// <returns>Colección de productos detallados.</returns>
        public async Task<IEnumerable<Product>> GetAllWithDetailsAsync()
        {
            return await context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.UnitOfMeasure)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene un producto por su código de barras.
        /// </summary>
        /// <param name="barcode">Código de barras.</param>
        /// <returns>La entidad del producto o null.</returns>
        public async Task<Product?> GetByBarcodeAsync(string barcode) =>
            await context.Products.FirstOrDefaultAsync(p => p.Barcode == barcode);

        /// <summary>
        /// Obtiene un producto mediante su id.
        /// </summary>
        /// <param name="id">Id del producto.</param>
        /// <returns>Entidad del producto.</returns>
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.UnitOfMeasure)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Recupera un producto que ha sido eliminado.
        /// </summary>
        /// <param name="id">Id del producto eliminado.</param>
        /// <returns>El producto encontrado en la papelera.</returns>
        public async Task<Product?> GetDeletedByIdAsync(int id)
        {
            return await context.Products
                .IgnoreQueryFilters()
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.UnitOfMeasure)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted);
        }

        /// <summary>
        /// Obtiene el listado de todos los productos marcados como eliminados.
        /// </summary>
        /// <returns>Colección de productos borrados.</returns>
        public async Task<IEnumerable<Product>> GetAllDeletedAsync()
        {
            return await context.Products
                .IgnoreQueryFilters()
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.UnitOfMeasure)
                .Where(p => p.IsDeleted)
                .ToListAsync();
        }

        /// <summary>
        /// Registra un nuevo producto.
        /// </summary>
        /// <param name="product">Entidad del producto.</param>
        public async Task AddAsync(Product product) =>
            await context.Products.AddAsync(product);

        /// <summary>
        /// Registra una entrada o salida de inventario asociada al producto.
        /// </summary>
        /// <param name="movement">Entidad de movimiento de stock.</param>
        public async Task AddMovementAsync(StockMovement movement) =>
            await context.StockMovements.AddAsync(movement);

        /// <summary>
        /// Actualiza un producto.
        /// </summary>
        /// <param name="product">Entidad modificada.</param>
        public void Update(Product product) =>
            context.Products.Update(product);

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}