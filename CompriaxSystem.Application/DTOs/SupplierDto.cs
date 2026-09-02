namespace CompriaxSystem.Application.DTOs
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string CUIT { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;
    }
}