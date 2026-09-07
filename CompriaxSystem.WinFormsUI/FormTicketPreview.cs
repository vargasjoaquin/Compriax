using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Enums;
using CompriaxSystem.WinFormsUI.Helpers;
using System.Diagnostics;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormTicketPreview : Form
    {
        private readonly IDocumentService _documentService;
        private readonly IWhatsappService? _whatsappService;
        private readonly IFileStorageService? _storageService;
        private readonly ITicketPrinter? _ticketPrinter;

        private SaleDto _sale = null!;
        private string _docNumber = string.Empty;
        private string _cashierName = string.Empty;
        private string? _customerPhone = null;
        private string? _customerName = null;
        private byte[]? _currentTicketBytes = null;
        private string? _lastGeneratedTempPdf = null;

        public FormTicketPreview(
            IDocumentService documentService,
            IWhatsappService? whatsappService = null,
            IFileStorageService? storageService = null,
            ITicketPrinter? ticketPrinter = null)
        {
            _documentService = documentService;
            _whatsappService = whatsappService;
            _storageService = storageService;
            _ticketPrinter = ticketPrinter;

            InitializeComponent();
            ApplyIcons();

            this.rb80mm.CheckedChanged += async (s, e) => { if (rb80mm.Checked) await RenderTicketAsync(); };
            this.rb58mm.CheckedChanged += async (s, e) => { if (rb58mm.Checked) await RenderTicketAsync(); };
            this.btnSavePdf.Click += async (s, e) => await ExecuteSavePdfAction();
            this.btnPrint.Click += async (s, e) => await ExecutePrintAction();
            this.btnWhatsapp.Click += async (s, e) => await ExecuteSendWhatsappAction();
        }

        private void ApplyIcons()
        {
            lblTicketTitle.Image = UIIconHelper.VistaPreviaTicket;
            lblTicketTitle.ImageAlign = ContentAlignment.MiddleLeft;

            btnPrint.Image = UIIconHelper.Imprimir;
            btnPrint.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrint.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnWhatsapp.Image = UIIconHelper.EnviarMensaje;
            btnWhatsapp.ImageAlign = ContentAlignment.MiddleLeft;
            btnWhatsapp.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnSavePdf.Image = UIIconHelper.Guardar;
            btnSavePdf.ImageAlign = ContentAlignment.MiddleLeft;
            btnSavePdf.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        public async Task LoadSaleTicketAsync(
            SaleDto sale,
            string docNumber,
            string cashierName,
            string? customerPhone = null,
            string? customerName = null)
        {
            _sale = sale;
            _docNumber = docNumber;
            _cashierName = cashierName;
            _customerPhone = customerPhone;
            _customerName = customerName ?? sale.CustomerName;

            this.lblTicketTitle.Text = $" VISTA PREVIA TICKET N.°: {docNumber}";
            btnWhatsapp.Enabled = !string.IsNullOrWhiteSpace(_customerPhone) && _whatsappService != null && _storageService != null;

            await RenderTicketAsync();
        }

        private async Task RenderTicketAsync()
        {
            if (_sale == null)
                return;

            var size = rb58mm.Checked ? ThermalPaperSize.Width58mm : ThermalPaperSize.Width80mm;

            using (new WaitCursorHelper(this))
            {
                try
                {
                    _currentTicketBytes = await _documentService.GenerateThermalTicketReceiptAsync(
                        _sale, _docNumber, _cashierName, size);

                    _lastGeneratedTempPdf = Path.Combine(Path.GetTempPath(), $"ticket_preview_{Guid.NewGuid()}.pdf");
                    await File.WriteAllBytesAsync(_lastGeneratedTempPdf, _currentTicketBytes);

                    pdfViewer.Navigate(_lastGeneratedTempPdf);
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"Error al renderizar ticket:\n{ex.Message}", "Fallo de Generación");
                }
            }
        }

        private async Task ExecuteSavePdfAction()
        {
            if (_currentTicketBytes == null)
            {
                UIHelper.WarnMessage(this, "No hay ningún ticket generado para guardar en PDF.", "Ticket No Disponible");
                return;
            }

            string defaultFileName = $"Ticket_{_docNumber.Replace('/', '-')}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
            await FileExportHelper.SaveAndOpenPdfAsync(this, _currentTicketBytes, defaultFileName, "Guardar Ticket Térmico en PDF");
        }

        private async Task ExecutePrintAction()
        {
            if (_currentTicketBytes == null)
            {
                UIHelper.WarnMessage(this, "No hay ningún ticket generado para enviar a la impresora.", "Impresión No Disponible");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                if (_ticketPrinter != null)
                {
                    bool success = await _ticketPrinter.PrintTicketAsync(_currentTicketBytes);
                    if (success)
                    {
                        UIHelper.InfoMessage(this, "El ticket fue enviado a la cola de impresión térmica con éxito.", "Impresión");
                    }
                    else
                    {
                        UIHelper.WarnMessage(this, "No se pudo comunicar con la impresora térmica predeterminada de Windows.", "Aviso de Impresora");
                    }
                }
                else
                {
                    try
                    {
                        string tempPdfPath = Path.Combine(Path.GetTempPath(), $"ticket_print_{_docNumber.Replace('/', '-')}.pdf");
                        File.WriteAllBytes(tempPdfPath, _currentTicketBytes);
                        Process.Start(new ProcessStartInfo(tempPdfPath) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        UIHelper.ErrorMessage(this, $"Error al enviar el ticket a la impresora:\n{ex.Message}", "Fallo de Impresión");
                    }
                }
            }
        }

        private async Task ExecuteSendWhatsappAction()
        {
            if (_whatsappService == null || _storageService == null)
            {
                UIHelper.WarnMessage(this, "Los servicios de Cloudinary o WhatsApp no están configurados en el sistema.", "Servicios No Disponibles");
                return;
            }

            if (string.IsNullOrWhiteSpace(_customerPhone))
            {
                UIHelper.WarnMessage(this, "El cliente no tiene un número de teléfono cargado para recibir WhatsApp.", "Teléfono Inexistente");
                return;
            }

            if (_currentTicketBytes == null)
            {
                UIHelper.WarnMessage(this, "No hay ningún ticket generado para enviar.", "Ticket No Disponible");
                return;
            }

            btnWhatsapp.Enabled = false;
            btnWhatsapp.Text = "ENVIANDO...";

            using (new WaitCursorHelper(this))
            {
                try
                {
                    byte[] pdfBytes = await _documentService.GenerateSaleReceiptAsync(_sale, _docNumber, _cashierName);
                    string fileName = $"Factura_{_docNumber.Replace("/", "-")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    string downloadUrl = await _storageService.UploadFileAsync(pdfBytes, fileName);

                    await _whatsappService.SendInvoiceLinkAsync(
                        _customerPhone,
                        _customerName,
                        downloadUrl);

                    UIHelper.InfoMessage(this, "¡El comprobante digital ha sido enviado por WhatsApp exitosamente!", "WhatsApp Enviado");
                }
                catch (Exception ex)
                {
                    UIHelper.WarnMessage(this, $"Ocurrió un problema al enviar por WhatsApp:\n{ex.Message}", "Fallo WhatsApp");
                }
                finally
                {
                    btnWhatsapp.Enabled = true;
                    btnWhatsapp.Text = "WHATSAPP";
                    btnWhatsapp.Image = UIIconHelper.EnviarMensaje;
                }
            }
        }
    }
}