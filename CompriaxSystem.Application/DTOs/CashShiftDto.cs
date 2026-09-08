namespace CompriaxSystem.Application.DTOs
{
    public class CashShiftDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public decimal InitialCash { get; set; }
        public decimal? RealCash { get; set; }
        public decimal? ExpectedCash { get; set; }
        public decimal? Difference { get; set; }

        public decimal TotalCashSales { get; set; }
        public decimal TotalDebitSales { get; set; }
        public decimal TotalCreditSales { get; set; }
        public decimal TotalTransferSales { get; set; }
        public decimal TotalQrSales { get; set; }

        public decimal TotalManualCashIn { get; set; }
        public decimal TotalManualCashOut { get; set; }

        public string? Status { get; set; }
        public string? ClosingNotes { get; set; }

        public decimal CurrentSystemCash => InitialCash + TotalCashSales + TotalManualCashIn - TotalManualCashOut;
        public decimal TotalTurnover => TotalCashSales + TotalDebitSales + TotalCreditSales + TotalTransferSales + TotalQrSales;
    }
}