using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ISaleService
    {
        /// <summary>
        /// Procesa una transacción de venta completa, incluyendo validaciones y stock.
        /// </summary>
        /// <param name="saleDto">Datos de la venta a procesar.</param>
        /// <returns>Resultado de la venta con ID generado o errores.</returns>
        Task<OperationResult> ProcessSaleAsync(SaleDto saleDto);

        /// <summary>
        /// Valida si existe stock suficiente de un producto antes de realizar una operación.
        /// </summary>
        /// <param name="productId">ID del producto.</param>
        /// <param name="requestQuantity">Cantidad solicitada.</param>
        /// <returns>Resultado indicando disponibilidad de stock.</returns>
        Task<OperationResult> ValidateStockAsync(int productId, int requestQuantity);

        /// <summary>
        /// Obtiene el próximo número de comprobante correlativo que se emitirá para un tipo de documento.
        /// </summary>
        /// <param name="documentTypeId">ID del tipo de documento fiscal o interno.</param>
        /// <returns>Próximo número correlativo formateado a 8 dígitos.</returns>
        Task<string> GetNextDocumentNumberAsync(int documentTypeId);
    }
}
