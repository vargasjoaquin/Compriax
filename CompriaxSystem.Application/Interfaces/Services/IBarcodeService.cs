using System.Drawing;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IBarcodeService
    {
        Image GenerateBarcode(string data, int width = 300, int height = 120);
        string? DecodeBarcode(Bitmap image);
    }
}
