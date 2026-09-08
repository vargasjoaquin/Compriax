namespace CompriaxSystem.Application.DTOs
{
    public class DashboardDto
    {
        public decimal TotalSalesToday { get; set; }
        public decimal TotalSalesWeek { get; set; }
        public int SalesCountToday { get; set; }
        public int ProductsLowStockCount { get; set; }

        public List<TopProductDto> TopSellingProducts { get; set; } = new();
        public List<CategorySalesDto> SalesByCategory { get; set; } = new();
        public List<CriticalStockDto> CriticalStockList { get; set; } = new();
    }
}