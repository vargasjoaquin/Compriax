using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.Configuration;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CompriaxSystem.Infrastructure.Services
{
    public class BackupService(ApplicationDbContext context, IOptions<DatabaseBackupSettings> options) : IBackupService
    {
        private readonly DatabaseBackupSettings _settings = options.Value;

        /// <summary>
        /// Ejecuta el proceso de respaldo automático de la base de datos SQL Server mediante el comando BACKUP DATABASE.
        /// </summary>
        /// <returns>Resultado de la operación indicando si fue exitosa y la ubicación del archivo.</returns>
        public async Task<OperationResult> ExecuteAutomaticBackupAsync()
        {
            if (!_settings.Enabled)
                return OperationResult.Ok("El servicio de copias automáticas está desactivado en appsettings.json.");

            if (string.IsNullOrWhiteSpace(_settings.BackupPath))
                return OperationResult.Failure("No se ha definido la propiedad 'BackupPath' en la sección 'DatabaseBackup' de appsettings.json.");

            try
            {
                string backupDirectoryPath = _settings.BackupPath;

                if (!Directory.Exists(backupDirectoryPath))
                {
                    Directory.CreateDirectory(backupDirectoryPath);
                }

                string databaseConnectionString = context.Database.GetConnectionString()
                    ?? throw new InvalidOperationException("Cadena de conexión no disponible.");

                var connectionStringBuilder = new SqlConnectionStringBuilder(databaseConnectionString);
                string databaseName = connectionStringBuilder.InitialCatalog;

                string backupTimestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string backupFileName = $"{databaseName}_AutoBackup_{backupTimestamp}.bak";
                string backupFilePath = Path.Combine(backupDirectoryPath, backupFileName);

                string backupSqlCommand = $@"
                    BACKUP DATABASE [{databaseName}] 
                    TO DISK = @backupPath 
                    WITH FORMAT, INIT, COMPRESSION, CHECKSUM, 
                    NAME = 'Compriax-AutoBackup';";

                await using (var databaseConnection = new SqlConnection(databaseConnectionString))
                {
                    await databaseConnection.OpenAsync();
                    
                    await using (var cmd = new SqlCommand(backupSqlCommand, databaseConnection))
                    {
                        cmd.CommandTimeout = 180;
                        cmd.Parameters.AddWithValue("@backupPath", backupFilePath);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                if (_settings.RetentionDays > 0)
                {
                    CleanOldBackups(backupDirectoryPath, databaseName, _settings.RetentionDays);
                }

                return OperationResult.Ok($"Backup generado exitosamente en: {backupFilePath}");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Error al generar el backup en '{_settings.BackupPath}': {ex.Message}");
            }
        }

        /// <summary>
        /// Elimina los archivos de respaldo antiguos que excedan el límite de días de retención configurado.
        /// </summary>
        /// <param name="backupDirectoryPath">Ruta de la carpeta de backups.</param>
        /// <param name="databaseName">Nombre de la base de datos.</param>
        /// <param name="retentionDays">Cantidad de días a conservar.</param>
        private static void CleanOldBackups(string backupDirectoryPath, string databaseName, int retentionDays)
        {
            try
            {
                var backupDirectory = new DirectoryInfo(backupDirectoryPath);
                DateTime backupThresholdDate = DateTime.Now.AddDays(-retentionDays);

                var expiredBackupFiles = backupDirectory.GetFiles($"{databaseName}_AutoBackup_*.bak")
                    .Where(f => f.CreationTime < backupThresholdDate);

                foreach (var backupFile in expiredBackupFiles)
                {
                    backupFile.Delete();
                }
            }
            catch
            {
                // Silencioso para no interrumpir el cierre
            }
        }
    }
}
