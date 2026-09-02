using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IDocumentService
    {
        Task<byte[]> GenerateSaleReceiptAsync(SaleDto sale, string documentNumber, string cashierName);
        Task<byte[]> GenerateThermalTicketReceiptAsync(SaleDto sale, string documentNumber, string cashierName, ThermalPaperSize paperSize = ThermalPaperSize.Width80mm);
        Task<byte[]> GenerateInventoryReportAsync(IEnumerable<ProductDto> products);
        Task<byte[]> GenerateCustomersReportAsync(IEnumerable<CustomerDto> customers);
        Task<byte[]> GenerateSuppliersReportAsync(IEnumerable<SupplierDto> suppliers);
        Task<byte[]> GenerateUsersReportAsync(IEnumerable<UserDto> users);
        Task<byte[]> GeneratePurchaseReceiptAsync(PurchaseCreateDto purchase, string supplierName, string supplierCuit, string registeredBy);
        Task<byte[]> GenerateCashShiftTicketAsync(CashShiftSummaryDto shift, bool isZClose = true);
    }
}
