using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface ICashRegisterRepository
    {
        /// <summary>
        /// Obtiene todas las cajas.
        /// </summary>
        /// <returns>Una colección de tipo CashRegister.</returns>
        Task<IEnumerable<CashRegister>> GetAllAsync();

        /// <summary>
        /// Obtiene una caja mediante su id.
        /// </summary>
        /// <param name="id">El id de la caja.</param>
        /// <returns>La instancia de CashRegister si existe; de lo contrario, null.</returns>
        Task<CashRegister?> GetByIdAsync(int id);

        /// <summary>
        /// Busca una caja por su número de caja asignado.
        /// </summary>
        /// <param name="number">Número de la caja.</param>
        /// <returns>La instancia de CashRegister correspondiente.</returns>
        Task<CashRegister?> GetByNumberAsync(int number);

        /// <summary>
        /// Verifica si existe un turno de caja abierto para una caja específica.
        /// </summary>
        /// <param name="cashRegisterId">ID de la caja a consultar.</param>
        /// <returns>true si tiene un turno abierto; false en caso contrario.</returns>
        Task<bool> HasOpenShiftAsync(int cashRegisterId);

        /// <summary>
        /// Agrega una nueva caja al sistema.
        /// </summary>
        /// <param name="register">Entidad de la caja a registrar.</param>
        Task AddAsync(CashRegister register);

        /// <summary>
        /// Actualiza una caja existente.
        /// </summary>
        /// <param name="register">Entidad con los cambios a aplicar.</param>
        void Update(CashRegister register);

        /// <summary>
        /// Guarda todos los cambios realizados en el repositorio.
        /// </summary>
        /// <returns>true si la operación afectó a una o más filas; de lo contrario, false.</returns>
        Task<bool> SaveChangesAsync();
    }
}
