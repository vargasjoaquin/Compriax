using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Services
{
    public class ReportService(IUnitOfWork unitOfWork) : IReportService
    {
        /// <summary>
        /// Genera las métricas consolidadas para el Dashboard,
        /// incluyendo ventas, stock crítico y productos más vendidos.
        /// </summary>
        /// <returns>DTO con las estadísticas generales de gestión.</returns>
        public async Task<DashboardDto> GetDashboardStatsAsync()
        {
                        var localNow = DateTime.Now;
            var localToday = localNow.Date;

            var todayUtcStart = localToday.ToUniversalTime();
            var tomorrowUtcEnd = localToday.AddDays(1).ToUniversalTime();
            var sevenDaysAgoUtcStart = localToday.AddDays(-7).ToUniversalTime();

            var todaySales = (await unitOfWork.Sales.GetHistoryAsync(todayUtcStart, tomorrowUtcEnd)).ToList();

            var weekSales = (await unitOfWork.Sales.GetHistoryAsync(sevenDaysAgoUtcStart, tomorrowUtcEnd)).ToList();

            var product = (await unitOfWork.Products.GetAllWithDetailsAsync()).ToList();

            int lowStockProductCount = product.Count(product => !product.IsDeleted && product.CurrentStock <= product.MinimumStock);

            var criticalStockProducts = product
                .Where(product =>
                    !product.IsDeleted &&
                    product.CurrentStock <= product.MinimumStock)
                .OrderBy(product => product.CurrentStock)
                .Take(5)
                .Select(product => new CriticalStockDto
                {
                    ProductName = product.Name,
                    CurrentStock = product.CurrentStock,
                    MinimumStock = product.MinimumStock
                })
                .ToList();

            var topSellingProducts = todaySales
                .SelectMany(sale => sale.SaleItems)
                .GroupBy(saleItem =>
                    saleItem.Product != null
                        ? saleItem.Product.Name
                        : $"Producto #{saleItem.ProductId}")
                .Select(productGroup => new TopProductDto
                {
                    ProductName = productGroup.Key,
                    QuantitySold = productGroup.Sum(
                        saleItem => saleItem.Quantity)
                })
                .OrderByDescending(
                    product => product.QuantitySold)
                .Take(5)
                .ToList();

            var salesByCategory = todaySales
                .SelectMany(sale => sale.SaleItems)
                .GroupBy(saleItem => saleItem.Product.Category.Name)
                .Select(categoryGroup => new CategorySalesDto
                {
                    CategoryName = categoryGroup.Key,
                    TotalRevenue = categoryGroup.Sum(
                        saleItem => saleItem.SubTotal)
                })
                .ToList();

            return new DashboardDto
            {
                TotalSalesToday = todaySales.Sum(sale => sale.TotalAmount),
                TotalSalesWeek = weekSales.Sum(sale => sale.TotalAmount),
                SalesCountToday = todaySales.Count,
                ProductsLowStockCount = lowStockProductCount,
                TopSellingProducts = topSellingProducts,
                SalesByCategory = salesByCategory,
                CriticalStockList = criticalStockProducts
            };
        }

        /// <summary>
        /// Recupera el historial detallado de ventas filtrado por fecha
        /// y, opcionalmente, por caja registradora.
        /// </summary>
        /// <param name="startDate">Fecha inicial del período.</param>
        /// <param name="endDate">Fecha final del período.</param>
        /// <param name="cashRegisterId">
        /// Identificador de la caja registradora utilizada como filtro.
        /// </param>
        /// <returns>Colección de reportes de ventas.</returns>
        public async Task<IEnumerable<SalesReportDto>> GetSalesHistoryAsync(DateTime startDate, DateTime endDate, int? cashRegisterId = null)
        {
                        var startUtc = startDate.Date.ToUniversalTime();
            var endUtc = endDate.Date.AddDays(1).ToUniversalTime();
            var salesHistory = await unitOfWork.Sales.GetHistoryAsync(startUtc, endUtc, cashRegisterId);

            return salesHistory
                .OrderByDescending(sale => sale.CreatedAt)
                .Select(sale => new SalesReportDto
                {
                    SaleId = sale.Id,
                    CashRegisterName = sale.CashRegister != null ? sale.CashRegister.Name : "Caja Principal",
                    DocumentNumber = sale.DocumentNumber,
                    DocumentType = sale.DocumentType != null ? sale.DocumentType.Name : "N/A",
                    Date = sale.CreatedAt,
                    CustomerName = sale.Customer != null ? $"{sale.Customer.LastName} {sale.Customer.FirstName}".Trim() : "Consumidor Final",
                    CashierName = sale.User != null ? sale.User.Username : "N/A",
                    TotalAmount = sale.TotalAmount
                })
                .ToList();
        }

        /// <summary>
        /// Obtiene los detalles completos de una venta,
        /// incluyendo sus ítems, mediante su identificador.
        /// </summary>
        /// <param name="saleId">Identificador de la venta.</param>
        /// <returns>
        /// DTO con el detalle de la venta o null si no existe.
        /// </returns>
        public async Task<SaleDto?> GetSaleDetailsAsync(int saleId)
        {
            var sale = await unitOfWork.Sales
                .GetByIdWithDetailsAsync(saleId);

            if (sale == null)
                return null;

            return MapToSaleDto(sale);
        }

        /// <summary>
        /// Busca los datos de una venta utilizando su número de comprobante.
        /// </summary>
        /// <param name="documentNumber">Número de comprobante o documento fiscal.</param>
        /// <returns>DTO de la venta encontrada o null si no existe.</returns>
        public async Task<SaleDto?> GetSaleByDocumentNumberAsync(string documentNumber)
        {
            var sale= await unitOfWork.Sales.GetByDocumentNumberAsync(documentNumber.Trim());

            if (sale == null)
                return null;

            return MapToSaleDto(sale);
        }

        /// <summary>
        /// Recupera el historial de compras realizadas a proveedores
        /// dentro de un rango de fechas y, opcionalmente, filtradas por proveedor.
        /// </summary>
        /// <param name="startDate">Fecha inicial del período.</param>
        /// <param name="endDate">Fecha final del período.</param>
        /// <param name="supplierId">Id del proveedor utilizado como filtro.</param>
        /// <returns>Colección de reportes de compras.</returns>
        public async Task<IEnumerable<PurchaseReportDto>> GetPurchaseHistoryAsync(DateTime startDate, DateTime endDate,int? supplierId)
        {
                        var startUtc = startDate.Date.ToUniversalTime();
            var endUtc = endDate.Date.AddDays(1).ToUniversalTime();
            var purchase = await unitOfWork.Purchases.GetHistoryAsync(startUtc, endUtc);

            if (supplierId.HasValue && supplierId.Value > 0)
            {
                purchase = purchase.Where(purchase => purchase.SupplierId == supplierId.Value);
            }

            return purchase
                .Select(purchase => new PurchaseReportDto
                {
                    Date = purchase.CreatedAt,
                    DocumentType = purchase.DocumentType?.Name,
                    DocumentNumber = purchase.DocumentNumber,
                    TotalAmount = purchase.TotalAmount,
                    CashierName = purchase.User?.Username,
                    SupplierTaxId = purchase.Supplier?.CUIT,
                    SupplierName = purchase.Supplier?.CompanyName
                })
                .ToList();
        }

        /// <summary>
        /// Convierte una entidad de venta en su DTO correspondiente,
        /// incluyendo la información del cliente, usuario, comprobante e ítems.
        /// </summary>
        /// <param name="sale">
        /// Entidad de venta que se desea convertir.
        /// </param>
        /// <returns>DTO con la información completa de la venta.</returns>
        private static SaleDto MapToSaleDto(Sale sale)
        {
            return new SaleDto
            {
                Id = sale.Id,
                DocumentNumber = sale.DocumentNumber,
                DocumentTypeId = sale.DocumentTypeId,
                DocumentTypeName = sale.DocumentType?.Name,
                Date = sale.CreatedAt,
                CustomerName = sale.Customer != null ? $"{sale.Customer.FirstName} {sale.Customer.LastName}".Trim() : "Consumidor Final",
                CustomerDoc = sale.Customer != null ? sale.Customer.DocumentNumber : "S/D",
                CashierName = sale.User?.Username,
                PaymentReceived = sale.PaymentReceived,
                TotalAmount = sale.TotalAmount,
                Items = sale.SaleItems
                    .Select(saleItem => new SaleItemDto
                    {
                        ProductId = saleItem.ProductId,
                        ProductName = saleItem.Product?.Name ?? $"Producto #{saleItem.ProductId}",
                        CategoryId = saleItem.Product?.CategoryId,
                        Quantity = saleItem.Quantity,
                        UnitPrice = saleItem.UnitPrice,
                        DiscountAmount = saleItem.DiscountAmount
                    })
                    .ToList()
            };
        }
    }
}