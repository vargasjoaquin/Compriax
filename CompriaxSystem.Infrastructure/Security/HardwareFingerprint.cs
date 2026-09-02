using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace CompriaxSystem.Infrastructure.Security
{
    public static class HardwareFingerprint
    {
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