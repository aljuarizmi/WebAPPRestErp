using BusinessEntity.Data.Models;
using BusinessLogic.Services;
using Common.Utils;
using Common.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace WebAppRest.Controllers.AP.Maintenance
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApvenfilController : ControllerBase
    {
        private readonly ApvenfilService _apvenfilService;
        private readonly ExcelService _excelService;
        public ApvenfilController(ApvenfilService apvenfilService, ExcelService excelService)
        {
            _apvenfilService = apvenfilService;
            _excelService = excelService;
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
            // 1 Obtener los datos de la base de datos
            var proveedores = await _apvenfilService.F_ListarProveedores();

            if (proveedores == null || !proveedores.Any())
                return BadRequest("No hay datos para exportar.");
            var propiedades = typeof(ApvenfilDTO).GetProperties();
            string nombreHoja = "Reporte_Proveedores";
            string nombreReporte = nombreHoja + "_" + DateTime.Now.ToString("yyyyMMdd_mmss");
            string contentType = MimeType.Xlsx.GetMimeType();
            var archivoExcel = _excelService.GenerarExcel(proveedores, propiedades, nombreHoja);
            // Devolver el archivo como respuesta HTTP
            return File(archivoExcel, contentType, nombreReporte + ".xlsx");
        }
    }
}
