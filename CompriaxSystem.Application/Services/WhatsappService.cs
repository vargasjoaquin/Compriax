using CompriaxSystem.Application.Interfaces.Services;
using System.Diagnostics;

namespace CompriaxSystem.Application.Services
{
    public class WhatsappService : IWhatsappService
    {
        /// <summary>
        /// Abre la API de WhatsApp con un mensaje predefinido que contiene el link de descarga del comprobante.
        /// </summary>
        /// <param name="phoneNumber">Teléfono del cliente.</param>
        /// <param name="customerName">Nombre del cliente.</param>
        /// <param name="downloadUrl">URL de descarga del PDF.</param>
        public async Task SendInvoiceLinkAsync(string phoneNumber, string customerName, string downloadUrl)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return;

            string normalizedPhoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

            string whatsappMessage = $"*¡Hola, {customerName}!* 👋%0A%0A" +
                             $"Gracias por tu compra. Aquí puedes descargar tu factura:%0A" +
                             $"{downloadUrl}%0A%0A" +
                             $"*Supermercado Los Dos Chinos* 🛒";

            string encodedMessage = Uri.EscapeDataString(whatsappMessage);
            string whatsappUrl = $"https://wa.me/{normalizedPhoneNumber}?text={encodedMessage}";

            await Task.Run(() =>
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = whatsappUrl,
                    UseShellExecute = true
                });
            });
        }
    }
}
