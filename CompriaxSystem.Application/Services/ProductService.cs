using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;
using FluentValidation;

namespace CompriaxSystem.Application.Services
{
    public class ProductService(IUnitOfWork unitOfWork, ICurrentUserService currentUser, IMapper mapper, IValidator<ProductCreateDto> validator) : IProductService
    {
        /// <summary>
        /// Obtiene todos los productos incluyendo sus categorías y marcas.
        /// </summary>
        /// <returns>Colección de DTOs de productos.</returns>
        public async Task<IEnumerable<ProductDto>> GetProductListAsync()
        {
            var products = await unitOfWork.Products.GetAllWithDetailsAsync();
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        /// <summary>
        /// Busca un producto por su código de barras.
        /// </summary>
        /// <param name="barcode">Código a buscar.</param>
        /// <returns>DTO del producto o null.</returns>
        public async Task<ProductDto?> GetByBarcodeAsync(string barcode)
        {
            var product = await unitOfWork.Products.GetByBarcodeAsync(barcode);
            return product == null ? null : mapper.Map<ProductDto>(product);
        }

        /// <summary>
        /// Registra un nuevo producto e inicia su stock.
        /// </summary>
        /// <param name="dto">Datos del nuevo producto.</param>
        /// <returns>Resultado de la creación con el id generado.</returns>
        public async Task<OperationResult> CreateProductAsync(ProductCreateDto dto)
        {
            var validation = await validator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var existingProduct = await unitOfWork.Products.GetByBarcodeAsync(dto.Barcode);
            
            if (existingProduct != null)
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

                return new OperationResult 
                { 
                    Success = true,
                    Message = "Producto creado.",
                    EntityId = product.Id };
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                
                return OperationResult.Failure($"Error de Base de Datos: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza un producto.
        /// </summary>
        /// <param name="id">Id del producto.</param>
        /// <param name="dto">Nuevos datos.</param>
        /// <returns>Resultado de la actualización.</returns>
        public async Task<OperationResult> UpdateProductAsync(int id, ProductCreateDto dto)
        {
            var validation = await validator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var product = await unitOfWork.Products.GetByIdAsync(id);
            
            if (product == null)
                return OperationResult.Failure("Producto no encontrado.");

            var existingBarcodeProduct = await unitOfWork.Products.GetByBarcodeAsync(dto.Barcode);
            
            if (existingBarcodeProduct != null && existingBarcodeProduct.Id != id)
                return OperationResult.Failure("El nuevo código de barras ya pertenece a otro producto.");

            mapper.Map(dto, product);
            
            var operationSucceeded = await unitOfWork.CompleteAsync();

            return operationSucceeded
                ? new OperationResult 
                { 
                    Success = true,
                    Message = "Producto actualizado.",
                    EntityId = product.Id
                }
                : OperationResult.Failure("Sin cambios detectados.");
        }

        /// <summary>
        /// Elimina un producto.
        /// </summary>
        /// <param name="id">Id del producto.</param>
        /// <returns>Resultado de la eliminación.</returns>
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
            
            var operationSucceeded = await unitOfWork.CompleteAsync();

            return operationSucceeded
                ? OperationResult.Ok($"Producto '{product.Name}' retirado correctamente.")
                : OperationResult.Failure("No se detectaron cambios en la base de datos.");
        }

        /// <summary>
        /// Busca productos activos que coincidan con un término de búsqueda en su nombre, código de barras, descripción o marca.
        /// </summary>
        /// <param name="searchTerm">Término utilizado para realizar la búsqueda.</param>
        /// <returns>Colección de hasta 15 productos coincidentes.</returns>
        public async Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return Enumerable.Empty<ProductDto>();

            var normalizedSearchTerm = searchTerm.Trim();
            
            var allProducts = await unitOfWork.Products.GetAllWithDetailsAsync();

            var matchingProducts = allProducts.Where(p =>
                !p.IsDeleted && p.IsActive &&
                (p.Name.Contains(normalizedSearchTerm, StringComparison.OrdinalIgnoreCase) ||
                 p.Barcode.Contains(normalizedSearchTerm, StringComparison.OrdinalIgnoreCase) ||
                 (p.Description != null && p.Description.Contains(normalizedSearchTerm, StringComparison.OrdinalIgnoreCase)) ||
                 (p.Brand != null && p.Brand.Name.Contains(normalizedSearchTerm, StringComparison.OrdinalIgnoreCase))))
                .Take(ProductConstants.DEFAULT_CATALOG_SEARCH_LIMIT);

            return mapper.Map<IEnumerable<ProductDto>>(matchingProducts);
        }
    }
}