using CompriaxSystem.Domain.Common;

namespace CompriaxSystem.Domain.Entities
{
    public class Customer : AuditableEntity
    {
        public string DocumentNumber { get; set; } = null!;
        public string? Cuil { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int? TaxConditionId { get; set; }
        public virtual TaxCondition? TaxCondition { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
