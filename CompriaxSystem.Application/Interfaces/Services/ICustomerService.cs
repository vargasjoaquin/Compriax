using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllActiveAsync();
        Task<OperationResult> RegisterCustomerAsync(CustomerDto dto);
        Task<OperationResult> DeleteCustomerAsync(int id);
    }
}
