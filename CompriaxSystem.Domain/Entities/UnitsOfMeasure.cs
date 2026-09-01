using CompriaxSystem.Domain.Common;

namespace CompriaxSystem.Domain.Entities
{
    public class UnitsOfMeasure : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
    }
}
