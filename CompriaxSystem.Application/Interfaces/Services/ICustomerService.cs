using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Obtiene todos los clientes activos.
        /// </summary>
        /// <returns>Colección de clientes activos.</returns>
        Task<IEnumerable<CustomerDto>> GetAllActiveAsync();

        /// <summary>
        /// Crea un cliente.
        /// </summary>
        /// <param name="dto">Datos del cliente.</param>
        /// <returns>Resultado del registro.</returns>
        Task<OperationResult> RegisterCustomerAsync(CustomerDto dto);

        /// <summary>
        /// Realiza la baja de un cliente.
        /// </summary>
        /// <param name="id">ID del cliente.</param>
        /// <returns>Resultado de la operación.</returns>
        Task<OperationResult> DeleteCustomerAsync(int id);
    }
}
