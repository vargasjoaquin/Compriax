using CompriaxSystem.Domain.Common;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Domain.Entities
{
    public class StoreSettings : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? CUIT { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public byte[]? Logo { get; set; }

        public string TicketFormat { get; set; } = ((int)ThermalPaperSize.Width80mm).ToString() + "mm";
        public string? TicketFooterMessage { get; set; }
        public bool ShowLogoOnTicket { get; set; } = true;
        public bool ShowBarcodeOnTicket { get; set; } = true;
        public bool AutoPrintTicket { get; set; } = false;
        public string? ThermalPrinterName { get; set; }

        public int PointOfSale { get; set; } = TaxConstants.DEFAULT_POINT_OF_SALE;
        public string? GrossIncomeNumber { get; set; }
        public DateTime? ActivityStartDate { get; set; }

        public int? TaxConditionId { get; set; }
        public virtual TaxCondition? TaxCondition { get; set; }
    }
}

