using CompriaxSystem.MercadoPago.Api.Configuration;
using CompriaxSystem.MercadoPago.Api.Interfaces;
using CompriaxSystem.MercadoPago.Api.Requests;
using CompriaxSystem.MercadoPago.Api.Responses;
using MercadoPago.Config;
using MercadoPago.Client.Qr;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
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
            var qrClient = new QrClient();

            var requestOptions = new MercadoPago.Http.RequestOptions
            {
                CustomHeaders = new Dictionary<string, string> { { "X-Idempotency-Key", idempotencyKey } }
            };

            var orderRequest = new QrRequest
            {
                ExternalReference = request.SaleId.ToString(),
                Title = request.Description,
                TotalAmount = request.Amount,
                ExternalId = $"COMPRIAX_{request.SaleId}"
            };

            var order = await qrClient.CreateAsync(orderRequest, requestOptions);

            return new PaymentResponse
            {
                TransactionId = 0,
                OrderId = order.ExternalId ?? idempotencyKey,
                QrData = order.QrData,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
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
