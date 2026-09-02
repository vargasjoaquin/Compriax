namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IFileStorageService
    {
        Task<string> UploadFileAsync(byte[] fileBytes, string fileName);
    }
}
