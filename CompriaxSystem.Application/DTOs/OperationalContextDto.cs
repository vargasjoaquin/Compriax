namespace CompriaxSystem.Application.DTOs
{
    public class OperationalContextDto
    {
        public int CashRegisterId { get; set; }
        public string CashRegisterName { get; set; } = null!;
        public int CashRegisterNumber { get; set; }
        public int? ActiveShiftId { get; set; }
    }
}