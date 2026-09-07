using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.EmployeeCode)
                .NotEmpty().WithMessage("El legajo del empleado es obligatorio.")
                .MaximumLength(20).WithMessage("El legajo no puede superar los 20 caracteres.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("El DNI es obligatorio.")
                .Length(7, 8).WithMessage("El DNI debe tener entre 7 y 8 dígitos.")
                .Matches(@"^[0-9]+$").WithMessage("El DNI solo puede contener números.");

            RuleFor(x => x.Cuil)
                .NotEmpty().WithMessage("El CUIL es obligatorio.")
                .MaximumLength(13).WithMessage("El CUIL no puede superar los 11 caracteres.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
                .MaximumLength(100).WithMessage("El correo electrónico no puede superar los 100 caracteres.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .MaximumLength(30).WithMessage("El teléfono no puede superar los 30 caracteres.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("La dirección es obligatoria.")
                .MaximumLength(150).WithMessage("La dirección no puede superar los 150 caracteres.");

            RuleFor(x => x.PositionId)
                .NotNull().WithMessage("Debe seleccionar un cargo.")
                .GreaterThan(0).WithMessage("Debe seleccionar un cargo válido.");

            RuleFor(x => x.GenderId)
                .NotNull().WithMessage("Debe seleccionar un género.")
                .GreaterThan(0).WithMessage("Debe seleccionar un género válido.");

            RuleFor(x => x.CivilStatusId)
                .NotNull().WithMessage("Debe seleccionar un estado civil.")
                .GreaterThan(0).WithMessage("Debe seleccionar un estado civil válido.");

            RuleFor(x => x.ChildrenCount)
                .GreaterThanOrEqualTo(0).WithMessage("La cantidad de hijos no puede ser negativa.");
        }
    }
}