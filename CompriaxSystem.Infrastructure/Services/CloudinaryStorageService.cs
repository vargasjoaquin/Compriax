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
            var cloudinarySettings = options.Value;
            var cloudinaryAccount = new Account(cloudinarySettings.CloudName, cloudinarySettings.ApiKey, cloudinarySettings.ApiSecret);
            
            _cloudinary = new Cloudinary(cloudinaryAccount);
        }

        /// <summary>
        /// Sube un archivo al almacenamiento en la nube de Cloudinary y devuelve la URL segura de acceso.
        /// </summary>
        /// <param name="fileBytes">Contenido del archivo en bytes.</param>
        /// <param name="fileName">Nombre del archivo a subir.</param>
        /// <returns>URL pública del archivo almacenado.</returns>
        public async Task<string> UploadFileAsync(byte[] fileBytes, string fileName)
        {
            using (var fileStream = new MemoryStream(fileBytes))
            {
                var uploadParameters = new RawUploadParams
                {
                    File = new FileDescription(fileName, fileStream),
                    PublicId = $"facturas/{Path.GetFileNameWithoutExtension(fileName)}",
                    AccessMode = "public",
                    Overwrite = true,
                    UseFilename = true,
                    UniqueFilename = false
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParameters);

                if (uploadResult.Error != null)
                    throw new Exception("Error Cloudinary: " + uploadResult.Error.Message);

                return uploadResult.SecureUrl.ToString();
            }
        }
    }
}
