using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.ViewModels;
using BusinessEntity.Data.Models;
using ClosedXML.Excel;


namespace WebAppRest.Controllers.AP.Maintenance
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApvenfilController : ControllerBase
    {
        private readonly ApvenfilService _apvenfilService;
        public ApvenfilController(ApvenfilService apvenfilService)
        {
            _apvenfilService = apvenfilService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertarProveedor([FromBody] InsertarProveedor request)
        {
            if (request.Apvenfil == null || request.Apvenext == null)
                return BadRequest("Los datos del proveedor y son obligatorios.");

            var resultado = await _apvenfilService.F_InsertarProveedor(request.Apvenfil, request.Apvenext);

            if (resultado <= 0)
                return StatusCode(500, "Error al insertar el proveedor.");

            return Ok("Proveedor insertado correctamente.");
        }

        [HttpGet("exportar-excel")]
        public async Task<IActionResult> ExportarExcel()
        {
            // 1️⃣ Obtener los datos de la base de datos
            var proveedores = await _apvenfilService.F_ListarProveedores();

            // 2️⃣ Crear el archivo Excel
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Proveedores");

            var propiedades = typeof(ApvenfilDTO).GetProperties();
            int columna = 1;

            foreach (var prop in propiedades){
                worksheet.Cell(1, columna).Value = prop.Name; // Nombre de la propiedad como encabezado
                worksheet.Cell(1, columna).Style.Font.Bold = true;
                worksheet.Cell(1, columna).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(1, columna).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                columna++;
            }
            // Rellenar con datos
            int fila = 2;
            foreach (var proveedor in proveedores){
                columna = 1;
                foreach (var prop in propiedades){
                    var valor = prop.GetValue(proveedor) ?? ""; // Obtener valor de la propiedad
                    worksheet.Cell(fila, columna).Value = valor.ToString();
                    columna++;
                }
                fila++;
            }

            // 3️⃣ Guardar el archivo en memoria
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            // 4️⃣ Devolver el archivo como respuesta HTTP
            return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Reporte_Proveedores.xlsx");
        }
    }
}
