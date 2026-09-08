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
            var sb = new StringBuilder();
            sb.Append(GetWmiProperty("Win32_Processor", "ProcessorId"));
            sb.Append(GetWmiProperty("Win32_BaseBoard", "SerialNumber"));
            sb.Append(GetWmiProperty("Win32_DiskDrive", "SerialNumber"));

            string raw = sb.ToString();
            if (string.IsNullOrWhiteSpace(raw))
            {
                raw = Environment.MachineName + Environment.UserName + Environment.OSVersion;
            }

            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(raw));
            return Convert.ToHexString(hash);
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
                
                foreach (var item in searcher.Get())
                {
                    var value = item[propertyName]?.ToString();
                    
                    if (!string.IsNullOrWhiteSpace(value))
                        return value.Trim();
                }
            }
            catch 
            {
            }
            return string.Empty;
        }
    }
}