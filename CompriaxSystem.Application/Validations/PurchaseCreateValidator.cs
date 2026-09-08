using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class PurchaseCreateValidator : AbstractValidator<PurchaseCreateDto>
    {
        public PurchaseCreateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.SupplierId)
                .GreaterThan(0).WithMessage("Debe seleccionar un proveedor válido para la orden de compra.");

            RuleFor(x => x.DocumentTypeId)
                .GreaterThan(0).WithMessage("Debe seleccionar un tipo de documento fiscal o interno válido para la compra.");

            RuleFor(x => x.PaymentMethodId)
                .GreaterThan(0).WithMessage("Debe seleccionar el medio de pago utilizado para liquidar la compra.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("El número de comprobante o factura del proveedor es obligatorio.")
                .MaximumLength(50).WithMessage("El número de documento no puede superar los 50 caracteres.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("La orden de compra debe contener al menos un artículo ingresado.");

            RuleForEach(x => x.Items)
                .SetValidator(new PurchaseItemCreateValidator());
        }
    }
}