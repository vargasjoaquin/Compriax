using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Services
{
    public class CashRegisterService(IUnitOfWork unitOfWork) : ICashRegisterService
    {
        /// <summary>
        /// Obtiene el listado de todas las cajas registradoras indicando si poseen turnos abiertos.
        /// </summary>
        /// <returns>Una colección de DTOs con la información de las cajas.</returns>
        public async Task<IEnumerable<CashRegisterDto>> GetAllRegistersAsync()
        {
            var cashRegisters = await unitOfWork.CashRegisters.GetAllAsync();

            return cashRegisters.Select(cashRegister => 
            {
                var openCashShift = cashRegister.CashShifts.FirstOrDefault(cs => cs.Status == CashShiftStatuses.OPEN);

                return new CashRegisterDto
                {
                    Id = cashRegister.Id,
                    Number = cashRegister.Number,
                    Name = cashRegister.Name,
                    Description = cashRegister.Description,
                    IsActive = cashRegister.IsActive,
                    HasOpenShift = openCashShift != null,
                    CurrentShiftId = openCashShift?.Id,
                    CurrentCashierName = openCashShift?.User?.Username
                };
            }).ToList();
        }

        /// <summary>
        /// Busca los datos de una caja registradora específica por su id.
        /// </summary>
        /// <param name="id">ID de la caja a consultar.</param>
        /// <returns>Los datos de la caja o null si no se encuentra.</returns>
        public async Task<CashRegisterDto?> GetByIdAsync(int id)
        {
            var cashRegister = await unitOfWork.CashRegisters.GetByIdAsync(id);
            
            if (cashRegister == null) 
                return null;

            return new CashRegisterDto
            {
                Id = cashRegister.Id,
                Number = cashRegister.Number,
                Name = cashRegister.Name,
                Description = cashRegister.Description,
                IsActive = cashRegister.IsActive
            };
        }

        /// <summary>
        /// Crea una nueva caja o actualiza una existente.
        /// </summary>
        /// <param name="dto">Objeto con los datos de la caja.</param>
        /// <returns>Resultado de la persistencia de datos.</returns>
        public async Task<OperationResult> UpsertCashRegisterAsync(CashRegisterDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return OperationResult.Failure("El nombre de la caja es obligatorio.");

            if (dto.Number <= 0)
                return OperationResult.Failure("El número de caja debe ser mayor a 0.");

            if (dto.Id == 0)
            {
                var existingCashRegister = await unitOfWork.CashRegisters.GetByNumberAsync(dto.Number);
                
                if (existingCashRegister != null)
                    return OperationResult.Failure($"Ya existe una caja registrada con el Número {dto.Number}.");

                var cashRegister = new CashRegister
                {
                    Number = dto.Number,
                    Name = dto.Name.Trim(),
                    Description = dto.Description?.Trim(),
                    IsActive = true
                };

                await unitOfWork.CashRegisters.AddAsync(cashRegister);
            }
            else
            {
                var cashRegister = await unitOfWork.CashRegisters.GetByIdAsync(dto.Id);
                
                if (cashRegister == null)
                    return OperationResult.Failure("Caja no encontrada.");

                var existingCashRegister = await unitOfWork.CashRegisters.GetByNumberAsync(dto.Number);
                
                if (existingCashRegister != null && existingCashRegister.Id != dto.Id)
                    return OperationResult.Failure($"El Número {dto.Number} ya pertenece a otra caja.");

                cashRegister.Number = dto.Number;
                cashRegister.Name = dto.Name.Trim();
                cashRegister.Description = dto.Description?.Trim();

                unitOfWork.CashRegisters.Update(cashRegister);
            }

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Caja guardada con éxito.")
                : OperationResult.Failure("No se realizaron cambios.");
        }

        /// <summary>
        /// Alterna el estado de activación de una caja, impidiendo la desactivación si hay un turno abierto.
        /// </summary>
        /// <param name="id">ID de la caja a modificar.</param>
        /// <returns>Resultado de la operación de cambio de estado.</returns>
        public async Task<OperationResult> ToggleRegisterStatusAsync(int id)
        {
            var cashRegister = await unitOfWork.CashRegisters.GetByIdAsync(id);
            
            if (cashRegister == null)
                return OperationResult.Failure("Caja no encontrada.");

            bool hasOpenCashShift = await unitOfWork.CashRegisters.HasOpenShiftAsync(id);
            
            if (hasOpenCashShift && cashRegister.IsActive)
                return OperationResult.Failure("No se puede desactivar una caja que tiene un turno abierto actualmente. Cierre el turno primero.");

            cashRegister.IsActive = !cashRegister.IsActive;
            unitOfWork.CashRegisters.Update(cashRegister);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok($"Caja {(cashRegister.IsActive ? "activada" : "desactivada")} correctamente.")
                : OperationResult.Failure("Error al cambiar el estado.");
        }
    }
}