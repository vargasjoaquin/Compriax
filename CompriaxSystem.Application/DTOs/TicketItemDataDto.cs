namespace CompriaxSystem.Application.DTOs
{
    public class TicketItemDataDto
    {
        public int Quantity { get; set; }
        public string Description { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Total { get; set; }
        public string? PromotionTag { get; set; }
    }
}