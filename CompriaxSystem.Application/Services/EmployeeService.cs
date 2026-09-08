using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;
using FluentValidation;

namespace CompriaxSystem.Application.Services
{
    public class EmployeeService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<EmployeeDto> validator) : IEmployeeService
    {
        /// <summary>
        /// Obtiene todos los empleados.
        /// </summary>
        /// <returns>Colección de DTOs de empleados.</returns>
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var employees = await unitOfWork.Employees.GetAllAsync();
            return mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        /// <summary>
        /// Obtiene un empleado por su id.
        /// </summary>
        /// <param name="id">Id del empleado.</param>
        /// <returns>Datos del empleado o null.</returns>
        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await unitOfWork.Employees.GetByIdAsync(id);
            return employee == null ? null : mapper.Map<EmployeeDto>(employee);
        }

        /// <summary>
        /// Crea o actualiza un empleado validando legajo y DNI.
        /// </summary>
        /// <param name="dto">DTO con los datos del empleado.</param>
        /// <returns>Resultado de la operación de persistencia.</returns>
        public async Task<OperationResult> UpsertEmployeeAsync(EmployeeDto dto)
        {
            var validation = await validator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            string employeeCode = dto.EmployeeCode.Trim();
            string documentNumber = dto.DocumentNumber.Trim();

            var allEmployees = await unitOfWork.Employees.GetAllAsync();

            bool employeeCodeExists = allEmployees.Any(e => e.EmployeeCode.Equals(employeeCode, StringComparison.OrdinalIgnoreCase) && e.Id != dto.Id);
            bool documentNumberExists = allEmployees.Any(e => e.DocumentNumber.Equals(documentNumber, StringComparison.OrdinalIgnoreCase) && e.Id != dto.Id);

            if (employeeCodeExists)
                return OperationResult.Failure($"El legajo '{employeeCode}' ya pertenece a otro empleado registrado.");

            if (documentNumberExists)
                return OperationResult.Failure($"El número de DNI '{documentNumber}' ya está registrado para otro empleado.");
            
            if (dto.Id == 0)
            {
                var employee = mapper.Map<Employee>(dto);
                employee.EmployeeCode = employeeCode;
                employee.DocumentNumber = documentNumber;
                employee.Position = null!;
                employee.Gender = null!;
                employee.CivilStatus = null!;
                employee.IsActive = true;
                employee.IsDeleted = false;

                await unitOfWork.Employees.AddAsync(employee);
            }
            else
            {
                var employee = await unitOfWork.Employees.GetByIdAsync(dto.Id);
                
                if (employee == null)
                    return OperationResult.Failure("Empleado no encontrado.");

                mapper.Map(dto, employee);
                employee.EmployeeCode = employeeCode;
                employee.DocumentNumber = documentNumber;
                employee.Position = null!;
                employee.Gender = null!;
                employee.CivilStatus = null!;

                unitOfWork.Employees.Update(employee);
            }

            var result = await unitOfWork.CompleteAsync();
            return result
                ? OperationResult.Ok("Registro de personal procesado con éxito.")
                : OperationResult.Failure("No se detectaron cambios en la base de datos.");
        }

        /// <summary>
        /// Desactiva y elimina a un empleado.
        /// </summary>
        /// <param name="id">Id del empleado.</param>
        /// <returns>Resultado de la baja.</returns>
        public async Task<OperationResult> DeleteEmployeeAsync(int id)
        {
            var employee = await unitOfWork.Employees.GetByIdAsync(id);
            
            if (employee == null)
                return OperationResult.Failure("Registro de personal no encontrado.");

            employee.IsActive = false;
            employee.IsDeleted = true;

            unitOfWork.Employees.Update(employee);
            var result = await unitOfWork.CompleteAsync();

            return result
                ? OperationResult.Ok("Empleado desactivado correctamente.")
                : OperationResult.Failure("Error al procesar la eliminación.");
        }
    }
}