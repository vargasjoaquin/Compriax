using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.EmployeeCode)
                .NotEmpty().WithMessage("El legajo es obligatorio.")
                .MaximumLength(20).WithMessage("El legajo no puede superar los 20 caracteres.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("El DNI es obligatorio.")
                .MaximumLength(20).WithMessage("El DNI no puede superar los 20 caracteres.");

            RuleFor(x => x.Cuil)
                .NotEmpty().WithMessage("El CUIL es obligatorio.")
                .MaximumLength(25).WithMessage("El CUIL no puede superar los 25 caracteres.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.");

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
        }
    }
}