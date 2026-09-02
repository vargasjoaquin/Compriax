using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IBackupService
    {
        Task<OperationResult> ExecuteAutomaticBackupAsync();
    }
}
