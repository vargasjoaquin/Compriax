using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;
using FluentValidation;

namespace CompriaxSystem.Application.Services
{
    public class CustomerService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CustomerDto> validator) : ICustomerService
    {
        public async Task<IEnumerable<CustomerDto>> GetAllActiveAsync()
        {
            var customers = await unitOfWork.Customers.GetAllActiveAsync();
            return mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<OperationResult> RegisterCustomerAsync(CustomerDto dto)
        {
            var validation = await validator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            try
            {
                if (dto.Id == 0)
                {
                    var existing = await unitOfWork.Customers.GetByDocumentAsync(dto.DocumentNumber);
                    
                    if (existing != null)
                        return OperationResult.Failure("Este número de documento ya está registrado.");

                    var customer = mapper.Map<Customer>(dto);
                    await unitOfWork.Customers.AddAsync(customer);
                }
                else
                {
                    var customer = await unitOfWork.Customers.GetByIdAsync(dto.Id);
                    
                    if (customer == null)
                        return OperationResult.Failure("Cliente no encontrado.");

                    mapper.Map(dto, customer);
                    unitOfWork.Customers.Update(customer);
                }

                var success = await unitOfWork.CompleteAsync();
                return success
                    ? OperationResult.Ok("Cliente guardado con éxito.")
                    : OperationResult.Failure("No se realizaron cambios en la base de datos.");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Error de persistencia: " + ex.Message);
            }
        }

        public async Task<OperationResult> DeleteCustomerAsync(int id)
        {
            var customer = await unitOfWork.Customers.GetByIdAsync(id);
            
            if (customer == null)
                return OperationResult.Failure("Cliente no encontrado.");

            customer.IsDeleted = true;
            unitOfWork.Customers.Update(customer);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Cliente eliminado correctamente.")
                : OperationResult.Failure("Error al procesar la eliminación.");
        }
    }
}