using CompriaxSystem.Domain.Common;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Domain.Entities
{
    public class Promotion : AuditableEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public PromotionType PromotionType { get; set; }

        public decimal? DiscountPercentage { get; set; }
        public int? RequiredQuantity { get; set; }
        public int? PayQuantity { get; set; }

        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? DaysOfWeek { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
