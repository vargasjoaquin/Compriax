using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class EmployeeRepository(ApplicationDbContext context) : IEmployeeRepository
    {
        /// <summary>
        /// Obtiene todos los empleados.
        /// </summary>
        /// <returns>Una colección de empleados ordenados por apellido.</returns>
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await context.Employees
                .Include(e => e.Position)
                .Include(e => e.Gender)
                .Include(e => e.CivilStatus)
                .AsNoTracking()
                .OrderBy(e => e.LastName)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene un empleado mediante su id.
        /// </summary>
        /// <param name="id">Id del empleado.</param>
        /// <returns>La entidad del empleado o null.</returns>
        public async Task<Employee?> GetByIdAsync(int id) =>
            await context.Employees.FirstOrDefaultAsync(e => e.Id == id);

        /// <summary>
        /// Obtiene un empleado eliminado.
        /// </summary>
        /// <param name="id">ID del empleado borrado.</param>
        /// <returns>La entidad del empleado en la papelera.</returns>
        public async Task<Employee?> GetDeletedByIdAsync(int id) =>
            await context.Employees
                .IgnoreQueryFilters()
                .Include(e => e.Position)
                .Include(e => e.Gender)
                .Include(e => e.CivilStatus)
                .FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted);

        /// <summary>
        /// Obtiene todos los empleados que han sido dados eliminados.
        /// </summary>
        /// <returns>Colección de empleados eliminados.</returns>
        public async Task<IEnumerable<Employee>> GetAllDeletedAsync() =>
            await context.Employees
                .IgnoreQueryFilters()
                .Include(e => e.Position)
                .Include(e => e.Gender)
                .Include(e => e.CivilStatus)
                .Where(e => e.IsDeleted)
                .ToListAsync();

        /// <summary>
        /// Registra un nuevo empleado.
        /// </summary>
        /// <param name="employee">Entidad del empleado.</param>
        public async Task AddAsync(Employee employee) =>
            await context.Employees.AddAsync(employee);

        /// <summary>
        /// Actualiza un empleado.
        /// </summary>
        /// <param name="employee">Entidad del empleado modificada.</param>
        public void Update(Employee employee) =>
            context.Employees.Update(employee);

        /// <summary>
        /// Guarda los cambios realizados en el repositorio de empleados.
        /// </summary>
        /// <returns>Verdadero si se persistieron los cambios.</returns>
        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() > 0;
    }
}