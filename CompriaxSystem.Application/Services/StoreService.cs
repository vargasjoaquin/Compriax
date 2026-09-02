using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using FluentValidation;

namespace CompriaxSystem.Application.Services
{
    public class StoreService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<StoreSettingsDto> storeValidator) : IStoreService
    {
        public async Task<StoreSettingsDto> GetStoreProfileAsync()
        {
            var settings = await unitOfWork.Store.GetSettingsAsync();

            return mapper.Map<StoreSettingsDto>(settings);
        }

        public async Task<OperationResult> UpdateStoreProfileAsync(StoreSettingsDto dto)
        {
            var validation = await storeValidator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var settings = await unitOfWork.Store.GetSettingsAsync();
            mapper.Map(dto, settings);

            unitOfWork.Store.Update(settings);
            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Perfil comercial actualizado con éxito.")
                : OperationResult.Failure("Sin cambios detectados.");
        }
    }
}