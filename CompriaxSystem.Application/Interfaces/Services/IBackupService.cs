using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IBackupService
    {
        /// <summary>
        /// Ejecuta el proceso de respaldo automático de la base de datos y archivos del sistema.
        /// </summary>
        /// <returns>Resultado indicando si el respaldo fue exitoso.</returns>
        Task<OperationResult> ExecuteAutomaticBackupAsync();
    }
}
