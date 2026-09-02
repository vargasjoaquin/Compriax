using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ISaleService
    {
        Task<OperationResult> ProcessSaleAsync(SaleDto saleDto);
        Task<OperationResult> ValidateStockAsync(int productId, int requestQuantity);
    }
}
