using CompriaxSystem.Domain.Common;
using CompriaxSystem.Domain.Constants;

namespace CompriaxSystem.Domain.Entities
{
    public class CashShift : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public int CashRegisterId { get; set; }
        public virtual CashRegister CashRegister { get; set; } = null!;

        public DateTime OpeningDate { get; set; } = DateTime.UtcNow;
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

        public string? Status { get; set; } = CashShiftStatusesConstants.OPEN;
        public string? ClosingNotes { get; set; }

        public virtual ICollection<CashMovement> CashMovements { get; set; } = new List<CashMovement>();
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
