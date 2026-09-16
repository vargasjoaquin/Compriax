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
            UIThemeHelper.ApplyCardStyle(panelFiltersCard);

            this.Load += async (s, e) => await InitializeSalesReportFormAsync();
            this.buttonFilterDates.Click += async (s, e) => await ExecuteSearchSalesReportHistoryAsync();
            this.buttonExportExcel.Click += (s, e) => ExecuteExportSalesReportToExcelAsync();
            this.dataGridViewSalesData.CellDoubleClick += (s, e) => ExecuteOpenAuditedSaleDetail();
            this.textBoxSearchValue.TextChanged += (s, e) => ExecuteFilterSalesReportData();
        }
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializeSalesReportFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                comboBoxSearchCriteria.DataSource = UIHelper.GetSearchableCriteria(
                    nameof(SalesReportDto.DocumentNumber),
                    nameof(SalesReportDto.CashRegisterName),
                    nameof(SalesReportDto.CustomerName),
                    nameof(SalesReportDto.CashierName)
                );
                comboBoxSearchCriteria.DisplayMember = "Name";
                comboBoxSearchCriteria.ValueMember = "Id";

                await ExecuteSearchSalesReportHistoryAsync();
            }
        }

        public async Task ExecuteSearchSalesReportHistoryAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var salesHistoryDataList = await _reportService.GetSalesHistoryAsync(dateTimePickerStartDate.Value, dateTimePickerEndDate.Value);
                _fullHistory = salesHistoryDataList.ToList();
                ExecuteFilterSalesReportData();
            }
        }

        private void ExecuteFilterSalesReportData()
        {
            string FilterText = textBoxSearchValue.Text.Trim().ToLower();
            string selectedSearchCriteriaProperty = comboBoxSearchCriteria.SelectedValue?.ToString() ?? nameof(SalesReportDto.DocumentNumber);

            var filteredSalesReportList = _fullHistory.Where(x =>
            {
                var value = x.GetType().GetProperty(selectedSearchCriteriaProperty)?.GetValue(x, null)?.ToString()?.ToLower() ?? "";
                return value.Contains(FilterText);
            }).ToList();

            dataGridViewSalesData.DataSource = filteredSalesReportList;
            DataGridViewHelper.ApplyStyle(dataGridViewSalesData);
        }

        private async void ExecuteExportSalesReportToExcelAsync()
        {
            if (dataGridViewSalesData.Rows.Count == 0 || !_fullHistory.Any())
            {
                UIHelper.WarnMessage(this, "No hay registros de ventas para exportar.", "Sin Datos");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] generatedExcelFileBytes = _excelService.ExportToExcel((List<SalesReportDto>)dataGridViewSalesData.DataSource, "Ventas");
                string exportExcelFileName = $"Ventas_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                await FileExportHelper.SaveAndOpenExcelAsync(this, generatedExcelFileBytes, exportExcelFileName, "Exportar Reporte de Ventas");
            }
        }

        private void ExecuteOpenAuditedSaleDetail()
        {
            if (dataGridViewSalesData.CurrentRow == null)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una venta de la lista para ver su detalle auditado.", "Selección Requerida");
                return;
            }

            var selectedSalesReport = (SalesReportDto)dataGridViewSalesData.CurrentRow.DataBoundItem;
            var saleDetailForm = _serviceProvider.GetRequiredService<FormSaleDetail>();
            saleDetailForm.Show();
            saleDetailForm.LoadSaleDetailsByDocumentNumber(selectedSalesReport.DocumentNumber);
        }
    }
}