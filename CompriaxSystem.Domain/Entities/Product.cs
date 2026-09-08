using CompriaxSystem.Domain.Common;

namespace CompriaxSystem.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Barcode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int CurrentStock { get; set; }
        public int MinimumStock { get; set; }
        public bool IsActive { get; set; } = true;
        public byte[]? Image { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; } = null!;

        public int UnitOfMeasureId { get; set; }
        public virtual UnitsOfMeasure UnitOfMeasure { get; set; } = null!;
    }
}
