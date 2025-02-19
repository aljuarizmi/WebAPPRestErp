
using ClosedXML.Excel;
using Common.ViewModels;
using System.Reflection;

public class ExcelService {
    /// <summary>
    /// Funcion que genera un archivo excel a partir de la consulta de datos
    /// </summary>
    /// <typeparam name="T">Objeto del tipo lista generica no editable</typeparam>
    /// <param name="datos">Parametro que contiene los datos a exportar</param>
    /// <returns></returns>
    public byte[] GenerarExcel<T>(IEnumerable<T> datos, PropertyInfo[] propiedades, string nombreHoja) {

        nombreHoja = System.Text.RegularExpressions.Regex.Replace(nombreHoja, @"[\\\/\?\*\[\]\:]", "");
        if (nombreHoja.Length > 31) {
            nombreHoja = nombreHoja.Substring(0, 31);
        }
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add(nombreHoja);

        int columna = 1;//A partir de la columna 1 y hasta la cantidad de atributos de la consulta va el encabezado
        foreach (var prop in propiedades){
            worksheet.Cell(1, columna).Value = prop.Name; // Nombre de la propiedad como encabezado
            worksheet.Cell(1, columna).Style.Font.Bold = true;
            worksheet.Cell(1, columna).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell(1, columna).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            columna++;
        }
        // 3 Rellenar con datos
        int fila = 2;//A partir de la fila 2 en adelante van los datos de la consulta
        foreach (var proveedor in datos){
            columna = 1;
            foreach (var prop in propiedades){
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
}