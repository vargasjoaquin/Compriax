using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ILicenseManagerService
    {
        Task<OperationResult> ValidateInstalledLicenseAsync();
        Task<OperationResult> ActivateOnlineAsync(string cuit, string licenseKey);
        LicenseInformationDto? CurrentLicense { get; }
    }
}
