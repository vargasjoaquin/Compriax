using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IRestoreService
    {
        Task<IEnumerable<DeletedItemDto>> GetDeletedEntitiesAsync(string entityType);
        Task<OperationResult> RestoreEntityAsync(string entityType, int id);
    }
}
