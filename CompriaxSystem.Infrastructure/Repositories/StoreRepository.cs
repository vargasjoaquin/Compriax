using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class StoreRepository(ApplicationDbContext context) : IStoreRepository
    {
        public async Task<StoreSettings?> GetSettingsAsync() =>
            await context.StoreSettings.FirstOrDefaultAsync(x => x.Id == 1);

        public void Update(StoreSettings settings) =>
            context.StoreSettings.Update(settings);

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}