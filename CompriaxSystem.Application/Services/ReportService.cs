using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Services
{
    public class ReportService(IUnitOfWork unitOfWork) : IReportService
    {
        public async Task<DashboardDto> GetDashboardStatsAsync()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            var sevenDaysAgo = today.AddDays(-7);

            var salesToday = (await unitOfWork.Sales.GetHistoryAsync(today, tomorrow)).ToList();
            var salesWeek = (await unitOfWork.Sales.GetHistoryAsync(sevenDaysAgo, tomorrow)).ToList();

            var products = (await unitOfWork.Products.GetAllWithDetailsAsync()).ToList();
            int lowStockCount = products.Count(p => !p.IsDeleted && p.CurrentStock <= p.MinimumStock);

            var criticalStock = products
                .Where(p => !p.IsDeleted && p.CurrentStock <= p.MinimumStock)
                .OrderBy(p => p.CurrentStock)
                .Take(5)
                .Select(p => new CriticalStockDto
                {
                    ProductName = p.Name,
                    CurrentStock = p.CurrentStock,
                    MinimumStock = p.MinimumStock
                })
                .ToList();

            var topProducts = salesToday
                .SelectMany(s => s.SaleItems)
                .GroupBy(i => i.Product != null ? i.Product.Name : $"Producto #{i.ProductId}")
                .Select(g => new TopProductDto
                {
                    ProductName = g.Key,
                    QuantitySold = g.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.QuantitySold)
                .Take(5)
                .ToList();

            var categorySales = salesToday
                .SelectMany(s => s.SaleItems)
                .GroupBy(i => i.Product.Category.Name)
                .Select(g => new CategorySalesDto
                {
                    CategoryName = g.Key,
                    TotalRevenue = g.Sum(x => x.SubTotal)
                })
                .ToList();

            return new DashboardDto
            {
                TotalSalesToday = salesToday.Sum(s => s.TotalAmount),
                TotalSalesWeek = salesWeek.Sum(s => s.TotalAmount),
                SalesCountToday = salesToday.Count,
                ProductsLowStockCount = lowStockCount,
                TopSellingProducts = topProducts,
                SalesByCategory = categorySales,
                CriticalStockList = criticalStock
            };
        }

        public async Task<IEnumerable<SalesReportDto>> GetSalesHistoryAsync(DateTime start, DateTime end, int? cashRegisterId = null)
        {
            var sales = await unitOfWork.Sales.GetHistoryAsync(start.Date, end.Date.AddDays(1), cashRegisterId);

            return sales
                .OrderByDescending(s => s.CreatedAt)
                .Select(s => new SalesReportDto
                {
                    SaleId = s.Id,
                    CashRegisterName = s.CashRegister.Name,
                    DocumentNumber = s.DocumentNumber,
                    DocumentType = s.DocumentType?.Name,
                    Date = s.CreatedAt,
                    CustomerName = $"{s.Customer.LastName}, {s.Customer.FirstName}".Trim(),
                    CashierName = s.User.Username,
                    TotalAmount = s.TotalAmount
                })
                .ToList();
        }

        public async Task<SaleDto?> GetSaleDetailsAsync(int saleId)
        {
            var sale = await unitOfWork.Sales.GetByIdWithDetailsAsync(saleId);
            
            if (sale == null)
                return null;

            return MapToSaleDto(sale);
        }

        public async Task<SaleDto?> GetSaleByDocumentNumberAsync(string documentNumber)
        {
            var sale = await unitOfWork.Sales.GetByDocumentNumberAsync(documentNumber.Trim());
            
            if (sale == null) 
                return null;

            return MapToSaleDto(sale);
        }

        public async Task<IEnumerable<PurchaseReportDto>> GetPurchaseHistoryAsync(DateTime start, DateTime end, int? supplierId)
        {
            var purchases = await unitOfWork.Purchases.GetHistoryAsync(start.Date, end.Date.AddDays(1));

            if (supplierId.HasValue && supplierId.Value > 0)
                purchases = purchases.Where(p => p.SupplierId == supplierId.Value);

            return purchases.Select(p => new PurchaseReportDto
            {
                Date = p.CreatedAt,
                DocumentType = p.DocumentType?.Name,
                DocumentNumber = p.DocumentNumber,
                TotalAmount = p.TotalAmount,
                CashierName = p.User?.Username,
                SupplierTaxId = p.Supplier?.CUIT,
                SupplierName = p.Supplier?.CompanyName
            }).ToList();
        }

        private static SaleDto MapToSaleDto(Sale sale)
        {
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
                Items = (sale.SaleItems).Select(i => new SaleItemDto
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product?.Name ?? $"Producto #{i.ProductId}",
                    CategoryId = i.Product?.CategoryId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    DiscountAmount = i.DiscountAmount
                }).ToList()
            };
        }
    }
}