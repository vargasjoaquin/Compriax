using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class CashRegisterRepository(ApplicationDbContext context) : ICashRegisterRepository
    {
        /// <summary>
        /// Obtiene todas las cajas registradoras.
        /// </summary>
        /// <returns>Colección de cajas registradoras.</returns>
        public async Task<IEnumerable<CashRegister>> GetAllAsync()
        {
            return await context.CashRegisters
                .Include(cr => cr.CashShifts)
                .ThenInclude(cs => cs.User)
                .Where(cr => !cr.IsDeleted)
                .OrderBy(cr => cr.Number)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene una caja registradora por su id.
        /// </summary>
        /// <param name="id">Id de la caja.</param>
        /// <returns>La caja encontrada o null.</returns>
        public async Task<CashRegister?> GetByIdAsync(int id)
        {
            return await context.CashRegisters
                .Include(cr => cr.CashShifts)
                .FirstOrDefaultAsync(cr => cr.Id == id);
        }

        /// <summary>
        /// Obtiene una caja por su número de terminal.
        /// </summary>
        /// <param name="number">Número de caja.</param>
        /// <returns>La caja encontrada o null.</returns>
        public async Task<CashRegister?> GetByNumberAsync(int number)
        {
            return await context.CashRegisters
                .FirstOrDefaultAsync(cr => cr.Number == number && !cr.IsDeleted);
        }

        /// <summary>
        /// Comprueba si una caja tiene un turno abierto actualmente.
        /// </summary>
        /// <param name="cashRegisterId">Id de la caja.</param>
        /// <returns>Verdadero si hay un turno abierto.</returns>
        public async Task<bool> HasOpenShiftAsync(int cashRegisterId)
        {
            return await context.CashShifts
                .AnyAsync(cs => cs.CashRegisterId == cashRegisterId && cs.Status == "Abierta");
        }

        /// <summary>
        /// Registra una nueva caja registradora.
        /// </summary>
        /// <param name="register">Entidad de la caja.</param>
        public async Task AddAsync(CashRegister register) =>
            await context.CashRegisters.AddAsync(register);

        /// <summary>
        /// Actualiza los datos de una caja existente.
        /// </summary>
        /// <param name="register">Entidad de la caja modificada.</param>
        public void Update(CashRegister register) =>
            context.CashRegisters.Update(register);

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}