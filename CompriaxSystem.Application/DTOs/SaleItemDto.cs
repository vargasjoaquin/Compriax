namespace CompriaxSystem.Application.DTOs
{
    public class SaleItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int? CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal SubTotal => (Quantity * UnitPrice) - DiscountAmount;
    }
}