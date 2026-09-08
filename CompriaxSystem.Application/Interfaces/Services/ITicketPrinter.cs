namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ITicketPrinter
    {
        /// <summary>
        /// Obtiene los nombres de las impresoras instaladas en el sistema operativo.
        /// </summary>
        /// <returns>Lista de nombres de impresoras.</returns>
        IEnumerable<string> GetInstalledPrinters();

        /// <summary>
        /// Envía un documento PDF a una impresora específica.
        /// </summary>
        /// <param name="pdfBytes">Contenido del ticket en PDF.</param>
        /// <param name="printerName">Nombre de la impresora (opcional, usa la predeterminada si es null).</param>
        /// <param name="copies">Cantidad de copias a imprimir.</param>
        /// <returns>Verdadero si el trabajo se envió correctamente.</returns>
        Task<bool> PrintTicketAsync(byte[] pdfBytes, string? printerName = null, int copies = 1);
    }
}
