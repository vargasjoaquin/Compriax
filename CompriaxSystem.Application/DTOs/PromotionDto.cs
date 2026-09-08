using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Application.DTOs
{
    public class PromotionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public PromotionType PromotionType { get; set; }
        public string PromotionTypeName => PromotionType switch
        {
            PromotionType.PercentageOnProduct => "% Descuento en Producto",
            PromotionType.PercentageOnCategory => "% Descuento en Categoría",
            PromotionType.BuyXPayY => "Lleva N Paga M (NxM)",
            PromotionType.PercentageOnTotal => "% Descuento en Carrito",
            _ => "Otro"
        };

        public decimal? DiscountPercentage { get; set; }
        public int? RequiredQuantity { get; set; }
        public int? PayQuantity { get; set; }

        public int? ProductId { get; set; }
        public string? ProductName { get; set; }

        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today.AddMonths(1);
        public string? DaysOfWeek { get; set; }
        public bool IsActive { get; set; } = true;
        public string StatusSummary => IsActive && DateTime.Today >= StartDate.Date && DateTime.Today <= EndDate.Date ? "Vigente" : "Inactiva / Vencida";
    }
}