using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class StoreSettingsValidator : AbstractValidator<StoreSettingsDto>
    {
        public StoreSettingsValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre de la empresa / comercio es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.CUIT)
                .NotEmpty().WithMessage("El CUIT del comercio es obligatorio.")
                .MaximumLength(13).WithMessage("El CUIT no puede superar los 11 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("El formato del correo electrónico es inválido.")
                .MaximumLength(100).WithMessage("El correo electrónico no puede superar los 100 caracteres.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .MaximumLength(30).WithMessage("El teléfono no puede superar los 30 caracteres.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("La dirección comercial es obligatoria.")
                .MaximumLength(150).WithMessage("La dirección comercial no puede superar los 150 caracteres.");

            RuleFor(x => x.PointOfSale)
                .GreaterThan(0).WithMessage("El número de Punto de Venta debe ser mayor a 0.");
        }
    }
}