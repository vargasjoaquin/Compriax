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
        /// <param name="dataToExport">Colección de elementos.</param>
        /// <param name="worksheetName">Nombre de la hoja de cálculo.</param>
        /// <returns>Arreglo de bytes del archivo generado.</returns>
        public byte[] ExportToExcel<T>(IEnumerable<T> dataToExport, string worksheetName)
        {
            using var excelWorkbook = new XLWorkbook();
            var excelWorksheet = excelWorkbook.Worksheets.Add(worksheetName);

            var excelTable = excelWorksheet.Cell(1, 1).InsertTable(dataToExport);
            excelTable.Theme = XLTableTheme.TableStyleMedium9;
            excelWorksheet.Columns().AdjustToContents();

            using var memoryStream = new MemoryStream();
            excelWorkbook.SaveAs(memoryStream);
            
            return memoryStream.ToArray();
        }
    }
}
