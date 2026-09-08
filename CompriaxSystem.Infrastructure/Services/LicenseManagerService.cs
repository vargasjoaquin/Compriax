using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.Json;

namespace CompriaxSystem.Infrastructure.Services
{
    public class LicenseManagerService : ILicenseManagerService
    {
        private readonly HttpClient _httpClient;
        private readonly string _serverUrl;
        private readonly string _rsaPublicKeyPem;
        private readonly string _primaryLicensePath;
        private readonly string _fallbackLicensePath;

        public LicenseInformationDto? CurrentLicense { get; private set; }

        public LicenseManagerService(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(15) };
            _serverUrl = config["Licensing:ServerUrl"] ?? "http://licensekeysadminstrator.runasp.net";

            string? keyFromConfig = config["Licensing:RsaPublicKeyPem"];
            string keyFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rsa_public_key.txt");

            if (string.IsNullOrWhiteSpace(keyFromConfig) && File.Exists(keyFilePath))
            {
                keyFromConfig = File.ReadAllText(keyFilePath);
            }

            _rsaPublicKeyPem = !string.IsNullOrWhiteSpace(keyFromConfig)
                ? keyFromConfig
                : throw new InvalidOperationException("Public Key de licenciamiento no configurada.");

            string commonFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "CompriaxSystem");
            EnsureFolderPermissions(commonFolder);
            _primaryLicensePath = Path.Combine(commonFolder, "license.dat");

