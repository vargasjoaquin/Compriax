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
                .Matches(@"^[0-9]+$").WithMessage("El DNI solo puede contener números.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre del cliente es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El apellido del cliente es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(x => x.Cuil)
                .NotEmpty().WithMessage("El CUIL es obligatorio.")
                .MaximumLength(13).WithMessage("El CUIL no puede superar los 11 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Cuil));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico del cliente es obligatorio.")
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
                .MaximumLength(100).WithMessage("El correo electrónico no puede superar los 100 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("El teléfono del cliente es obligatorio.")
                .MaximumLength(30).WithMessage("El teléfono no puede superar los 30 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Phone));

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("El dirección es obligatorio.")
                .MaximumLength(150).WithMessage("La dirección no puede superar los 150 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Address));

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("La cuidad es obligatoria.")
                .MaximumLength(80).WithMessage("La ciudad no puede superar los 80 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.City));
        }
    }
}