using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class StoreSettingsValidator : AbstractValidator<StoreSettingsDto>
    {
        public StoreSettingsValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre de la empresa / comercio es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.CUIT)
                .MaximumLength(20).WithMessage("El CUIT no puede superar los 20 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.CUIT));

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("El formato del correo electrónico es inválido.")
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