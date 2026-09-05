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

            this.Load += async (s, e) => await RefreshDashboardAsync();
        }

        public async Task RefreshDashboardAsync()
        {
            if (!await _dashboardLock.WaitAsync(0))
                return;

            using (new WaitCursorHelper(this))
            {
                try
                {
                    var stats = await _reportService.GetDashboardStatsAsync();

                    lblSalesAmount.Text = stats.TotalSalesToday.ToString("C2");
                    lblWeeklyAmount.Text = stats.TotalSalesWeek.ToString("C2");
                    lblSalesCount.Text = stats.SalesCountToday.ToString("N0");
                    lblLowStockCount.Text = stats.ProductsLowStockCount.ToString("N0");

                    cardStockAlert.BackColor = stats.ProductsLowStockCount > 0 ? UIThemeHelper.DangerLight : UIThemeHelper.Surface;
                    lblLowStockCount.ForeColor = stats.ProductsLowStockCount > 0 ? UIThemeHelper.Danger : UIThemeHelper.TextMain;

                    dgvTopProducts.DataSource = null;
                    dgvTopProducts.AutoGenerateColumns = true;
                    dgvTopProducts.DataSource = stats.TopSellingProducts.ToList();
                    UIHelper.FormatGrid(dgvTopProducts);

                    dgvCriticalStock.DataSource = null;
                    dgvCriticalStock.AutoGenerateColumns = true;
                    dgvCriticalStock.DataSource = stats.CriticalStockList.ToList();
                    UIHelper.FormatGrid(dgvCriticalStock);
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"No se pudieron cargar las estadísticas del dashboard:\n{ex.Message}", "Dashboard");
                }
            }
        }
    }
}