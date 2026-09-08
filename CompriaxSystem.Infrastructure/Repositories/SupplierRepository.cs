using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class SupplierRepository(ApplicationDbContext context) : ISupplierRepository
    {
        /// <summary>
        /// Obtiene el listado de todos los proveedores registrados.
        /// </summary>
        /// <returns>Una colección de proveedores.</returns>
        public async Task<IEnumerable<Supplier>> GetAllAsync() =>
            await context.Suppliers.ToListAsync();

        /// <summary>
        /// Obtiene un proveedor mediante su id.
        /// </summary>
        /// <param name="id">Id del proveedor.</param>
        /// <returns>La entidad del proveedor o null.</returns>
        public async Task<Supplier?> GetByIdAsync(int id) =>
            await context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);

        /// <summary>
        /// Obtiene un proveedor eliminado mediante su id.
        /// </summary>
        /// <param name="id">Id del proveedor borrado.</param>
        /// <returns>La entidad del proveedor encontrada en la papelera.</returns>
        public async Task<Supplier?> GetDeletedByIdAsync(int id) =>
            await context.Suppliers
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted);

        /// <summary>
        /// Obtiene todos los proveedores que se encuentran eliminados.
        /// </summary>
        /// <returns>Una colección de proveedores eliminados.</returns>
        public async Task<IEnumerable<Supplier>> GetAllDeletedAsync() =>
            await context.Suppliers
                .IgnoreQueryFilters()
                .Where(s => s.IsDeleted)
                .ToListAsync();

        /// <summary>
        /// Registra un nuevo proveedor.
        /// </summary>
        /// <param name="supplier">Entidad del proveedor a agregar.</param>
        public async Task AddAsync(Supplier supplier) =>
            await context.Suppliers.AddAsync(supplier);

        /// <summary>
        /// Actualiza un proveedor.
        /// </summary>
        /// <param name="supplier">Entidad del proveedor modificada.</param>
        public void Update(Supplier supplier) =>
            context.Suppliers.Update(supplier);

        /// <summary>
        /// Guarda los cambios realizados en el repositorio de proveedores.
        /// </summary>
        /// <returns>Verdadero si se guardó al menos un registro.</returns>
        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}