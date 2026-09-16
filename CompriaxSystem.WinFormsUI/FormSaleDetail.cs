using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormSaleDetail : Form
    {
        private readonly IReportService _reportService;
        private readonly IDocumentService _documentService;
        private SaleDto? _currentSale;

        public FormSaleDetail(IReportService reportService, IDocumentService documentService)
        {
            _reportService = reportService;
            _documentService = documentService;
            InitializeComponent();

            this.buttonSearch.Click += async (s, e) => await ExecuteSearchSaleByDocumentNumberAsync();
            this.buttonClearSearch.Click += (s, e) => ResetSaleDetailFormFields();
            this.buttonDownloadPdf.Click += async (s, e) => await ExecuteDownloadAndOpenSaleReceiptPdfAsync();

            this.textBoxSearchDocumentNumber.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    await ExecuteSearchSaleByDocumentNumberAsync();
                }
            };
        }

        public async void LoadSaleDetailsByDocumentNumber(string docNumber)
        {
            textBoxSearchDocumentNumber.Text = docNumber;
            await ExecuteSearchSaleByDocumentNumberAsync();
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de SearchSaleByDocumentNumber.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteSearchSaleByDocumentNumberAsync()
        {
            if (string.IsNullOrWhiteSpace(textBoxSearchDocumentNumber.Text))
            {
                UIHelper.WarnMessage(this, "Debe ingresar un número de comprobante para realizar la búsqueda.", "Búsqueda Requerida");
                textBoxSearchDocumentNumber.Focus();
                return;
            }

            using (new WaitCursorHelper(this))
            {
                _currentSale = await _reportService.GetSaleByDocumentNumberAsync(textBoxSearchDocumentNumber.Text.Trim());

                if (_currentSale != null)
                {
                    SynchronizeSaleDetailsToFormFields();
                }
                else
                {
                    UIHelper.WarnMessage(this, $"No se encontró ninguna venta registrada con el comprobante N.° '{textBoxSearchDocumentNumber.Text.Trim()}'.", "Comprobante Inexistente");
                    ResetSaleDetailFormFields();
                }
            }
        }
        /// <summary>
        /// Sincroniza la entidad SaleDetailsToFormFields seleccionada con los campos de entrada de la interfaz.
        /// </summary>

        private void SynchronizeSaleDetailsToFormFields()
        {
            if (_currentSale == null)
                return;

            textBoxIssueDate.Text = _currentSale.Date.ToString("dd/MM/yyyy HH:mm");
            textBoxDocumentType.Text = _currentSale.DocumentTypeName;
            textBoxCashierName.Text = _currentSale.CashierName;
            textBoxCustomerDoc.Text = _currentSale.CustomerDoc;

            if (!string.IsNullOrWhiteSpace(_currentSale.CustomerName) && _currentSale.CustomerName != TaxConstants.DEFAULT_TAX_CONDITION_NAME)
            {
                var customerNameParts = _currentSale.CustomerName.Split(' ', 2);
                textBoxCustomerFirstName.Text = customerNameParts.Length > 0 ? customerNameParts[0] : _currentSale.CustomerName;
                textBoxCustomerLastName.Text = customerNameParts.Length > 1 ? customerNameParts[1] : "";
            }
            else
            {
                textBoxCustomerFirstName.Text = "Consumidor";
                textBoxCustomerLastName.Text = "Final";
            }

            dataGridViewSaleItems.DataSource = null;
            dataGridViewSaleItems.AutoGenerateColumns = true;
            dataGridViewSaleItems.DataSource = _currentSale.Items.ToList();

            UIHelper.FormatGrid(dataGridViewSaleItems);

            textBoxTotalAmount.Text = _currentSale.TotalAmount.ToString("C2");
            textBoxAmountPaid.Text = _currentSale.PaymentReceived.ToString("C2");
            textBoxChangeAmount.Text = _currentSale.PaymentChange.ToString("C2");
        }

        private void ResetSaleDetailFormFields()
        {
            _currentSale = null;
            UIHelper.CleanControls(this);
            textBoxSearchDocumentNumber.Clear();
            dataGridViewSaleItems.DataSource = null;
            textBoxTotalAmount.Text = "$ 0.00";
            textBoxAmountPaid.Text = "$ 0.00";
            textBoxChangeAmount.Text = "$ 0.00";
            textBoxSearchDocumentNumber.Focus();
        }
        /// <summary>
        /// Ejecuta de manera asincrona la accion de DownloadAndOpenSaleReceiptPdf.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la operacion.</returns>

        private async Task ExecuteDownloadAndOpenSaleReceiptPdfAsync()
        {
            if (_currentSale == null)
            {
                UIHelper.WarnMessage(this, "Primero debe buscar y cargar un comprobante de venta en pantalla para poder descargarlo en PDF.", "Selección Requerida");
                textBoxSearchDocumentNumber.Focus();
                return;
            }

            using (new WaitCursorHelper(this))
            {
                try
                {
                    byte[] saleReceiptPdfBytes = await _documentService.GenerateSaleReceiptAsync(_currentSale, _currentSale.DocumentNumber, _currentSale.CashierName);
                    string saleReceiptFileName = $"FacturaVenta_{_currentSale.DocumentNumber}_{DateTime.Now:yyyyMMdd}.pdf";

                    await FileExportHelper.SaveAndOpenPdfAsync(this, saleReceiptPdfBytes, saleReceiptFileName, "Descargar Comprobante de Venta");
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"Error al generar el documento PDF:\n{ex.Message}", "Error de Exportación");
                }
            }
        }
    }
}