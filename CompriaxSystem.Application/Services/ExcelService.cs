using CompriaxSystem.Application.Interfaces.Services;
using ClosedXML.Excel;

namespace CompriaxSystem.Application.Services
{
    public class ExcelService : IExcelService
    {
        public byte[] ExportToExcel<T>(IEnumerable<T> data, string sheetName)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(sheetName);

            var table = worksheet.Cell(1, 1).InsertTable(data);
            table.Theme = XLTableTheme.TableStyleMedium9;
            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
