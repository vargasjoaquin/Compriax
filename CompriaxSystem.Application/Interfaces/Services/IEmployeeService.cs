using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<OperationResult> UpsertEmployeeAsync(EmployeeDto dto);
        Task<OperationResult> DeleteEmployeeAsync(int id);
    }
}
