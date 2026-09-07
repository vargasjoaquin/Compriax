using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormPurchaseReport : Form
    {
        private readonly IReportService _reportService;
        private readonly ISupplyChainService _supplyService;
        private readonly IExcelService _excelService;
        private List<PurchaseReportDto> _fullHistory = new();

        public FormPurchaseReport(IReportService reportService, ISupplyChainService supplyService, IExcelService excelService)
        {
            _reportService = reportService;
            _supplyService = supplyService;
            _excelService = excelService;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(pnlFilters);

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnSearch.Click += async (s, e) => await ExecuteSearchAction();
            this.btnExport.Click += (s, e) => ExecuteExportExcelAction();
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

                await ExecuteSearchAction();
            }
        }

        public async Task ExecuteSearchAction()
        {
            using (new WaitCursorHelper(this))
            {
                int? supId = (cboSupplierFilter.SelectedValue is int id && id > 0) ? id : null;
                var data = await _reportService.GetPurchaseHistoryAsync(dtpStart.Value, dtpEnd.Value, supId);
                _fullHistory = data.ToList();
                ExecuteFilterAction();
            }
        }

        private void ExecuteFilterAction()
        {
            string filterText = txtSearchText.Text.Trim().ToLower();
            string criteria = cboSearchBy.SelectedValue?.ToString() ?? nameof(PurchaseReportDto.DocumentNumber);

            var filtered = _fullHistory.Where(x =>
            {
                var prop = x.GetType().GetProperty(criteria);
                var value = prop?.GetValue(x, null)?.ToString()?.ToLower() ?? "";
                return value.Contains(filterText);
            }).ToList();

            dgvData.DataSource = filtered;
            DataGridViewHelper.ApplyStyle(dgvData);
        }

        private async void ExecuteExportExcelAction()
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
    }
}