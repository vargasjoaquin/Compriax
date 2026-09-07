using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        void Update(Employee employee);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Employee>> GetAllDeletedAsync();
        Task<Employee?> GetDeletedByIdAsync(int id);
    }
}
