using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface ICashRegisterRepository
    {
        Task<IEnumerable<CashRegister>> GetAllAsync();
        Task<CashRegister?> GetByIdAsync(int id);
        Task<CashRegister?> GetByNumberAsync(int number);
        Task<bool> HasOpenShiftAsync(int cashRegisterId);
        Task AddAsync(CashRegister register);
        void Update(CashRegister register);
        Task<bool> SaveChangesAsync();
    }
}
