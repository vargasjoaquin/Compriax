namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IFileStorageService
    {
        /// <summary>
        /// Sube un archivo al almacenamiento configurado y devuelve la ruta o URL de acceso.
        /// </summary>
        /// <param name="fileBytes">Contenido del archivo en bytes.</param>
        /// <param name="fileName">Nombre sugerido para el archivo.</param>
        /// <returns>Ruta final donde se almacenó el archivo.</returns>
        Task<string> UploadFileAsync(byte[] fileBytes, string fileName);
    }
}
