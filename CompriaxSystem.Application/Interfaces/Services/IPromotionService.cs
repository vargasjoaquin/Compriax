using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IPromotionService
    {
        /// <summary>
        /// Obtiene todas las promociones.
        /// </summary>
        /// <returns>Colección de promociones.</returns>
        Task<IEnumerable<PromotionDto>> GetAllPromotionsAsync();

        /// <summary>
        /// Busca una promoción por id.
        /// </summary>
        /// <param name="id">ID de la promoción.</param>
        /// <returns>Datos de la promoción.</returns>
        Task<PromotionDto?> GetByIdAsync(int id);

        /// <summary>
        /// Crea o actualiza una promoción.
        /// </summary>
        /// <param name="dto">Datos de la promoción.</param>
        /// <returns>Resultado de la operación.</returns>
        Task<OperationResult> UpsertPromotionAsync(PromotionDto dto);

        /// <summary>
        /// Elimina una promoción.
        /// </summary>
        /// <param name="id">ID de la promoción.</param>
        /// <returns>Resultado de la eliminación.</returns>
        Task<OperationResult> DeletePromotionAsync(int id);

        /// <summary>
        /// Activa o desactiva una promoción.
        /// </summary>
        /// <param name="id">ID de la promoción.</param>
        /// <returns>Resultado del cambio de estado.</returns>
        Task<OperationResult> ToggleStatusAsync(int id);

        /// <summary>
        /// Calcula los descuentos aplicables a una lista de artículos de venta en una fecha dada.
        /// </summary>
        /// <param name="items">Artículos a evaluar.</param>
        /// <param name="date">Fecha de aplicación.</param>
        /// <returns>Resultado con el desglose de descuentos y totales.</returns>
        Task<SaleCalculationResultDto> CalculateSaleDiscountsAsync(IEnumerable<SaleItemDto> items, DateTime date);
    }
}
