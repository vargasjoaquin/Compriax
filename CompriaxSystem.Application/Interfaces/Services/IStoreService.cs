using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IStoreService
    {
        Task<StoreSettingsDto> GetStoreProfileAsync();
        Task<OperationResult> UpdateStoreProfileAsync(StoreSettingsDto dto);
    }
}
