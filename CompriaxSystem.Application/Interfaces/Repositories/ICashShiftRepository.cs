using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface ICashShiftRepository
    {
        Task<CashShift?> GetActiveShiftByUserIdAsync(int userId);
        Task<CashShift?> GetActiveShiftByRegisterIdAsync(int registerId);
        Task<CashShift?> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<CashShift>> GetHistoryAsync(DateTime start, DateTime end);
        Task<IEnumerable<CashMovement>> GetMovementsByShiftIdAsync(int shiftId);
        Task AddAsync(CashShift shift);
        void Update(CashShift shift);
        Task AddMovementAsync(CashMovement movement);
    }
}
