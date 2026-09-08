using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ICurrentUserService
    {
        /// <summary>
        /// Almacena los datos del usuario que inició sesión.
        /// </summary>
        UserSessionDto? CurrentUser { get; set; }

        /// <summary>
        /// Define el contexto de operación actual, como la caja asignada.
        /// </summary>
        OperationalContextDto? OperationalContext { get; set; }

        /// <summary>
        /// Indica si hay un usuario autenticado en la sesión actual.
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Indica si el usuario actual tiene una caja registradora asignada para operar.
        /// </summary>
        bool HasRegisterAssigned { get; }

        /// <summary>
        /// Asigna una caja registradora al contexto operativo actual.
        /// </summary>
        /// <param name="registerId">ID de la caja.</param>
        /// <param name="number">Número de la caja.</param>
        /// <param name="name">Nombre identificador de la caja.</param>
        void SetCashRegister(int registerId, int number, string name);
    }
}
