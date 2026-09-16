using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using System.Text;
using System.Text.Json;

namespace CompriaxSystem.Infrastructure.Services
{
    public class MercadoPagoQrClient(IHttpClientFactory httpClientFactory) : IMercadoPagoQrClient
    {
        private const string BASE_URL = "https://localhost:7133";

        /// <summary>
        /// Crea una orden de pago mediante código QR para una venta determinada.
        /// </summary>
        /// <param name="saleId">Identificador de la venta asociada a la orden de pago.</param>
        /// <param name="amount">Importe total de la orden de pago.</param>
        /// <param name="description">Descripción asociada al pago.</param>
        /// <param name="baseUrl">
        /// URL base opcional del servicio de pagos. Actualmente no se utiliza y se mantiene
        /// por compatibilidad con la interfaz existente.
        /// </param>
        /// <returns>
        /// Resultado de la creación de la orden, incluyendo su identificador y los datos del código QR.
        /// </returns>
        public async Task<MercadoPagoQrOrderResponseDto> CreateQrOrderAsync(int saleId, decimal amount, string description, string? baseUrl = null)
        {
            string serviceBaseUrl = (BASE_URL).TrimEnd('/');
            string paymentEndpoint = $"{url}/api/mercadopago/payments";

            try
            {
                var httpClient = httpClientFactory.CreateClient();
                string idempotencyKey = Guid.NewGuid().ToString();

                var paymentRequest = new
                {
                    saleId = saleId,
                    amount = amount,
                    description = description
                };

                using var requestMessage = new HttpRequestMessage(HttpMethod.Post, paymentEndpoint)
                {
                    Content = new StringContent(JsonSerializer.Serialize(paymentRequest), Encoding.UTF8, "application/json")
                };

                requestMessage.Headers.Add("X-Idempotency-Key", idempotencyKey);

                var response = await httpClient.SendAsync(requestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return MercadoPagoQrOrderResponseDto.Failure($"Respuesta de error ({response.StatusCode}: {responseContent})");
                }

                using var jsonDocument = JsonDocument.Parse(responseContent);
                string orderId = jsonDocument.RootElement.GetProperty("orderId").GetString();
                string qrData = jsonDocument.RootElement.GetProperty("qrData").GetString();

                return MercadoPagoQrOrderResponseDto.Ok(orderId, qrData);
            }
            catch (Exception ex)
            {
                return MercadoPagoQrOrderResponseDto.Failure($"Fallo de conexión con servicio de pagos: {ex.Message}");
            }
        }
    }
}
