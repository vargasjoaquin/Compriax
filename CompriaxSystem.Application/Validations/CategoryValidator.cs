using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("El nombre de la categoría es obligatorio.")
                 .MaximumLength(50).WithMessage("El nombre de la categoría no puede exceder los 50 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("La descripción no puede exceder los 200 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));
        }
    }
}