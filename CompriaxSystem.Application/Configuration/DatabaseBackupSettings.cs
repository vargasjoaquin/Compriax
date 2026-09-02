namespace CompriaxSystem.Application.Configuration
{
    public class DatabaseBackupSettings
    {
        public bool Enabled { get; set; }
        public string BackupPath { get; set; } = string.Empty;
        public int RetentionDays { get; set; }
    }
}
