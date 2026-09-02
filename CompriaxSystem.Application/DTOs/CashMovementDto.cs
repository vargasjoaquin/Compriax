using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Application.DTOs
{
    public class CashMovementDto
    {
        public int Id { get; set; }
        public int CashShiftId { get; set; }
        public CashMovementType MovementType { get; set; }
        public string MovementTypeName => MovementType == CashMovementType.CashIn ? "➕ Ingreso Manual" : "➖ Retiro / Egreso";
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; } = null!;
    }
}