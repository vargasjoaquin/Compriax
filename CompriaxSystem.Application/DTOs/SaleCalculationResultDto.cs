namespace CompriaxSystem.Application.DTOs
{
    public class SaleCalculationResultDto
    {
        public decimal SubTotal { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal FinalTotal { get; set; }
        public List<AppliedDiscountDto> Discounts { get; set; } = new();
        public List<SaleItemDto> CalculatedItems { get; set; } = new();
    }
}