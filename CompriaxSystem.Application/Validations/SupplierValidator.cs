using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class SupplierValidator : AbstractValidator<SupplierDto>
    {
        public SupplierValidator()
        {
            RuleFor(x => x.CUIT)
                .NotEmpty().WithMessage("El CUIT/CUIL del proveedor es obligatorio.")
                .MaximumLength(20).WithMessage("El CUIT no puede superar los 20 caracteres.");

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("El nombre de la empresa es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre de la empresa no puede superar los 100 caracteres.");

            RuleFor(x => x.ContactName)
                .MaximumLength(80).WithMessage("El nombre de contacto no puede superar los 80 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.ContactName));

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
                .MaximumLength(100).WithMessage("El correo electrónico no puede superar los 100 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.Phone)
                .MaximumLength(30).WithMessage("El teléfono no puede superar los 30 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Phone));

            RuleFor(x => x.Address)
                .MaximumLength(150).WithMessage("La dirección no puede superar los 150 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Address));
        }
    }
}