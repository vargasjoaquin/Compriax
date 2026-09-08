using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class SaleValidator : AbstractValidator<SaleDto>
    {
        public SaleValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.DocumentTypeId)
                .GreaterThan(0).WithMessage("Debe seleccionar un tipo de comprobante válido para la venta.");

            RuleFor(x => x.PaymentMethodId)
                .GreaterThan(0).WithMessage("Debe seleccionar un medio de pago válido.");

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("El total de la venta debe ser mayor a $ 0.00.");

            RuleFor(x => x.PaymentReceived)
                .GreaterThanOrEqualTo(x => x.TotalAmount)
                .WithMessage("El monto recibido del cliente no puede ser inferior al total de la venta.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("La venta debe contener al menos un producto en el carrito.");

            RuleForEach(x => x.Items)
                .SetValidator(new SaleItemValidator());
        }
    }
}