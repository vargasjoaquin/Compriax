using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Obtiene la lista de todos los empleados.
        /// </summary>
        /// <returns>Colección de empleados.</returns>
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();

        /// <summary>
        /// Busca un empleado por id.
        /// </summary>
        /// <param name="id">ID del empleado.</param>
        /// <returns>Datos del empleado.</returns>
        Task<EmployeeDto?> GetByIdAsync(int id);

        /// <summary>
        /// Registra o actualiza un empleado.
        /// </summary>
        /// <param name="dto">Datos del empleado.</param>
        /// <returns>Resultado de la operación.</returns>
        Task<OperationResult> UpsertEmployeeAsync(EmployeeDto dto);

        /// <summary>
        /// Da de baja a un empleado.
        /// </summary>
        /// <param name="id">ID del empleado.</param>
        /// <returns>Resultado de la eliminación.</returns>
        Task<OperationResult> DeleteEmployeeAsync(int id);
    }
}
