namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IWhatsappService
    {
        Task SendInvoiceLinkAsync(string phoneNumber, string customerName, string downloadUrl);
    }
}
