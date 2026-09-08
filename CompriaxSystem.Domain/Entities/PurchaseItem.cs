using CompriaxSystem.Domain.Common;

namespace CompriaxSystem.Domain.Entities
{
    public class PurchaseItem : BaseEntity
    {
        public int PurchaseId { get; set; }
        public virtual Purchase Purchase { get; set; } = null!;

        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}
