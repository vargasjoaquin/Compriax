using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class CashMovementCreateValidator : AbstractValidator<CashMovementCreateDto>
    {
        public CashMovementCreateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("El monto del movimiento debe ser mayor a $ 0.00.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Debe ingresar una descripción para el movimiento.")
                .MaximumLength(200).WithMessage("La descripción no puede superar los 200 caracteres.");

            RuleFor(x => x.MovementType)
                .IsInEnum().WithMessage("El tipo de movimiento de caja no es válido.");
        }
    }
}
