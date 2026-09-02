using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class ProductRepository(ApplicationDbContext context) : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAllWithDetailsAsync()
        {
            return await context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.UnitOfMeasure)
                .ToListAsync();
        }

        public async Task<Product?> GetByBarcodeAsync(string barcode) =>
            await context.Products.FirstOrDefaultAsync(p => p.Barcode == barcode);

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.UnitOfMeasure)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Product product) =>
            await context.Products.AddAsync(product);

        public async Task AddMovementAsync(StockMovement movement) =>
            await context.StockMovements.AddAsync(movement);

        public void Update(Product product) =>
            context.Products.Update(product);

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}