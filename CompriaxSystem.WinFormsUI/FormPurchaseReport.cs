using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;
using System.Data;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormPurchaseReport : Form
    {
        private readonly IReportService _reportService;
        private readonly ISupplyChainService _supplyService;
        private readonly IExcelService _excelService;
        private readonly IServiceProvider _serviceProvider;
        private List<PurchaseReportDto> _fullHistory = new();

        public FormPurchaseReport(IReportService reportService, ISupplyChainService supplyService, IExcelService excelService, IServiceProvider serviceProvider)
        {
            _reportService = reportService;
            _supplyService = supplyService;
            _excelService = excelService;
            _serviceProvider = serviceProvider;
            InitializeComponent();

            this.Load += (s, e) => InitializeFormAsync();
            this.btnSearch.Click += async (s, e) => await ExecuteSearchAction();
            this.btnExport.Click += (s, e) => ExecuteExportExcelAction();
            this.dgvData.CellDoubleClick += (s, e) => ExecuteOpenDetailAction();
        }

        public async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var suppliers = (await _supplyService.GetSuppliersAsync()).ToList();

                suppliers.Insert(0, new SupplierDto { Id = 0, CompanyName = "[ TODOS ]" });
                cboSupplierFilter.DataSource = suppliers;
                cboSupplierFilter.DisplayMember = nameof(SupplierDto.CompanyName);
                cboSupplierFilter.ValueMember = nameof(SupplierDto.Id);

                cboSearchBy.DataSource = UIHelper.GetSearchableCriteria(
                    nameof(PurchaseReportDto.DocumentNumber),
                    nameof(PurchaseReportDto.SupplierName),
                    nameof(PurchaseReportDto.SupplierTaxId)
                );
                cboSearchBy.DisplayMember = "Name";
                cboSearchBy.ValueMember = "Id";

                UIHelper.FormatGrid(dgvData);
                await ExecuteSearchAction();
            }
        }

        public async Task ExecuteSearchAction()
        {
            using (new WaitCursorHelper(this))
            {
                int? supId = (int)cboSupplierFilter.SelectedValue == 0 ? null : (int)cboSupplierFilter.SelectedValue;
                var data = await _reportService.GetPurchaseHistoryAsync(dtpStart.Value, dtpEnd.Value, supId);
                _fullHistory = data.ToList();
                ExecuteFilterAction();
            }
        }

        private async Task ExecuteExportExcelAction()
        {
            if (dgvData.Rows.Count == 0 || !_fullHistory.Any())
            {
                UIHelper.WarnMessage(this, "No hay registros de compras en el período seleccionado para exportar a Excel.", "Sin Datos");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] fileBytes = _excelService.ExportToExcel((List<PurchaseReportDto>)dgvData.DataSource, "Compras");
                string fileName = $"Compras_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";

                await FileExportHelper.SaveAndOpenExcelAsync(this, fileBytes, fileName, "Exportar Reporte de Compras");
            }
        }

        private void ExecuteOpenDetailAction()
        {
            if (dgvData.CurrentRow == null)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una compra de la lista para consultar su detalle.", "Selección Requerida");
                return;
            }

            var reportRow = (PurchaseReportDto)dgvData.CurrentRow.DataBoundItem;
            UIHelper.InfoMessage(this, $"Compra Nro: {reportRow.DocumentNumber}\nProveedor: {reportRow.SupplierName}\nTotal: {reportRow.TotalAmount:C2}", "Comprobante de Compra");
        }

        private void ExecuteFilterAction()
        {
            string filterText = txtSearchText.Text.Trim().ToLower();
            string criteria = cboSearchBy.SelectedValue?.ToString() ?? nameof(PurchaseReportDto.DocumentNumber);

            var filtered = _fullHistory.Where(x =>
            {
                var value = x.GetType().GetProperty(criteria)?.GetValue(x, null)?.ToString()?.ToLower() ?? "";
                return value.Contains(filterText);
            }).ToList();

            dgvData.DataSource = filtered;
            UIHelper.FormatGrid(dgvData);
        }

        private void cboSupplierFilter_SelectedIndexChanged(object sender, EventArgs e) { }
        private void FormPurchaseReport_Load(object sender, EventArgs e) { }
        private void btnSearch_Click(object sender, EventArgs e) { }
        private void btnExport_Click(object sender, EventArgs e) { }
    }
}
