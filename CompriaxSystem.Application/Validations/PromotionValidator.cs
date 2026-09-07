using FluentValidation;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Application.Validations
{
    public class PromotionValidator : AbstractValidator<PromotionDto>
    {
        public PromotionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre de la promoción es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("La descripción no puede superar los 250 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));

            RuleFor(x => x.StartDate)
                .NotNull().WithMessage("La fecha de inicio es obligatoria.");

            RuleFor(x => x.EndDate)
                .NotNull().WithMessage("La fecha de fin es obligatoria.")
                .GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("La fecha de fin debe ser posterior o igual a la fecha de inicio.");

            RuleFor(x => x.DiscountPercentage)
                .NotNull().WithMessage("El porcentaje de descuento es obligatorio para este tipo de promoción.")
                .InclusiveBetween(0.01m, 100.00m).WithMessage("El porcentaje de descuento debe estar comprendido entre 0.01% y 100%.")
                .When(x => x.PromotionType is PromotionType.PercentageOnProduct
                                         or PromotionType.PercentageOnCategory
                                         or PromotionType.PercentageOnTotal);

            RuleFor(x => x.ProductId)
                .NotNull().GreaterThan(0).WithMessage("Debe seleccionar un producto válido para aplicar el descuento.")
                .When(x => x.PromotionType == PromotionType.PercentageOnProduct);

            RuleFor(x => x.CategoryId)
                .NotNull().GreaterThan(0).WithMessage("Debe seleccionar una categoría válida para aplicar el descuento.")
                .When(x => x.PromotionType == PromotionType.PercentageOnCategory);

            RuleFor(x => x.RequiredQuantity)
                .NotNull().GreaterThan(1).WithMessage("La cantidad requerida (Lleva) en combos NxM debe ser mayor a 1.")
                .When(x => x.PromotionType == PromotionType.BuyXPayY);

            RuleFor(x => x.PayQuantity)
                .NotNull().GreaterThan(0).WithMessage("La cantidad a abonar (Paga) debe ser mayor a 0.")
                .LessThan(x => x.RequiredQuantity).WithMessage("La cantidad a pagar debe ser estrictamente menor que la cantidad requerida (ej: Lleva 2, Paga 1).")
                .When(x => x.PromotionType == PromotionType.BuyXPayY);
        }
    }
}