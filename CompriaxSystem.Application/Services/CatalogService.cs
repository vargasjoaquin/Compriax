using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;
using FluentValidation;

namespace CompriaxSystem.Application.Services
{
    public class CatalogService(
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser,
        IMapper mapper,
        IValidator<CategoryDto> categoryValidator) : ICatalogService
    {
        public async Task<IEnumerable<CategoryDto>> GetActiveCategoriesAsync()
        {
            var categories = await unitOfWork.Categories.GetAllAsync();
            return mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await unitOfWork.Categories.GetByIdAsync(id);
            return category == null ? null : mapper.Map<CategoryDto>(category);
        }

        public async Task<OperationResult> CreateCategoryAsync(CategoryDto dto)
        {
            var validation = await categoryValidator.ValidateAsync(dto);

            if (!validation.IsValid)
                return validation.ToResult();

            var category = mapper.Map<Category>(dto);
            await unitOfWork.Categories.AddAsync(category);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Categoría creada exitosamente.")
                : OperationResult.Failure("Error al guardar la categoría.");
        }

        public async Task<OperationResult> UpdateCategoryAsync(CategoryDto dto)
        {
            var category = await unitOfWork.Categories.GetByIdAsync(dto.Id);

            if (category == null)
                return OperationResult.Failure("Categoría no encontrada.");

            mapper.Map(dto, category);
            unitOfWork.Categories.Update(category);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Categoría actualizada exitosamente.")
                : OperationResult.Failure("No se detectaron cambios.");
        }

        public async Task<OperationResult> DeleteCategoryAsync(int id)
        {
            var category = await unitOfWork.Categories.GetByIdAsync(id);

            if (category == null)
                return OperationResult.Failure("Categoría no encontrada.");

            var allProducts = await unitOfWork.Products.GetAllWithDetailsAsync();
            bool hasActiveProducts = allProducts.Any(p => p.CategoryId == id && !p.IsDeleted);

            if (hasActiveProducts)
                return OperationResult.Failure("No se puede eliminar la categoría porque tiene productos activos vinculados. Reasigne o elimine los productos primero.");

            category.IsDeleted = true;
            category.LastUpdatedBy = currentUser.CurrentUser?.Username;
            category.LastUpdatedAt = DateTime.UtcNow;

            unitOfWork.Categories.Update(category);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Categoría eliminada exitosamente.")
                : OperationResult.Failure("Error al intentar persistir la eliminación.");
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync() => await unitOfWork.Brands.GetAllAsync();

        public async Task<Brand?> GetBrandByIdAsync(int id) => await unitOfWork.Brands.GetByIdAsync(id);

        public async Task<OperationResult> CreateBrandAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return OperationResult.Failure("El nombre de la marca es obligatorio y no puede estar vacío.");

            var brand = new Brand { Name = name.Trim() };
            await unitOfWork.Brands.AddAsync(brand);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Marca creada exitosamente.")
                : OperationResult.Failure("No se realizaron cambios en la base de datos.");
        }

        public async Task<OperationResult> UpdateBrandAsync(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return OperationResult.Failure("El nombre de la marca es obligatorio y no puede estar vacío.");

            var brand = await unitOfWork.Brands.GetByIdAsync(id);

            if (brand == null)
                return OperationResult.Failure("La marca que intenta actualizar no fue encontrada.");

            brand.Name = name.Trim();
            unitOfWork.Brands.Update(brand);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Marca actualizada correctamente.")
                : OperationResult.Failure("No se detectaron cambios en la base de datos.");
        }

        public async Task<OperationResult> DeleteBrandAsync(int id)
        {
            var brand = await unitOfWork.Brands.GetByIdAsync(id);

            if (brand == null)
                return OperationResult.Failure("Marca no encontrada.");

            var allProducts = await unitOfWork.Products.GetAllWithDetailsAsync();
            bool hasActiveProducts = allProducts.Any(p => p.BrandId == id && !p.IsDeleted);

            if (hasActiveProducts)
                return OperationResult.Failure("No se puede eliminar la marca porque tiene productos activos vinculados.");

            brand.IsDeleted = true;
            brand.LastUpdatedBy = currentUser.CurrentUser?.Username;
            brand.LastUpdatedAt = DateTime.UtcNow;

            unitOfWork.Brands.Update(brand);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Marca eliminada exitosamente.")
                : OperationResult.Failure("Error al eliminar la marca.");
        }
    }
}