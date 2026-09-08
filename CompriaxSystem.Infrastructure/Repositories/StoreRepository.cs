using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class StoreRepository(ApplicationDbContext context) : IStoreRepository
    {
        /// <summary>
        /// Obtiene la configuración del perfil comercial de la tienda.
        /// </summary>
        /// <returns>La entidad de configuración de la tienda.</returns>
        public async Task<StoreSettings?> GetSettingsAsync() =>
            await context.StoreSettings.FirstOrDefaultAsync(x => x.Id == 1);

        /// <summary>
        /// Actualiza los datos de  configuración de la tienda.
        /// </summary>
        /// <param name="settings">Entidad con los nuevos ajustes.</param>
        public void Update(StoreSettings settings) =>
            context.StoreSettings.Update(settings);

        /// <summary>
        /// Guarda los cambios en la configuración de la tienda.
        /// </summary>
        /// <returns>Verdadero si se persistieron los cambios.</returns>
        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}