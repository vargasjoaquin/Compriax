using CompriaxSystem.MercadoPago.Api.Configuration;
using CompriaxSystem.MercadoPago.Api.Interfaces;
using CompriaxSystem.MercadoPago.Api.Requests;
using CompriaxSystem.MercadoPago.Api.Responses;
using MercadoPago.Config;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace CompriaxSystem.MercadoPago.Api.Services
{
    public class MercadoPagoService : IMercadoPagoService
    {
        private readonly MercadoPagoSettings _settings;
        private readonly IHttpClientFactory _httpClientFactory;

        public MercadoPagoService(IOptions<MercadoPagoSettings> options, IHttpClientFactory httpClientFactory)
        {
            _settings = options.Value;
            _httpClientFactory = httpClientFactory;

            MercadoPagoConfig.AccessToken = _settings.AccessToken;
        }
        public async Task<PaymentResponse> CreateOrderAsync(CreatePaymentRequest request, string idempotencyKey)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.AccessToken);

            httpClient.DefaultRequestHeaders.Add("X-Idempotency-Key", idempotencyKey);

            // Payload oficial requerido por la Instore Orders API
            var payload = new
            {
                external_reference = request.SaleId.ToString(),
                title = request.Description,
                description = request.Description,
                total_amount = request.Amount,
                items = new[]
                {
                    new
                    {
                        title = request.Description,
                        unit_price = request.Amount,
                        quantity = 1,
                        unit_measure = "unit",
                        total_amount = request.Amount
                    }
                }
            };

            var jsonPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            // URL oficial para la creación de órdenes QR
            string url = $"https://api.mercadopago.com/instore/orders/qr/seller/collectors/{_settings.CollectorId}/pos/{_settings.PosId}/qrs";

            var response = await httpClient.PostAsync(url, content);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error de Mercado Pago ({response.StatusCode}): {responseBody}");
            }

            using var jsonDocument = JsonDocument.Parse(responseBody);

            string qrData = jsonDocument.RootElement.GetProperty("qr_data").GetString() ?? string.Empty;
            string inStoreOrderId = jsonDocument.RootElement.GetProperty("in_store_order_id").GetString() ?? idempotencyKey;

            return new PaymentResponse
            {
                TransactionId = 0,
                OrderId = inStoreOrderId,
                QrData = qrData,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };
        }
        public async Task<string> GetOrderStatusAsync(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                return "unkown";

            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.AccessToken);

                var response = await httpClient.GetAsync($"https://api.mercadopago.com/v1/orders/{orderId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    using var jsonDocument = JsonDocument.Parse(content);

                    if (jsonDocument.RootElement.TryGetProperty("status", out var statusElement))
                    {
                        return statusElement.GetString() ?? "unknown";
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return "expired";
                }

                return "unkown";
            }
            catch (Exception)
            {
                return "error";
            }
        }

        public async Task<bool> CancelOrderAsync(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                return false;

            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.AccessToken);

                // Llamada explícita al endpoint de cancelación
                // El endpoint de cancelación usualmente no requiere body, pero enviamos StringContent vacío por convención de POST HTTP.
                var content = new StringContent(string.Empty);
                var response = await httpClient.PostAsync($"https://api.mercadopago.com/v1/orders/{orderId}/cancel", content);

                return response.IsSuccessStatusCode;
            }
            catch
            {
                // Si falla por problemas de red o la orden ya estaba cerrada, retornamos falso.
                return false;
            }
        }


    }
}
