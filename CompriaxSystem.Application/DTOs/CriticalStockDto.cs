namespace CompriaxSystem.Application.DTOs
{
    public class CriticalStockDto
    {
        public string ProductName { get; set; } = null!;
        public int CurrentStock { get; set; }
        public int MinimumStock { get; set; }
    }
}