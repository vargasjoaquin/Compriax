using CompriaxSystem.Domain.Common;

namespace CompriaxSystem.Domain.Entities
{
    public class Brand : AuditableEntity
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
