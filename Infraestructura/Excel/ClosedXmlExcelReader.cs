using ClosedXML.Excel;
using LogicaNegocio.InterfacesServicios;

namespace Infraestructura.Excel;

public class ClosedXmlExcelReader : ILectorExcel
{
    public List<Dictionary<string, object?>> Leer(Stream fileStream, string[] columnasEsperadas)
    {
        using var workbook = new XLWorkbook(fileStream);
        var worksheet = workbook.Worksheets.First();

        var (headerRow, headers) = EncontrarFilaDeHeaders(worksheet, columnasEsperadas);

        if (headers == null || headers.Count == 0)
            throw new InvalidOperationException("No se pudo detectar la fila de encabezados en el archivo Excel");

        var data = new List<Dictionary<string, object?>>();

        var rangeUsed = worksheet.RangeUsed();
        if (rangeUsed == null)
            throw new InvalidOperationException("La hoja de Excel está vacía");

        var lastRow = rangeUsed.LastRow().RowNumber();

        for (int rowNum = headerRow + 1; rowNum <= lastRow; rowNum++)
        {
            var row = worksheet.Row(rowNum);

            // saltar filas completamente vacías
            if (row.IsEmpty())
                continue;

            var rowData = new Dictionary<string, object?>();
            for (int col = 0; col < headers.Count; col++)
            {
                var cell = worksheet.Cell(rowNum, col + 1);
                rowData[headers[col]] = ObtenerValorCelda(cell);
            }

            data.Add(rowData);
        }

        return data;
    }

    // Busca la fila de headers probando las primeras N filas,
    // en vez de asumir que siempre es la fila 1 (por logos, títulos, etc.)
    private (int rowNumber, List<string>? headers) EncontrarFilaDeHeaders(
        IXLWorksheet worksheet, string[] columnasEsperadas)
    {
        var maxFilasABuscar = 10;

        for (int rowNum = 1; rowNum <= maxFilasABuscar; rowNum++)
        {
            var row = worksheet.Row(rowNum);
            if (row.IsEmpty()) continue;

            var valores = row.CellsUsed().Select(c => c.GetString().Trim()).ToList();

            // si encontramos al menos una de las columnas esperadas, asumimos que es el header
            if (columnasEsperadas.Any(col => valores.Contains(col, StringComparer.OrdinalIgnoreCase)))
            {
                return (rowNum, valores);
            }
        }

        return (1, null); // no se encontró, el caller decide qué hacer
    }

    private object? ObtenerValorCelda(IXLCell cell)
    {
        if (cell.IsEmpty()) return null;

        return cell.DataType switch
        {
            XLDataType.Number => cell.GetDouble(),
            XLDataType.DateTime => cell.GetDateTime(),
            XLDataType.Boolean => cell.GetBoolean(),
            _ => cell.GetString().Trim()
        };
    }
}