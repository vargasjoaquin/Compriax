using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Application.Services
{
    public class InventoryService(IUnitOfWork unitOfWork, ICurrentUserService currentUser) : IInventoryService
    {
        /// <summary>
        /// Ajusta el stock de un producto y registra el movimiento de inventario dentro de una transacción.
        /// </summary>
        /// <param name="productId">ID del producto a ajustar.</param>
        /// <param name="amount">Cantidad a sumar o restar.</param>
        /// <param name="reason">Motivo o comentario del ajuste.</param>
        /// <returns>Resultado del ajuste de stock.</returns>
        public async Task<OperationResult> AdjustStockAsync(int productId, int amount, string reason)
        {
            var product = await unitOfWork.Products.GetByIdAsync(productId);
            
            if (product == null)
                return OperationResult.Failure("Producto no encontrado.");

            await unitOfWork.BeginTransactionAsync();
            
            try
            {
                product.CurrentStock += amount;

                await unitOfWork.Products.AddMovementAsync(new StockMovement
                {
                    ProductId = productId,
                    UserId = currentUser.CurrentUser!.UserId,
                    Quantity = amount,
                    MovementType = MovementType.Adjustment,
                    Remarks = reason,
                    CreatedBy = currentUser.CurrentUser!.Username
                });

                await unitOfWork.CompleteAsync();
                await unitOfWork.CommitAsync();
                
                return OperationResult.Ok("Inventario ajustado correctamente.");
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                
                return OperationResult.Failure("Error al procesar el ajuste de inventario.");
            }
        }
    }
}