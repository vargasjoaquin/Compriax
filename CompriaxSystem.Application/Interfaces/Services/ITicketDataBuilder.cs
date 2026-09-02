using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ITicketDataBuilder
    {
        Task<TicketDataDto> BuildSaleTicketDataAsync(SaleDto sale, string documentNumber, string cashierName, ThermalPaperSize paperSize = ThermalPaperSize.Width80mm);
    }
}
