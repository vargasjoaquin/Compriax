namespace CompriaxSystem.Application.DTOs
{
    public class CashRegisterDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public bool HasOpenShift { get; set; }
        public string? CurrentCashierName { get; set; }
        public int? CurrentShiftId { get; set; }
        public string StatusSummary => HasOpenShift
            ? $"🟢 Turno #{CurrentShiftId} ({CurrentCashierName})"
            : (IsActive ? "⚪ Disponible" : "🔴 Inactiva");
    }
}