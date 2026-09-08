using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CompriaxSystem.Application.Configuration;
using CompriaxSystem.Application.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace CompriaxSystem.Infrastructure.Services
{
    public class CloudinaryStorageService : IFileStorageService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryStorageService(IOptions<CloudinarySettings> options)
        {
            var settings = options.Value;
            var account = new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        /// <summary>
        /// Sube un archivo al almacenamiento en la nube de Cloudinary y devuelve la URL segura de acceso.
        /// </summary>
        /// <param name="fileBytes">Contenido del archivo en bytes.</param>
        /// <param name="fileName">Nombre del archivo a subir.</param>
        /// <returns>URL pública del archivo almacenado.</returns>
        public async Task<string> UploadFileAsync(byte[] fileBytes, string fileName)
        {
            using (var stream = new MemoryStream(fileBytes))
            {
                var uploadParams = new RawUploadParams
                {
                    File = new FileDescription(fileName, stream),
                    PublicId = $"facturas/{Path.GetFileNameWithoutExtension(fileName)}",
                    AccessMode = "public",
                    Overwrite = true,
                    UseFilename = true,
                    UniqueFilename = false
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                    throw new Exception("Error Cloudinary: " + uploadResult.Error.Message);

                return uploadResult.SecureUrl.ToString();
            }
        }
    }
}
