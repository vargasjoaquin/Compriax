namespace CompriaxSystem.MercadoPago.Api.Models
{
    public class WebhookPayload
    {
        public string Action { get; set; } = null!; // Ej: "order.updated"
        public string DataId { get; set; } = null!; // El ID de la order/pago
        public string Type { get; set; } = null!;   // Ej: "payment"
    }
}
