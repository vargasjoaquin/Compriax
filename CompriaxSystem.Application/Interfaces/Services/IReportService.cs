using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IReportService
    {
        Task<IEnumerable<SalesReportDto>> GetSalesHistoryAsync(DateTime start, DateTime end, int? cashRegisterId = null);
        Task<IEnumerable<PurchaseReportDto>> GetPurchaseHistoryAsync(DateTime start, DateTime end, int? supplierId);
        Task<DashboardDto> GetDashboardStatsAsync();
        Task<SaleDto?> GetSaleDetailsAsync(int saleId);
        Task<SaleDto?> GetSaleByDocumentNumberAsync(string documentNumber);
    }
}
