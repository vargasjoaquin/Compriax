using CompriaxSystem.MercadoPago.Api.Configuration;
using CompriaxSystem.MercadoPago.Api.Interfaces;
using CompriaxSystem.MercadoPago.Api.Requests;
using CompriaxSystem.MercadoPago.Api.Responses;
using Microsoft.Extensions.Options;
using System.Globalization;
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

        public async Task<PaymentResponse> CreateOrderAsync(CreatePaymentRequest paymentRequest, string idempotencyKey)
        {
            // 1. Crear el cliente HTTP que se utilizará para comunicarnos con la API de Mercado Pago.
            var httpClient = _httpClientFactory.CreateClient();

            // 2. Configurar el Access Token para autenticar las solicitudes realizadas contra Mercado Pago.
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.AccessToken);

            // 3. Agregar la clave de idempotencia para evitar la creación de órdenes duplicadas.
            httpClient.DefaultRequestHeaders.Add("X-Idempotency-Key", idempotencyKey);

            // 4. Obtener el identificador externo del punto de venta configurado para la integración con Mercado Pago.
            string pointOfSaleId = _settings.PointOfSaleId;

            // 5. Verificar que el punto de venta exista y que tenga configurado correctamente su id externo.
            await EnsurePointOfSaleHasIdAsync(httpClient, pointOfSaleId);

            // 6. Formatear el monto utilizando dos decimales y la cultura invariante para garantizar el formato numérico esperado por la API.
            string formattedAmount = paymentRequest.Amount.ToString("F2", CultureInfo.InvariantCulture);

            // 7. Construir la solicitud de creación de la orden QR con los datos requeridos por Mercado Pago.
            var orderRequest = new
            {
                type = "qr",
                external_reference = idempotencyKey,
                total_amount = formattedAmount,
                description = paymentRequest.Description,
                config = new
                {
                    qr = new
                    {
                        mode = "dynamic",
                        external_pos_id = pointOfSaleId
                    }
                },
                transactions = new
                {
                    payments = new[]
                    {
                new
                {
                    amount = formattedAmount
                }
            }
                }
            };

            // 8. Convertir la solicitud de la orden a formato JSON.
            var serializedOrderRequest = JsonSerializer.Serialize(orderRequest);

            // 9. Crear el contenido HTTP utilizando JSON
            // y codificación UTF-8.
            var orderRequestContent = new StringContent(serializedOrderRequest, Encoding.UTF8, "application/json");

            // 10. Definir la URL del endpoint de Orders API utilizado para crear la orden de Mercado Pago.
            string ordersApiUrl =
                "https://api.mercadopago.com/v1/orders";

            // 11. Enviar la solicitud POST para crear la orden de pago mediante QR.
            var createOrderResponse =  await httpClient.PostAsync(ordersApiUrl, orderRequestContent);

            // 12. Leer el contenido de la respuesta devuelta por Mercado Pago.
            var responseContent = await createOrderResponse.Content.ReadAsStringAsync();

            // 13. Verificar si Mercado Pago respondió correctamente. si ocurrió un error, lanzamos una excepción con
            // la información devuelta por la API.
            if (!createOrderResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Error de Mercado Pago ({createOrderResponse.StatusCode}): {responseContent}");
            }

            // 14. Parsear la respuesta JSON recibida.
            using var responseDocument = JsonDocument.Parse(responseContent);

            // 15. Obtener el identificador de la orden creada. Si Mercado Pago no devuelve un ID, utilizamos
            // la clave de idempotencia como respaldo.
            string orderId = responseDocument.RootElement.GetProperty("id").GetString() ?? idempotencyKey;

            // 16. Inicializar el contenido del QR. Se completará si Mercado Pago devuelve
            // la propiedad correspondiente.
            string qrData = string.Empty;

            // 17. Intentar obtener los datos del QR desde la respuesta de Mercado Pago.
            if (responseDocument.RootElement.TryGetProperty("type_response", out var typeResponseProperty) && typeResponseProperty.TryGetProperty("qr_data", out var qrDataProperty))
            {
                // 18. Guardar la información del QR queposteriormente podrá utilizar la aplicación.
                qrData = qrDataProperty.GetString() ?? string.Empty;
            }

            // 19. Construir la respuesta que será devuelta a las capas superiores del sistema.
            return new PaymentResponse
            {
                TransactionId = 0,
                OrderId = orderId,
                QrData = qrData,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };
        }


        public async Task<string> GetOrderStatusAsync(string orderId)
        {
            // 1. Validar que se haya recibido un identificador de orden válido.
            if (string.IsNullOrWhiteSpace(orderId))
                return "unknown";

            try
            {
                // 2. Crear el cliente HTTP para consultar el estado de la orden en Mercado Pago.
                var httpClient = _httpClientFactory.CreateClient();

                // 3. Configurar el Access Token para autenticar la consulta contra Mercado Pago.
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.AccessToken);

                // 4. Consultar directamente la orden utilizando su identificador en la Orders API.
                var orderResponse = await httpClient.GetAsync($"https://api.mercadopago.com/v1/orders/{orderId}");

                // 5. Verificar si Mercado Pago respondió correctamente.
                if (orderResponse.IsSuccessStatusCode)
                {
                    // 6. Leer el contenido JSON de la respuesta.
                    var responseContent = await orderResponse.Content.ReadAsStringAsync();

                    // 7. Parsear la respuesta JSON.
                    using var responseDocument =  JsonDocument.Parse(responseContent);

                    // 8. Buscar la propiedad que contiene el estado actual de la orden.
                    if (responseDocument.RootElement.TryGetProperty("status",  out var statusProperty))
                    {
                        // 9. Obtener el estado.
                        string orderStatus = statusProperty.GetString()?.ToLowerInvariant() ?? "created";

                        // 10. Convertir los estados de Mercado Pago a los estados utilizados por el sistema.
                        switch (orderStatus)
                        {
                            // 11. Estados que indican que el pago fue procesado o aprobado correctamente.
                            case "processed":
                            case "paid":
                            case "approved":
                                return "approved";

                            // 12. Estados que indican que la orden fue cancelada.
                            case "canceled":
                            case "cancelled":
                                return "cancelled";

                            // 13. Estado que indica que la orden ya no puede utilizarse porque expiró.
                            case "expired":
                                return "expired";

                            // 14. Una orden recién creada todavía se considera pendiente.
                            case "created":
                                return "pending";

                            // 15. Si recibimos un estado que no está
                            // contemplado específicamente, devolvemos
                            // el estado original.
                            default:
                                return orderStatus;
                        }
                    }
                }

                // 16. Si no fue posible obtener el estado de la orden, la consideramos pendiente.
                return "pending";
            }
            catch
            {
                // 17. Si ocurre un error durante la comunicación con Mercado Pago, devolvemos "error" para que
                // la capa superior pueda manejarlo.
                return "error";
            }
        }


        public async Task<bool> CancelOrderAsync(string orderId)
        {
            // 1. Validar que se haya recibido un identificador de orden válido.
            if (string.IsNullOrWhiteSpace(orderId))
                return false;

            try
            {
                // 2. Crear el cliente HTTP para realizar la solicitud de cancelación.
                var httpClient = _httpClientFactory.CreateClient();

                // 3. Configurar el Access Token para autenticar la solicitud contra Mercado Pago.
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.AccessToken);

                // 4. Enviar la solicitud de cancelación utilizando el identificador de la orden.
                var cancelOrderResponse = await httpClient.PostAsync($"https://api.mercadopago.com/v1/orders/{orderId}/cancel", null);

                // 5. Devolver true si Mercado Pago confirmó correctamente la cancelación de la orden.
                return cancelOrderResponse.IsSuccessStatusCode;
            }
            catch
            {
                // 6. Si ocurre un error durante la comunicación con Mercado Pago, informamos que la cancelación falló.
                return false;
            }
        }


        private async Task EnsurePointOfSaleHasIdAsync(HttpClient httpClient, string externalPointOfSaleId)
        {
            try
            {
                // 1. Consultar los puntos de venta configurados actualmente en Mercado Pago.
                var pointOfSaleResponse = await httpClient.GetAsync("https://api.mercadopago.com/pos");

                // 2. Continuar solamente si Mercado Pago respondió correctamente.
                if (pointOfSaleResponse.IsSuccessStatusCode)
                {
                    // 3. Leer el contenido de la respuesta.
                    var responseContent =  await pointOfSaleResponse.Content.ReadAsStringAsync();

                    // 4. Parsear la respuesta JSON.
                    using var responseDocument = JsonDocument.Parse(responseContent);

                    // 5. Verificar que existan puntos de venta y que la respuesta contenga al menos uno.
                    if (responseDocument.RootElement.TryGetProperty("results", out var pointOfSaleResults) && pointOfSaleResults.GetArrayLength() > 0)
                    {
                        // 6. Obtener el primer punto de venta encontrado en Mercado Pago.
                        var pointOfSale = pointOfSaleResults[0];

                        // 7. Obtener el identificador interno del punto de venta proporcionado por Mercado Pago.
                        long pointOfSaleId = pointOfSale.GetProperty("id").GetInt64();

                        // 8. Verificar si el punto de venta ya tiene configurado el identificador externo esperado.
                        bool hasMatchingExternalId = pointOfSale.TryGetProperty("external_id", out var externalIdProperty) && externalIdProperty.GetString() ==  externalPointOfSaleId;

                        // 9. Si el identificador externo no coincide, preparamos una solicitud para actualizarlo.
                        if (!hasMatchingExternalId)
                        {
                            var updateRequest = new
                            {
                                external_id = externalPointOfSaleId
                            };

                            // 10. Convertir la solicitud de actualización a formato JSON.
                            var updateRequestContent = new StringContent(JsonSerializer.Serialize(updateRequest), Encoding.UTF8, "application/json");

                            // 11. Actualizar el punto de venta en Mercado Pago utilizando su id interno.
                            await httpClient.PutAsync($"https://api.mercadopago.com/pos/{pointOfSaleId}", updateRequestContent);
                        }
                    }
                }
            }
            catch
            {
                // 12. Si ocurre un error durante la validación o actualización
                // del punto de venta, lo ignoramos para permitir que el flujo
                // de creación de la orden continúe.
            }
        }
    }
}