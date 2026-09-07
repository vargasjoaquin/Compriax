using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class UserCreateValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
                .MinimumLength(4).WithMessage("El nombre de usuario debe tener al menos 4 caracteres.")
                .MaximumLength(50).WithMessage("El usuario no puede superar los 50 caracteres.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre del usuario es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El apellido del usuario es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
                .MaximumLength(100).WithMessage("El correo electrónico no puede superar los 100 caracteres.");

            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("Debe seleccionar un rol de acceso válido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria para nuevos usuarios.")
                .MinimumLength(6).WithMessage("La contraseña de seguridad debe tener al menos 6 caracteres.")
                .When(x => x.Id == 0);
        }
    }
}