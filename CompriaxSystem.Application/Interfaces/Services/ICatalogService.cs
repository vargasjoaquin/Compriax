using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ICatalogService
    {
        /// <summary>
        /// Obtiene las categorías que están disponibles.
        /// </summary>
        /// <returns>Colección de categorías activas.</returns>
        Task<IEnumerable<CategoryDto>> GetActiveCategoriesAsync();

        /// <summary>
        /// Busca una categoría por id.
        /// </summary>
        /// <param name="id">ID de la categoría.</param>
        /// <returns>Datos de la categoría.</returns>
        Task<CategoryDto?> GetCategoryByIdAsync(int id);

        /// <summary>
        /// Crea una nueva categoría en el catálogo.
        /// </summary>
        /// <param name="categoryDto">Datos de la nueva categoría.</param>
        /// <returns>Resultado de la creación.</returns>
        Task<OperationResult> CreateCategoryAsync(CategoryDto categoryDto);

        /// <summary>
        /// Actualiza los datos de una categoría.
        /// </summary>
        /// <param name="categoryDto">Datos actualizados.</param>
        /// <returns>Resultado de la actualización.</returns>
        Task<OperationResult> UpdateCategoryAsync(CategoryDto categoryDto);

        /// <summary>
        /// Realiza una eliminación de una categoría.
        /// </summary>
        /// <param name="id">ID de la categoría a eliminar.</param>
        /// <returns>Resultado de la eliminación.</returns>
        Task<OperationResult> DeleteCategoryAsync(int id);

        /// <summary>
        /// Obtiene todas las marcas registradas.
        /// </summary>
        /// <returns>Colección de marcas.</returns>
        Task<IEnumerable<Brand>> GetBrandsAsync();

        /// <summary>
        /// Busca una marca por su id.
        /// </summary>
        /// <param name="id">ID de la marca.</param>
        /// <returns>Entidad de la marca.</returns>
        Task<Brand?> GetBrandByIdAsync(int id);

        /// <summary>
        /// Registra una nueva marca.
        /// </summary>
        /// <param name="name">Nombre de la marca.</param>
        /// <returns>Resultado de la operación.</returns>
        Task<OperationResult> CreateBrandAsync(string name);

        /// <summary>
        /// Actualiza el nombre de una marca.
        /// </summary>
        /// <param name="id">ID de la marca.</param>
        /// <param name="name">Nuevo nombre.</param>
        /// <returns>Resultado de la operación.</returns>
        Task<OperationResult> UpdateBrandAsync(int id, string name);

        /// <summary>
        /// Elimina una marca del sistema.
        /// </summary>
        /// <param name="id">ID de la marca.</param>
        /// <returns>Resultado de la eliminación.</returns>
        Task<OperationResult> DeleteBrandAsync(int id);
    }
}
