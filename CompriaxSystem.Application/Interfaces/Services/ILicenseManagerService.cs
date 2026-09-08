using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ILicenseManagerService
    {
        /// <summary>
        /// Valida si la licencia instalada actualmente en el equipo es válida y no ha expirado.
        /// </summary>
        /// <returns>Resultado de la validación local.</returns>
        Task<OperationResult> ValidateInstalledLicenseAsync();

        /// <summary>
        /// Realiza la activación en línea del producto utilizando un CUIT y una clave de licencia.
        /// </summary>
        /// <param name="cuit">CUIT de la empresa titular.</param>
        /// <param name="licenseKey">Clave de producto proporcionada.</param>
        /// <returns>Resultado de la activación.</returns>
        Task<OperationResult> ActivateOnlineAsync(string cuit, string licenseKey);

        /// <summary>
        /// Obtiene la información detallada de la licencia activa.
        /// </summary>
        LicenseInformationDto? CurrentLicense { get; }
    }
}
