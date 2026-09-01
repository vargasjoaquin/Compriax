using CompriaxSystem.Domain.Common;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Domain.Entities
{
    public class StockMovement : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public int Quantity { get; set; }
        public MovementType MovementType { get; set; }
        public string Remarks { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = null!;
    }
}
