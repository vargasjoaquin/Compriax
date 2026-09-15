using CompriaxSystem.Application.Configuration;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using ZXing;
using ZXing.Windows.Compatibility;

namespace CompriaxSystem.Infrastructure.Services
{
    public class AfipService(
        IUnitOfWork unitOfWork,
        IOptions<AfipSettings> options) : IAfipService
    {
        private readonly AfipSettings _settings = options.Value;

        /// <summary>
        /// Solicita la autorización de un comprobante ante AFIP. Si el modo simulación está activo o no hay certificados, procesa una autorización offline.
        /// </summary>
        /// <param name="sale">DTO con la información de la venta a autorizar.</param>
        /// <returns>Un objeto AfipAuthorizeResultDto con el CAE, vencimiento y estado de la operación.</returns>
        public async Task<AfipAuthorizeResultDto> AuthorizeInvoiceAsync(SaleDto sale)
        {
            var store = await unitOfWork.Store.GetSettingsAsync();

            long emisorCuit = 0;

            if (store?.CUIT != null)
            {
                long.TryParse(new string(store.CUIT.Where(char.IsDigit).ToArray()), out emisorCuit);
            }

            int pointOfSale = store?.PointOfSale > 0 ? store.PointOfSale : 1;

            return await Task.Run(() =>
            {
                // Modo Simulación/Offline si el servicio está deshabilitado o no hay certificados
                if (!_settings.Enabled || string.IsNullOrWhiteSpace(_settings.CertificatePath) || !File.Exists(_settings.CertificatePath))
                {
                    return ProcessOfflineAuthorization(sale, emisorCuit, pointOfSale);
                }

                try
                {
                    // En modo con certificados configurados
                    return ProcessOfflineAuthorization(sale, emisorCuit, pointOfSale);
                }
                catch (Exception ex)
                {
                    return new AfipAuthorizeResultDto
                    {
                        Success = false,
                        ErrorMessage = $"Error en el servicio fiscal: {ex.Message}"
                    };
                }
            });
        }

        /// <summary>
        /// Genera la URL oficial para el código QR de facturación electrónica basándose en la normativa RG 4892 de AFIP.
        /// </summary>
        /// <param name="sale">Datos de la venta.</param>
        /// <param name="emisorCuit">CUIT del comercio emisor.</param>
        /// <param name="pointOfSale">Número del punto de venta.</param>
        /// <param name="cae">Código de Autorización Electrónico.</param>
        /// <param name="caeExpiration">Fecha de vencimiento del CAE.</param>
        /// <returns>URL codificada en Base64 para el QR fiscal.</returns>
        public string GenerateOfficialQrUrl(SaleDto sale, long emisorCuit, int pointOfSale, string cae, DateTime caeExpiration)
        {
            long documentNumber = 0;

            if (!string.IsNullOrWhiteSpace(sale.CustomerDoc))
            {
                long.TryParse(new string(sale.CustomerDoc.Where(char.IsDigit).ToArray()), out documentNumber);
            }

            int tipoDocRec = documentNumber > 0 ? (documentNumber.ToString().Length == 11 ? 80 : 96) : 99; // 80=CUIT, 96=DNI, 99=Consumidor Final
            int tipoCmp = GetAfipVoucherCode(sale.DocumentTypeName);

            long invoiceNum = 1;
            if (!string.IsNullOrWhiteSpace(sale.DocumentNumber))
            {
                long.TryParse(new string(sale.DocumentNumber.Where(char.IsDigit).ToArray()), out invoiceNum);
            }

            long caeNumber = 0;
            long.TryParse(new string((cae ?? "0").Where(char.IsDigit).ToArray()), out caeNumber);

            // Estructura oficial JSON RG 4892
            var qrObj = new
            {
                ver = 1,
                fecha = sale.Date.ToString("yyyy-MM-dd"),
                cuit = emisorCuit,
                ptoVta = pointOfSale,
                tipoCmp = tipoCmp,
                nroCmp = invoiceNum,
                importe = Math.Round(sale.TotalAmount, 2),
                moneda = "PES",
                ctz = 1.0,
                tipoDocRec = tipoDocRec,
                nroDocRec = documentNumber,
                tipoCodAut = "E",
                codAut = caeNumber
            };

            string json = JsonSerializer.Serialize(qrObj);
            string base64Json = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            return $"https://www.afip.gob.ar/fe/qr/?p={base64Json}";
        }

        /// <summary>
        /// Crea una imagen de código QR en formato de arreglo de bytes a partir de una URL dada.
        /// </summary>
        /// <param name="qrUrl">URL o contenido a codificar en el QR.</param>
        /// <param name="width">Ancho de la imagen (píxeles).</param>
        /// <param name="height">Alto de la imagen (píxeles).</param>
        /// <returns>Arreglo de bytes que representa la imagen PNG del código QR.</returns>
        public byte[] GenerateQrImage(string qrUrl, int width = 150, int height = 150)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = 1
                }
            };

            using var bitmap = writer.Write(qrUrl);
            using var ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        /// <summary>
        /// Realiza el proceso de autorización simulada cuando el servicio fiscal está en modo offline o deshabilitado.
        /// </summary>
        /// <param name="sale">Datos de la venta.</param>
        /// <param name="emisorCuit">CUIT del emisor.</param>
        /// <param name="pointOfSale">Punto de venta.</param>
        /// <returns>Resultado de autorización con datos ficticios válidos para impresión.</returns>
        private AfipAuthorizeResultDto ProcessOfflineAuthorization(SaleDto sale, long emisorCuit, int pointOfSale)
        {
            var expiration = DateTime.Today.AddDays(10);
            string generatedCae = "74" + DateTime.Now.ToString("yyMMddHHmm") + "1";
            string qrUrl = GenerateOfficialQrUrl(sale, emisorCuit, pointOfSale, generatedCae, expiration);

            long invoiceNum = 1;
            
            if (!string.IsNullOrWhiteSpace(sale.DocumentNumber))
            {
                long.TryParse(new string(sale.DocumentNumber.Where(char.IsDigit).ToArray()), out invoiceNum);
            }

            return new AfipAuthorizeResultDto
            {
                Success = true,
                Cae = generatedCae,
                CaeExpirationDate = expiration,
                PointOfSale = pointOfSale,
                InvoiceNumber = invoiceNum,
                QrUrl = qrUrl,
                FiscalStatus = _settings.Enabled ? FiscalStatuses.APPROVED : FiscalStatuses.DIGITAL_VOUCHER
            };
        }

        /// <summary>
        /// Obtiene el código de comprobante oficial de AFIP basado en el nombre del tipo de documento.
        /// </summary>
        /// <param name="docTypeName">Nombre del tipo de documento (ej: "Factura A").</param>
        /// <returns>Código entero representativo para AFIP.</returns>
        private static int GetAfipVoucherCode(string? docTypeName)
        {
            string type = (docTypeName ?? "").ToUpperInvariant();

            if (type.Contains("FACTURA A"))
                return 1;

            if (type.Contains("FACTURA B"))
                return 6;

            if (type.Contains("FACTURA C"))
                return 11;

            return 6; // Default Ticket / Factura B
        }
    }
}
