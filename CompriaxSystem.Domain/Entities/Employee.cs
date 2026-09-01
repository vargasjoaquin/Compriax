using CompriaxSystem.Domain.Common;

namespace CompriaxSystem.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public string EmployeeCode { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Cuil { get; set; }
        public string? Address { get; set; }
        public int ChildrenCount { get; set; }
        public byte[]? Photo { get; set; }
        public bool IsActive { get; set; } = true;

        public int? GenderId { get; set; }
        public virtual Gender? Gender { get; set; }

        public int? CivilStatusId { get; set; }
        public virtual CivilStatus? CivilStatus { get; set; }

        public int? PositionId { get; set; }
        public virtual Position? Position { get; set; }
    }
}
