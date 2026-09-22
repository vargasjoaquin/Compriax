using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.Domain.Entities;
using FluentValidation;

namespace CompriaxSystem.Application.Services
{
    public class CatalogService(IUnitOfWork unitOfWork, ICurrentUserService currentUser, IMapper mapper, IValidator<CategoryDto> categoryValidator) : ICatalogService
    {
        /// <summary>
        /// Obtiene todas las categorías activas.
        /// </summary>
        /// <returns>Una colección de DTOs de categorías activas.</returns>
        public async Task<IEnumerable<CategoryDto>> GetActiveCategoriesAsync()
        {
            var activeCategories = await unitOfWork.Categories.GetAllAsync();
            return mapper.Map<IEnumerable<CategoryDto>>(activeCategories);
        }

        /// <summary>
        /// Recupera los datos de una categoría por su id.
        /// </summary>
        /// <param name="id">Id de la categoría.</param>
        /// <returns>La categoría encontrada o null.</returns>
        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await unitOfWork.Categories.GetByIdAsync(id);
            return category == null ? null : mapper.Map<CategoryDto>(category);
        }

        /// <summary>
        /// Registra una nueva categoría.
        /// </summary>
        /// <param name="dto">DTO con la información de la categoría.</param>
        /// <returns>Resultado de la operación de creación.</returns>
        public async Task<OperationResult> CreateCategoryAsync(CategoryDto dto)
        {
            var validation = await categoryValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                return validation.ToResult();

            var category = mapper.Map<Category>(dto);
            category.CreatedBy = currentUser.CurrentUser?.Username ?? RoleConstants.DEFAULT_ADMIN_USERNAME;
            category.CreatedAt = DateTime.UtcNow;

            await unitOfWork.Categories.AddAsync(category);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Categoría­ creada exitosamente.")
                : OperationResult.Failure("Error al guardar la categoría.");
        }

        /// <summary>
        /// Actualiza una categoría.
        /// </summary>
        /// <param name="dto">DTO con los datos actualizados.</param>
        /// <returns>Resultado de la actualización.</returns>
        public async Task<OperationResult> UpdateCategoryAsync(CategoryDto dto)
        {
            var validation = await categoryValidator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var category = await unitOfWork.Categories.GetByIdAsync(dto.Id);
            
            if (category == null)
                return OperationResult.Failure("Categoría no encontrada.");

            mapper.Map(dto, category);
            category.LastUpdatedBy = currentUser.CurrentUser?.Username ?? RoleConstants.DEFAULT_ADMIN_USERNAME;
            category.LastUpdatedAt = DateTime.UtcNow;

            unitOfWork.Categories.Update(category);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Categoría actualizada exitosamente.")
                : OperationResult.Failure("No se detectaron cambios.");
        }

        /// <summary>
        /// Elimina una categoría si no tiene productos activos vinculados.
        /// </summary>
        /// <param name="id">Id de la categoría a eliminar.</param>
        /// <returns>Resultado de la eliminación.</returns>
        public async Task<OperationResult> DeleteCategoryAsync(int id)
        {
            var category = await unitOfWork.Categories.GetByIdAsync(id);

            if (category == null)
                return OperationResult.Failure("Categoría no encontrada.");

            var products = await unitOfWork.Products.GetAllWithDetailsAsync();
            bool hasActiveProducts = products.Any(p => p.CategoryId == id && !p.IsDeleted);

            if (hasActiveProducts)
                return OperationResult.Failure("No se puede eliminar la categoría porque tiene productos activos vinculados. Reasigne o elimine los productos primero.");

            category.IsDeleted = true;
            category.LastUpdatedBy = currentUser.CurrentUser?.Username ?? RoleConstants.DEFAULT_ADMIN_USERNAME;
            category.LastUpdatedAt = DateTime.UtcNow;

            unitOfWork.Categories.Update(category);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Categoría eliminada exitosamente.")
                : OperationResult.Failure("Error al intentar persistir la eliminación.");
        }

