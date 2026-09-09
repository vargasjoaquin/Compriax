namespace CompriaxSystem.MercadoPago.Api.Configuration
{
    public class MercadoPagoSettings
    {
        public bool Enabled { get; set; }
        public string PublicKey { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public string WebhookSecret { get; set; } = null!;

        public string CollectorId { get; set; } = null!; //ID de tu cuenta de mercado pago
        public string PosId { get; set; } = null!; //Caja que se le va a asignar el QR
    }
}
