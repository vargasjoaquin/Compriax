using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class UserProfileUpdateValidator : AbstractValidator<UserProfileUpdateDto>
    {
        public UserProfileUpdateValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Identificador de usuario inválido.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("El formato de correo electrónico no es válido.")
                .MaximumLength(100).WithMessage("El correo no puede superar los 100 caracteres.");

            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("Debe ingresar la contraseña actual para poder cambiarla.")
                .When(x => !string.IsNullOrWhiteSpace(x.NewPassword));

            RuleFor(x => x.NewPassword)
                .MinimumLength(4).WithMessage("La nueva contraseña debe tener al menos 4 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.NewPassword));
        }
    }
}