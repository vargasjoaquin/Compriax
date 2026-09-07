using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        void Update(User user);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<User>> GetAllDeletedAsync();
        Task<User?> GetDeletedByIdAsync(int id);
    }
}
