using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IInventoryService
    {
        /// <summary>
        /// Realiza un ajuste manual del stock de un producto.
        /// </summary>
        /// <param name="productId">ID del producto.</param>
        /// <param name="amount">Cantidad a ajustar (positiva para suma, negativa para resta).</param>
        /// <param name="reason">Motivo justificado del ajuste.</param>
        /// <returns>Resultado del ajuste de inventario.</returns>
        Task<OperationResult> AdjustStockAsync(int productId, int amount, string reason);
    }
}
