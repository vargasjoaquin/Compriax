namespace CompriaxSystem.Application.DTOs
{
    public class ProductLabelDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string LabelDescription {  get; set; } = null!;
        public decimal Price {  get; set; }
        public int Quantity { get; set; }

        public string? CategoryName { get; set; }
        public string? BrandName { get; set; }
        public string? StoreName { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.Now;

        public string FormattedPrice => Price.ToString("C2");
    }
}
