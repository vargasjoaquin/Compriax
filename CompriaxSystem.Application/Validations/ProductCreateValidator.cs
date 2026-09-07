using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Barcode)
                .NotEmpty().WithMessage("El código de barras es obligatorio.")
                .MaximumLength(50).WithMessage("El código de barras no puede exceder los 50 caracteres.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(250).WithMessage("La descripción no puede exceder los 250 caracteres.");

            RuleFor(x => x.BuyPrice)
                .GreaterThan(0).WithMessage("El precio de compra (costo) debe ser mayor a $ 0.00.");

            RuleFor(x => x.SellPrice)
                .GreaterThan(0).WithMessage("El precio de venta debe ser mayor a $ 0.00.")
                .GreaterThanOrEqualTo(x => x.BuyPrice).WithMessage("El precio de venta no puede ser inferior al precio de compra.");

            RuleFor(x => x.InitialStock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock inicial no puede ser negativo.");

            RuleFor(x => x.MinimumStock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock mínimo de alerta no puede ser negativo.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Debe seleccionar una categoría válida.");

            RuleFor(x => x.BrandId)
                .GreaterThan(0).WithMessage("Debe seleccionar una marca válida.");

            RuleFor(x => x.UnitOfMeasureId)
                .GreaterThan(0).WithMessage("Debe seleccionar una unidad de medida válida.");
        }
    }
}