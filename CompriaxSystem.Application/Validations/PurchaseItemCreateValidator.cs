using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class PurchaseItemCreateValidator : AbstractValidator<PurchaseItemCreateDto>
    {
        public PurchaseItemCreateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Identificador de producto inválido en el detalle de compra.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("La cantidad a comprar en la línea debe ser mayor a 0.");

            RuleFor(x => x.BuyPrice)
                .GreaterThan(0).WithMessage("El precio de costo de compra debe ser mayor a $ 0.00.");
        }
    }
}