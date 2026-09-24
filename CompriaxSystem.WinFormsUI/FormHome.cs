using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormHome : Form
    {
        private readonly IReportService _reportService;
        private readonly SemaphoreSlim _dashboardLock = new(1, 1);

        public FormHome(IReportService reportService)
        {
            _reportService = reportService;
            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);

            this.Load += async (s, e) => await RefreshDashboardMetricsAndTablesAsync();
        }

        public async Task RefreshDashboardMetricsAndTablesAsync()
        {
            if (!await _dashboardLock.WaitAsync(0))
                return;

            using (new WaitCursorHelper(this))
            {
                try
                {
                    var dashboardStats = await _reportService.GetDashboardStatsAsync();

                    labelSalesAmountToday.Text = dashboardStats.TotalSalesToday.ToString("C2");
                    labelWeeklyAmount.Text = dashboardStats.TotalSalesWeek.ToString("C2");
                    labelSalesCountToday.Text = dashboardStats.SalesCountToday.ToString("N0");
                    labelLowStockCount.Text = dashboardStats.ProductsLowStockCount.ToString("N0");

                    panelCardStockAlert.BackColor = dashboardStats.ProductsLowStockCount > 0 ? UIThemeHelper.DangerLight : UIThemeHelper.Surface;
                    labelLowStockCount.ForeColor = dashboardStats.ProductsLowStockCount > 0 ? UIThemeHelper.Danger : UIThemeHelper.TextMain;

                    dataGridViewTopProducts.DataSource = null;
                    dataGridViewTopProducts.AutoGenerateColumns = true;
                    dataGridViewTopProducts.DataSource = dashboardStats.TopSellingProducts.ToList();
                    UIHelper.FormatGrid(dataGridViewTopProducts);

                    dataGridViewCriticalStock.DataSource = null;
                    dataGridViewCriticalStock.AutoGenerateColumns = true;
                    dataGridViewCriticalStock.DataSource = dashboardStats.CriticalStockList.ToList();
                    UIHelper.FormatGrid(dataGridViewCriticalStock);
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"No se pudieron cargar las estadísticas del dashboard:\n{ex.Message}", "Dashboard");
                }
            }
        }
    }
}
