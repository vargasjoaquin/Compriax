using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;

namespace CompriaxSystem.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public UserSessionDto? CurrentUser { get; set; }
        public OperationalContextDto? OperationalContext { get; set; }

        /// <summary>
        /// Establece la caja registradora en la que el usuario operará durante la sesión.
        /// </summary>
        /// <param name="registerId">ID de la caja.</param>
        /// <param name="number">Número correlativo de la caja.</param>
        /// <param name="name">Nombre descriptivo de la caja.</param>
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