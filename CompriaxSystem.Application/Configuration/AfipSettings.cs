namespace CompriaxSystem.Application.Configuration
{
    public class AfipSettings
    {
        public bool Enabled { get; set; }
        public bool IsProduction { get; set; }
        public string? CertificatePath { get; set; }
        public string? CertificatePassword { get; set; }
        public string? WsaaUrl { get; set; }
        public string? WsfeUrl { get; set; }
    }
}
