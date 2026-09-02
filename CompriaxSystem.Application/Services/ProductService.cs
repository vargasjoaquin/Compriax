using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;
using FluentValidation;

namespace CompriaxSystem.Application.Services
{
    public class ProductService(
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser,
        IMapper mapper,
        IValidator<ProductCreateDto> validator) : IProductService
    {
        public async Task<IEnumerable<ProductDto>> GetProductListAsync()
        {
            var products = await unitOfWork.Products.GetAllWithDetailsAsync();
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetByBarcodeAsync(string barcode)
        {
            var product = await unitOfWork.Products.GetByBarcodeAsync(barcode);
            return product == null ? null : mapper.Map<ProductDto>(product);
        }

        public async Task<OperationResult> CreateProductAsync(ProductCreateDto dto)
        {
            var validation = await validator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var existing = await unitOfWork.Products.GetByBarcodeAsync(dto.Barcode);
            
            if (existing != null)
                return OperationResult.Failure("Código de barras ya registrado.");

            await unitOfWork.BeginTransactionAsync();

            try
            {
                var product = mapper.Map<Product>(dto);

                product.CurrentStock = dto.InitialStock;
                product.CreatedBy = currentUser.CurrentUser?.Username;

                await unitOfWork.Products.AddAsync(product);
                await unitOfWork.CompleteAsync();

                await unitOfWork.Products.AddMovementAsync(new StockMovement
                {
                    Product = product,
                    ProductId = product.Id,
                    UserId = currentUser.CurrentUser!.UserId,
                    Quantity = dto.InitialStock,
                    MovementType = MovementType.Initial,
                    Remarks = "Stock inicial",
                    CreatedBy = currentUser.CurrentUser!.Username
                });

                await unitOfWork.CompleteAsync();
                await unitOfWork.CommitAsync();

                return new OperationResult { Success = true, Message = "Producto creado.", EntityId = product.Id };
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                string realMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return OperationResult.Failure("Error de Base de Datos: " + realMsg);
            }
        }

        public async Task<OperationResult> UpdateProductAsync(int id, ProductCreateDto dto)
        {
            var validation = await validator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var product = await unitOfWork.Products.GetByIdAsync(id);
            
            if (product == null)
                return OperationResult.Failure("Producto no encontrado.");

            var existingBarcode = await unitOfWork.Products.GetByBarcodeAsync(dto.Barcode);
            
            if (existingBarcode != null && existingBarcode.Id != id)
                return OperationResult.Failure("El nuevo código de barras ya pertenece a otro producto.");

            mapper.Map(dto, product);
            var success = await unitOfWork.CompleteAsync();

            return success
                ? new OperationResult { Success = true, Message = "Producto actualizado.", EntityId = product.Id }
                : OperationResult.Failure("Sin cambios detectados.");
        }

        public async Task<OperationResult> DeleteProductAsync(int id)
        {
            var product = await unitOfWork.Products.GetByIdAsync(id);
            
            if (product == null)
                return OperationResult.Failure("Producto no encontrado en el catálogo.");

            product.IsActive = false;
            product.IsDeleted = true;
            product.LastUpdatedBy = currentUser.CurrentUser?.Username;
            product.LastUpdatedAt = DateTime.UtcNow;

            unitOfWork.Products.Update(product);
            var result = await unitOfWork.CompleteAsync();

            return result
                ? OperationResult.Ok($"Producto '{product.Name}' retirado correctamente.")
                : OperationResult.Failure("No se detectaron cambios en la base de datos.");
        }
    }
}