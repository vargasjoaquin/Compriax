using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormHome : Form
    {
        private readonly IReportService _reportService;

        public FormHome(IReportService reportService)
        {
            _reportService = reportService;
            InitializeComponent();
        }

        private async void FormHome_Load(object sender, EventArgs e)
        {
            await RefreshDashboardAsync();
        }

        public async Task RefreshDashboardAsync()
        {
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
                    dgvTopProducts.DataSource = stats.TopSellingProducts.ToList();

                    dgvCriticalStock.DataSource = null;
                    dgvCriticalStock.DataSource = stats.CriticalStockList.ToList();

                    UIHelper.FormatGrid(dgvTopProducts);
                    UIHelper.FormatGrid(dgvCriticalStock);
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"No se pudieron cargar las estadísticas del dashboard:\n{ex.Message}", "Error de Conexión");
                }
            }
        }
    }
}