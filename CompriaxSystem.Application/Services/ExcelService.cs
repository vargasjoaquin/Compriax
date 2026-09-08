using CompriaxSystem.Application.Interfaces.Services;
using ClosedXML.Excel;

namespace CompriaxSystem.Application.Services
{
    public class ExcelService : IExcelService
    {
        /// <summary>
        /// Exporta una colección de datos genéricos a un archivo Excel (.xlsx) con formato de tabla.
        /// </summary>
        /// <typeparam name="T">Tipo de los datos a exportar.</typeparam>
        /// <param name="data">Colección de elementos.</param>
        /// <param name="sheetName">Nombre de la hoja de cálculo.</param>
        /// <returns>Arreglo de bytes del archivo generado.</returns>
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
