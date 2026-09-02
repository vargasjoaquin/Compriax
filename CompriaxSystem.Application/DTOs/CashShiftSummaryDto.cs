namespace CompriaxSystem.Application.DTOs
{
    public class CashShiftSummaryDto
    {
        public int ShiftId { get; set; }
        public string CashierName { get; set; } = null!;
        public DateTime OpeningDate { get; set; }
        public DateTime CurrentDate { get; set; } = DateTime.Now;

        public decimal InitialCash { get; set; }
        public decimal TotalCashSales { get; set; }
        public decimal TotalDebitSales { get; set; }
        public decimal TotalCreditSales { get; set; }
        public decimal TotalTransferSales { get; set; }
        public decimal TotalQrSales { get; set; }

        public decimal TotalManualCashIn { get; set; }
        public decimal TotalManualCashOut { get; set; }

        public int SalesCount { get; set; }
        public decimal ExpectedCashInDrawer => InitialCash + TotalCashSales + TotalManualCashIn - TotalManualCashOut;
        public decimal TotalSalesAmount => TotalCashSales + TotalDebitSales + TotalCreditSales + TotalTransferSales + TotalQrSales;

        public decimal? RealCashCounted { get; set; }
        public decimal? Difference => RealCashCounted.HasValue ? (RealCashCounted.Value - ExpectedCashInDrawer) : null;
    }
}