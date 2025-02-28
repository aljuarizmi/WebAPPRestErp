using BusinessLogic.Services;
using Common.Utils;
using Common.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAppRest.Controllers.AP
{
    /// <summary>
    /// controlador de la clase apopnfil
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApopnfilController : ControllerBase
    {
        private readonly ApopnfilService _apopnfilService;
        private readonly ExcelService _excelService;
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apopnfilService"></param>
        /// <param name="excelService"></param>
        /// <param name="configuration"></param>
        public ApopnfilController(ApopnfilService apopnfilService, ExcelService excelService, IConfiguration configuration)
        {
            _apopnfilService = apopnfilService;
            _excelService = excelService;
            _configuration = configuration;
        }
        /// <summary>
        /// Funcion que devuelve la consulta de documentos en un archivo excel
        /// </summary>
        /// <param name="parametros">Lista de parametros que contiene los filtros a usar en la consulta</param>
        /// <returns>Devuelve un objeto que contiene el archivo excel para su descarga</returns>
        [HttpPost("exportar-excel")]
        public async Task<IActionResult> ExportarExcel([FromBody] ApopnfilDTO parametros)
        {
            // 1 Obtener los datos de la base de datos
            //string? cadena = CryptoService.Decrypt(_configuration["Credenciales:SU_Clave"]);
            parametros.TipoFg = "H";
            parametros.VendNo = "000000012960";
            parametros.PageIndex = 0;
            parametros.PageSize = 100;
            parametros.OrderColumn = "";
            var documentos = await _apopnfilService.F_ListarDocumentosDapper(parametros);
            if (documentos == null || !documentos.Any())
                return BadRequest("No hay datos para exportar.");
            string nombreHoja = "Reporte_Documentos";
            string nombreReporte = nombreHoja + "_" + DateTime.Now.ToString("yyyyMMdd_mmss");
            string contentType = MimeType.Xlsx.GetMimeType();
            var archivoExcel = _excelService.GenerarExcelDinamico(documentos, nombreHoja);
            // Devolver el archivo como respuesta HTTP
            return File(archivoExcel, contentType, nombreReporte + ".xlsx");
        }
    }
}
