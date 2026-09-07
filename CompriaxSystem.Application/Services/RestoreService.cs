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
            return entityType.ToUpperInvariant() switch
            {
                "PRODUCTOS" => (await unitOfWork.Products.GetAllDeletedAsync())
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

                "CLIENTES" => (await unitOfWork.Customers.GetAllDeletedAsync())
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

                "PROVEEDORES" => (await unitOfWork.Suppliers.GetAllDeletedAsync())
                    .Select(s => new DeletedItemDto
                    {
                        Id = s.Id,
                        EntityType = "Proveedores",
                        Identifier = s.CUIT,
                        Name = s.CompanyName,
                        AdditionalInfo = s.ContactName,
                        DeletedAt = s.LastUpdatedAt ?? s.CreatedAt,
                        DeletedBy = s.LastUpdatedBy ?? s.CreatedBy
                    }),

                "USUARIOS" => (await unitOfWork.Users.GetAllDeletedAsync())
                    .Select(u => new DeletedItemDto
                    {
                        Id = u.Id,
                        EntityType = "Usuarios",
                        Identifier = u.Username,
                        Name = $"{u.FirstName} {u.LastName}".Trim(),
                        AdditionalInfo = u.Role?.Name,
                        DeletedAt = u.LastUpdatedAt ?? u.CreatedAt,
                        DeletedBy = u.LastUpdatedBy ?? u.CreatedBy
                    }),

                "EMPLEADOS" => (await unitOfWork.Employees.GetAllDeletedAsync())
                    .Select(e => new DeletedItemDto
                    {
                        Id = e.Id,
                        EntityType = "Empleados",
                        Identifier = e.EmployeeCode,
                        Name = $"{e.LastName} {e.FirstName}".Trim(),
                        AdditionalInfo = e.Position?.Name,
                        DeletedAt = e.LastUpdatedAt ?? e.CreatedAt,
                        DeletedBy = e.LastUpdatedBy ?? e.CreatedBy
                    }),

                "CATEGORÍAS" => (await unitOfWork.Categories.GetAllDeletedAsync())
                    .Select(c => new DeletedItemDto
                    {
                        Id = c.Id,
                        EntityType = "Categorías",
                        Identifier = c.Id.ToString(),
                        Name = c.Name,
                        AdditionalInfo = c.Description,
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
                    var product = await unitOfWork.Products.GetDeletedByIdAsync(id);
                    if (product == null)
                        return OperationResult.Failure("Producto no encontrado en la papelera.");

                    product.IsDeleted = false;
                    product.IsActive = true;
                    product.LastUpdatedAt = DateTime.UtcNow;
                    product.LastUpdatedBy = currentUsername;
                    unitOfWork.Products.Update(product);
                    break;

                case "CLIENTES":
                    var customer = await unitOfWork.Customers.GetDeletedByIdAsync(id);
                    if (customer == null)
                        return OperationResult.Failure("Cliente no encontrado en la papelera.");

                    customer.IsDeleted = false;
                    customer.IsActive = true;
                    customer.LastUpdatedAt = DateTime.UtcNow;
                    customer.LastUpdatedBy = currentUsername;
                    unitOfWork.Customers.Update(customer);
                    break;

                case "PROVEEDORES":
                    var supplier = await unitOfWork.Suppliers.GetDeletedByIdAsync(id);
                    if (supplier == null)
                        return OperationResult.Failure("Proveedor no encontrado en la papelera.");

                    supplier.IsDeleted = false;
                    supplier.IsActive = true;
                    supplier.LastUpdatedAt = DateTime.UtcNow;
                    supplier.LastUpdatedBy = currentUsername;
                    unitOfWork.Suppliers.Update(supplier);
                    break;

                case "USUARIOS":
                    var user = await unitOfWork.Users.GetDeletedByIdAsync(id);
                    if (user == null)
                        return OperationResult.Failure("Usuario no encontrado en la papelera.");

                    user.IsDeleted = false;
                    user.IsActive = true;
                    user.LastUpdatedAt = DateTime.UtcNow;
                    user.LastUpdatedBy = currentUsername;
                    unitOfWork.Users.Update(user);
                    break;

                case "EMPLEADOS":
                    var employee = await unitOfWork.Employees.GetDeletedByIdAsync(id);
                    if (employee == null)
                        return OperationResult.Failure("Empleado no encontrado en la papelera.");

                    employee.IsDeleted = false;
                    employee.IsActive = true;
                    employee.LastUpdatedAt = DateTime.UtcNow;
                    employee.LastUpdatedBy = currentUsername;
                    unitOfWork.Employees.Update(employee);
                    break;

                case "CATEGORÍAS":
                    var category = await unitOfWork.Categories.GetDeletedByIdAsync(id);
                    if (category == null)
                        return OperationResult.Failure("Categoría no encontrada en la papelera.");

                    category.IsDeleted = false;
                    category.IsActive = true;
                    category.LastUpdatedAt = DateTime.UtcNow;
                    category.LastUpdatedBy = currentUsername;
                    unitOfWork.Categories.Update(category);
                    break;

                default:
                    return OperationResult.Failure("Tipo de entidad no reconocido.");
            }

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok($"Registro de {entityType} restaurado exitosamente.")
                : OperationResult.Failure("No se realizaron cambios en la base de datos.");
        }
    }
}