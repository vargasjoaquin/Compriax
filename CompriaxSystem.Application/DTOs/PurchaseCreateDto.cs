namespace CompriaxSystem.Application.DTOs
{
    public class PurchaseCreateDto
    {
        public int SupplierId { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public int DocumentTypeId { get; set; }
        public string? DocumentTypeName { get; set; }
        public decimal TotalAmount { get; set; }
        public int PaymentMethodId { get; set; } = 1;
        public string? PaymentMethodName { get; set; }
        public List<PurchaseItemCreateDto> Items { get; set; } = new();
    }
}