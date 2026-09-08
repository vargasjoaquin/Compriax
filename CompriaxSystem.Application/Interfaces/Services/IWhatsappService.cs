namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IWhatsappService
    {
        /// <summary>
        /// Envía un mensaje de WhatsApp al cliente con el enlace de descarga de su factura.
        /// </summary>
        /// <param name="phoneNumber">Número de teléfono del cliente.</param>
        /// <param name="customerName">Nombre del cliente.</param>
        /// <param name="downloadUrl">URL pública de la factura.</param>
        Task SendInvoiceLinkAsync(string phoneNumber, string customerName, string downloadUrl);
    }
}
