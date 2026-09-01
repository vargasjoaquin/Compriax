using CompriaxSystem.Domain.Common;

namespace CompriaxSystem.Domain.Entities
{
    public class PaymentMethod : LookupEntity
    {
        public bool IsActive { get; set; } = true;
    }
}
