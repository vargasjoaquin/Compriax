using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IPromotionService
    {
        Task<IEnumerable<PromotionDto>> GetAllPromotionsAsync();
        Task<PromotionDto?> GetByIdAsync(int id);
        Task<OperationResult> UpsertPromotionAsync(PromotionDto dto);
        Task<OperationResult> DeletePromotionAsync(int id);
        Task<OperationResult> ToggleStatusAsync(int id);
        Task<SaleCalculationResultDto> CalculateSaleDiscountsAsync(IEnumerable<SaleItemDto> items, DateTime date);
    }
}
