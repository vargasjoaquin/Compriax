namespace CompriaxSystem.MercadoPago.Api.Requests
{
    public class CreatePaymentRequest
    {
        public int SaleId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;
    }
}
