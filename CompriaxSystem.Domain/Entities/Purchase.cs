using CompriaxSystem.Domain.Common;

namespace CompriaxSystem.Domain.Entities
{
    public class Purchase : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;

        public int DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; } = null!;

        public string DocumentNumber { get; set; } = null!;

        public int PaymentMethodId { get; set; } = 1;
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;

        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Completada";
        public string? Remarks { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
    }

}
