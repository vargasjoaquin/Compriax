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

        /// <summary>
        /// Registra un nuevo cliente o actualiza un cliente.
        /// </summary>
        /// <param name="dto">Datos del cliente.</param>
        /// <returns>Resultado de la operación de guardado.</returns>
        public async Task<OperationResult> RegisterCustomerAsync(CustomerDto dto)
        {
            var validation = await validator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            string documentNumber = dto.DocumentNumber.Trim();

            var allCustomers = await unitOfWork.Customers.GetAllActiveAsync();
            bool documentNumberExists = allCustomers.Any(c => c.DocumentNumber.Equals(documentNumber, StringComparison.OrdinalIgnoreCase) && c.Id != dto.Id);

            if (documentNumberExists)
                return OperationResult.Failure($"El número de documento '{documentNumber}' ya pertenece a otro cliente registrado.");

            try
            {
                if (dto.Id == 0)
                {
                    var customer = mapper.Map<Customer>(dto);
                    customer.DocumentNumber = documentNumber;
                    await unitOfWork.Customers.AddAsync(customer);
                }
                else
                {
                    var customer = await unitOfWork.Customers.GetByIdAsync(dto.Id);
                    
                    if (customer == null)
                        return OperationResult.Failure("Cliente no encontrado.");

                    mapper.Map(dto, customer);
                    customer.DocumentNumber = documentNumber;
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

        /// <summary>
        /// Realiza la eliminación de un cliente.
        /// </summary>
        /// <param name="id">ID del cliente a eliminar.</param>
        /// <returns>Resultado del proceso.</returns>
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