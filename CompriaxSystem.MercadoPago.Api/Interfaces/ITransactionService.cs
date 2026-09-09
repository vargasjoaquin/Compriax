using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.MercadoPago.Api.Interfaces
{
    public interface ITransactionService
    {
        // Registra el intento de transacción antes de llamar a Mercado Pago.
        Task<MercadoPagoTransaction> InitializeTransactionAsync(int saleId, decimal amount, string idempotencyKey);

        // Obtiene una transacción por su clave de idempotencia.
        Task<MercadoPagoTransaction> GetByIpempotencyKeyAsync(string idempotencyKey);

        // Actualiza el estado tras recibir una notifiación o realizar una consulta.
        Task UpdateTransactionStatusAsync(string orderId, MercadoPagoPaymentStatus status, string? externalPaymentId = null);

        // Verifica si la venta ya tiene un pago aprobado para evitar duplicados.
        Task<bool> HasApprovedTransactionAsync(int saleId);
    }
}
