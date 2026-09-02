using System.Management;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CompriaxSystem.SetupActivator
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Parámetros pasados desde el instalador (ej. Inno Setup):
            // CompriaxSystem.SetupActivator.exe --activate "CUIT" "KEY" "SERVER_URL" "ERROR_FILE_PATH"
            if (args.Length >= 4 && args[0] == "--activate")
            {
                string cuit = args[1];
                string key = args[2];
                string serverUrl = args[3];
                string errorFilePath = args.Length >= 5 ? args[4] : Path.Combine(Path.GetTempPath(), "activation_error.txt");

                var (success, message) = ExecuteActivationAsync(cuit, key, serverUrl).GetAwaiter().GetResult();

                if (success)
                {
                    Environment.Exit(0); // Código 0 = Éxito para el instalador
                }
                else
                {
                    try
                    {
                        File.WriteAllText(errorFilePath, message, Encoding.UTF8);
                    }
                    catch { }

                    Environment.Exit(1); // Código 1 = Bloquear instalación
                }
                return;
            }

            MessageBox.Show("Este asistente de activación solo debe ser ejecutado por el instalador del sistema.",
                "Compriax POS Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static async Task<(bool Success, string Message)> ExecuteActivationAsync(string cuit, string licenseKey, string serverUrl)
        {
            try
            {
                string hwid = GetMachineHardwareId();
                string machineName = Environment.MachineName;

                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };

                using var httpClient = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(15) };

                string requestUrl = $"{serverUrl.TrimEnd('/')}/api/licenses/activate";

                var response = await httpClient.PostAsJsonAsync(requestUrl, new
                {
                    LicenseKey = licenseKey.Trim().ToUpper(),
                    Cuit = cuit.Trim(),
                    HardwareId = hwid,
                    MachineName = machineName,
                    OsVersion = Environment.OSVersion.ToString()
                });

                if (!response.IsSuccessStatusCode)
                {
                    try
                    {
                        var errorObj = await response.Content.ReadFromJsonAsync<JsonElement>();
                        string msg = errorObj.TryGetProperty("message", out var m) ? m.GetString()! :
                                     errorObj.TryGetProperty("error", out var e) ? e.GetString()! :
                                     $"La activación fue rechazada (HTTP {(int)response.StatusCode}).";
                        return (false, msg);
                    }
                    catch
                    {
                        return (false, $"Error de respuesta del servidor (HTTP {(int)response.StatusCode})");
                    }
                }

                var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                string token = result.GetProperty("signedToken").GetString()!;

                // Guardar token cifrado con Windows DPAPI a nivel máquina
                string commonAppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string targetFolder = Path.Combine(commonAppData, "CompriaxPOS");
                Directory.CreateDirectory(targetFolder);

                string licensePath = Path.Combine(targetFolder, "license.dat");
                byte[] rawTokenBytes = Encoding.UTF8.GetBytes(token);
                byte[] encryptedBytes = ProtectedData.Protect(rawTokenBytes, null, DataProtectionScope.LocalMachine);

                await File.WriteAllBytesAsync(licensePath, encryptedBytes);

                return (true, "Activación aprobada exitosamente.");
            }
            catch (Exception ex)
            {
                string realError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return (false, $"No se pudo comunicar con el servidor de licencias ({serverUrl}):\n{realError}");
            }
        }

        private static string GetMachineHardwareId()
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
                    var val = item[propertyName]?.ToString();
                    if (!string.IsNullOrWhiteSpace(val))
                        return val.Trim();
                }
            }
            catch { }
            return string.Empty;
        }
    }
}