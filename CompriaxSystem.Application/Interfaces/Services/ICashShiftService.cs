using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ICashShiftService
    {
        /// <summary>
        /// Recupera los datos del turno de caja que se encuentra abierto actualmente.
        /// </summary>
        /// <returns>Datos del turno activo o null si no hay ninguno abierto.</returns>
        Task<CashShiftDto?> GetCurrentActiveShiftAsync();

        /// <summary>
        /// Registra la apertura de un nuevo turno de caja con su saldo inicial.
        /// </summary>
        /// <param name="dto">Datos para la apertura del turno.</param>
        /// <returns>Resultado de la apertura.</returns>
        Task<OperationResult> OpenShiftAsync(CashShiftOpenDto dto);

        /// <summary>
        /// Registra un movimiento de efectivo manual (entrada o salida) en el turno actual.
        /// </summary>
        /// <param name="dto">Datos del movimiento de caja.</param>
        /// <returns>Resultado del registro del movimiento.</returns>
        Task<OperationResult> RegisterMovementAsync(CashMovementCreateDto dto);

        /// <summary>
        /// Obtiene un resumen financiero (ventas, entradas, salidas) del turno actual.
        /// </summary>
        /// <returns>Resumen consolidado del turno.</returns>
        Task<CashShiftSummaryDto> GetCurrentShiftSummaryAsync();

        /// <summary>
        /// Realiza el cierre definitivo del turno de caja actual.
        /// </summary>
        /// <param name="dto">Datos de cierre y arqueo de caja.</param>
        /// <returns>Resultado de la operación de cierre.</returns>
        Task<OperationResult> CloseShiftAsync(CashShiftCloseDto dto);

        /// <summary>
        /// Obtiene un historial de turnos cerrados en un rango de fechas.
        /// </summary>
        /// <param name="start">Fecha inicial.</param>
        /// <param name="end">Fecha final.</param>
        /// <returns>Colección de turnos históricos.</returns>
        Task<IEnumerable<CashShiftDto>> GetShiftHistoryAsync(DateTime start, DateTime end);

        /// <summary>
        /// Recupera todos los movimientos de dinero realizados en el turno abierto actual.
        /// </summary>
        /// <returns>Colección de movimientos del turno.</returns>
        Task<IEnumerable<CashMovementDto>> GetCurrentShiftMovementsAsync();
    }
}
