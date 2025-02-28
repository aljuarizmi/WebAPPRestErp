using ClosedXML.Excel;
using System.Reflection;
//using OfficeOpenXml;
//using OfficeOpenXml.Style;

public class ExcelService
{
    /// <summary>
    /// Funcion que genera un archivo excel a partir de la consulta de datos
    /// </summary>
    /// <typeparam name="T">Objeto del tipo lista generica no editable</typeparam>
    /// <param name="datos">Parametro que contiene los datos a exportar</param>
    /// <param name="propiedades">Parametro que contiene los nombres de los encabezados</param>
    /// <param name="nombreHoja">Parametro que contiene el nombre de la hoja/sheet a crear</param>
    /// <returns>Retorna un objeto de tipo byte[] que contiene los datos del excel generado</returns>
    public byte[] GenerarExcel<T>(IEnumerable<T> datos, PropertyInfo[] propiedades, string nombreHoja)
    {

        nombreHoja = System.Text.RegularExpressions.Regex.Replace(nombreHoja, @"[\\\/\?\*\[\]\:]", "");
        if (nombreHoja.Length > 31)
        {
            nombreHoja = nombreHoja.Substring(0, 31);
        }
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add(nombreHoja);

        int columna = 1;//A partir de la columna 1 y hasta la cantidad de atributos de la consulta va el encabezado
        foreach (var prop in propiedades)
        {
            worksheet.Cell(1, columna).Value = prop.Name; // Nombre de la propiedad como encabezado
            worksheet.Cell(1, columna).Style.Font.Bold = true;
            worksheet.Cell(1, columna).Style.Fill.BackgroundColor = XLColor.LightGray;
            worksheet.Cell(1, columna).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell(1, columna).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(1, columna).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            columna++;
        }
        // 3 Rellenar con datos
        int fila = 2;//A partir de la fila 2 en adelante van los datos de la consulta
        foreach (var proveedor in datos)
        {
            columna = 1;
            foreach (var prop in propiedades)
            {
                var valor = prop.GetValue(proveedor) ?? ""; // Obtener valor de la propiedad
                worksheet.Cell(fila, columna).Value = valor.ToString();
                columna++;
            }
            fila++;
        }
        // 4 Guardar el archivo en memoria
        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        stream.Position = 0;
        return stream.ToArray();
    }
    /// <summary>
    /// Funcion que genera un archivo excel a partir de la consulta de datos
    /// </summary>
    /// <param name="datos">Parametro que contiene los datos a exportar</param>
    /// <param name="nombreHoja">Parametro que contiene el nombre de la hoja/sheet a crear</param>
    /// <returns>Retorna un objeto de tipo byte[] que contiene los datos del excel generado</returns>
    /// <exception cref="Exception"></exception>
    public byte[] GenerarExcelDinamico(IEnumerable<IDictionary<string, object>> datos, string nombreHoja)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add(nombreHoja);

        if (!datos.Any())
            throw new Exception("No hay datos para exportar.");

        // Obtener todas las claves del primer elemento (encabezados)
        var encabezados = datos.First().Keys.ToList();

        // Crear encabezados en la primera fila
        for (int i = 0; i < encabezados.Count; i++)
        {
            worksheet.Cell(1, i + 1).Value = encabezados[i];
            worksheet.Cell(1, i + 1).Style.Font.Bold = true;
            worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
            worksheet.Cell(1, i + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(1, i + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        }

        // Llenar los datos
        int row = 2;
        foreach (var fila in datos)
        {
            for (int col = 0; col < encabezados.Count; col++)
            {
                var key = encabezados[col];
                var valor = fila.ContainsKey(key) ? fila[key]?.ToString() ?? "" : "";
                worksheet.Cell(row, col + 1).Value = valor;
            }
            row++;
        }

        // Autoajustar las columnas al contenido
        worksheet.Columns().AdjustToContents();

        // Guardar el archivo en memoria y devolverlo como array de bytes
        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }
}