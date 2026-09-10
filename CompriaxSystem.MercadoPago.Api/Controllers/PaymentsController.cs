using CompriaxSystem.Domain.Enums;
using CompriaxSystem.MercadoPago.Api.Interfaces;
using CompriaxSystem.MercadoPago.Api.Requests;
using CompriaxSystem.MercadoPago.Api.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CompriaxSystem.MercadoPago.Api.Controllers
{
    [ApiController]
    [Route("api/mercadopago/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IMercadoPagoService _mercadoPagoService;
        private readonly ITransactionService _transactionService;
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(IMercadoPagoService mercadoPagoService, ITransactionService transactionService, ILogger<PaymentsController> logger)
        {
            _mercadoPagoService = mercadoPagoService;
            _transactionService = transactionService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest request, [FromHeader(Name = "X-Idempotency-Key")] string idempotencyKey)
        {
            if (string.IsNullOrWhiteSpace(idempotencyKey))
                return BadRequest(new { message = "Se requiere X-Idempotency-Key en la cabecera." });

            if (request.Amount <= 0)
                return BadRequest(new { message = "El monto debe ser mayor a 0 (cero)" });

            try
            {
                // 1. La venta ya fue pagada?
                bool isSaleAlreadyApproved = await _transactionService.HasApprovedTransactionAsync(request.SaleId);

                if (isSaleAlreadyApproved)
                    return BadRequest(new { message = "La venta especifica ya cuenta con un pago aprobado en Mercado Pado" });

                // 2. Ya existe esta misma peticion exacta?
                var existingTransaction = await _transactionService.GetByIpempotencyKeyAsync(idempotencyKey);

                if (existingTransaction != null)
                {
                    // Si ya existe la peticion, devolvemos el estado actual en lugar de crear otra peticion.
                    return Ok(new PaymentResponse
                    {
                        TransactionId = existingTransaction.Id,
                        OrderId = existingTransaction.OrderId ?? string.Empty,
                        QrData = "PREVIAMENTE_GENERADO",
                        Status = existingTransaction.Status.Name,
                        CreatedAt = existingTransaction.CreatedAt
                    });
                }

                // 3. Registrar la transaccion en estado 'Pendiente'.
                var transaction = await _transactionService.InitializeTransactionAsync(request.SaleId, request.Amount, idempotencyKey);

                // 4. Llamar a Mercado Pago para generar la orden QR.
                var response = await _mercadoPagoService.CreateOrderAsync(request, idempotencyKey);
                response.TransactionId = transaction.Id;

                // 5. Actualizamos la transaccion con el id real que nos dio Mercado Pago.
                await _transactionService.UpdateTransactionStatusAsync(response.OrderId, MercadoPagoPaymentStatus.Pending);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Fallo al crear el pago para el id de la venta: {request.SaleId}");
                return BadRequest(new { message = "Ha ocurrido un error al procesar la solicitud con el proveedor de pagos." });
            }
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetStatus(string orderId)
        {
            try
            {
                // 1. Consultamos el estado real a Mercado Pago
                string rawStatus = await _mercadoPagoService.GetOrderStatusAsync(orderId);

                // 2. Actualizamos nuestra base de datos por si el webhook se retraso
                MercadoPagoPaymentStatus internalStatus;
                switch (rawStatus.ToLower())
                {
                    case "closed":
                    case "processed":
                    case "paid":
                    case "approved":
                        internalStatus = MercadoPagoPaymentStatus.Approved;
                        break;

                    case "canceled":
                    case "cancelled":
                        internalStatus = MercadoPagoPaymentStatus.Cancelled;
                        break;

                    case "expired":
                        internalStatus = MercadoPagoPaymentStatus.Expired;
                        break;

                    case "refunded":
                    case "rejected":
                        internalStatus = MercadoPagoPaymentStatus.Rejected;
                        break;

                    default:
                        internalStatus = MercadoPagoPaymentStatus.Pending;
                        break;
                }

                await _transactionService.UpdateTransactionStatusAsync(orderId, internalStatus);

                return Ok(new { orderId, status = internalStatus.ToString() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al consultar estado de la orden {orderId}");
                return BadRequest(new { message = "Error de comunicación al consultar el estado." });
            }
        }


        [HttpPost("{orderId}/cancel")]
        public async Task<IActionResult> CancelPayment(string orderId)
        {
            try
            {
                // 1. Solicitar a Mercado Pago la cancelación de la orden.
                bool isSuccess = await _mercadoPagoService.CancelOrderAsync(orderId);

                if (isSuccess)
                {
                    // 2. Si Mercado Pago confirmó la cancelación, actualizamos el estado de la transacción en nuestra base de datos.
                    await _transactionService.UpdateTransactionStatusAsync(orderId, MercadoPagoPaymentStatus.Cancelled);

                    return Ok(new { message = "La orden fue cancelada exitosamente."});
                }

                return BadRequest(new { message = "No se pudo cancelar la orden en Mercado Pago. Es posible que ya haya expirado o haya sido pagada."});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ha ocurrido un error al cancelar la orden {orderId}");

                return BadRequest(new { message = "Error interno al intentar cancelar la orden."});
            }
        }
    }
}
