using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;

namespace CompriaxSystem.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public UserSessionDto? CurrentUser { get; set; }
        public OperationalContextDto? OperationalContext { get; set; }

        /// <summary>
        /// Indica si hay un usuario con sesión activa.
        /// </summary>
        public bool IsAuthenticated => CurrentUser != null;

        /// <summary>
        /// Indica si el usuario ya ha seleccionado una caja para operar.
        /// </summary>
        public bool HasRegisterAssigned => OperationalContext != null && OperationalContext.CashRegisterId > 0;

        /// <summary>
        /// Establece la caja registradora en la que el usuario operará durante la sesión.
        /// </summary>
        /// <param name="registerId">ID de la caja.</param>
        /// <param name="cashRegisterNumber">Número correlativo de la caja.</param>
        /// <param name="cashRegisterName">Nombre descriptivo de la caja.</param>
        public void SetCashRegister(int registerId, int cashRegisterNumber, string cashRegisterName)
        {
            OperationalContext = new OperationalContextDto
            {
                CashRegisterId = registerId,
                CashRegisterNumber = cashRegisterNumber,
                CashRegisterName = cashRegisterName
            };
        }
    }
}