        // <summary>
        /// Obtiene el listado de marcas registradas.
        /// </summary>
        /// <returns>Colección de entidades de marca.</returns>
        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await unitOfWork.Brands.GetAllAsync();
        }

        /// <summary>
        /// Registra una nueva marca en el sistema.
        /// </summary>
        /// <param name="name">Nombre de la marca.</param>
        /// <returns>Resultado de la creación.</returns>
        public async Task<Brand?> GetBrandByIdAsync(int id)
        {
            return await unitOfWork.Brands.GetByIdAsync(id);
        }

        /// <summary>
        /// Registra una nueva marca en el sistema.
        /// </summary>
        /// <param name="name">Nombre de la marca.</param>
        /// <returns>Resultado de la creación.</returns>
        public async Task<OperationResult> CreateBrandAsync(string brandName)
        {
            if (string.IsNullOrWhiteSpace(brandName))
                return OperationResult.Failure("El nombre de la marca es obligatorio y no puede estar vacío.");

            string normalizedBrandName = brandName.Trim();
            
            if (normalizedBrandName.Length > 50)
                return OperationResult.Failure("El nombre de la marca no puede superar los 50 caracteres.");

            var brand = new Brand 
            { 
                Name = normalizedBrandName,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = currentUser.CurrentUser?.Username ?? RoleConstants.DEFAULT_ADMIN_USERNAME
            };
            
            await unitOfWork.Brands.AddAsync(brand);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Marca creada exitosamente.")
                : OperationResult.Failure("No se realizaron cambios en la base de datos.");
        }

        /// <summary>
        /// Actualiza una marca.
        /// </summary>
        /// <param name="id">Id de la marca.</param>
        /// <param name="name">Nombre de la marca.</param>
        /// <returns>Resultado de la actualización.</returns>
        public async Task<OperationResult> UpdateBrandAsync(int id, string brandName)
        {
            if (string.IsNullOrWhiteSpace(brandName))
                return OperationResult.Failure("El nombre de la marca es obligatorio y no puede estar vacío.");

            string normalizedBrandName = brandName.Trim();
            
            if (normalizedBrandName.Length > 50)
                return OperationResult.Failure("El nombre de la marca no puede superar los 50 caracteres.");

            var brand = await unitOfWork.Brands.GetByIdAsync(id);

            if (brand == null)
                return OperationResult.Failure("La marca que intenta actualizar no fue encontrada.");

            brand.Name = normalizedBrandName;
            brand.LastUpdatedBy = currentUser.CurrentUser?.Username ?? RoleConstants.DEFAULT_ADMIN_USERNAME;
            brand.LastUpdatedAt = DateTime.UtcNow;

            unitOfWork.Brands.Update(brand);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Marca actualizada correctamente.")
                : OperationResult.Failure("No se detectaron cambios en la base de datos.");
        }

        /// <summary>
        /// Elimina una marca si no posee productos asociados.
        /// </summary>
        /// <param name="id">ID de la marca.</param>
        /// <returns>Resultado de la eliminación.</returns>
        public async Task<OperationResult> DeleteBrandAsync(int id)
        {
            var brand = await unitOfWork.Brands.GetByIdAsync(id);

            if (brand == null)
                return OperationResult.Failure("Marca no encontrada.");

            var products = await unitOfWork.Products.GetAllWithDetailsAsync();

            bool hasActiveProducts = products.Any(p => p.BrandId == id && !p.IsDeleted);

            if (hasActiveProducts)
                return OperationResult.Failure("No se puede eliminar la marca porque tiene productos activos vinculados.");

            brand.IsDeleted = true;
            brand.LastUpdatedBy = currentUser.CurrentUser?.Username ?? RoleConstants.DEFAULT_ADMIN_USERNAME;
            brand.LastUpdatedAt = DateTime.UtcNow;

            unitOfWork.Brands.Update(brand);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Marca eliminada exitosamente.")
                : OperationResult.Failure("Error al eliminar la marca.");
        }
    }
}