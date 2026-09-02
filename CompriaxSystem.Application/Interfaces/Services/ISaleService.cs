using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ISaleService
    {
        Task<OperationResult> ProcessSaleAsync(SaleDto saleDto);
        Task<OperationResult> ValidateStockAsync(int productId, int requestQuantity);
    }
}
