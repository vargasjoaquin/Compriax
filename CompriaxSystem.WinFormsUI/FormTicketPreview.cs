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
            
            ButtonIconOverlayHelper.BindEvents(this.buttonPrintTicket, this.picIconPrintTicket);
            ButtonIconOverlayHelper.BindEvents(this.buttonSendWhatsapp, this.picIconSendWhatsapp);
            ButtonIconOverlayHelper.BindEvents(this.buttonSavePdf, this.picIconSavePdf);
            

            this.radioButtonWidth80mm.CheckedChanged += async (s, e) => { if (radioButtonWidth80mm.Checked) await RenderThermalTicketPreviewPdfAsync(); };
            this.radioButtonWidth58mm.CheckedChanged += async (s, e) => { if (radioButtonWidth58mm.Checked) await RenderThermalTicketPreviewPdfAsync(); };
            this.buttonSavePdf.Click += async (s, e) => await ExecuteSaveThermalTicketPdfAsync();
            this.buttonPrintTicket.Click += async (s, e) => await ExecuteSendTicketToThermalPrinterAsync();
            this.buttonSendWhatsapp.Click += async (s, e) => await ExecuteSendDigitalTicketViaWhatsappAsync();
        }

        public async Task LoadSaleTicketAndRenderPreviewAsync(
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

            this.labelTicketTitle.Text = $"TICKET GENERADO";
            buttonSendWhatsapp.Enabled = !string.IsNullOrWhiteSpace(_customerPhone) && _whatsappService != null && _storageService != null;

            await RenderThermalTicketPreviewPdfAsync();
        }

        private async Task RenderThermalTicketPreviewPdfAsync()
        {
            if (_sale == null)
                return;

            var selectedThermalPaperSize = radioButtonWidth58mm.Checked ? ThermalPaperSize.Width58mm : ThermalPaperSize.Width80mm;

            using (new WaitCursorHelper(this))
            {
                try
                {
                    _currentTicketBytes = await _documentService.GenerateThermalTicketReceiptAsync(
                        _sale, _docNumber, _cashierName, selectedThermalPaperSize);

                    _lastGeneratedTempPdf = Path.Combine(Path.GetTempPath(), $"ticket_preview_{Guid.NewGuid()}.pdf");
                    await File.WriteAllBytesAsync(_lastGeneratedTempPdf, _currentTicketBytes);

                    webBrowserPdfViewer.Navigate(_lastGeneratedTempPdf);
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"Error al renderizar ticket:\n{ex.Message}", "Fallo de Generación");
                }
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SaveThermalTicketPdf.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSaveThermalTicketPdfAsync()
        {
            if (_currentTicketBytes == null)
            {
                UIHelper.WarnMessage(this, "No hay ningún ticket generado para guardar en PDF.", "Ticket No Disponible");
                return;
            }

            string suggestedTicketPdfFileName = $"Ticket_{_docNumber.Replace('/', '-')}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
            await FileExportHelper.SaveAndOpenPdfAsync(this, _currentTicketBytes, suggestedTicketPdfFileName, "Guardar Ticket Térmico en PDF");
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SendTicketToThermalPrinter.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSendTicketToThermalPrinterAsync()
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
                    bool printerJobSuccess = await _ticketPrinter.PrintTicketAsync(_currentTicketBytes);
                    if (printerJobSuccess)
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
                        string temporaryPdfFilePath = Path.Combine(Path.GetTempPath(), $"ticket_print_{_docNumber.Replace('/', '-')}.pdf");
                        File.WriteAllBytes(temporaryPdfFilePath, _currentTicketBytes);
                        Process.Start(new ProcessStartInfo(temporaryPdfFilePath) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        UIHelper.ErrorMessage(this, $"Error al enviar el ticket a la impresora:\n{ex.Message}", "Fallo de Impresión");
                    }
                }
            }
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SendDigitalTicketViaWhatsapp.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSendDigitalTicketViaWhatsappAsync()
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

            buttonSendWhatsapp.Enabled = false;
            buttonSendWhatsapp.Text = "ENVIANDO...";

            using (new WaitCursorHelper(this))
            {
                try
                {
                    byte[] saleInvoicePdfBytes = await _documentService.GenerateSaleReceiptAsync(_sale, _docNumber, _cashierName);
                    string cloudPdfFileName = $"Factura_{_docNumber.Replace("/", "-")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    string uploadedPdfCloudUrl = await _storageService.UploadFileAsync(saleInvoicePdfBytes, cloudPdfFileName);

                    await _whatsappService.SendInvoiceLinkAsync(
                        _customerPhone,
                        _customerName,
                        uploadedPdfCloudUrl);

                    UIHelper.InfoMessage(this, "¡El comprobante digital ha sido enviado por WhatsApp exitosamente!", "WhatsApp Enviado");
                }
                catch (Exception ex)
                {
                    UIHelper.WarnMessage(this, $"Ocurrió un problema al enviar por WhatsApp:\n{ex.Message}", "Fallo WhatsApp");
                }
                finally
                {
                    buttonSendWhatsapp.Enabled = true;
                    buttonSendWhatsapp.Text = "WHATSAPP";
                }
            }
        }
    }
}










