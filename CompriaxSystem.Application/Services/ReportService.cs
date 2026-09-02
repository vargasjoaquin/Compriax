using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;

namespace CompriaxSystem.Application.Services
{
    public class ReportService(IUnitOfWork unitOfWork) : IReportService
    {
        public async Task<IEnumerable<SalesReportDto>> GetSalesHistoryAsync(DateTime start, DateTime end, int? cashRegisterId = null)
        {
            var shifts = await unitOfWork.CashShifts.GetHistoryAsync(start, end);
            var allSales = shifts.SelectMany(s => s.Sales ?? Enumerable.Empty<Domain.Entities.Sale>());

            if (cashRegisterId.HasValue && cashRegisterId.Value > 0)
                allSales = allSales.Where(s => s.CashRegisterId == cashRegisterId.Value);

            return allSales
                .OrderByDescending(s => s.CreatedAt)
                .Select(s => new SalesReportDto
                {
                    SaleId = s.Id,
                    CashRegisterName = s.CashRegister.Name,
                    DocumentNumber = s.DocumentNumber,
                    DocumentType = s.DocumentType.Name,
                    Date = s.CreatedAt,
                    CustomerName = $"{s.Customer.LastName} {s.Customer.FirstName}".Trim(),
                    CashierName = s.User.Username,
                    TotalAmount = s.TotalAmount
                }).ToList();
        }

        public async Task<DashboardDto> GetDashboardStatsAsync()
        {
            var today = DateTime.Today;
            var sevenDaysAgo = today.AddDays(-7);

            var products = (await unitOfWork.Products.GetAllWithDetailsAsync()).ToList();
            var shiftsToday = (await unitOfWork.CashShifts.GetHistoryAsync(today, today.AddDays(1))).ToList();
            var salesToday = shiftsToday.SelectMany(s => s.Sales ?? Enumerable.Empty<Domain.Entities.Sale>()).ToList();
            var shiftsWeek = (await unitOfWork.CashShifts.GetHistoryAsync(sevenDaysAgo, today.AddDays(1))).ToList();
            var salesWeek = shiftsWeek.SelectMany(s => s.Sales ?? Enumerable.Empty<Domain.Entities.Sale>()).ToList();

            return new DashboardDto
            {
                TotalSalesToday = salesToday.Sum(s => s.TotalAmount),
                TotalSalesWeek = salesWeek.Sum(s => s.TotalAmount),
                SalesCountToday = salesToday.Count,
                ProductsLowStockCount = products.Count(p => !p.IsDeleted && p.CurrentStock <= p.MinimumStock),
                CriticalStockList = products
                    .Where(p => !p.IsDeleted && p.CurrentStock <= p.MinimumStock)
                    .OrderBy(p => p.CurrentStock)
                    .Take(5)
                    .Select(p => new CriticalStockDto
                    {
                        ProductName = p.Name,
                        CurrentStock = p.CurrentStock,
                        MinimumStock = p.MinimumStock
                    }).ToList()
            };
        }

        public async Task<SaleDto?> GetSaleDetailsAsync(int saleId)
        {
            var shifts = await unitOfWork.CashShifts.GetHistoryAsync(DateTime.MinValue, DateTime.MaxValue);
            var sale = shifts.SelectMany(s => s.Sales ?? Enumerable.Empty<Domain.Entities.Sale>()).FirstOrDefault(s => s.Id == saleId);

            if (sale == null) 
                return null;

            return new SaleDto
            {
                Id = sale.Id,
                DocumentNumber = sale.DocumentNumber,
                DocumentTypeId = sale.DocumentTypeId,
                DocumentTypeName = sale.DocumentType?.Name,
                Date = sale.CreatedAt,
                CustomerName = $"{sale.Customer.FirstName} {sale.Customer.LastName}".Trim(),
                CustomerDoc = sale.Customer?.DocumentNumber,
                CashierName = sale.User?.Username,
                PaymentReceived = sale.PaymentReceived,
                TotalAmount = sale.TotalAmount,
                Items = (sale.SaleItems ?? Enumerable.Empty<Domain.Entities.SaleItem>()).Select(i => new SaleItemDto
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product?.Name ?? $"Producto #{i.ProductId}",
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };
        }

        public async Task<IEnumerable<PurchaseReportDto>> GetPurchaseHistoryAsync(DateTime start, DateTime end, int? supplierId)
        {
            var purchases = await unitOfWork.Purchases.GetHistoryAsync(start, end);
            
            if (supplierId.HasValue && supplierId.Value > 0)
                purchases = purchases.Where(p => p.SupplierId == supplierId.Value);

            return purchases.Select(p => new PurchaseReportDto
            {
                Date = p.CreatedAt,
                DocumentType = p.DocumentType.Name,
                DocumentNumber = p.DocumentNumber,
                TotalAmount = p.TotalAmount,
                CashierName = p.User.Username,
                SupplierTaxId = p.Supplier.CUIT,
                SupplierName = p.Supplier.CompanyName
            }).ToList();
        }

        public async Task<SaleDto?> GetSaleByDocumentNumberAsync(string documentNumber)
        {
            var shifts = await unitOfWork.CashShifts.GetHistoryAsync(DateTime.MinValue, DateTime.MaxValue);
            var sale = shifts.SelectMany(s => s.Sales ?? Enumerable.Empty<Domain.Entities.Sale>())
                             .FirstOrDefault(s => s.DocumentNumber == documentNumber.Trim());

            if (sale == null) 
                return null;
            
            return await GetSaleDetailsAsync(sale.Id);
        }
    }
}