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
                string licenseKey = args[2];
                string licenseServerUrl = args[3];
                string activationErrorFilePath = args.Length >= 5 ? args[4] : Path.Combine(Path.GetTempPath(), "activation_error.txt");

                var (activationSucceeded, activationMessage) = ExecuteActivationAsync(cuit, licenseKey, licenseServerUrl).GetAwaiter().GetResult();

                if (activationSucceeded)
                {
                    Environment.Exit(0); // Código 0 = Éxito para el instalador
                }
                else
                {
                    try
                    {
                        File.WriteAllText(activationErrorFilePath, activationMessage, Encoding.UTF8);
                    }
                    catch { }

                    Environment.Exit(1); // Código 1 = Bloquear instalación
                }
                return;
            }

            MessageBox.Show("Este asistente de activación solo debe ser ejecutado por el instalador del sistema.",
                "Compriax POS Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static async Task<(bool Success, string Message)> ExecuteActivationAsync(string cuit, string licenseKey, string licenseServerUrl)
        {
            try
            {
                string hardwareId = GetMachineHardwareId();
                string machineName = Environment.MachineName;

                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (activationMessage, cert, chain, errors) => true
                };

                using var httpClientHandler = new HttpClient(handler) 
                { 
                    Timeout = TimeSpan.FromSeconds(15) 
                };

                string activationRequestUrl = $"{licenseServerUrl.TrimEnd('/')}/api/licenses/activate";

                var activationResponse = await httpClientHandler.PostAsJsonAsync(activationRequestUrl, new
                {
                    LicenseKey = licenseKey.Trim().ToUpper(),
                    Cuit = cuit.Trim(),
                    HardwareId = hardwareId,
                    MachineName = machineName,
                    OsVersion = Environment.OSVersion.ToString()
                });

                if (!activationResponse.IsSuccessStatusCode)
                {
                    try
                    {
                        var errorResponse = await activationResponse.Content.ReadFromJsonAsync<JsonElement>();
                        
                        string errorMessage = errorResponse.TryGetProperty("activationMessage", out var m) ? m.GetString()! :
                                     errorResponse.TryGetProperty("error", out var e) ? e.GetString()! :
                                     $"La activación fue rechazada (HTTP {(int)activationResponse.StatusCode}).";
                        
                        return (false, errorMessage);
                    }
                    catch
                    {
                        return (false, $"Error de respuesta del servidor (HTTP {(int)activationResponse.StatusCode})");
                    }
                }

                var activationResult = await activationResponse.Content.ReadFromJsonAsync<JsonElement>();
                
                string signedToken = activationResult.GetProperty("signedToken").GetString()!;

                // Guardar signedToken cifrado con Windows DPAPI a nivel máquina
                string commonAppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string licenseDirectoryPath = Path.Combine(commonAppData, "CompriaxPOS");
                
                Directory.CreateDirectory(licenseDirectoryPath);

                string licenseFilePath = Path.Combine(licenseDirectoryPath, "license.dat");
                
                byte[] rawTokenBytes = Encoding.UTF8.GetBytes(signedToken);
                
                byte[] encryptedBytes = ProtectedData.Protect(rawTokenBytes, null, DataProtectionScope.LocalMachine);

                await File.WriteAllBytesAsync(licenseFilePath, encryptedBytes);

                return (true, "Activación aprobada exitosamente.");
            }
            catch (Exception ex)
            {
                return (false, $"No se pudo comunicar con el servidor de licencias ({licenseServerUrl}):\n{ex.Message}");
            }
        }

        private static string GetMachineHardwareId()
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

        private static string GetWmiProperty(string wmiClassName, string wmiPropertyName)
        {
            try
            {
                using var managementObjectSearcher = new ManagementObjectSearcher($"SELECT {wmiPropertyName} FROM {wmiClassName}");
                
                foreach (var managementObject in managementObjectSearcher.Get())
                {
                    var propertyValue = managementObject[wmiPropertyName]?.ToString();
                    
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