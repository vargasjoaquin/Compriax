using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IInventoryService
    {
        Task<OperationResult> AdjustStockAsync(int productId, int amount, string reason);
    }
}
