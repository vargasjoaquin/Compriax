namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IEmailService
    {
        /// <summary>
        /// Envía un correo electrónico.
        /// </summary>
        /// <param name="to">Dirección del destinatario.</param>
        /// <param name="subject">Asunto del mensaje.</param>
        /// <param name="body">Contenido del correo (puede ser HTML).</param>
        Task SendEmailAsync(string to, string subject, string body);
    }
}
