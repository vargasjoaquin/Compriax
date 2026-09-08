using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IStoreRepository
    {
        /// <summary>
        /// Obtiene la configuración general del establecimiento o tienda.
        /// </summary>
        /// <returns>La entidad de configuración de la tienda.</returns>
        Task<StoreSettings?> GetSettingsAsync();

        /// <summary>
        /// Actualiza los parámetros de configuración de la tienda.
        /// </summary>
        /// <param name="settings">Entidad con la nueva configuración.</param>
        void Update(StoreSettings settings);

        /// <summary>
        /// Guarda los cambios en la configuración de la tienda.
        /// </summary>
        /// <returns>Verdadero si se actualizaron los datos.</returns>
        Task<bool> SaveChangesAsync();
    }
}
