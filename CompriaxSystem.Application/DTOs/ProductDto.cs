namespace CompriaxSystem.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Barcode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int CurrentStock { get; set; }
        public int MinimumStock { get; set; }
        public string StockStatus => CurrentStock <= MinimumStock ? "Stock bajo" : "OK";
        public bool IsActive { get; set; } = true;
        public byte[]? Image { get; set; }
    }
}