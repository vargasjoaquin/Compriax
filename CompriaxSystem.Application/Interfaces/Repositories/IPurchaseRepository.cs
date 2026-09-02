using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IPurchaseRepository
    {
        Task AddAsync(Purchase purchase);
        Task<Purchase?> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<Purchase>> GetHistoryAsync(DateTime start, DateTime end);
        Task<bool> SaveChangesAsync();
    }
}
