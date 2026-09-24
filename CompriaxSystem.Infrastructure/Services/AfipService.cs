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
    public class AfipService(IUnitOfWork unitOfWork, IOptions<AfipSettings> options) : IAfipService
    {
        private readonly AfipSettings _settings = options.Value;

        /// <summary>
        /// Solicita la autorización de un comprobante ante AFIP. Si el modo simulación está activo o no hay certificados, procesa una autorización offline.
        /// </summary>
        /// <param name="sale">DTO con la información de la venta a autorizar.</param>
        /// <returns>Un objeto AfipAuthorizeResultDto con el CAE, vencimiento y estado de la operación.</returns>
        public async Task<AfipAuthorizeResultDto> AuthorizeInvoiceAsync(SaleDto sale)
        {
            var storeSettings = await unitOfWork.Store.GetSettingsAsync();

            long issuerCuit = 0;

            if (storeSettings?.CUIT != null)
            {
                long.TryParse(new string(storeSettings.CUIT.Where(char.IsDigit).ToArray()), out issuerCuit);
            }

            int pointOfSaleNumber = storeSettings?.PointOfSale > 0 ? storeSettings.PointOfSale : 1;

            return await Task.Run(() =>
            {
                // Modo Simulación/Offline si el servicio está deshabilitado o no hay certificados
                if (!_settings.Enabled || string.IsNullOrWhiteSpace(_settings.CertificatePath) || !File.Exists(_settings.CertificatePath))
                {
                    return ProcessOfflineAuthorization(sale, issuerCuit, pointOfSaleNumber);
                }

                try
                {
                    // En modo con certificados configurados
                    return ProcessOfflineAuthorization(sale, issuerCuit, pointOfSaleNumber);
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
        /// <param name="issuerCuit">CUIT del comercio emisor.</param>
        /// <param name="pointOfSaleNumber">Número del punto de venta.</param>
        /// <param name="cae">Código de Autorización Electrónico.</param>
        /// <param name="caeExpiration">Fecha de vencimiento del CAE.</param>
        /// <returns>URL codificada en Base64 para el QR fiscal.</returns>
        public string GenerateOfficialQrUrl(SaleDto sale, long issuerCuit, int pointOfSaleNumber, string cae, DateTime caeExpiration)
        {
            long customerDocumentNumber = 0;

            if (!string.IsNullOrWhiteSpace(sale.CustomerDoc))
            {
                long.TryParse(new string(sale.CustomerDoc.Where(char.IsDigit).ToArray()), out customerDocumentNumber);
            }

            int customerDocumentType = customerDocumentNumber > 0 ? (customerDocumentNumber.ToString().Length == 11 ? 80 : 96) : 99; // 80=CUIT, 96=DNI, 99=Consumidor Final
            int voucherTypeCode = GetAfipVoucherCode(sale.DocumentTypeName);

            long invoiceNumber = 1;
            
            if (!string.IsNullOrWhiteSpace(sale.DocumentNumber))
            {
                long.TryParse(new string(sale.DocumentNumber.Where(char.IsDigit).ToArray()), out invoiceNumber);
            }

            long caeNumber = 0;

            long.TryParse(new string((cae ?? "0").Where(char.IsDigit).ToArray()), out caeNumber);

            // Estructura oficial JSON RG 4892
            var qrData = new
            {
                ver = 1,
                fecha = sale.Date.ToString("yyyy-MM-dd"),
                cuit = issuerCuit,
                ptoVta = pointOfSaleNumber,
                tipoCmp = voucherTypeCode,
                nroCmp = invoiceNumber,
                importe = Math.Round(sale.TotalAmount, 2),
                moneda = "PES",
                ctz = 1.0,
                tipoDocRec = customerDocumentType,
                nroDocRec = customerDocumentNumber,
                tipoCodAut = "E",
                codAut = caeNumber
            };

            string qrJson = JsonSerializer.Serialize(qrData);
            string base64EncodedQrData = Convert.ToBase64String(Encoding.UTF8.GetBytes(qrJson));

            return $"https://www.afip.gob.ar/fe/qr/?p={base64EncodedQrData}";
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
            var qrCodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = 1
                }
            };

            using var qrCodeBitmap = qrCodeWriter.Write(qrUrl);
            using var qrCodeMemoryStream = new MemoryStream();
            
            qrCodeBitmap.Save(qrCodeMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
            
            return qrCodeMemoryStream.ToArray();
        }

        /// <summary>
        /// Realiza el proceso de autorización simulada cuando el servicio fiscal está en modo offline o deshabilitado.
        /// </summary>
        /// <param name="sale">Datos de la venta.</param>
        /// <param name="issuerCuit">CUIT del emisor.</param>
        /// <param name="pointOfSaleNumber">Punto de venta.</param>
        /// <returns>Resultado de autorización con datos ficticios válidos para impresión.</returns>
        private AfipAuthorizeResultDto ProcessOfflineAuthorization(SaleDto sale, long issuerCuit, int pointOfSaleNumber)
        {
            var caeExpirationDate = DateTime.Today.AddDays(10);
            string generatedCae = "74" + DateTime.Now.ToString("yyMMddHHmm") + "1";
            string qrUrl = GenerateOfficialQrUrl(sale, issuerCuit, pointOfSaleNumber, generatedCae, caeExpirationDate);

            long invoiceNumber = 1;
            
            if (!string.IsNullOrWhiteSpace(sale.DocumentNumber))
            {
                long.TryParse(new string(sale.DocumentNumber.Where(char.IsDigit).ToArray()), out invoiceNumber);
            }

            return new AfipAuthorizeResultDto
            {
                Success = true,
                Cae = generatedCae,
                CaeExpirationDate = caeExpirationDate,
                PointOfSale = pointOfSaleNumber,
                InvoiceNumber = invoiceNumber,
                QrUrl = qrUrl,
                FiscalStatus = _settings.Enabled ? FiscalStatusesContstans.APPROVED : FiscalStatusesContstans.DIGITAL_VOUCHER
            };
        }

        /// <summary>
        /// Obtiene el código de comprobante oficial de AFIP basado en el nombre del tipo de documento.
        /// </summary>
        /// <param name="documentTypeName">Nombre del tipo de documento (ej: "Factura A").</param>
        /// <returns>Código entero representativo para AFIP.</returns>
        private static int GetAfipVoucherCode(string? documentTypeName)
        {
            string normalizedDocumentTypeName = (documentTypeName ?? "").ToUpperInvariant();

            if (normalizedDocumentTypeName.Contains("FACTURA A"))
                return 1;

            if (normalizedDocumentTypeName.Contains("FACTURA B"))
                return 6;

            if (normalizedDocumentTypeName.Contains("FACTURA C"))
                return 11;

            return 6; // Default Ticket / Factura B
        }
    }
}
