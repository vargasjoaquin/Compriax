using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;
using CompriaxSystem.Domain.Constants;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class SaleRepository(ApplicationDbContext context) : ISaleRepository
    {
        /// <summary>
        /// Registra una nueva venta.
        /// </summary>
        /// <param name="sale">Entidad de la venta.</param>
        public async Task AddAsync(Sale sale) => await context.Sales.AddAsync(sale);

        /// <summary>
        /// Obtiene el último número de comprobante para un tipo de comprobante fiscal.
        /// </summary>
        /// <param name="documentTypeId">Id del tipo de comprobante.</param>
        /// <returns>El último número registrado o ceros si no hay registros.</returns>
        public async Task<string> GetLastDocumentNumberAsync(int documentTypeId)
        {
            var last = await context.Sales
                .FromSqlRaw(@"SELECT TOP 1 * FROM Sales WITH (UPDLOCK, HOLDLOCK) 
                              WHERE DocumentTypeId = {0} 
                              ORDER BY Id DESC", documentTypeId)
                .AsNoTracking()
                .Select(s => s.DocumentNumber)
                .FirstOrDefaultAsync();

            return last ?? DocumentTypeConstants.EMPTY_DOCUMENT_NUMBER;
        }

        public async Task<bool> SaveChangesAsync() => await context.SaveChangesAsync() > 0;

        /// <summary>
        /// Obtiene el historial de ventas filtrado por fecha y caja, incluyendo detalles de ítems y clientes.
        /// </summary>
        /// <param name="start">Fecha inicial.</param>
        /// <param name="end">Fecha final.</param>
        /// <param name="cashRegisterId">Id de caja.</param>
        /// <returns>Colección de ventas.</returns>
        public async Task<IEnumerable<Sale>> GetHistoryAsync(DateTime start, DateTime end, int? cashRegisterId = null)
        {
            var query = context.Sales
                .AsNoTracking()
                .Include(s => s.CashRegister)
                .Include(s => s.DocumentType)
                .Include(s => s.Customer)
                .Include(s => s.User)
                .Include(s => s.SaleItems)
                    .ThenInclude(si => si.Product)
                        .ThenInclude(p => p.Category)
                .Where(s => s.CreatedAt >= start && s.CreatedAt < end);

            if (cashRegisterId.HasValue && cashRegisterId.Value > 0)
                query = query.Where(s => s.CashRegisterId == cashRegisterId.Value);

            return await query.OrderByDescending(s => s.CreatedAt).ToListAsync();
        }

        /// <summary>
        /// Obtiene una venta por id cargando todas sus relaciones y líneas de productos.
        /// </summary>
        /// <param name="id">Id de la venta.</param>
        /// <returns>La venta detallada.</returns>
        public async Task<Sale?> GetByIdWithDetailsAsync(int id)
        {
            return await context.Sales
                .AsNoTracking()
                .Include(s => s.CashRegister)
                .Include(s => s.DocumentType)
                .Include(s => s.Customer)
                .Include(s => s.User)
                .Include(s => s.PaymentMethod)
                .Include(s => s.SaleItems)
                    .ThenInclude(si => si.Product)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Obtiene una venta utilizando su número de comprobante.
        /// </summary>
        /// <param name="documentNumber">Número de comprobante.</param>
        /// <returns>La venta encontrada o null.</returns>
        public async Task<Sale?> GetByDocumentNumberAsync(string documentNumber)
        {
            return await context.Sales
                .AsNoTracking()
                .Include(s => s.CashRegister)
                .Include(s => s.DocumentType)
                .Include(s => s.Customer)
                .Include(s => s.User)
                .Include(s => s.PaymentMethod)
                .Include(s => s.SaleItems)
                    .ThenInclude(si => si.Product)
                .FirstOrDefaultAsync(s => s.DocumentNumber == documentNumber);
        }
    }
}