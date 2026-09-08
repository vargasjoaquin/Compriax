using CompriaxSystem.Application.Interfaces.Services;
using System.Diagnostics;
using System.Drawing.Printing;

namespace CompriaxSystem.Infrastructure.Services
{
    public class TicketPrinter : ITicketPrinter
    {
        /// <summary>
        /// Obtiene el listado de todas las impresoras instaladas y configuradas en el sistema operativo.
        /// </summary>
        /// <returns>Colección de nombres de impresoras.</returns>
        public IEnumerable<string> GetInstalledPrinters()
        {
            var printers = new List<string>();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                printers.Add(printer);
            }
            return printers;
        }

        /// <summary>
        /// Envía un archivo PDF a la cola de impresión de una impresora determinada.
        /// </summary>
        /// <param name="pdfBytes">Contenido del ticket en formato PDF.</param>
        /// <param name="printerName">Nombre de la impresora de destino (opcional).</param>
        /// <param name="copies">Número de copias a imprimir.</param>
        /// <returns>Verdadero si el trabajo se envió correctamente a la impresora.</returns>
        public async Task<bool> PrintTicketAsync(byte[] pdfBytes, string? printerName = null, int copies = 1)
        {
            if (pdfBytes == null || pdfBytes.Length == 0)
                return false;

            return await Task.Run(() =>
            {
                try
                {
                    string tempFile = Path.Combine(Path.GetTempPath(), $"ticket_print_{Guid.NewGuid()}.pdf");
                    File.WriteAllBytes(tempFile, pdfBytes);

                    var psi = new ProcessStartInfo
                    {
                        FileName = tempFile,
                        UseShellExecute = true
                    };

                    if (!string.IsNullOrWhiteSpace(printerName))
                    {
                        psi.Verb = "printto";
                        psi.Arguments = $"\"{printerName}\"";
                    }
                    else
                    {
                        psi.Verb = "print";
                    }

                    psi.CreateNoWindow = true;
                    psi.WindowStyle = ProcessWindowStyle.Hidden;

                    using var process = Process.Start(psi);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}
