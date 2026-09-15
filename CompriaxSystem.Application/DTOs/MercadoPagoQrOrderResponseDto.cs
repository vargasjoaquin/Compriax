namespace CompriaxSystem.Application.DTOs
{
    public class MercadoPagoQrOrderResponseDto
    {
        public bool Success { get; set; }
        public string OrderId { get; set; } = string.Empty;
        public string QrData { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; }

        public static MercadoPagoQrOrderResponseDto Ok(string orderId, string qrData)
        {
            return new MercadoPagoQrOrderResponseDto
            {
                Success = true,
                OrderId = orderId,
                QrData = qrData
            };
        }

        public static MercadoPagoQrOrderResponseDto Failure(string errorMessage)
        {
            return new MercadoPagoQrOrderResponseDto
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
