using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class CashShiftCloseValidator : AbstractValidator<CashShiftCloseDto>
    {
        public CashShiftCloseValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.ShiftId)
                .GreaterThan(0).WithMessage("Identificador de turno de caja inválido.");

            RuleFor(x => x.RealCash)
                .GreaterThanOrEqualTo(0).WithMessage("El monto contado en caja no puede ser negativo.");

            RuleFor(x => x.ClosingNotes)
                .MaximumLength(250).WithMessage("Las observaciones de cierre no pueden superar los 250 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.ClosingNotes));
        }
    }
}
