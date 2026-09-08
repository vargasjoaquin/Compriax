using CompriaxSystem.Domain.Common;

namespace CompriaxSystem.Domain.Entities
{
    public class CashRegister : AuditableEntity
    {
        public int Number { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<CashShift> CashShifts { get; set; } = new List<CashShift>();
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
