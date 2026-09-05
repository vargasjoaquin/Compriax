using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        Task AddAsync(Sale sale);
        Task<string> GetLastDocumentNumberAsync(int documentTypeId);
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<Sale>> GetHistoryAsync(DateTime start, DateTime end, int? cashRegisterId = null);
        Task<Sale?> GetByIdWithDetailsAsync(int id);
        Task<Sale?> GetByDocumentNumberAsync(string documentNumber);
    }
}
