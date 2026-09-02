using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class PromotionRepository(ApplicationDbContext context) : IPromotionRepository
    {
        public async Task<IEnumerable<Promotion>> GetAllAsync()
        {
            return await context.Promotions
                .Include(p => p.Product)
                .Include(p => p.Category)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Promotion>> GetActivePromotionsAsync(DateTime date)
        {
            var targetDate = date.Date;

            return await context.Promotions
                .AsNoTracking()
                .Include(p => p.Product)
                .Include(p => p.Category)
                .Where(p => p.IsActive && !p.IsDeleted && p.StartDate.Date <= targetDate && p.EndDate.Date >= targetDate)
                .ToListAsync();
        }

        public async Task<Promotion?> GetByIdAsync(int id)
        {
            return await context.Promotions
                .Include(p => p.Product)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Promotion promotion) =>
            await context.Promotions.AddAsync(promotion);

        public void Update(Promotion promotion) =>
            context.Promotions.Update(promotion);
    }
}