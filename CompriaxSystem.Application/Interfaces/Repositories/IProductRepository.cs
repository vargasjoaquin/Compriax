using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByBarcodeAsync(string barcode);
        Task<IEnumerable<Product>> GetAllWithDetailsAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task AddMovementAsync(StockMovement movement);
        void Update(Product product);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Product>> GetAllDeletedAsync();
        Task<Product?> GetDeletedByIdAsync(int id);
    }
}
