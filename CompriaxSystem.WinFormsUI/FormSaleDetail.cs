using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
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

            ApplyIcons();

            this.btnSearch.Click += async (s, e) => await ExecuteSearchAction();
            this.btnClear.Click += (s, e) => ResetUI();
            this.btnDownloadPdf.Click += async (s, e) => await ExecuteDownloadPdfAction();

            this.txtSearchNumber.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    await ExecuteSearchAction();
                }
            };
        }

        private void ApplyIcons()
        {
            btnSearch.Image = UIIconHelper.Buscar;
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnDownloadPdf.Image = UIIconHelper.ExportarPdf;
            btnDownloadPdf.ImageAlign = ContentAlignment.MiddleLeft;
            btnDownloadPdf.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        public async void LoadByNumber(string docNumber)
        {
            txtSearchNumber.Text = docNumber;
            await ExecuteSearchAction();
        }

        private async Task ExecuteSearchAction()
        {
            if (string.IsNullOrWhiteSpace(txtSearchNumber.Text))
            {
                UIHelper.WarnMessage(this, "Debe ingresar un número de comprobante para realizar la búsqueda.", "Búsqueda Requerida");
                txtSearchNumber.Focus();
                return;
            }

            using (new WaitCursorHelper(this))
            {
                _currentSale = await _reportService.GetSaleByDocumentNumberAsync(txtSearchNumber.Text.Trim());

                if (_currentSale != null)
                {
                    SyncEntityToFields();
                }
                else
                {
                    UIHelper.WarnMessage(this, $"No se encontró ninguna venta registrada con el comprobante N.° '{txtSearchNumber.Text.Trim()}'.", "Comprobante Inexistente");
                    ResetUI();
                }
            }
        }

        private void SyncEntityToFields()
        {
            if (_currentSale == null)
                return;

            txtDate.Text = _currentSale.Date.ToString("dd/MM/yyyy HH:mm");
            txtDocType.Text = _currentSale.DocumentTypeName;
            txtUser.Text = _currentSale.CashierName;
            txtClientDoc.Text = _currentSale.CustomerDoc;

            if (!string.IsNullOrWhiteSpace(_currentSale.CustomerName) && _currentSale.CustomerName != "Consumidor Final")
            {
                var parts = _currentSale.CustomerName.Split(' ', 2);
                txtClientName.Text = parts.Length > 0 ? parts[0] : _currentSale.CustomerName;
                txtClientLastName.Text = parts.Length > 1 ? parts[1] : "";
            }
            else
            {
                txtClientName.Text = "Consumidor";
                txtClientLastName.Text = "Final";
            }

            dgvItems.DataSource = null;
            dgvItems.AutoGenerateColumns = true;
            dgvItems.DataSource = _currentSale.Items.ToList();

            UIHelper.FormatGrid(dgvItems);

            txtTotal.Text = _currentSale.TotalAmount.ToString("C2");
            txtPaid.Text = _currentSale.PaymentReceived.ToString("C2");
            txtChange.Text = _currentSale.PaymentChange.ToString("C2");
        }

        private void ResetUI()
        {
            _currentSale = null;
            UIHelper.CleanControls(this);
            txtSearchNumber.Clear();
            dgvItems.DataSource = null;
            txtTotal.Text = "$ 0.00";
            txtPaid.Text = "$ 0.00";
            txtChange.Text = "$ 0.00";
            txtSearchNumber.Focus();
        }

        private async Task ExecuteDownloadPdfAction()
        {
            if (_currentSale == null)
            {
                UIHelper.WarnMessage(this, "Primero debe buscar y cargar un comprobante de venta en pantalla para poder descargarlo en PDF.", "Selección Requerida");
                txtSearchNumber.Focus();
                return;
            }

            using (new WaitCursorHelper(this))
            {
                try
                {
                    byte[] pdfBytes = await _documentService.GenerateSaleReceiptAsync(_currentSale, _currentSale.DocumentNumber, _currentSale.CashierName);
                    string fileName = $"FacturaVenta_{_currentSale.DocumentNumber}_{DateTime.Now:yyyyMMdd}.pdf";

                    await FileExportHelper.SaveAndOpenPdfAsync(this, pdfBytes, fileName, "Descargar Comprobante de Venta");
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"Error al generar el documento PDF:\n{ex.Message}", "Error de Exportación");
                }
            }
        }
    }
}