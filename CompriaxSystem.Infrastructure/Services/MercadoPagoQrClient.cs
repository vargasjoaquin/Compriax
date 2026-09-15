using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using System.Text;
using System.Text.Json;

namespace CompriaxSystem.Infrastructure.Services
{
    public class MercadoPagoQrClient(IHttpClientFactory httpClientFactory) : IMercadoPagoQrClient
    {
        private const string BASE_URL = "https://localhost:7133";
        public async Task<MercadoPagoQrOrderResponseDto> CreateQrOrderAsync(int saleId, decimal amount, string description, string? baseUrl = null)
        {
            string url = (BASE_URL).TrimEnd('/');
            string endpoint = $"{url}/api/mercadopago/payments";

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

                using var requestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint)
                {
                    Content = new StringContent(JsonSerializer.Serialize(paymentRequest), Encoding.UTF8, "application/json")
                };

                requestMessage.Headers.Add("X-Idempotency-Key", idempotencyKey);

                var response = await httpClient.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return MercadoPagoQrOrderResponseDto.Failure($"Respuesta de error ({response.StatusCode}: {content})");
                }

                using var jsonDocument = JsonDocument.Parse(content);
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
