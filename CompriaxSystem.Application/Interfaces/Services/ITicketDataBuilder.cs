using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ITicketDataBuilder
    {
        /// <summary>
        /// Construye y organiza toda la información necesaria para imprimir un ticket de venta.
        /// </summary>
        /// <param name="sale">Datos de la venta.</param>
        /// <param name="documentNumber">Número de comprobante.</param>
        /// <param name="cashierName">Nombre del cajero.</param>
        /// <param name="paperSize">Tamaño de papel seleccionado.</param>
        /// <returns>Objeto con datos formateados para el ticket.</returns>
        Task<TicketDataDto> BuildSaleTicketDataAsync(SaleDto sale, string documentNumber, string cashierName, ThermalPaperSize paperSize = ThermalPaperSize.Width80mm);
    }
}
