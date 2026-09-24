using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class CashRegisterValidator : AbstractValidator<CashRegisterDto>
    {
        public CashRegisterValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Number)
                .GreaterThan(0).WithMessage("El número de caja debe ser mayor a 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre de la caja es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre de la caja no puede superar los 50 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(150).WithMessage("La descripción no puede superar los 150 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));
        }
    }
}
