using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task AddAsync(Category category);
        void Update(Category category);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Category>> GetAllDeletedAsync();
        Task<Category?> GetDeletedByIdAsync(int id);
    }
}
