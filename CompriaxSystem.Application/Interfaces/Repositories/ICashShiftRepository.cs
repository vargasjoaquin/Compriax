using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface ICashShiftRepository
    {
        /// <summary>
        /// Busca el turno actualmente activo para un usuario específico.
        /// </summary>
        /// <param name="userId">ID del usuario (Cajero).</param>
        /// <returns>El turno activo o null si el usuario no tiene una sesión abierta.</returns>
        Task<CashShift?> GetActiveShiftByUserIdAsync(int userId);

        /// <summary>
        /// Busca el turno actualmente activo en una caja específica.
        /// </summary>
        /// <param name="registerId">ID de la caja.</param>
        /// <returns>El turno activo asociado a la caja.</returns>
        Task<CashShift?> GetActiveShiftByRegisterIdAsync(int registerId);

        /// <summary>
        /// Obtiene la información detallada de un turno.
        /// </summary>
        /// <param name="id">ID del turno.</param>
        /// <returns>La entidad CashShift con sus relaciones cargadas.</returns>
        Task<CashShift?> GetByIdWithDetailsAsync(int id);

        /// <summary>
        /// Obtiene el historial de turnos dentro de un rango de fechas determinado.
        /// </summary>
        /// <param name="start">Fecha de inicio del rango.</param>
        /// <param name="end">Fecha de fin del rango.</param>
        /// <returns>Colección de turnos encontrados en el periodo.</returns>
        Task<IEnumerable<CashShift>> GetHistoryAsync(DateTime start, DateTime end);

        /// <summary>
        /// Recupera todos los movimientos financieros asociados a un turno.
        /// </summary>
        /// <param name="shiftId">ID del turno a consultar.</param>
        /// <returns>Una colección de movimientos de caja.</returns>
        Task<IEnumerable<CashMovement>> GetMovementsByShiftIdAsync(int shiftId);

        /// <summary>
        /// Registra la apertura de un nuevo turno de caja.
        /// </summary>
        /// <param name="shift">Entidad del turno a crear.</param>
        Task AddAsync(CashShift shift);

        /// <summary>
        /// Actualiza la información de un turno (ej. proceso de cierre).
        /// </summary>
        /// <param name="shift">Entidad del turno con datos actualizados.</param>
        void Update(CashShift shift);

        /// <summary>
        /// Registra un nuevo movimiento (entrada o salida de dinero) de forma asíncrona.
        /// </summary>
        /// <param name="movement">Entidad del movimiento a registrar.</param>
        Task AddMovementAsync(CashMovement movement);
    }
}
