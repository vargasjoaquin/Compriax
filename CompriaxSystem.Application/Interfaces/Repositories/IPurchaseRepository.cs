using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IPurchaseRepository
    {
        /// <summary>
        /// Registra una nueva compra realizada a un proveedor.
        /// </summary>
        /// <param name="purchase">Entidad de la compra.</param>
        Task AddAsync(Purchase purchase);

        /// <summary>
        /// Obtiene una compra específica incluyendo sus artículos y detalles.
        /// </summary>
        /// <param name="id">ID de la compra.</param>
        /// <returns>La compra con sus detalles cargados.</returns>
        Task<Purchase?> GetByIdWithDetailsAsync(int id);

        /// <summary>
        /// Recupera el historial de compras en un rango de fechas determinado.
        /// </summary>
        /// <param name="start">Fecha de inicio.</param>
        /// <param name="end">Fecha de fin.</param>
        /// <returns>Colección de compras realizadas en el periodo.</returns>
        Task<IEnumerable<Purchase>> GetHistoryAsync(DateTime start, DateTime end);

        /// <summary>
        /// Obtiene el último número de documento generado para un tipo de comprobante de compra.
        /// </summary>
        /// <param name="documentTypeId">ID del tipo de documento.</param>
        /// <returns>El último número de documento como cadena.</returns>
        Task<string> GetLastDocumentNumberAsync(int documentTypeId);

        /// <summary>
        /// Guarda los cambios en el repositorio de compras.
        /// </summary>
        /// <returns>Verdadero si se guardó correctamente.</returns>
        Task<bool> SaveChangesAsync();
    }
}
