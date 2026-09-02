using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        Task AddAsync(Sale sale);
        Task<string> GetLastDocumentNumberAsync(int documentTypeId);
        Task<bool> SaveChangesAsync();
    }
}
