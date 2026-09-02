using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;

namespace CompriaxSystem.Application.Services
{
    public class RestoreService(
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUserService) : IRestoreService
    {
        public async Task<IEnumerable<DeletedItemDto>> GetDeletedEntitiesAsync(string entityType)
        {
            // Orquestación limpia de los elementos eliminados por tipo
            return entityType.ToUpperInvariant() switch
            {
                "PRODUCTOS" => (await unitOfWork.Products.GetAllWithDetailsAsync())
                    .Where(p => p.IsDeleted)
                    .Select(p => new DeletedItemDto
                    {
                        Id = p.Id,
                        EntityType = "Productos",
                        Identifier = p.Barcode,
                        Name = p.Name,
                        AdditionalInfo = p.Category?.Name,
                        DeletedAt = p.LastUpdatedAt ?? p.CreatedAt,
                        DeletedBy = p.LastUpdatedBy ?? p.CreatedBy
                    }),

                "CLIENTES" => (await unitOfWork.Customers.GetAllActiveAsync())
                    .Where(c => c.IsDeleted)
                    .Select(c => new DeletedItemDto
                    {
                        Id = c.Id,
                        EntityType = "Clientes",
                        Identifier = c.DocumentNumber,
                        Name = $"{c.LastName} {c.FirstName}",
                        AdditionalInfo = c.TaxCondition?.Name ?? string.Empty,
                        DeletedAt = c.LastUpdatedAt ?? c.CreatedAt,
                        DeletedBy = c.LastUpdatedBy ?? c.CreatedBy
                    }),

                _ => Enumerable.Empty<DeletedItemDto>()
            };
        }

        public async Task<OperationResult> RestoreEntityAsync(string entityType, int id)
        {
            string currentUsername = currentUserService.CurrentUser!.Username;

            switch (entityType.ToUpperInvariant())
            {
                case "PRODUCTOS":
                    var product = await unitOfWork.Products.GetByIdAsync(id);
                    
                    if (product == null) 
                        return OperationResult.Failure("Producto no encontrado.");
                    
                    if (!product.IsDeleted) 
                        return OperationResult.Failure("El producto ya se encuentra activo.");

                    product.IsDeleted = false;
                    product.IsActive = true;
                    product.LastUpdatedAt = DateTime.UtcNow;
                    product.LastUpdatedBy = currentUsername;
                    unitOfWork.Products.Update(product);
                    break;

                case "CLIENTES":
                    var customer = await unitOfWork.Customers.GetByIdAsync(id);
                    
                    if (customer == null)
                        return OperationResult.Failure("Cliente no encontrado.");
                    
                    if (!customer.IsDeleted) 
                        return OperationResult.Failure("El cliente ya se encuentra activo.");

                    customer.IsDeleted = false;
                    customer.IsActive = true;
                    customer.LastUpdatedAt = DateTime.UtcNow;
                    customer.LastUpdatedBy = currentUsername;
                    unitOfWork.Customers.Update(customer);
                    break;

                default:
                    return OperationResult.Failure("Tipo de entidad no reconocido.");
            }

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok($"Registro de {entityType} restaurado exitosamente.")
                : OperationResult.Failure("No se realizaron cambios.");
        }
    }
}