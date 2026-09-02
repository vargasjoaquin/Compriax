using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllActiveAsync();
        Task<OperationResult> RegisterCustomerAsync(CustomerDto dto);
        Task<OperationResult> DeleteCustomerAsync(int id);
    }
}
