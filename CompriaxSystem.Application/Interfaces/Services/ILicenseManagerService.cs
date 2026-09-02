using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ILicenseManagerService
    {
        Task<OperationResult> ValidateInstalledLicenseAsync();
        Task<OperationResult> ActivateOnlineAsync(string cuit, string licenseKey);
        LicenseInformationDto? CurrentLicense { get; }
    }
}
