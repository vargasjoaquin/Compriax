using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class CustomerRepository(ApplicationDbContext context) : ICustomerRepository
    {
        /// <summary>
        /// Obtiene un cliente por su id.
        /// </summary>
        /// <param name="id">Id del cliente.</param>
        /// <returns>La entidad del cliente o null.</returns>
        public async Task<Customer?> GetByIdAsync(int id) =>
            await context.Customers.FirstOrDefaultAsync(c => c.Id == id);

        /// <summary>
        /// Obtiene un cliente eliminado.
        /// </summary>
        /// <param name="id">Id del cliente borrado.</param>
        /// <returns>La entidad del cliente en la papelera.</returns>
        public async Task<Customer?> GetDeletedByIdAsync(int id) =>
            await context.Customers
                .IgnoreQueryFilters()
                .Include(c => c.TaxCondition)
                .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted);

        /// <summary>
        /// Obtiene todos los clientes que han sido marcados como eliminados.
        /// </summary>
        /// <returns>Una colección de clientes eliminados.</returns>
        public async Task<IEnumerable<Customer>> GetAllDeletedAsync() =>
            await context.Customers
                .IgnoreQueryFilters()
                .Include(c => c.TaxCondition)
                .Where(c => c.IsDeleted)
                .ToListAsync();

        /// <summary>
        /// Obtiene un cliente mediante su número de documento.
        /// </summary>
        /// <param name="documentNumber">Número de documento a buscar.</param>
        /// <returns>La entidad del cliente o null.</returns>
        public async Task<Customer?> GetByDocumentAsync(string documentNumber) =>
            await context.Customers.FirstOrDefaultAsync(c => c.DocumentNumber == documentNumber);

        /// <summary>
        /// Obtiene todos los clientes activos.
        /// </summary>
        /// <returns>Una colección de clientes con su condición fiscal incluida.</returns>
        public async Task<IEnumerable<Customer>> GetAllActiveAsync()
        {
            return await context.Customers
                .Include(c => c.TaxCondition)
                .AsNoTracking()
                .OrderBy(c => c.LastName)
                .ToListAsync();
        }

        /// <summary>
        /// Agrega un nuevo cliente.
        /// </summary>
        /// <param name="customer">Entidad del cliente a registrar.</param>
        public async Task AddAsync(Customer customer) =>
            await context.Customers.AddAsync(customer);

        /// <summary>
        /// Actualiza un cliente.
        /// </summary>
        /// <param name="customer">Entidad del cliente con los nuevos datos.</param>
        public void Update(Customer customer) =>
            context.Entry(customer).State = EntityState.Modified;

        /// <summary>
        /// Guarda los cambios realizados en el repositorio de clientes.
        /// </summary>
        /// <returns>Verdadero si la operación fue exitosa.</returns>
        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}