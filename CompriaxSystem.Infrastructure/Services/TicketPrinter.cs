using CompriaxSystem.Application.Interfaces.Services;
using System.Diagnostics;
using System.Drawing.Printing;

namespace CompriaxSystem.Infrastructure.Services
{
    public class TicketPrinter : ITicketPrinter
    {
        public IEnumerable<string> GetInstalledPrinters()
        {
            var printers = new List<string>();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                printers.Add(printer);
            }
            return printers;
        }

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
