namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ITicketPrinter
    {
        IEnumerable<string> GetInstalledPrinters();
        Task<bool> PrintTicketAsync(byte[] pdfBytes, string? printerName = null, int copies = 1);
    }
}
