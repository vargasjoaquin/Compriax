using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
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
            if (amount == 0)
                return OperationResult.Failure("La cantidad del ajuste debe ser distinta de cero.");

            var product = await unitOfWork.Products.GetByIdAsync(productId);

            if (product == null)
                return OperationResult.Failure("Producto no encontrado.");

            if (!currentUser.IsAuthenticated || currentUser.CurrentUser == null)
                return OperationResult.Failure("Operación no autorizada: No hay una sesión de usuario activa.");

            string sanitizedReason = !string.IsNullOrWhiteSpace(reason) 
                ? (reason.Trim().Length > 250 ? reason.Trim().Substring(0, 250) : reason.Trim())
                : "Ajuste manual de inventario";

            string currentUsername = !string.IsNullOrWhiteSpace(currentUser.CurrentUser.Username)
                ? (currentUser.CurrentUser.Username.Length > 50 ? currentUser.CurrentUser.Username.Substring(0, 50) : currentUser.CurrentUser.Username)
                : RoleConstants.DEFAULT_ADMIN_USERNAME;

            await unitOfWork.BeginTransactionAsync();

            try
            {
                product.CurrentStock += amount;
                product.LastUpdatedAt = DateTime.UtcNow;
                product.LastUpdatedBy = currentUsername;

                await unitOfWork.Products.AddMovementAsync(new StockMovement
                {
                    ProductId = productId,
                    UserId = currentUser.CurrentUser.UserId,
                    Quantity = amount,
                    MovementType = MovementType.Adjustment,
                    Remarks = sanitizedReason,
                    CreatedBy = currentUsername,
                    CreatedAt = DateTime.UtcNow
                });

                await unitOfWork.CompleteAsync();
                await unitOfWork.CommitAsync();

                return OperationResult.Ok("Inventario ajustado correctamente.");
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                return OperationResult.Failure($"Error al procesar el ajuste de inventario: {ex.Message}");
            }
        }
    }
}