namespace CompriaxSystem.MercadoPago.Api.Responses
{
    public class PaymentResponse
    {
        public int TransactionId { get; set; }
        public string OrderId { get; set; } = null!;
        public string QrData { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
