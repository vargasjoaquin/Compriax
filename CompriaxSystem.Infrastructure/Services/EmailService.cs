using CompriaxSystem.Application.Configuration;
using CompriaxSystem.Application.Interfaces.Services;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace CompriaxSystem.Infrastructure.Services
{
    public class EmailService(IOptions<EmailSettings> options) : IEmailService
    {
        private readonly EmailSettings _emailSettings = options.Value;

        /// <summary>
        /// Envía un correo electrónico asíncronamente. Si el servicio está deshabilitado en configuración, simula el envío en la consola de depuración.
        /// </summary>
        /// <param name="to">Dirección de correo del destinatario.</param>
        /// <param name="subject">Asunto del mensaje.</param>
        /// <param name="body">Contenido del correo.</param>
        /// <returns>Una tarea que representa la operación de envío.</returns>
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            if (!_emailSettings.Enabled || string.IsNullOrWhiteSpace(_emailSettings.SmtpHost) || _emailSettings.SmtpPort <= 0 || string.IsNullOrWhiteSpace(_emailSettings.SmtpUsername))
            {
                Debug.WriteLine($"[SIMULACIÓN EMAIL] Para: {to} | Asunto: {subject}\n{body}");
                return;
            }

            using var message = new MailMessage
            {
                From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            message.To.Add(to);

            using var client = new SmtpClient(_emailSettings.SmtpHost, _emailSettings.SmtpPort)
            {
                Credentials = new NetworkCredential(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword),
                EnableSsl = _emailSettings.EnableSsl,
                Timeout = 15000
            };

            await client.SendMailAsync(message);
        }
    }
}
