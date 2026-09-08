namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IExcelService
    {
        /// <summary>
        /// Exporta una colección de datos genéricos a un archivo Excel (.xlsx).
        /// </summary>
        /// <typeparam name="T">Tipo de entidad a exportar.</typeparam>
        /// <param name="data">Colección de datos.</param>
        /// <param name="sheetName">Nombre de la hoja de cálculo.</param>
        /// <returns>Arreglo de bytes del archivo Excel.</returns>
        byte[] ExportToExcel<T>(IEnumerable<T> data, string sheetName);
    }
}
