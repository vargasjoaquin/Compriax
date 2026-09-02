using AutoMapper;
using FluentValidation;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Common;
using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Services
{
    public class EmployeeService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<EmployeeDto> validator) : IEmployeeService
    {
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var employees = await unitOfWork.Employees.GetAllAsync();
            return mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await unitOfWork.Employees.GetByIdAsync(id);
            return employee == null ? null : mapper.Map<EmployeeDto>(employee);
        }

        public async Task<OperationResult> UpsertEmployeeAsync(EmployeeDto dto)
        {
            var validation = await validator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            if (dto.Id == 0)
            {
                var employee = mapper.Map<Employee>(dto);
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