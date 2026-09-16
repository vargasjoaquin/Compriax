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
            UIThemeHelper.ApplyCardStyle(panelFiltersCard);

            this.Load += async (s, e) => await InitializePurchaseReportFormAsync();
            this.buttonSearch.Click += async (s, e) => await ExecuteSearchPurchaseHistoryAsync();
            this.buttonExportExcel.Click += (s, e) => ExecuteExportPurchasesReportToExcelAsync();
        }
        /// <summary>
        /// Inicializa asincronamente los origenes de datos, catalogos y controles visuales del formulario.
        /// </summary>
        /// <returns>Una tarea asincrona que representa la inicializacion completa.</returns>

        public async Task InitializePurchaseReportFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var suppliersFilterList = (await _supplyService.GetSuppliersAsync()).ToList();
                suppliersFilterList.Insert(0, new SupplierDto { Id = 0, CompanyName = "[ TODOS ]" });

                comboBoxSupplierFilter.DataSource = suppliersFilterList;
                comboBoxSupplierFilter.DisplayMember = nameof(SupplierDto.CompanyName);
                comboBoxSupplierFilter.ValueMember = nameof(SupplierDto.Id);

                comboBoxSearchCriteria.DataSource = UIHelper.GetSearchableCriteria(
                    nameof(PurchaseReportDto.DocumentNumber),
                    nameof(PurchaseReportDto.SupplierName),
                    nameof(PurchaseReportDto.SupplierTaxId)
                );
                comboBoxSearchCriteria.DisplayMember = "Name";
                comboBoxSearchCriteria.ValueMember = "Id";

                await ExecuteSearchPurchaseHistoryAsync();
            }
        }

        public async Task ExecuteSearchPurchaseHistoryAsync()
        {
            using (new WaitCursorHelper(this))
            {
                int? supplierId = (comboBoxSupplierFilter.SelectedValue is int id && id > 0) ? id : null;
                var purchaseHistoryDataList = await _reportService.GetPurchaseHistoryAsync(dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, supplierId);
                _fullHistory = purchaseHistoryDataList.ToList();
                ExecuteFilterPurchaseReportData();
            }
        }

        private void ExecuteFilterPurchaseReportData()
        {
            string FilterText = textBoxSearchValue.Text.Trim().ToLower();
            string criteria = comboBoxSearchCriteria.SelectedValue?.ToString() ?? nameof(PurchaseReportDto.DocumentNumber);

            var filteredPurchaseReportsList = _fullHistory.Where(x =>
            {
                var prop = x.GetType().GetProperty(criteria);
                var value = prop?.GetValue(x, null)?.ToString()?.ToLower() ?? "";
                return value.Contains(FilterText);
            }).ToList();

            dataGridViewPurchaseData.DataSource = filteredPurchaseReportsList;
            DataGridViewHelper.ApplyStyle(dataGridViewPurchaseData);
        }

        private async void ExecuteExportPurchasesReportToExcelAsync()
        {
            if (dataGridViewPurchaseData.Rows.Count == 0 || !_fullHistory.Any())
            {
                UIHelper.WarnMessage(this, "No hay registros de compras en el período seleccionado para exportar a Excel.", "Sin Datos");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] generatedExcelFileBytes = _excelService.ExportToExcel((List<PurchaseReportDto>)dataGridViewPurchaseData.DataSource, "Compras");
                string fileName = $"Compras_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                await FileExportHelper.SaveAndOpenExcelAsync(this, generatedExcelFileBytes, fileName, "Exportar Reporte de Compras");
            }
        }
    }
}