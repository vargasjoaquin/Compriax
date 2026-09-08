using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IDocumentService
    {
        /// <summary>
        /// Genera un comprobante de venta en formato PDF (tamaño A4/Carta).
        /// </summary>
        /// <param name="sale">Datos de la venta.</param>
        /// <param name="documentNumber">Número oficial del comprobante.</param>
        /// <param name="cashierName">Nombre del cajero.</param>
        /// <returns>Arreglo de bytes del PDF generado.</returns>
        Task<byte[]> GenerateSaleReceiptAsync(SaleDto sale, string documentNumber, string cashierName);

        /// <summary>
        /// Genera un ticket de venta para impresoras térmicas.
        /// </summary>
        /// <param name="sale">Datos de la venta.</param>
        /// <param name="documentNumber">Número del comprobante.</param>
        /// <param name="cashierName">Nombre del cajero.</param>
        /// <param name="paperSize">Tamaño del papel térmico (ej. 80mm).</param>
        /// <returns>Arreglo de bytes del ticket.</returns>
        Task<byte[]> GenerateThermalTicketReceiptAsync(SaleDto sale, string documentNumber, string cashierName, ThermalPaperSize paperSize = ThermalPaperSize.Width80mm);

        /// <summary>
        /// Genera un reporte de inventario actual en formato PDF.
        /// </summary>
        /// <param name="products">Lista de productos a incluir.</param>
        /// <returns>Documento PDF con el reporte.</returns>
        Task<byte[]> GenerateInventoryReportAsync(IEnumerable<ProductDto> products);

        /// <summary>
        /// Genera un listado de clientes en PDF.
        /// </summary>
        /// <param name="customers">Colección de clientes.</param>
        /// <returns>Reporte en formato PDF.</returns>
        Task<byte[]> GenerateCustomersReportAsync(IEnumerable<CustomerDto> customers);

        /// <summary>
        /// Genera un listado de proveedores en PDF.
        /// </summary>
        /// <param name="suppliers">Colección de proveedores.</param>
        /// <returns>Reporte en formato PDF.</returns>
        Task<byte[]> GenerateSuppliersReportAsync(IEnumerable<SupplierDto> suppliers);

        /// <summary>
        /// Genera un listado de usuarios del sistema en PDF.
        /// </summary>
        /// <param name="users">Colección de usuarios.</param>
        /// <returns>Reporte en formato PDF.</returns>
        Task<byte[]> GenerateUsersReportAsync(IEnumerable<UserDto> users);

        /// <summary>
        /// Genera un comprobante de compra para registro interno o proveedor.
        /// </summary>
        /// <param name="purchase">Datos de la compra.</param>
        /// <param name="supplierName">Nombre del proveedor.</param>
        /// <param name="supplierCuit">CUIT del proveedor.</param>
        /// <param name="registeredBy">Usuario que registró la compra.</param>
        /// <returns>PDF de la compra.</returns>
        Task<byte[]> GeneratePurchaseReceiptAsync(PurchaseCreateDto purchase, string supplierName, string supplierCuit, string registeredBy);

        /// <summary>
        /// Genera un ticket con el resumen de un turno de caja (Arqueo o Cierre Z).
        /// </summary>
        /// <param name="shift">Resumen del turno.</param>
        /// <param name="isZClose">Indica si es un cierre definitivo.</param>
        /// <returns>Ticket en formato PDF/Térmico.</returns>
        Task<byte[]> GenerateCashShiftTicketAsync(CashShiftSummaryDto shift, bool isZClose = true);
    }
}
