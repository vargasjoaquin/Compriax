namespace CompriaxSystem.Application.DTOs
{
    public class PurchaseReportDto
    {
        public DateTime Date { get; set; }
        public string DocumentType { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public string CashierName { get; set; } = null!;
        public string SupplierTaxId { get; set; } = null!;
        public string SupplierName { get; set; } = null!;
    }
}