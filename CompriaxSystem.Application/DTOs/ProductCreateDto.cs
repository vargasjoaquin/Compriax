namespace CompriaxSystem.Application.DTOs
{
    public class ProductCreateDto
    {
        public string Barcode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int UnitOfMeasureId { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int InitialStock { get; set; }
        public int MinimumStock { get; set; }
        public byte[]? Image { get; set; }
    }
}