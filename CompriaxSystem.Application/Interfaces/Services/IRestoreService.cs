using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IRestoreService
    {
        /// <summary>
        /// Recupera una lista de entidades que han sido eliminadas.
        /// </summary>
        /// <param name="entityType">Tipo de entidad (ej: "Product", "Customer").</param>
        /// <returns>Colección de elementos eliminados con metadatos.</returns>
        Task<IEnumerable<DeletedItemDto>> GetDeletedEntitiesAsync(string entityType);

        /// <summary>
        /// Restaura una entidad eliminada previamente a su estado activo.
        /// </summary>
        /// <param name="entityType">Tipo de entidad.</param>
        /// <param name="id">ID de la entidad.</param>
        /// <returns>Resultado de la restauración.</returns>
        Task<OperationResult> RestoreEntityAsync(string entityType, int id);
    }
}
