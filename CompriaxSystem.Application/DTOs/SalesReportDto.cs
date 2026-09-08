namespace CompriaxSystem.Application.DTOs
{
    public class SalesReportDto
    {
        public int SaleId { get; set; }
        public string CashRegisterName { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string DocumentType { get; set; } = null!;
        public DateTime Date { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CashierName { get; set; } = null!;
        public decimal TotalAmount { get; set; }
    }
}