using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class PurchaseItemCreateValidator : AbstractValidator<PurchaseItemCreateDto>
    {
        public PurchaseItemCreateValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Identificador de producto inválido.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("La cantidad a comprar debe ser mayor a 0.");

            RuleFor(x => x.BuyPrice)
                .GreaterThan(0).WithMessage("El precio de costo debe ser mayor a 0.");
        }
    }
}