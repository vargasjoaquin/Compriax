using CompriaxSystem.Application.DTOs;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IAfipService
    {
        /// <summary>
        /// Solicita la autorización de una factura electrónica ante AFIP para obtener el CAE.
        /// </summary>
        /// <param name="sale">Datos de la venta a facturar.</param>
        /// <returns>Resultado de la autorización con el CAE y vencimiento.</returns>
        Task<AfipAuthorizeResultDto> AuthorizeInvoiceAsync(SaleDto sale);

        /// <summary>
        /// Genera la URL oficial requerida para el código QR de la factura según normativas de AFIP.
        /// </summary>
        /// <param name="sale">Datos de la venta.</param>
        /// <param name="emisorCuit">CUIT del emisor.</param>
        /// <param name="pointOfSale">Punto de venta.</param>
        /// <param name="cae">Código de Autorización Electrónico.</param>
        /// <param name="caeExpiration">Fecha de vencimiento del CAE.</param>
        /// <returns>URL codificada para el QR.</returns>
        string GenerateOfficialQrUrl(SaleDto sale, long emisorCuit, int pointOfSale, string cae, DateTime caeExpiration);

        /// <summary>
        /// Convierte una URL de AFIP en una imagen de código QR.
        /// </summary>
        /// <param name="qrUrl">URL a codificar.</param>
        /// <param name="width">Ancho de la imagen.</param>
        /// <param name="height">Alto de la imagen.</param>
        /// <returns>Arreglo de bytes que representa la imagen del QR.</returns>
        byte[] GenerateQrImage(string qrUrl, int width = 150, int height = 150);
    }
}
