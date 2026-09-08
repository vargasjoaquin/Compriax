using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class PurchaseRepository(ApplicationDbContext context) : IPurchaseRepository
    {
        /// <summary>
        /// Registra una nueva compra realizada a un proveedor.
        /// </summary>
        /// <param name="purchase">Entidad de la compra.</param>
        public async Task AddAsync(Purchase purchase) =>
            await context.Purchases.AddAsync(purchase);

        /// <summary>
        /// Obtiene una compra mediante ID cargando el proveedor y todos los ítems de productos asociados.
        /// </summary>
        /// <param name="id">Id de la compra.</param>
        /// <returns>La entidad de compra detallada.</returns>
        public async Task<Purchase?> GetByIdWithDetailsAsync(int id) =>
            await context.Purchases
                .Include(p => p.Supplier)
                .Include(p => p.PurchaseItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(p => p.Id == id);

        /// <summary>
        /// Recupera el historial de compras en un rango de fechas incluyendo proveedor, tipo de documento y usuario.
        /// </summary>
        /// <param name="start">Fecha inicial.</param>
        /// <param name="end">Fecha final.</param>
        /// <returns>Colección de compras realizadas en el periodo.</returns>
        public async Task<IEnumerable<Purchase>> GetHistoryAsync(DateTime start, DateTime end) =>
            await context.Purchases
                .Include(p => p.Supplier)
                .Include(p => p.DocumentType)
                .Include(p => p.User)
                .Where(p => p.CreatedAt >= start && p.CreatedAt <= end)
                .ToListAsync();

        /// <summary>
        /// Obtiene el último número de comprobante registrado para un tipo de comprobante de compra específico.
        /// </summary>
        /// <param name="documentTypeId">ID del tipo de comprobante.</param>
        /// <returns>El número del último comprobante de compra o null si no hay registros.</returns>
        public async Task<string> GetLastDocumentNumberAsync(int documentTypeId)
        {
            var lastNumber = await context.Purchases
                .AsNoTracking()
                .Where(p => p.DocumentTypeId == documentTypeId)
                .OrderByDescending(p => p.Id)
                .Select(p => p.DocumentNumber)
                .FirstOrDefaultAsync();

            return lastNumber;
        }

        /// <summary>
        /// Guarda los cambios realizados en el repositorio de compras.
        /// </summary>
        /// <returns>Verdadero si la operación fue exitosa.</returns>
        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}