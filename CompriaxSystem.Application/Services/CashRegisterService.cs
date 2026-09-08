using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
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
            var registers = await unitOfWork.CashRegisters.GetAllAsync();

            return registers.Select(cr => {
                var openShift = cr.CashShifts.FirstOrDefault(cs => cs.Status == "Abierta");
                return new CashRegisterDto
                {
                    Id = cr.Id,
                    Number = cr.Number,
                    Name = cr.Name,
                    Description = cr.Description,
                    IsActive = cr.IsActive,
                    HasOpenShift = openShift != null,
                    CurrentShiftId = openShift?.Id,
                    CurrentCashierName = openShift?.User?.Username
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
                var existing = await unitOfWork.CashRegisters.GetByNumberAsync(dto.Number);
                
                if (existing != null)
                    return OperationResult.Failure($"Ya existe una caja registrada con el Número {dto.Number}.");

                var register = new CashRegister
                {
                    Number = dto.Number,
                    Name = dto.Name.Trim(),
                    Description = dto.Description?.Trim(),
                    IsActive = true
                };

                await unitOfWork.CashRegisters.AddAsync(register);
            }
            else
            {
                var register = await unitOfWork.CashRegisters.GetByIdAsync(dto.Id);
                
                if (register == null)
                    return OperationResult.Failure("Caja no encontrada.");

                var existing = await unitOfWork.CashRegisters.GetByNumberAsync(dto.Number);
                
                if (existing != null && existing.Id != dto.Id)
                    return OperationResult.Failure($"El Número {dto.Number} ya pertenece a otra caja.");

                register.Number = dto.Number;
                register.Name = dto.Name.Trim();
                register.Description = dto.Description?.Trim();

                unitOfWork.CashRegisters.Update(register);
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
            var register = await unitOfWork.CashRegisters.GetByIdAsync(id);
            
            if (register == null)
                return OperationResult.Failure("Caja no encontrada.");

            bool hasOpenShift = await unitOfWork.CashRegisters.HasOpenShiftAsync(id);
            
            if (hasOpenShift && register.IsActive)
                return OperationResult.Failure("No se puede desactivar una caja que tiene un turno abierto actualmente. Cierre el turno primero.");

            register.IsActive = !register.IsActive;
            unitOfWork.CashRegisters.Update(register);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok($"Caja {(register.IsActive ? "activada" : "desactivada")} correctamente.")
                : OperationResult.Failure("Error al cambiar el estado.");
        }
    }
}