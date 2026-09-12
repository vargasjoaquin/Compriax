using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Obtiene el listado completo de producto.
        /// </summary>
        /// <returns>Colección de productos.</returns>
        Task<IEnumerable<ProductDto>> GetProductListAsync();

        /// <summary>
        /// Busca un producto específico mediante su código de barras.
        /// </summary>
        /// <param name="barcode">Código de barras.</param>
        /// <returns>Datos del producto o null.</returns>
        Task<ProductDto?> GetByBarcodeAsync(string barcode);

        /// <summary>
        /// Registra un nuevo producto en el catálogo.
        /// </summary>
        /// <param name="dto">Datos del nuevo producto.</param>
        /// <returns>Resultado de la creación.</returns>
        Task<OperationResult> CreateProductAsync(ProductCreateDto dto);

        /// <summary>
        /// Actualiza la información de un producto.
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <param name="dto">Nuevos datos del producto.</param>
        /// <returns>Resultado de la actualización.</returns>
        Task<OperationResult> UpdateProductAsync(int id, ProductCreateDto dto);

        /// <summary>
        /// Elimina un producto.
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <returns>Resultado de la eliminación.</returns>
        Task<OperationResult> DeleteProductAsync(int id);

        /// <summary>
        /// Realiza una busqueda rapida de productos por nombre, codigo de barras y descripcion.
        /// </summary>
        /// <param name="searchTerm">Termino de busqueda ingreso por el usuario.</param>
        /// <returns>Collecion de productos que coinciden con el criterio de busqueda.</returns>
        Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchTerm);
    }
}
