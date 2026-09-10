using CompriaxSystem.Domain.Enums;
using CompriaxSystem.MercadoPago.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CompriaxSystem.MercadoPago.Api.Controllers
{
    [ApiController]
    [Route("api/mercadopago/[controller]")]
    public class WebhooksController : ControllerBase
    {
        private readonly IMercadoPagoService _mercadoPagoService;
        private readonly ITransactionService _transactionService;
        private readonly ILogger<WebhooksController> _logger;

        public WebhooksController(IMercadoPagoService mercadoPagoService, ITransactionService transactionService, ILogger<WebhooksController> logger)
        {
            _mercadoPagoService = mercadoPagoService;
            _transactionService = transactionService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> ReceiveNotifation([FromBody] JsonElement payload, [FromQuery] string? topic, [FromQuery] string? id)
        {
            try
            {
                // 1. Intentamos obtener el identificador de la orden directamente desde el parámetro "id" enviado por Mercado Pago.
                string orderId = id ?? string.Empty;

                // 2. Si no recibimos el "id" mediante la URL, intentamos obtenerlo desde el cuerpo de la notificación.
                if (string.IsNullOrWhiteSpace(orderId) && payload.TryGetProperty("data", out var dataElement))
                {
                    // 3. Buscamos el identificador de la orden dentro del objeto "data" enviado por Mercado Pago.
                    if (dataElement.TryGetProperty("id", out var idElement))
                    {
                        orderId = idElement.GetString() ?? string.Empty;
                    }
                }

                // 4. Si después de ambas comprobaciones no tenemos un identificador válido no podemos determinar qué orden debemos actualizar.
                if (string.IsNullOrWhiteSpace(orderId))
                {
                    _logger.LogWarning("Webhook recibido sin un id válido.");
                    return Ok();
                }

                _logger.LogInformation($"Se esta procesando el webhook para la orden/pago: {orderId}");

                // 6. Consultamos directamente a Mercado Pago para obtener el estado actual y real de la orden.
                string realStatus = await _mercadoPagoService.GetOrderStatusAsync(orderId);

                // 7. Convertimos el estado de Mercado Pago al estado utilizado internamente por nuestro sistema.
                var internalStatus = MapMercadoPagoStatusToInternal(realStatus);

                // 8. Actualizamos el estado de la transacción en nuestra base de datos.
                await _transactionService.UpdateTransactionStatusAsync(orderId, internalStatus);

                _logger.LogInformation($"Orden {orderId} actualizada al estado: {internalStatus}");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error critico al procesar el webhook");
                return BadRequest();
            }
        }

        private static MercadoPagoPaymentStatus MapMercadoPagoStatusToInternal(string mpStatus)
        {
            switch (mpStatus.ToLowerInvariant())
            {
                case "closed":
                case "processed":
                case "paid":
                case "approved":
                    return MercadoPagoPaymentStatus.Approved;

                case "canceled":
                case "cancelled":
                    return MercadoPagoPaymentStatus.Cancelled;

                case "expired":
                    return MercadoPagoPaymentStatus.Expired;

                case "refunded":
                case "rejected":
                    return MercadoPagoPaymentStatus.Rejected;

                case "error":
                    // Mantenemos pendiente si hubo un fallo de red temporal
                    return MercadoPagoPaymentStatus.Pending;

                default:
                    // "opened", "created", etc.
                    return MercadoPagoPaymentStatus.Pending;
            }
        }
    }
}
