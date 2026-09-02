using CompriaxSystem.Domain.Common;

namespace CompriaxSystem.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
