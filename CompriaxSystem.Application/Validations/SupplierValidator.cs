using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class SupplierValidator : AbstractValidator<SupplierDto>
    {
        public SupplierValidator()
        {
            RuleFor(x => x.CUIT)
                .NotEmpty().WithMessage("El CUIT del proveedor es obligatorio.")
                .MaximumLength(13).WithMessage("El CUIT no puede superar los 11 caracteres.");

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("El nombre de la empresa es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre de la empresa no puede superar los 100 caracteres.");

            RuleFor(x => x.ContactName)
                .NotEmpty().WithMessage("El nombre de contacto es obligatorio.")
                .MaximumLength(80).WithMessage("El nombre de contacto no puede superar los 80 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.ContactName));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
                .MaximumLength(100).WithMessage("El correo electrónico no puede superar los 100 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .MaximumLength(30).WithMessage("El teléfono no puede superar los 30 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Phone));

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("La direccion es obligatoria.")
                .MaximumLength(150).WithMessage("La dirección no puede superar los 150 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Address));
        }
    }
}