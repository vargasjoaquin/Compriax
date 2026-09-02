using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class PurchaseCreateValidator : AbstractValidator<PurchaseCreateDto>
    {
        public PurchaseCreateValidator()
        {
            RuleFor(x => x.SupplierId)
                .GreaterThan(0).WithMessage("Debe seleccionar un proveedor válido.");

            RuleFor(x => x.DocumentTypeId)
                .GreaterThan(0).WithMessage("Debe seleccionar un tipo de documento válido.");

            RuleFor(x => x.PaymentMethodId)
                .GreaterThan(0).WithMessage("Debe seleccionar el medio de pago utilizado para la compra.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("El número de comprobante/factura de compra es obligatorio.")
                .MaximumLength(50).WithMessage("El número de documento no puede superar los 50 caracteres.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("La compra debe contener al menos un producto.");

            RuleForEach(x => x.Items)
                .SetValidator(new PurchaseItemCreateValidator());
        }
    }
}