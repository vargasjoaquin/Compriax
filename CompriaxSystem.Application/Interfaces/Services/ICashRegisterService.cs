using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ICashRegisterService
    {
        Task<IEnumerable<CashRegisterDto>> GetAllRegistersAsync();
        Task<CashRegisterDto?> GetByIdAsync(int id);
        Task<OperationResult> UpsertCashRegisterAsync(CashRegisterDto dto);
        Task<OperationResult> ToggleRegisterStatusAsync(int id);
    }
}
