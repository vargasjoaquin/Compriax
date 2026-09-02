namespace CompriaxSystem.Application.DTOs
{
    public class PurchaseItemCreateDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SubTotal => Quantity * BuyPrice;
    }
}