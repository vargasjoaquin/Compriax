using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ICashShiftService
    {
        Task<CashShiftDto?> GetCurrentActiveShiftAsync();
        Task<OperationResult> OpenShiftAsync(CashShiftOpenDto dto);
        Task<OperationResult> RegisterMovementAsync(CashMovementCreateDto dto);
        Task<CashShiftSummaryDto> GetCurrentShiftSummaryAsync();
        Task<OperationResult> CloseShiftAsync(CashShiftCloseDto dto);
        Task<IEnumerable<CashShiftDto>> GetShiftHistoryAsync(DateTime start, DateTime end);
        Task<IEnumerable<CashMovementDto>> GetCurrentShiftMovementsAsync();
    }
}
