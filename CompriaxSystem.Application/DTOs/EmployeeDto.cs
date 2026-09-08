namespace CompriaxSystem.Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string? Cuil { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{LastName} {FirstName}";
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int ChildrenCount { get; set; }
        public byte[]? Photo { get; set; }
        public bool IsActive { get; set; } = true;
        public int? GenderId { get; set; }
        public string? GenderName { get; set; }
        public int? CivilStatusId { get; set; }
        public string? CivilStatusName { get; set; }
        public int? PositionId { get; set; }
        public string? PositionName { get; set; }
    }
}