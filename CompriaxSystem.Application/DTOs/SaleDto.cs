namespace CompriaxSystem.Application.DTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public int DocumentTypeId { get; set; }
        public string? DocumentTypeName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string CashierName { get; set; } = null!;

        public int? CustomerId { get; set; }
        public string? CustomerDoc { get; set; }
        public string? CustomerName { get; set; }

        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaymentReceived { get; set; }
        public decimal PaymentChange => PaymentReceived - TotalAmount;

        public int PaymentMethodId { get; set; } = 1;
        public string? PaymentMethodName { get; set; }

        public int PointOfSale { get; set; } = 1;
        public string? Cae { get; set; }
        public DateTime? CaeExpirationDate { get; set; }
        public string? AfipQrUrl { get; set; }
        public string? FiscalStatus { get; set; }

        public List<SaleItemDto> Items { get; set; } = new();
        public List<AppliedDiscountDto> AppliedDiscounts { get; set; } = new();
    }
}