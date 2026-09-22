using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
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
        /// <param name="barcodeData">Información a codificar.</param>
        /// <param name="width">Ancho de la imagen.</param>
        /// <param name="height">Alto de la imagen.</param>
        /// <returns>Objeto Image con el código de barras generado.</returns>
        public Image GenerateBarcode(string barcodeData, int width = 380, int height = 95)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(barcodeData))
                    barcodeData = ProductConstants.EMPTY_BARCODE_FALLBACK;

                var barcodeGenerator = new BarcodeStandard.Barcode();
                barcodeGenerator.IncludeLabel = true;

                var barcodeType = barcodeData.Length == 13 && barcodeData.All(char.IsDigit) ? BarcodeStandard.Type.Ean13 : BarcodeStandard.Type.Code128;

                using (var barcodeImage = barcodeGenerator.Encode(barcodeType, barcodeData, SKColors.Black, SKColors.White, width, height))
                
                using (var barcodeImageData = barcodeImage.Encode(SKEncodedImageFormat.Png, 100))
                
                using (var barcodeMemoryStream = new MemoryStream(barcodeImageData.ToArray()))
                {
                    return Image.FromStream(barcodeMemoryStream);
                }
            }
            catch (Exception ex)
            {
                Bitmap errorImage = new Bitmap(width, height);
                using (Graphics graphics = Graphics.FromImage(errorImage))
                {
                    graphics.Clear(Color.White);
                    graphics.DrawString("Codigo de barras invalido.", new Font("Arial", 8), Brushes.Red, 10, 10);
                }
                return errorImage;
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
                var barcodeReader = new BarcodeReader
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

                var decodeResult = barcodeReader.Decode(image);
                return decodeResult?.Text;
            }
            catch
            {
                return null;
            }

        }
    }
}
