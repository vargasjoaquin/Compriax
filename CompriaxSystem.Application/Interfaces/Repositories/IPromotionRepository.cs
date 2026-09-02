using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IPromotionRepository
    {
        Task<IEnumerable<Promotion>> GetAllAsync();
        Task<IEnumerable<Promotion>> GetActivePromotionsAsync(DateTime date);
        Task<Promotion?> GetByIdAsync(int id);
        Task AddAsync(Promotion promotion);
        void Update(Promotion promotion);
    }
}
