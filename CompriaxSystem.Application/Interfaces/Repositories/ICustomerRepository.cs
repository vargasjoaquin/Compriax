using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Busca un cliente por su id.
        /// </summary>
        /// <param name="id">ID del cliente.</param>
        /// <returns>La entidad del cliente o null.</returns>
        Task<Customer?> GetByIdAsync(int id);

        /// <summary>
        /// Obtiene un cliente por su número de documento (DNI).
        /// </summary>
        /// <param name="documentNumber">Número de documento del cliente.</param>
        /// <returns>El cliente asociado al documento proporcionado.</returns>
        Task<Customer?> GetByDocumentAsync(string documentNumber);

        /// <summary>
        /// Recupera el listado de todos los clientes que se encuentran activos.
        /// </summary>
        /// <returns>Una colección de clientes activos.</returns>
        Task<IEnumerable<Customer>> GetAllActiveAsync();

        /// <summary>
        /// Agrega un nuevo cliente.
        /// </summary>
        /// <param name="customer">Entidad del cliente a registrar.</param>
        Task AddAsync(Customer customer);

        /// <summary>
        /// Actualiza la información de un cliente existente.
        /// </summary>
        /// <param name="customer">Entidad del cliente con los nuevos datos.</param>
        void Update(Customer customer);

        /// <summary>
        /// Guarda los cambios realizados en la entidad de clientes.
        /// </summary>
        /// <returns>Resultado de la operación de guardado.</returns>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// Obtiene todos los clientes que fueron dados de baja del sistema.
        /// </summary>
        /// <returns>Colección de clientes eliminados.</returns>
        Task<IEnumerable<Customer>> GetAllDeletedAsync();

        /// <summary>
        /// Recupera un cliente eliminado mediante su ID.
        /// </summary>
        /// <param name="id">ID del cliente borrado.</param>
        /// <returns>La entidad del cliente eliminado.</returns>
        Task<Customer?> GetDeletedByIdAsync(int id);
    }
}
