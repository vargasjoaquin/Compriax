using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class SaleValidator : AbstractValidator<SaleDto>
    {
        public SaleValidator()
        {
            RuleFor(x => x.DocumentTypeId)
                .GreaterThan(0).WithMessage("Debe seleccionar un tipo de comprobante válido.");

            RuleFor(x => x.PaymentMethodId)
                .GreaterThan(0).WithMessage("Debe seleccionar un medio de pago válido.");

            RuleFor(x => x.PaymentReceived)
                .GreaterThan(0).WithMessage("El monto recibido debe ser mayor a 0.")
                .GreaterThanOrEqualTo(x => x.TotalAmount).WithMessage("El monto recibido no puede ser inferior al total de la venta.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("La venta debe contener al menos un producto.");

            RuleForEach(x => x.Items)
                .SetValidator(new SaleItemValidator());
        }
    }
}