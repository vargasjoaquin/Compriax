namespace CompriaxSystem.Application.DTOs
{
    public class TicketPaymentDataDto
    {
        public class TicketPaymentData
        {
            public string PaymentMethodName { get; set; } = null!;
            public decimal Amount { get; set; }
        }
    }
}