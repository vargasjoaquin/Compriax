using CompriaxSystem.Domain.Common;

namespace CompriaxSystem.Domain.Entities
{
    public class MercadoPagoTransaction : BaseEntity
    {
        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; } = null!;

        public int StatusId { get; set; }
        public virtual MercadoPagoPaymentStatues Status { get; set; } = null!;

        public string? ExternalPaymentId { get; set; } // ID de pago en MP
        public string? ExternalReference { get; set; } // Referencia propia del cliente
        public string? OrderId { get; set; }           // ID de la Orden en MP

        public string IdempotencyKey { get; set; } = null!;
        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
