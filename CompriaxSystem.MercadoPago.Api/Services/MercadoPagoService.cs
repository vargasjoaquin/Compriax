using CompriaxSystem.MercadoPago.Api.Configuration;
using CompriaxSystem.MercadoPago.Api.Interfaces;
using CompriaxSystem.MercadoPago.Api.Requests;
using CompriaxSystem.MercadoPago.Api.Responses;
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
        }

        public async Task<PaymentResponse> CreateOrderAsync(CreatePaymentRequest request, string idempotencyKey)
        {
            // 1. Crear un HttpClient para realizar la comunicación con la API de Mercado Pago.
            var httpClient = _httpClientFactory.CreateClient();

            // 2. Configurar el Access Token que permitirá autenticar las solicitudes contra Mercado Pago.
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.AccessToken);

            // 3. Agregar la clave de idempotencia para evitar la creación de operaciones duplicadas.
            httpClient.DefaultRequestHeaders.Add("X-Idempotency-Key", idempotencyKey);

            // 4. Construir el cuerpo de la solicitud con la información necesaria para crear la orden/preferencia de pago.
            var payload = new
            {
                external_reference = request.SaleId.ToString(),
                items = new[]
                {
                    new
                    {
                        id = request.SaleId.ToString(),
                        title = request.Description,
                        description = request.Description,
                        unit_price = request.Amount,
                        quantity = 1,
                        currency_id = "ARS"
                    }
                }
            };

            // 5. Convertir el objeto de la solicitud a formato JSON.
            var jsonPayload = JsonSerializer.Serialize(payload);

            // 6. Crear el contenido HTTP indicando que la información será enviada utilizando el formato JSON.
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            // 7. Definir la URL del endpoint de Mercado Pago utilizado para crear la preferencia de pago.
            string mercadoPagoPreferenceUrl = "https://api.mercadopago.com/checkout/preferences";

            // 8. Enviar la solicitud POST a Mercado Pago.
            var response = await httpClient.PostAsync(mercadoPagoPreferenceUrl, content);

            // 9. Leer el contenido de la respuesta para poder procesar la información devuelta por Mercado Pago.
            var responseBody = await response.Content.ReadAsStringAsync();

            // 10. Si Mercado Pago devuelve un código HTTP de error, detenemos el proceso y notificamos el problema.
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error de Mercado Pago ({response.StatusCode}): {responseBody}");
            }

            // 11. Parsear la respuesta JSON recibida desde Mercado Pago.
            using var jsonDocument = JsonDocument.Parse(responseBody);

            // 12. Obtener el identificador de la preferencia creada. Si no existe, utilizamos la clave de idempotencia como respaldo.
            string preferenceId = jsonDocument.RootElement.GetProperty("id").GetString() ?? idempotencyKey;

            // 13. Determinar qué propiedad contiene la URL de inicio, dependiendo de si estamos trabajando con el entorno de prueba // o con el entorno productivo.
            string pointProperty = _settings.AccessToken.StartsWith("TEST-", StringComparison.OrdinalIgnoreCase) ? "sandbox_init_point" : "init_point";

            // 14. Obtener la URL que permitirá iniciar el proceso de pago.
            string initPoint = jsonDocument.RootElement.GetProperty(pointProperty).GetString() ?? string.Empty;

            // 15. Construir la respuesta que será utilizada por el sistema.
            return new PaymentResponse
            {
                TransactionId = 0,
                OrderId = preferenceId,
                QrData = initPoint,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };
        }

        public async Task<string> GetOrderStatusAsync(string identifier)
        {
            // 1. Validar que se haya recibido un identificador válido.
            if (string.IsNullOrWhiteSpace(identifier))
                return "unknown";

            try
            {
                // 2. Crear el cliente HTTP para comunicarnos con la API de Mercado Pago.
                var httpClient = _httpClientFactory.CreateClient();

                // 3. Configurar el Access Token para autenticar las solicitudes contra Mercado Pago.
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.AccessToken);

                // 4. Intentamos determinar si el identificador recibido corresponde directamente a un ID numérico de pago de Mercado Pago.
                if (long.TryParse(identifier, out _))
                {
                    // 5. Consultar directamente el pago utilizando su id.
                    var paymentResponse = await httpClient.GetAsync($"https://api.mercadopago.com/v1/payments/{identifier}");

                    // 6. Si Mercado Pago responde correctamente, procesamos la información del pago.
                    if (paymentResponse.IsSuccessStatusCode)
                    {
                        // 7. Leer el contenido JSON de la respuesta.
                        var paymentContent = await paymentResponse.Content.ReadAsStringAsync();

                        // 8. Parsear la respuesta JSON.
                        using var paymentDocument = JsonDocument.Parse(paymentContent);

                        // 9. Buscar el estado actual del pago.
                        if (paymentDocument.RootElement.TryGetProperty("status", out var statusElement))
                        {
                            // 10. Devolver el estado informado por Mercado Pago.
                            return statusElement.GetString() ?? "unknown";
                        }
                    }
                }

                // 11. Si el identificador no corresponde a un ID de pago o no se pudo encontrar directamente, buscamos mediante la referencia externa asociada al pago.
                var searchResponse = await httpClient.GetAsync($"https://api.mercadopago.com/v1/payments/search?external_reference={identifier}");

                // 12. Verificar si Mercado Pago respondió correctamente a la búsqueda por referencia externa.
                if (searchResponse.IsSuccessStatusCode)
                {
                    // 13. Leer el contenido JSON de la búsqueda.
                    var searchContent = await searchResponse.Content.ReadAsStringAsync();

                    // 14. Parsear la respuesta JSON.
                    using var jsonDocument = JsonDocument.Parse(searchContent);

                    // 15. Verificar que la respuesta contenga resultados y que exista al menos un pago encontrado.
                    if (jsonDocument.RootElement.TryGetProperty("results", out var results) && results.GetArrayLength() > 0)
                    {
                        // 16. Obtener el primer pago encontrado.
                        var firstResult = results[0];

                        // 17. Buscar el estado del pago dentro del resultado.
                        if (firstResult.TryGetProperty("status", out var statusElement))
                        {
                            // 18. Devolver el estado informado por Mercado Pago.
                            return statusElement.GetString() ?? "unknown";
                        }
                    }
                }
                // 19. Si no encontramos información sobre el pago, // lo consideramos pendiente.
                return "pending";
            }
            catch
            {
                // 20. Si ocurre un error durante la comunicación // con Mercado Pago, devolvemos "error" para que // la capa superior pueda manejarlo.
                return "error";
            }
        }

        public async Task<bool> CancelOrderAsync(string orderId)
        {
            return await Task.FromResult(true);
        }
    }
}