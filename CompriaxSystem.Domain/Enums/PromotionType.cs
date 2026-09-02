namespace CompriaxSystem.Domain.Enums
{
    public enum PromotionType
    {
        PercentageOnProduct = 1,  // % de descuento en un producto específico
        PercentageOnCategory = 2, // % de descuento en toda una categoría
        BuyXPayY = 3,             // NxM (ej. 2x1, 3x2)
        PercentageOnTotal = 4     // % de descuento al total del ticket
    }
}
