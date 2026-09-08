using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Obtiene la lista completa de empleados activos.
        /// </summary>
        /// <returns>Una colección de empleados.</returns>
        Task<IEnumerable<Employee>> GetAllAsync();

        /// <summary>
        /// Busca un empleado por su id.
        /// </summary>
        /// <param name="id">ID del empleado.</param>
        /// <returns>La entidad del empleado o null.</returns>
        Task<Employee?> GetByIdAsync(int id);

        /// <summary>
        /// Registra un nuevo empleado.
        /// </summary>
        /// <param name="employee">Entidad del empleado.</param>
        Task AddAsync(Employee employee);

        /// <summary>
        /// Actualiza los datos de un empleado.
        /// </summary>
        /// <param name="employee">Entidad con datos actualizados.</param>
        void Update(Employee employee);

        /// <summary>
        /// Confirma los cambios realizados sobre los empleados.
        /// </summary>
        /// <returns>Booleano indicando el éxito de la operación.</returns>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// Obtiene todos los empleados que han sido eliminados del sistema.
        /// </summary>
        /// <returns>Colección de empleados dados de baja.</returns>
        Task<IEnumerable<Employee>> GetAllDeletedAsync();

        /// <summary>
        /// Busca un empleado eliminado por su id.
        /// </summary>
        /// <param name="id">ID del empleado eliminado.</param>
        /// <returns>La entidad del empleado.</returns>
        Task<Employee?> GetDeletedByIdAsync(int id);
    }
}
