using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ISupplyChainService
    {
        Task<IEnumerable<SupplierDto>> GetSuppliersAsync();
        Task<OperationResult> UpsertSupplierAsync(SupplierDto dto);
        Task<OperationResult> DeleteSupplierAsync(int id);
        Task<OperationResult> ProcessPurchaseAsync(PurchaseCreateDto dto);
    }
}
