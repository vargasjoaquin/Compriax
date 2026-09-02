using FluentValidation;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Validations
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Barcode)
                .NotEmpty().WithMessage("El código de barras es obligatorio.")
                .MaximumLength(50).WithMessage("El código de barras no puede superar los 50 caracteres.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.BuyPrice)
                .GreaterThan(0).WithMessage("El precio de compra debe ser mayor a 0.");

            RuleFor(x => x.SellPrice)
                .GreaterThan(0).WithMessage("El precio de venta debe ser mayor a 0.")
                .GreaterThanOrEqualTo(x => x.BuyPrice).WithMessage("El precio de venta debe ser mayor o igual al precio de costo.");

            RuleFor(x => x.CurrentStock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock actual no puede ser negativo.");

            RuleFor(x => x.MinimumStock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock mínimo no puede ser negativo.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Debe seleccionar una categoría válida.");

            RuleFor(x => x.BrandId)
                .GreaterThan(0).WithMessage("Debe seleccionar una marca válida.");
        }
    }
}