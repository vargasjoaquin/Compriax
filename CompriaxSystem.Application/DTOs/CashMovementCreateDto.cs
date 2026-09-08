using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Application.DTOs
{
    public class CashMovementCreateDto
    {
        public CashMovementType MovementType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;
    }
}