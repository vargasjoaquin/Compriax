namespace CompriaxSystem.Application.DTOs
{
    public class AppliedDiscountDto
    {
        public int PromotionId { get; set; }
        public string PromotionName { get; set; } = null!;
        public decimal DiscountAmount { get; set; }
        public string Description { get; set; } = null!;
    }
}