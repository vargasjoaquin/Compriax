using CompriaxSystem.Domain.Common;

namespace CompriaxSystem.Domain.Entities
{
    internal class Category : AuditableEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
