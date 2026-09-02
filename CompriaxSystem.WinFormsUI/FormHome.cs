using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;
using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            await LoadDashboardData();
        }

        private async Task LoadDashboardData()
        {
            using (new WaitCursor(this))
            {
                try
                {
                    var stats = await _reportService.GetDashboardStatsAsync();

                    lblSalesAmount.Text = stats.TotalSalesToday.ToString("C2");
                    lblWeeklyAmount.Text = stats.TotalSalesWeek.ToString("C2");
                    lblSalesCount.Text = stats.SalesCountToday.ToString("N0");
                    lblLowStockCount.Text = stats.ProductsLowStockCount.ToString("N0");

                    // Resaltar alerta visual si hay stock bajo
                    cardStockAlert.BackColor = stats.ProductsLowStockCount > 0 ? UITheme.DangerLight : UITheme.Surface;
                    lblLowStockCount.ForeColor = stats.ProductsLowStockCount > 0 ? UITheme.Danger : UITheme.TextMain;

                    // Carga de Grillas
                    dgvTopProducts.DataSource = stats.TopSellingProducts.ToList();
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
