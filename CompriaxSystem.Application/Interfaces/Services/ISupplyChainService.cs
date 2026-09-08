using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ISupplyChainService
    {
        /// <summary>
        /// Obtiene el listado de proveedores.
        /// </summary>
        /// <returns>Colección de proveedores.</returns>
        Task<IEnumerable<SupplierDto>> GetSuppliersAsync();

        /// <summary>
        /// Crea o actualiza un proveedor.
        /// </summary>
        /// <param name="dto">Datos del proveedor.</param>
        /// <returns>Resultado de la operación.</returns>
        Task<OperationResult> UpsertSupplierAsync(SupplierDto dto);

        /// <summary>
        /// Elimina un proveedor.
        /// </summary>
        /// <param name="id">ID del proveedor.</param>
        /// <returns>Resultado de la eliminación.</returns>
        Task<OperationResult> DeleteSupplierAsync(int id);

        /// <summary>
        /// Procesa una orden de compra, impactando el stock de los productos.
        /// </summary>
        /// <param name="dto">Datos de la compra.</param>
        /// <returns>Resultado del procesamiento.</returns>
        Task<OperationResult> ProcessPurchaseAsync(PurchaseCreateDto dto);

        /// <summary>
        /// Obtiene el próximo número correlativo para un documento de compra.
        /// </summary>
        /// <param name="documentTypeId">Tipo de documento.</param>
        /// <returns>Siguiente número disponible.</returns>
        Task<string> GetNextPurchaseNumberAsync(int documentTypeId);
    }
}
