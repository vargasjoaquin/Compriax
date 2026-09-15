using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    /// <summary>
    /// Solicita al microservicio de Mercado Pago la creación de una orden de cobro dinámico con código QR.
    /// </summary>
    /// <param name="saleId">Id de la venta registrada.</param>
    /// <param name="amount">Monto total a cobrar.</param>
    /// <param name="description">Descripción visible en la pasarela de pago.</param>
    /// <param name="apiBaseUrl">URL base del servicio de pagos.</param>
    /// <returns>Resultado con el ID de la orden y la cadena codificada para el QR.</returns>
    public interface IMercadoPagoQrClient
    {
        Task<MercadoPagoQrOrderResponseDto> CreateQrOrderAsync(int saleId, decimal amount, string description, string? baseUrl = null);
    }
}
