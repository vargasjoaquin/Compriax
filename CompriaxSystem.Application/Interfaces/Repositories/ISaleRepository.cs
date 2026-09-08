using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        /// <summary>
        /// Registra una nueva venta.
        /// </summary>
        /// <param name="sale">Entidad de la venta.</param>
        Task AddAsync(Sale sale);

        /// <summary>
        /// Recupera el último número de factura o documento emitido según su tipo.
        /// </summary>
        /// <param name="documentTypeId">ID del tipo de comprobante.</param>
        /// <returns>Número del último documento.</returns>
        Task<string> GetLastDocumentNumberAsync(int documentTypeId);

        /// <summary>
        /// Guarda los cambios en el repositorio de ventas.
        /// </summary>
        /// <returns>Éxito de la operación.</returns>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// Obtiene el historial de ventas filtrado por fecha y, opcionalmente, por caja.
        /// </summary>
        /// <param name="start">Fecha de inicio.</param>
        /// <param name="end">Fecha de fin.</param>
        /// <param name="cashRegisterId">ID de la caja (opcional).</param>
        /// <returns>Colección de ventas que cumplen los criterios.</returns>
        Task<IEnumerable<Sale>> GetHistoryAsync(DateTime start, DateTime end, int? cashRegisterId = null);

        /// <summary>
        /// Busca una venta por ID cargando todos sus detalles y líneas de venta.
        /// </summary>
        /// <param name="id">ID de la venta.</param>
        /// <returns>La venta con detalles.</returns>
        Task<Sale?> GetByIdWithDetailsAsync(int id);

        /// <summary>
        /// Busca una venta utilizando el número de comprobante/documento.
        /// </summary>
        /// <param name="documentNumber">Número de documento de la venta.</param>
        /// <returns>La entidad de la venta encontrada.</returns>
        Task<Sale?> GetByDocumentNumberAsync(string documentNumber);
    }
}
