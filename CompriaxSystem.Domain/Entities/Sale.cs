using CompriaxSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompriaxSystem.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        public string DocumentNumber { get; set; } = null!;
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaymentReceived { get; set; }
        public decimal PaymentChange { get; set; }

        public int PaymentMethodId { get; set; } = 1;
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;

        public int? CashShiftId { get; set; }
        public virtual CashShift? CashShift { get; set; }

        public int? CashRegisterId { get; set; }
        public virtual CashRegister? CashRegister { get; set; }

        // Datos Fiscales Oficiales (AFIP / ARCA)
        public int PointOfSale { get; set; } = 1;
        public string? Cae { get; set; }
        public DateTime? CaeExpirationDate { get; set; }
        public string? AfipQrUrl { get; set; }
        public string? FiscalStatus { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; } = null!;

        public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}
