using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IReportService
    {
        /// <summary>
        /// Obtiene el historial de ventas detallado para reportes.
        /// </summary>
        /// <param name="start">Fecha inicio.</param>
        /// <param name="end">Fecha fin.</param>
        /// <param name="cashRegisterId">ID de caja opcional.</param>
        /// <returns>Colección de registros de venta.</returns>
        Task<IEnumerable<SalesReportDto>> GetSalesHistoryAsync(DateTime start, DateTime end, int? cashRegisterId = null);

        /// <summary>
        /// Obtiene el historial de compras realizadas a proveedores.
        /// </summary>
        /// <param name="start">Fecha inicio.</param>
        /// <param name="end">Fecha fin.</param>
        /// <param name="supplierId">ID de proveedor opcional.</param>
        /// <returns>Colección de registros de compra.</returns>
        Task<IEnumerable<PurchaseReportDto>> GetPurchaseHistoryAsync(DateTime start, DateTime end, int? supplierId);

        /// <summary>
        /// Genera estadísticas generales para el panel principal (Dashboard).
        /// </summary>
        /// <returns>Datos estadísticos consolidados.</returns>
        Task<DashboardDto> GetDashboardStatsAsync();

        /// <summary>
        /// Obtiene los detalles completos de una venta específica por id.
        /// </summary>
        /// <param name="saleId">ID de la venta.</param>
        /// <returns>Datos detallados de la venta.</returns>
        Task<SaleDto?> GetSaleDetailsAsync(int saleId);

        /// <summary>
        /// Busca una venta por su número de comprobante.
        /// </summary>
        /// <param name="documentNumber">Número de documento.</param>
        /// <returns>Datos de la venta encontrada.</returns>
        Task<SaleDto?> GetSaleByDocumentNumberAsync(string documentNumber);
    }
}
