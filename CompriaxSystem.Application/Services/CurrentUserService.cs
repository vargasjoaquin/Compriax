using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;

namespace CompriaxSystem.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public UserSessionDto? CurrentUser { get; set; }
        public OperationalContextDto? OperationalContext { get; set; }

        public void SetCashRegister(int registerId, int number, string name)
        {
            OperationalContext = new OperationalContextDto
            {
                CashRegisterId = registerId,
                CashRegisterNumber = number,
                CashRegisterName = name
            };
        }
    }
}