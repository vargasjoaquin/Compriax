using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;
using FluentValidation;

namespace CompriaxSystem.Application.Services
{
    public class CustomerService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CustomerDto> validator) : ICustomerService
    {
        /// <summary>
        /// Obtiene todos los clientes activos.
        /// </summary>
        /// <returns>Una colección de DTOs de clientes activos.</returns>
        public async Task<IEnumerable<CustomerDto>> GetAllActiveAsync()
        {
            var activeCustomers = await unitOfWork.Customers.GetAllActiveAsync();
            return mapper.Map<IEnumerable<CustomerDto>>(activeCustomers);
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

            string normalizedDocumentNumber = dto.DocumentNumber.Trim();

            var activeCustomers = await unitOfWork.Customers.GetAllActiveAsync();
            
            bool documentNumberExists = activeCustomers.Any(c => c.DocumentNumber.Equals(normalizedDocumentNumber, StringComparison.OrdinalIgnoreCase) && c.Id != dto.Id);

            if (documentNumberExists)
                return OperationResult.Failure($"El número de documento '{normalizedDocumentNumber}' ya pertenece a otro cliente registrado.");

            try
            {
                if (dto.Id == 0)
                {
                    var customer = mapper.Map<Customer>(dto);
                    customer.DocumentNumber = normalizedDocumentNumber;
                    await unitOfWork.Customers.AddAsync(customer);
                }
                else
                {
                    var customer = await unitOfWork.Customers.GetByIdAsync(dto.Id);
                    
                    if (customer == null)
                        return OperationResult.Failure("Cliente no encontrado.");

                    mapper.Map(dto, customer);
                    customer.DocumentNumber = normalizedDocumentNumber;
                    unitOfWork.Customers.Update(customer);
                }

                var operationSucceeded = await unitOfWork.CompleteAsync();
                
                return operationSucceeded
                    ? OperationResult.Ok("Cliente guardado con éxito.")
                    : OperationResult.Failure("No se realizaron cambios en la base de datos.");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Error de persistencia: {ex.Message}");
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