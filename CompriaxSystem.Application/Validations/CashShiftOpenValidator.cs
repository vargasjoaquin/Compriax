using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class CashShiftOpenValidator : AbstractValidator<CashShiftOpenDto>
    {
        public CashShiftOpenValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.InitialCash)
                .GreaterThanOrEqualTo(0).WithMessage("El fondo inicial de caja no puede ser negativo.");
        }
    }
}
