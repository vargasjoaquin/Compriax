using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ITicketTemplateService
    {
        byte[] RenderThermalTicketPdf(TicketDataDto data);
    }
}
