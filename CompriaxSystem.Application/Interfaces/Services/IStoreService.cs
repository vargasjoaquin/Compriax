using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IStoreService
    {
        /// <summary>
        /// Obtiene el perfil y la configuración de la tienda.
        /// </summary>
        /// <returns>Configuración actual del establecimiento.</returns>
        Task<StoreSettingsDto> GetStoreProfileAsync();

        /// <summary>
        /// Actualiza la información del perfil del negocio.
        /// </summary>
        /// <param name="dto">Nuevos datos de la tienda.</param>
        /// <returns>Resultado de la actualización.</returns>
        Task<OperationResult> UpdateStoreProfileAsync(StoreSettingsDto dto);
    }
}
