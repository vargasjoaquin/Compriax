namespace CompriaxSystem.Application.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public string? Cuil { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public bool IsActive { get; set; } = true;
        public byte[]? RowVersion { get; set; }
        public int? TaxConditionId { get; set; }
        public string? TaxConditionName { get; set; }
        public string FullName => $"{LastName}, {FirstName}";
    }
}