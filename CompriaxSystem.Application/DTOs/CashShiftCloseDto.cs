namespace CompriaxSystem.Application.DTOs
{
    public class CashShiftCloseDto
    {
        public int ShiftId { get; set; }
        public decimal RealCash { get; set; }
        public string? ClosingNotes { get; set; }
    }
}