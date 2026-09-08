using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ICashRegisterService
    {
        /// <summary>
        /// Obtiene la lista de todas las cajas registradoras.
        /// </summary>
        /// <returns>Colección de cajas registradoras.</returns>
        Task<IEnumerable<CashRegisterDto>> GetAllRegistersAsync();

        /// <summary>
        /// Busca una caja por su id.
        /// </summary>
        /// <param name="id">ID de la caja.</param>
        /// <returns>Datos de la caja encontrada.</returns>
        Task<CashRegisterDto?> GetByIdAsync(int id);

        /// <summary>
        /// Crea o actualiza una caja registradora.
        /// </summary>
        /// <param name="dto">Datos de la caja.</param>
        /// <returns>Resultado de la operación.</returns>
        Task<OperationResult> UpsertCashRegisterAsync(CashRegisterDto dto);

        /// <summary>
        /// Cambia el estado de activación (habilitado/deshabilitado) de una caja.
        /// </summary>
        /// <param name="id">ID de la caja.</param>
        /// <returns>Resultado del cambio de estado.</returns>
        Task<OperationResult> ToggleRegisterStatusAsync(int id);
    }
}
