using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Common.Services;
using Common.ViewModels;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace WebAppRest.Controllers.SY
{
    [Route("api/sy/managment")]
    [ApiController]
    public class SqlsrchController : ControllerBase
    {
        //private readonly ConnectionManager _connectionmanager;
        private readonly SqlsrchService _sqlsrchService;
        //private readonly ISyactfilService _syactfilService;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly CmcurrteService _cmcurrteService;
        //private readonly CmcurratService _cmcurratService;
        //private readonly IConfiguration _configuration;
        public SqlsrchController(ConnectionManager connectionmanager, SqlsrchService sqlsrchService, IHttpContextAccessor httpContextAccessor, CmcurrteService cmcurrteService, CmcurratService cmcurratService, IConfiguration configuration,ISyactfilService syactfilService)
        {
            //_connectionmanager = connectionmanager;
            _sqlsrchService = sqlsrchService;
            //_httpContextAccessor = httpContextAccessor;
            //_cmcurrteService = cmcurrteService;
            //_cmcurratService = cmcurratService;
            //_configuration = configuration;
        }
        /// <summary>
        /// Lista los datos segun el buscador seleccionado
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("search")]
        public async Task<IActionResult> GetConsultaDatos(SqlsrchDTO parametros)
        {
            SqlsrchDTO consulta = new SqlsrchDTO();
            //Consulta los datos para llenar en la grilla
            consulta =await _sqlsrchService.F_Buscar(parametros);
            return Ok(consulta);
        }
        /// <summary>
        /// Busca un código ingresado en el buscador
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("searchCodigo")]
        public async Task<IActionResult> GetConsultaCodigo(SqlsrchDTO parametros)
        {
            IDictionary<string, object> consulta;
            //Consulta el codigo ingresado o seleccionado en el buscador
            consulta = await _sqlsrchService.F_BuscarCodigo(parametros);
            return Ok(consulta);
        }
        /// <summary>
        /// Lista todos los buscadores configurados por un mismo ID
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("searchers")]
        public async Task<IActionResult> GetConsultaBuscadores(SqlsrchDTO parametros)
        {
            //Consulta la lista de buscadores
            var consulta = await _sqlsrchService.F_ListarBuscadores(parametros);
            return Ok(consulta);
        }
    }
}
