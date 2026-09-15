using CompriaxSystem.Domain.Constants;

namespace CompriaxSystem.Application.DTOs
{
    public class AfipAuthorizeResultDto
    {
        public bool Success { get; set; }
        public string Cae { get; set; } = null!;
        public DateTime CaeExpirationDate { get; set; }
        public int PointOfSale { get; set; }
        public long InvoiceNumber { get; set; }
        public string QrUrl { get; set; } = null!;
        public string FiscalStatus { get; set; } = FiscalStatuses.APPROVED;
        public string? ErrorMessage { get; set; }
    }
}
