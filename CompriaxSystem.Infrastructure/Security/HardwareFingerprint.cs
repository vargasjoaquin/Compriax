using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace CompriaxSystem.Infrastructure.Security
{
    public static class HardwareFingerprint
    {
        /// <summary>
        /// Genera un id único de hardware (HWID) del equipo actual combinando 
        /// los números de serie del procesador, placa base y disco duro.
        /// </summary>
        /// <returns>Una cadena hexadecimal SHA256 que identifica unívocamente a la máquina.</returns>
        public static string GetMachineHardwareId()
        {
            var hardwareIdentifierBuilder = new StringBuilder();

            hardwareIdentifierBuilder.Append(GetWmiProperty("Win32_Processor", "ProcessorId"));
            hardwareIdentifierBuilder.Append(GetWmiProperty("Win32_BaseBoard", "SerialNumber"));
            hardwareIdentifierBuilder.Append(GetWmiProperty("Win32_DiskDrive", "SerialNumber"));

            string hardwareIdentifierSource = hardwareIdentifierBuilder.ToString();
            
            if (string.IsNullOrWhiteSpace(hardwareIdentifierSource))
            {
                hardwareIdentifierSource = Environment.MachineName + Environment.UserName + Environment.OSVersion;
            }

            byte[] hardwareHash = SHA256.HashData(Encoding.UTF8.GetBytes(hardwareIdentifierSource));
            
            return Convert.ToHexString(hardwareHash);
        }

        /// <summary>
        /// Realiza una consulta WMI (Windows Management Instrumentation) para obtener el valor 
        /// de una propiedad de hardware específica.
        /// </summary>
        /// <param name="wmiClass">La clase WMI a consultar (ej. Win32_Processor).</param>
        /// <param name="propertyName">El nombre de la propiedad a recuperar (ej. ProcessorId).</param>
        /// <returns>El valor de la propiedad como cadena de texto, o una cadena vacía si ocurre un error.</returns>
        private static string GetWmiProperty(string wmiClass, string propertyName)
        {
            try
            {
                using var searcher = new ManagementObjectSearcher($"SELECT {propertyName} FROM {wmiClass}");
                
                foreach (var hardwareItem in searcher.Get())
                {
                    var propertyValue = hardwareItem[propertyName]?.ToString();
                    
                    if (!string.IsNullOrWhiteSpace(propertyValue))
                        return propertyValue.Trim();
                }
            }
            catch 
            {
            }
            return string.Empty;
        }
    }
}