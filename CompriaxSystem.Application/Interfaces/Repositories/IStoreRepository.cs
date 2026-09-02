using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IStoreRepository
    {
        Task<StoreSettings?> GetSettingsAsync();
        void Update(StoreSettings settings);
        Task<bool> SaveChangesAsync();
    }
}
