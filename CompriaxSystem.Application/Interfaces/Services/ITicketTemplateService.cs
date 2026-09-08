using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ITicketTemplateService
    {
        /// <summary>
        /// Convierte los datos de un ticket en un PDF optimizado para impresión térmica.
        /// </summary>
        /// <param name="data">Datos del ticket.</param>
        /// <returns>Arreglo de bytes del PDF renderizado.</returns>
        byte[] RenderThermalTicketPdf(TicketDataDto data);
    }
}
