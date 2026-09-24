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
            var installedPrinterNames = new List<string>();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                installedPrinterNames.Add(printer);
            }
            return installedPrinterNames;
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
                    string temporaryPdfFilePath = Path.Combine(Path.GetTempPath(), $"ticket_print_{Guid.NewGuid()}.pdf");
                    File.WriteAllBytes(temporaryPdfFilePath, pdfBytes);

                    var printProcessStartInfo = new ProcessStartInfo
                    {
                        FileName = temporaryPdfFilePath,
                        UseShellExecute = true
                    };

                    if (!string.IsNullOrWhiteSpace(printerName))
                    {
                        printProcessStartInfo.Verb = "printto";
                        printProcessStartInfo.Arguments = $"\"{printerName}\"";
                    }
                    else
                    {
                        printProcessStartInfo.Verb = "print";
                    }

                    printProcessStartInfo.CreateNoWindow = true;
                    printProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    using var printProcess = Process.Start(printProcessStartInfo);

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
