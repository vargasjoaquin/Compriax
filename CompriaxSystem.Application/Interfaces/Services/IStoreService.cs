using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IStoreService
    {
        Task<StoreSettingsDto> GetStoreProfileAsync();
        Task<OperationResult> UpdateStoreProfileAsync(StoreSettingsDto dto);
    }
}
