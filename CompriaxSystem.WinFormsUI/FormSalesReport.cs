using Microsoft.Extensions.DependencyInjection;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormSalesReport : Form
    {
        private readonly IReportService _reportService;
        private readonly IExcelService _excelService;
        private readonly IServiceProvider _serviceProvider;
        private List<SalesReportDto> _fullHistory = new();

        public FormSalesReport(
            IReportService reportService,
            IExcelService excelService,
            IServiceProvider serviceProvider)
        {
            _reportService = reportService;
            _excelService = excelService;
            _serviceProvider = serviceProvider;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(pnlFilters);

            this.Load += async (s, e) => await InitializeFormAsync();
            this.btnSearchDates.Click += async (s, e) => await ExecuteSearchAction();
            this.btnExportExcel.Click += (s, e) => ExecuteExportExcelAction();
            this.dgvData.CellDoubleClick += (s, e) => ExecuteOpenDetailAction();
            this.txtSearchValue.TextChanged += (s, e) => ExecuteFilterAction();
        }

        public async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                cboSearchBy.DataSource = UIHelper.GetSearchableCriteria(
                    nameof(SalesReportDto.DocumentNumber),
                    nameof(SalesReportDto.CashRegisterName),
                    nameof(SalesReportDto.CustomerName),
                    nameof(SalesReportDto.CashierName)
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
                var data = await _reportService.GetSalesHistoryAsync(dtpStart.Value, dtpEnd.Value);
                _fullHistory = data.ToList();
                ExecuteFilterAction();
            }
        }

        private void ExecuteFilterAction()
        {
            string filterText = txtSearchValue.Text.Trim().ToLower();
            string criteria = cboSearchBy.SelectedValue?.ToString() ?? nameof(SalesReportDto.DocumentNumber);

            var filtered = _fullHistory.Where(x =>
            {
                var value = x.GetType().GetProperty(criteria)?.GetValue(x, null)?.ToString()?.ToLower() ?? "";
                return value.Contains(filterText);
            }).ToList();

            dgvData.DataSource = filtered;

            DataGridViewHelper.ApplyStyle(dgvData);
        }

        private async void ExecuteExportExcelAction()
        {
            if (dgvData.Rows.Count == 0 || !_fullHistory.Any())
            {
                UIHelper.WarnMessage(this, "No hay registros de ventas para exportar.", "Sin Datos");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] fileBytes = _excelService.ExportToExcel((List<SalesReportDto>)dgvData.DataSource, "Ventas");
                string fileName = $"Ventas_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                await FileExportHelper.SaveAndOpenExcelAsync(this, fileBytes, fileName, "Exportar Reporte de Ventas");
            }
        }

        private void ExecuteOpenDetailAction()
        {
            if (dgvData.CurrentRow == null)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una venta de la lista para ver su detalle auditado.", "Selección Requerida");
                return;
            }

            var item = (SalesReportDto)dgvData.CurrentRow.DataBoundItem;
            var detailWindow = _serviceProvider.GetRequiredService<FormSaleDetail>();
            detailWindow.Show();
            detailWindow.LoadByNumber(item.DocumentNumber);
        }
    }
}