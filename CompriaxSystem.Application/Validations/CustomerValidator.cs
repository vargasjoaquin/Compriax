using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("El número de documento (DNI) es obligatorio.")
                .Length(7, 8).WithMessage("El DNI debe tener entre 7 y 8 dígitos.")
                .Matches(@"^[a-zA-Z0-9]+$").WithMessage("El documento solo puede contener letras y números.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre del cliente es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El apellido del cliente es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(x => x.Cuil)
                .MaximumLength(20).WithMessage("El CUIL/CUIT no puede superar los 20 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Cuil));

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

            RuleFor(x => x.City)
                .MaximumLength(80).WithMessage("La ciudad no puede superar los 80 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.City));
        }
    }
}