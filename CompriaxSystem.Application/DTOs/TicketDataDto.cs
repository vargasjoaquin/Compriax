using CompriaxSystem.Domain.Constants;
using CompriaxSystem.Domain.Enums;
using static CompriaxSystem.Application.DTOs.TicketPaymentDataDto;

namespace CompriaxSystem.Application.DTOs
{
    public class TicketDataDto
    {
        public string StoreName { get; set; } = null!;
        public string? LegalName { get; set; }
        public string? Cuit { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? TaxConditionName { get; set; }
        public string? GrossIncomeNumber { get; set; }
        public DateTime? ActivityStartDate { get; set; }
        public byte[]? LogoBytes { get; set; }

        public string DocumentTypeName { get; set; } = "Ticket";
        public string DocumentLetter { get; set; } = VoucherLetterCodesConstants.LETTER_B;
        public string DocumentTypeCode { get; set; } = VoucherLetterCodesConstants.CODE_FACTURA_B;
        public int PointOfSale { get; set; } = 1;
        public string DocumentNumber { get; set; } = null!;
        public DateTime Date { get; set; } = DateTime.Now;

        public string CashierName { get; set; } = null!;
        public int? ShiftId { get; set; }
        public int? PosNumber { get; set; }

        public string? CustomerName { get; set; } 
        public string? CustomerDoc { get; set; }
        public string? CustomerTaxCondition { get; set; }
        public string? CustomerAddress { get; set; }

        public List<TicketItemDataDto> Items { get; set; } = new();

        public decimal SubTotal { get; set; }
        public decimal TotalDiscounts { get; set; }
        public decimal FinalTotal { get; set; }

        public List<TicketPaymentData> Payments { get; set; } = new();
        public decimal PaymentReceived { get; set; }
        public decimal PaymentChange { get; set; }

        public decimal TaxRate { get; set; } = TaxConstants.STANDARD_VAR_RATE;
        public decimal TaxAmount { get; set; }
        public decimal NetTaxableAmount { get; set; }

        public string? Cae { get; set; }
        public DateTime? CaeExpirationDate { get; set; }
        public string? AfipQrUrl { get; set; }
        public byte[]? FiscalQrImageBytes { get; set; }

        public byte[]? InternalBarcodeBytes { get; set; }
        public string? FooterMessage { get; set; }
        public bool ShowLogo { get; set; } = true;
        public bool ShowBarcode { get; set; } = true;
        public ThermalPaperSize PaperSize { get; set; } = ThermalPaperSize.Width80mm;
    }
}