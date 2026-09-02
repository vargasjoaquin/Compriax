using CompriaxSystem.Domain.Common;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Domain.Entities
{
    public class CashMovement : BaseEntity
    {
        public int CashShiftId { get; set; }
        public virtual CashShift CashShift { get; set; } = null!;

        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public CashMovementType MovementType { get; set; }
        public decimal Amount { get; set; }

        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
