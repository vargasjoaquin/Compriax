using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<CategoryDto>> GetActiveCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<OperationResult> CreateCategoryAsync(CategoryDto categoryDto);
        Task<OperationResult> UpdateCategoryAsync(CategoryDto categoryDto);
        Task<OperationResult> DeleteCategoryAsync(int id);

        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task<Brand?> GetBrandByIdAsync(int id);
        Task<OperationResult> CreateBrandAsync(string name);
        Task<OperationResult> UpdateBrandAsync(int id, string name);
        Task<OperationResult> DeleteBrandAsync(int id);
    }
}
