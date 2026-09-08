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
        /// <summary>
        /// Obtiene la configuración y datos institucionales del comercio.
        /// </summary>
        /// <returns>DTO con los ajustes de la tienda.</returns>
        public async Task<StoreSettingsDto> GetStoreProfileAsync()
        {
            var settings = await unitOfWork.Store.GetSettingsAsync();

            return mapper.Map<StoreSettingsDto>(settings);
        }

        /// <summary>
        /// Actualiza el perfil comercial..
        /// </summary>
        /// <param name="dto">Datos actualizados.</param>
        /// <returns>Resultado de la operación.</returns>
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