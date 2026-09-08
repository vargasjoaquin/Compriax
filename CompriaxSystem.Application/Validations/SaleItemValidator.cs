using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class SaleItemValidator : AbstractValidator<SaleItemDto>
    {
        public SaleItemValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Identificador de producto en la línea de venta inválido.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("La cantidad a vender debe ser mayor a 0.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("El precio unitario de venta debe ser mayor a $ 0.00.");

            RuleFor(x => x.DiscountAmount)
                .GreaterThanOrEqualTo(0).WithMessage("El monto de descuento en la línea no puede ser negativo.");
        }
    }
}