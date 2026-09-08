using CompriaxSystem.Application.Interfaces.Services;
using SkiaSharp;
using System.Drawing;
using ZXing;
using ZXing.Windows.Compatibility;

namespace CompriaxSystem.Infrastructure.Services
{
    public class BarcodeService : IBarcodeService
    {
        /// <summary>
        /// Genera una imagen de código de barras (EAN13 o Code128) con etiqueta de texto incluida.
        /// </summary>
        /// <param name="data">Información a codificar.</param>
        /// <param name="width">Ancho de la imagen.</param>
        /// <param name="height">Alto de la imagen.</param>
        /// <returns>Objeto Image con el código de barras generado.</returns>
        public Image GenerateBarcode(string data, int width = 380, int height = 95)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(data))
                    data = "0000000000000";

                var barcode = new BarcodeStandard.Barcode();
                barcode.IncludeLabel = true;

                var type = data.Length == 13 && data.All(char.IsDigit) ? BarcodeStandard.Type.Ean13 : BarcodeStandard.Type.Code128;

                using (var skImage = barcode.Encode(type, data, SKColors.Black, SKColors.White, width, height))
                using (var skData = skImage.Encode(SKEncodedImageFormat.Png, 100))
                using (var ms = new MemoryStream(skData.ToArray()))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                Bitmap errorImg = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(errorImg))
                {
                    g.Clear(Color.White);
                    g.DrawString("Codigo de barras invalido.", new Font("Arial", 8), Brushes.Red, 10, 10);
                }
                return errorImg;
            }
        }

        /// <summary>
        /// Analiza una imagen de mapa de bits para intentar decodificar y extraer el valor de un código de barras.
        /// </summary>
        /// <param name="image">Imagen que contiene el código de barras.</param>
        /// <returns>Cadena de texto decodificada o null si la lectura falla.</returns>
        public string? DecodeBarcode(Bitmap image)
        {
            try
            {
                var reader = new BarcodeReader
                {
                    AutoRotate = true,
                    Options = new ZXing.Common.DecodingOptions
                    {
                        TryHarder = true,
                        PossibleFormats = new List<BarcodeFormat>
                        {
                            BarcodeFormat.EAN_13,
                            BarcodeFormat.CODE_128
                        }
                    }
                };

                var result = reader.Decode(image);
                return result?.Text;
            }
            catch
            {
                return null;
            }

        }
    }
}
