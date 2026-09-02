using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductListAsync();
        Task<ProductDto?> GetByBarcodeAsync(string barcode);
        Task<OperationResult> CreateProductAsync(ProductCreateDto dto);
        Task<OperationResult> UpdateProductAsync(int id, ProductCreateDto dto);
        Task<OperationResult> DeleteProductAsync(int id);
    }
}
