using CompriaxSystem.Application.DTOs;
using FluentValidation;

namespace CompriaxSystem.Application.Validations
{
    public class ProductLabelValidator : AbstractValidator<ProductLabelDto>
    {
        public ProductLabelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Barcode)
                .NotEmpty().WithMessage("El código de barras del producto es obligatorio.")
                .MaximumLength(50).WithMessage("El código de barras no puede superar los 50 caracteres.");

            RuleFor(x => x.LabelDescription)
                .NotEmpty().WithMessage("La descripción para la etiqueta es obligatoria.")
                .MaximumLength(60).WithMessage("La descripción de la etiqueta no puede exceder los 60 caracteres.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("El precio del artículo debe ser mayor a $ 0.00.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("La cantidad de etiquetas a imprimir debe ser mayor a 0.")
                .LessThanOrEqualTo(1000).WithMessage("La cantidad no puede superar las 1.000 etiquetas por lote.");
        }
    }
}
