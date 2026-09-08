using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.Configuration;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CompriaxSystem.Infrastructure.Services
{
    public class BackupService(
        ApplicationDbContext context,
        IOptions<DatabaseBackupSettings> options) : IBackupService
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
                string targetFolder = _settings.BackupPath;

                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }

                string connectionString = context.Database.GetConnectionString()
                    ?? throw new InvalidOperationException("Cadena de conexión no disponible.");

                var builder = new SqlConnectionStringBuilder(connectionString);
                string databaseName = builder.InitialCatalog;

                string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileName = $"{databaseName}_AutoBackup_{timeStamp}.bak";
                string fullPath = Path.Combine(targetFolder, fileName);

                string sql = $@"
                    BACKUP DATABASE [{databaseName}] 
                    TO DISK = @backupPath 
                    WITH FORMAT, INIT, COMPRESSION, CHECKSUM, 
                    NAME = 'Compriax-AutoBackup';";

                await using (var conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    
                    await using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandTimeout = 180;
                        cmd.Parameters.AddWithValue("@backupPath", fullPath);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                if (_settings.RetentionDays > 0)
                {
                    CleanOldBackups(targetFolder, databaseName, _settings.RetentionDays);
                }

                return OperationResult.Ok($"Backup generado exitosamente en: {fullPath}");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Error al generar el backup en '{_settings.BackupPath}': {ex.Message}");
            }
        }

        /// <summary>
        /// Elimina los archivos de respaldo antiguos que excedan el límite de días de retención configurado.
        /// </summary>
        /// <param name="folder">Ruta de la carpeta de backups.</param>
        /// <param name="dbName">Nombre de la base de datos.</param>
        /// <param name="retentionDays">Cantidad de días a conservar.</param>
        private static void CleanOldBackups(string folder, string dbName, int retentionDays)
        {
            try
            {
                var directory = new DirectoryInfo(folder);
                DateTime thresholdDate = DateTime.Now.AddDays(-retentionDays);

                var oldFiles = directory.GetFiles($"{dbName}_AutoBackup_*.bak")
                    .Where(f => f.CreationTime < thresholdDate);

                foreach (var file in oldFiles)
                {
                    file.Delete();
                }
            }
            catch
            {
                // Silencioso para no interrumpir el cierre
            }
        }
    }
}