            string localFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CompriaxSystem");
            Directory.CreateDirectory(localFolder);
            _fallbackLicensePath = Path.Combine(localFolder, "license.dat");
        }

        /// <summary>
        /// Valida la existencia y autenticidad de la licencia instalada localmente verificando el Hardware ID y la firma digital.
        /// </summary>
        /// <returns>Resultado de la operación indicando si la licencia es válida y autorizada para este equipo.</returns>
        public async Task<OperationResult> ValidateInstalledLicenseAsync()
        {
            string? activePath = null;

            if (File.Exists(_primaryLicensePath))
                activePath = _primaryLicensePath;
            else if (File.Exists(_fallbackLicensePath))
                activePath = _fallbackLicensePath;

            if (activePath == null)
                return OperationResult.Failure("El sistema no se encuentra activado en esta computadora.");

            try
            {
                byte[] encryptedBytes = await File.ReadAllBytesAsync(activePath);
                byte[] rawTokenBytes = ProtectedData.Unprotect(encryptedBytes, null, DataProtectionScope.LocalMachine);
                string tokenString = Encoding.UTF8.GetString(rawTokenBytes);

                var (isValidSignature, payload) = VerifyTokenSignature(tokenString);
                
                if (!isValidSignature || payload == null)
                    return OperationResult.Failure("La credencial de activación está corrupta o fue alterada.");

                string currentHwid = HardwareFingerprint.GetMachineHardwareId();
                
                if (payload.HardwareId != currentHwid)
                    return OperationResult.Failure("Esta instalación fue copiada a otro equipo y no coincide con el hardware autorizado.");

                if (payload.ExpiresAt.HasValue && payload.ExpiresAt.Value < DateTime.UtcNow)
                    return OperationResult.Failure("La licencia ha expirado.");

                CurrentLicense = new LicenseInformationDto
                {
                    LicenseKey = payload.LicenseKey,
                    Cuit = payload.Cuit,
                    BusinessName = payload.BusinessName,
                    ExpiresAt = payload.ExpiresAt,
                    IsValid = true
                };

                if (DateTime.UtcNow > payload.ValidationGraceUntil)
                {
                    _ = Task.Run(async () => await RevalidateWithServerAsync(payload.LicenseKey, payload.Cuit, currentHwid));
                }

                return OperationResult.Ok($"Licencia válida: {payload.BusinessName}");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Error al verificar activación local: " + ex.Message);
            }
        }

        /// <summary>
        /// Realiza la activación en línea del sistema mediante el envío del CUIT y la clave al servidor de licencias.
        /// </summary>
        /// <param name="cuit">CUIT del titular.</param>
        /// <param name="licenseKey">Clave de producto a activar.</param>
        /// <returns>Resultado del proceso de activación y registro local de la licencia.</returns>
        public async Task<OperationResult> ActivateOnlineAsync(string cuit, string licenseKey)
        {
            try
            {
                string hwid = HardwareFingerprint.GetMachineHardwareId();
                string machineName = Environment.MachineName;

                var response = await _httpClient.PostAsJsonAsync($"{_serverUrl.TrimEnd('/')}/api/licenses/activate", new
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
                        var error = await response.Content.ReadFromJsonAsync<JsonElement>();
                        string msg = error.TryGetProperty("message", out var m) ? m.GetString()! : "Activación rechazada por el servidor.";
                        return OperationResult.Failure(msg);
                    }
                    catch
                    {
                        return OperationResult.Failure($"Fallo del servidor (HTTP {(int)response.StatusCode})");
                    }
                }

                var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                string token = result.GetProperty("signedToken").GetString()!;

                byte[] rawBytes = Encoding.UTF8.GetBytes(token);
                byte[] encryptedBytes = ProtectedData.Protect(rawBytes, null, DataProtectionScope.LocalMachine);

                // Guardado seguro con manejo de permisos y fallback
                await SafeWriteLicenseFileAsync(encryptedBytes);

                return await ValidateInstalledLicenseAsync();
            }
            catch (Exception ex)
            {
                string realError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return OperationResult.Failure("Error en la activación: " + realError);
            }
        }

        /// <summary>
        /// Escribe de forma segura el archivo de licencia encriptado, manejando alternativas de rutas si los permisos de sistema están restringidos.
        /// </summary>
        /// <param name="data">Datos encriptados de la licencia.</param>
        /// <returns>Tarea que representa la escritura del archivo.</returns>
        private async Task SafeWriteLicenseFileAsync(byte[] data)
        {
            try
            {
                if (File.Exists(_primaryLicensePath))
                {
                    File.SetAttributes(_primaryLicensePath, FileAttributes.Normal);
                }
                await File.WriteAllBytesAsync(_primaryLicensePath, data);
            }
            catch
            {
                // Si ProgramData está bloqueado por permisos de Windows, guarda en AppData/Local
                if (File.Exists(_fallbackLicensePath))
                {
                    File.SetAttributes(_fallbackLicensePath, FileAttributes.Normal);
                }
                await File.WriteAllBytesAsync(_fallbackLicensePath, data);
            }
        }

        /// <summary>
        /// Asegura que la carpeta de almacenamiento de licencias tenga los permisos de escritura necesarios para los usuarios del sistema.
        /// </summary>
        /// <param name="folderPath">Ruta de la carpeta a configurar.</param>
        private static void EnsureFolderPermissions(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Otorgar permisos de escritura a usuarios locales
                var dInfo = new DirectoryInfo(folderPath);
                var dSecurity = dInfo.GetAccessControl();
                var usersSid = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);

                dSecurity.AddAccessRule(new FileSystemAccessRule(
                    usersSid,
                    FileSystemRights.Modify | FileSystemRights.Synchronize,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow));

                dInfo.SetAccessControl(dSecurity);
            }
            catch { }
        }

        /// <summary>
        /// Realiza una revalidación asíncrona con el servidor para actualizar el estado de la licencia local.
        /// </summary>
        /// <param name="licenseKey">Clave de licencia.</param>
        /// <param name="cuit">CUIT del titular.</param>
        /// <param name="hwid">Identificador único de hardware.</param>
        /// <returns>Tarea de fondo.</returns>
        private async Task RevalidateWithServerAsync(string licenseKey, string cuit, string hwid)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_serverUrl.TrimEnd('/')}/api/licenses/validate", new
                {
                    LicenseKey = licenseKey,
                    Cuit = cuit,
                    HardwareId = hwid
                });

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                    string newToken = result.GetProperty("signedToken").GetString()!;
                    byte[] encrypted = ProtectedData.Protect(Encoding.UTF8.GetBytes(newToken), null, DataProtectionScope.LocalMachine);
                    
                    await SafeWriteLicenseFileAsync(encrypted);
                }
            }
            catch 
            { 
            }
        }

        /// <summary>
        /// Verifica la integridad y firma RSA de un token de licencia.
        /// </summary>
        /// <param name="token">Token firmado en formato Base64.</param>
        /// <returns>Una tupla indicando si la firma es válida y el payload de la licencia.</returns>
        private (bool IsValid, LicenseTokenPayload? Payload) VerifyTokenSignature(string token)
        {
            try
            {
                var parts = token.Split('.');
                
                if (parts.Length != 2)
                    return (false, null);

                byte[] payloadBytes = Convert.FromBase64String(parts[0]);
                byte[] signatureBytes = Convert.FromBase64String(parts[1]);

                using var rsa = RSA.Create();
                rsa.ImportFromPem(_rsaPublicKeyPem);

                bool validSignature = rsa.VerifyData(payloadBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                
                if (!validSignature)
                {
                    return (false, null);
                }

                string json = Encoding.UTF8.GetString(payloadBytes);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var payload = JsonSerializer.Deserialize<LicenseTokenPayload>(json, options);

                return (payload != null, payload);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Fallo verificación RSA]: {ex.Message}");
                return (false, null);
            }
        }
    }
}
