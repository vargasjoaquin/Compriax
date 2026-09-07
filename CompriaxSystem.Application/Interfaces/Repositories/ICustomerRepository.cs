using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer?> GetByDocumentAsync(string documentNumber);
        Task<IEnumerable<Customer>> GetAllActiveAsync();
        Task AddAsync(Customer customer);
        void Update(Customer customer);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Customer>> GetAllDeletedAsync();
        Task<Customer?> GetDeletedByIdAsync(int id);
    }
}
