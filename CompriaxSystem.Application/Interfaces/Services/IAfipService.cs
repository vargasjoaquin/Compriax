namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IAfipService
    {
        Task<AfipAuthorizeResultDto> AuthorizeInvoiceAsync(SaleDto sale);
        string GenerateOfficialQrUrl(SaleDto sale, long emisorCuit, int pointOfSale, string cae, DateTime caeExpiration);
        byte[] GenerateQrImage(string qrUrl, int width = 150, int height = 150);
    }
}
