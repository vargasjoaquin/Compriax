using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class SaleItemValidator : AbstractValidator<SaleItemDto>
    {
        public SaleItemValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Identificador de producto inválido.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("La cantidad a vender debe ser mayor a 0.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("El precio unitario debe ser mayor a 0.");
        }
    }
}