namespace CompriaxSystem.Application.DTOs
{
    public class StoreSettingsDto
    {
        public string Name { get; set; } = null!;
        public string? CUIT { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public byte[]? Logo { get; set; }

        public string TicketFormat { get; set; } = "80mm";
        public string? TicketFooterMessage { get; set; }
        public bool ShowLogoOnTicket { get; set; } = true;
        public bool ShowBarcodeOnTicket { get; set; } = true;
        public bool AutoPrintTicket { get; set; } = false;
        public string? ThermalPrinterName { get; set; }

        public int PointOfSale { get; set; } = 1;
        public string? GrossIncomeNumber { get; set; }
        public DateTime? ActivityStartDate { get; set; }
        public int? TaxConditionId { get; set; }
        public string? TaxConditionName { get; set; }
    }
}