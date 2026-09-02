using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IUnitOfMeasureRepository
    {
        Task<IEnumerable<UnitsOfMeasure>> GetAllAsync();
        Task<UnitsOfMeasure?> GetByIdAsync(int id);
        Task AddAsync(UnitsOfMeasure unit);
        Task<bool> SaveChangesAsync();
    }
}
