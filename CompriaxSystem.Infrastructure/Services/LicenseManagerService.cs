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

        public LicenseManagerService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(httpClientHandler) { Timeout = TimeSpan.FromSeconds(15) };
            _serverUrl = configuration["Licensing:ServerUrl"] ?? "http://licensekeysadminstrator.runasp.net";

            string? configuredPublicKey = configuration["Licensing:RsaPublicKeyPem"];
            string publicKeyFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rsa_public_key.txt");

            if (string.IsNullOrWhiteSpace(configuredPublicKey) && File.Exists(publicKeyFilePath))
            {
                configuredPublicKey = File.ReadAllText(publicKeyFilePath);
            }

            _rsaPublicKeyPem = !string.IsNullOrWhiteSpace(configuredPublicKey)
                ? configuredPublicKey
                : throw new InvalidOperationException("Public Key de licenciamiento no configurada.");

            string commonApplicationDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "CompriaxSystem");
            EnsureFolderPermissions(commonApplicationDataPath);
            _primaryLicensePath = Path.Combine(commonApplicationDataPath, "license.dat");

            string localApplicationDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CompriaxSystem");
            Directory.CreateDirectory(localApplicationDataPath);
            _fallbackLicensePath = Path.Combine(localApplicationDataPath, "license.dat");
        }

        /// <summary>
        /// Valida la existencia y autenticidad de la licencia instalada localmente verificando el Hardware ID y la firma digital.
        /// </summary>
        /// <returns>Resultado de la operación indicando si la licencia es válida y autorizada para este equipo.</returns>
        public async Task<OperationResult> ValidateInstalledLicenseAsync()
        {
            string? activeLicensePath = null;

            if (File.Exists(_primaryLicensePath))
                activeLicensePath = _primaryLicensePath;
            else if (File.Exists(_fallbackLicensePath))
                activeLicensePath = _fallbackLicensePath;

            if (activeLicensePath == null)
                return OperationResult.Failure("El sistema no se encuentra activado en esta computadora.");

            try
            {
                byte[] encryptedTokenBytes = await File.ReadAllBytesAsync(activeLicensePath);
                byte[] rawTokenBytes = ProtectedData.Unprotect(encryptedTokenBytes, null, DataProtectionScope.LocalMachine);
                string tokenString = Encoding.UTF8.GetString(rawTokenBytes);

                var (isValidSignature, licensePayload) = VerifyTokenSignature(tokenString);
                
                if (!isValidSignature || licensePayload == null)
                    return OperationResult.Failure("La credencial de activación está corrupta o fue alterada.");

                string currentHardwareId = HardwareFingerprint.GetMachineHardwareId();
                
                if (licensePayload.HardwareId != currentHardwareId)
                    return OperationResult.Failure("Esta instalación fue copiada a otro equipo y no coincide con el hardware autorizado.");

                if (licensePayload.ExpiresAt.HasValue && licensePayload.ExpiresAt.Value < DateTime.UtcNow)
                    return OperationResult.Failure("La licencia ha expirado.");

                CurrentLicense = new LicenseInformationDto
                {
                    LicenseKey = licensePayload.LicenseKey,
                    Cuit = licensePayload.Cuit,
                    BusinessName = licensePayload.BusinessName,
                    ExpiresAt = licensePayload.ExpiresAt,
                    IsValid = true
                };

                if (DateTime.UtcNow > licensePayload.ValidationGraceUntil)
                {
                    _ = Task.Run(async () => await RevalidateWithServerAsync(licensePayload.LicenseKey, licensePayload.Cuit, currentHardwareId));
                }

                return OperationResult.Ok($"Licencia válida: {licensePayload.BusinessName}");
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
                string hardwareId = HardwareFingerprint.GetMachineHardwareId();
                string machineName = Environment.MachineName;

                var response = await _httpClient.PostAsJsonAsync($"{_serverUrl.TrimEnd('/')}/api/licenses/activate", new
                {
                    LicenseKey = licenseKey.Trim().ToUpper(),
                    Cuit = cuit.Trim(),
                    HardwareId = hardwareId,
                    MachineName = machineName,
                    OsVersion = Environment.OSVersion.ToString()
                });

                if (!response.IsSuccessStatusCode)
                {
                    try
                    {
                        var errorResponse = await response.Content.ReadFromJsonAsync<JsonElement>();
                        string errorMessage = errorResponse.TryGetProperty("message", out var m) ? m.GetString()! : "Activación rechazada por el servidor.";
                        return OperationResult.Failure(errorMessage);
                    }
                    catch
                    {
                        return OperationResult.Failure($"Fallo del servidor (HTTP {(int)response.StatusCode})");
                    }
                }

                var validationResponse = await response.Content.ReadFromJsonAsync<JsonElement>();
                string signedToken = validationResponse.GetProperty("signedToken").GetString()!;

                byte[] rawTokenBytes = Encoding.UTF8.GetBytes(signedToken);
                byte[] encryptedTokenBytes = ProtectedData.Protect(rawTokenBytes, null, DataProtectionScope.LocalMachine);

                // Guardado seguro con manejo de permisos y fallback
                await SafeWriteLicenseFileAsync(encryptedTokenBytes);

                return await ValidateInstalledLicenseAsync();
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Error en la activación: " + ex.Message);
            }
        }

        /// <summary>
        /// Escribe de forma segura el archivo de licencia encriptado, manejando alternativas de rutas si los permisos de sistema están restringidos.
        /// </summary>
        /// <param name="encryptedLicenseData">Datos encriptados de la licencia.</param>
        /// <returns>Tarea que representa la escritura del archivo.</returns>
        private async Task SafeWriteLicenseFileAsync(byte[] encryptedLicenseData)
        {
            try
            {
                if (File.Exists(_primaryLicensePath))
                {
                    File.SetAttributes(_primaryLicensePath, FileAttributes.Normal);
                }
                await File.WriteAllBytesAsync(_primaryLicensePath, encryptedLicenseData);
            }
            catch
            {
                // Si ProgramData está bloqueado por permisos de Windows, guarda en AppData/Local
                if (File.Exists(_fallbackLicensePath))
                {
                    File.SetAttributes(_fallbackLicensePath, FileAttributes.Normal);
                }
                await File.WriteAllBytesAsync(_fallbackLicensePath, encryptedLicenseData);
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
                var directoryInfo = new DirectoryInfo(folderPath);
                var directorySecurity = directoryInfo.GetAccessControl();
                var usersSecurityIdentifier = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);

                directorySecurity.AddAccessRule(new FileSystemAccessRule(
                    usersSecurityIdentifier,
                    FileSystemRights.Modify | FileSystemRights.Synchronize,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow));

                directoryInfo.SetAccessControl(directorySecurity);
            }
            catch 
            {
            }
        }

        /// <summary>
        /// Realiza una revalidación asíncrona con el servidor para actualizar el estado de la licencia local.
        /// </summary>
        /// <param name="licenseKey">Clave de licencia.</param>
        /// <param name="cuit">CUIT del titular.</param>
        /// <param name="hardwareId">Identificador único de hardware.</param>
        /// <returns>Tarea de fondo.</returns>
        private async Task RevalidateWithServerAsync(string licenseKey, string cuit, string hardwareId)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_serverUrl.TrimEnd('/')}/api/licenses/validate", new
                {
                    LicenseKey = licenseKey,
                    Cuit = cuit,
                    HardwareId = hardwareId
                });

                if (response.IsSuccessStatusCode)
                {
                    var validationResponse = await response.Content.ReadFromJsonAsync<JsonElement>();
                    string refreshedSignedToken = validationResponse.GetProperty("signedToken").GetString()!;
                    byte[] encryptedTokenBytes = ProtectedData.Protect(Encoding.UTF8.GetBytes(refreshedSignedToken), null, DataProtectionScope.LocalMachine);
                    
                    await SafeWriteLicenseFileAsync(encryptedTokenBytes);
                }
            }
            catch 
            { 
            }
        }

        /// <summary>
        /// Verifica la integridad y firma RSA de un signedToken de licencia.
        /// </summary>
        /// <param name="signedToken">Token firmado en formato Base64.</param>
        /// <returns>Una tupla indicando si la firma es válida y el licensePayload de la licencia.</returns>
        private (bool IsValid, LicenseTokenPayload? Payload) VerifyTokenSignature(string signedToken)
        {
            try
            {
                var tokenParts = signedToken.Split('.');
                
                if (tokenParts.Length != 2)
                    return (false, null);

                byte[] payloadBytes = Convert.FromBase64String(tokenParts[0]);
                byte[] signatureBytes = Convert.FromBase64String(tokenParts[1]);

                using var rsa = RSA.Create();
                rsa.ImportFromPem(_rsaPublicKeyPem);

                bool isSignatureValid = rsa.VerifyData(payloadBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                
                if (!isSignatureValid)
                {
                    return (false, null);
                }

                string json = Encoding.UTF8.GetString(payloadBytes);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var licensePayload = JsonSerializer.Deserialize<LicenseTokenPayload>(json, options);

                return (licensePayload != null, licensePayload);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Fallo verificación RSA]: {ex.Message}");
                return (false, null);
            }
        }
    }
}
