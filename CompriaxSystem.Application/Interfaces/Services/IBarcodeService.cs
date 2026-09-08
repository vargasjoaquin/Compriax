using System.Drawing;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IBarcodeService
    {
        /// <summary>
        /// Genera una imagen de código de barras a partir de una cadena de texto.
        /// </summary>
        /// <param name="data">Información a codificar.</param>
        /// <param name="width">Ancho de la imagen generada.</param>
        /// <param name="height">Alto de la imagen generada.</param>
        /// <returns>Objeto Image con el código de barras.</returns>
        Image GenerateBarcode(string data, int width = 300, int height = 120);

        /// <summary>
        /// Decodifica una imagen que contiene un código de barras para extraer su valor.
        /// </summary>
        /// <param name="image">Imagen del código de barras.</param>
        /// <returns>Texto contenido en el código o null si no se puede leer.</returns>
        string? DecodeBarcode(Bitmap image);
    }
}
