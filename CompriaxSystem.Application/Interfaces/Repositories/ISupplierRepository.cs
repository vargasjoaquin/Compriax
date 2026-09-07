using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(int id);
        Task AddAsync(Supplier supplier);
        void Update(Supplier supplier);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Supplier>> GetAllDeletedAsync();
        Task<Supplier?> GetDeletedByIdAsync(int id);
    }
}
