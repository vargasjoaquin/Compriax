using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface ISupplierRepository
    {
        /// <summary>
        /// Obtiene el listado de todos los proveedores activos.
        /// </summary>
        /// <returns>Colección de proveedores.</returns>
        Task<IEnumerable<Supplier>> GetAllAsync();

        /// <summary>
        /// Busca un proveedor por su id.
        /// </summary>
        /// <param name="id">ID del proveedor.</param>
        /// <returns>La entidad del proveedor.</returns>
        Task<Supplier?> GetByIdAsync(int id);

        /// <summary>
        /// Registra un nuevo proveedor.
        /// </summary>
        /// <param name="supplier">Entidad del proveedor.</param>
        Task AddAsync(Supplier supplier);

        /// <summary>
        /// Actualiza la información de un proveedor.
        /// </summary>
        /// <param name="supplier">Entidad actualizada.</param>
        void Update(Supplier supplier);

        /// <summary>
        /// Guarda los cambios realizados sobre los proveedores.
        /// </summary>
        /// <returns>Éxito de la operación.</returns>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// Obtiene los proveedores que han sido marcados como eliminados.
        /// </summary>
        /// <returns>Colección de proveedores eliminados.</returns>
        Task<IEnumerable<Supplier>> GetAllDeletedAsync();

        /// <summary>
        /// Recupera un proveedor eliminado mediante su id.
        /// </summary>
        /// <param name="id">ID del proveedor borrado.</param>
        /// <returns>La entidad del proveedor.</returns>
        Task<Supplier?> GetDeletedByIdAsync(int id);
    }
}
