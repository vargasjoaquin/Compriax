using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;
using CompriaxSystem.Infrastructure.Persistence;
using CompriaxSystem.MercadoPago.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompriaxSystem.MercadoPago.Api.Services
{
    public class TransactionService(ApplicationDbContext context) : ITransactionService
    {
        public async Task<MercadoPagoTransaction> InitializeTransactionAsync(int saleId, decimal amount, string idempotencyKey)
        {
            // 1. Crear una nueva transacción asociada a la venta. La transacción comienza en estado "Pendiente" porque
            // todavía no tenemos confirmación de Mercado Pago.
            var transaction = new MercadoPagoTransaction
            {
                SaleId = saleId,
                StatusId = (int)MercadoPagoPaymentStatus.Pending,
                Amount = amount,
                IdempotencyKey = idempotencyKey,
                CreatedAt = DateTime.UtcNow,
            };

            // 2. Agregar la nueva transacción al contexto de Entity Framework.
            await context.MercadoPagoTransactions.AddAsync(transaction);

            // 3. Guardar la transacción en la base de datos.
            await context.SaveChangesAsync();

            // 4. Devolver la transacción creada para que pueda // ser utilizada por la capa que realizó la solicitud.
            return transaction;
        }

        public async Task<MercadoPagoTransaction?> GetByIdempotencyKeyAsync(string idempotencyKey)
        {
            // 1. Buscar una transacción utilizando la clave de idempotencia. También incluimos el estado relacionado para poder
            // conocer directamente su información.
            return await context.MercadoPagoTransactions
                .Include(t => t.Status)
                .FirstOrDefaultAsync(t => t.IdempotencyKey == idempotencyKey);
        }

        public async Task UpdateTransactionStatusAsync(string identifier, MercadoPagoPaymentStatus? status = null, string? orderId = null, string? externalReference = null, string? externalPaymentId = null)
        {
            // 1. Buscar la transacción utilizando cualquiera de los identificadores disponibles.
            // Esto permite localizarla mediante el OrderId, la clave de idempotencia o la referencia externa.
            var transaction = await context.MercadoPagoTransactions
                    .FirstOrDefaultAsync(t => t.OrderId == identifier || t.IdempotencyKey == identifier || t.ExternalReference == identifier);

            // 2. Verificar que se haya encontrado una transacción.
            if (transaction != null)
            {
                // 3. Si se recibió un nuevo estado, actualizar el estado de la transacción.
                if (status.HasValue)
                    transaction.StatusId = (int)status.Value;

                // 4. Si se recibió un OrderId válido, actualizar el identificador de la orden.
                if (!string.IsNullOrWhiteSpace(orderId))
                    transaction.OrderId = orderId;

                // 5. Si se recibió una referencia externa válida, actualizar la referencia de la transacción.
                if (!string.IsNullOrWhiteSpace(externalReference))
                    transaction.ExternalReference = externalReference;

                // 6. Si se recibió un identificador de pago válido, // actualizar el ID del pago proporcionado por Mercado Pago.
                if (!string.IsNullOrWhiteSpace(externalPaymentId))
                    transaction.ExternalPaymentId = externalPaymentId;

                transaction.UpdatedAt = DateTime.UtcNow;
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> HasApprovedTransactionAsync(int saleId)
        {
            // 1. Verificar si existe una transacción asociada a la venta que tenga actualmente el estado "Aprobado".
            return await context.MercadoPagoTransactions
                .AnyAsync(t => t.SaleId == saleId && t.StatusId == (int)MercadoPagoPaymentStatus.Approved);
        }
    }
}
