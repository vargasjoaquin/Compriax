namespace CompriaxSystem.Application.DTOs
{
    public class LicenseInformationDto
    {
        public string LicenseKey { get; set; } = null!;
        public string Cuit { get; set; } = null!;
        public string BusinessName { get; set; } = null!;
        public DateTime? ExpiresAt { get; set; }
        public bool IsValid { get; set; }
    }
}