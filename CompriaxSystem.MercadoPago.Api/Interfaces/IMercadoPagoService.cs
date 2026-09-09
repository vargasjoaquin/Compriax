using CompriaxSystem.MercadoPago.Api.Requests;
using CompriaxSystem.MercadoPago.Api.Responses;

namespace CompriaxSystem.MercadoPago.Api.Interfaces
{
    public interface IMercadoPagoService
    {
        // Crea la orden QR y devuelve el QR codificado.
        Task<PaymentResponse> CreateOrderAsync(CreatePaymentRequest request, string idempotencyKey);

        // Consulta el estado actual de la orden en Mercado Pago.
        Task<string> GetOrderStatusAsync(string orderId);

        // Cancela una orden perdiente.
        Task<bool> CancelOrderAsync(string orderId);
    }
}
