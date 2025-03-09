using BusinessLogic.Services;
using Common.Services;
using Common.ViewModels;
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
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly CmcurrteService _cmcurrteService;
        //private readonly CmcurratService _cmcurratService;
        //private readonly IConfiguration _configuration;
        public SqlsrchController(ConnectionManager connectionmanager, SqlsrchService sqlsrchService, IHttpContextAccessor httpContextAccessor, CmcurrteService cmcurrteService, CmcurratService cmcurratService, IConfiguration configuration)
        {
            //_connectionmanager = connectionmanager;
            _sqlsrchService = sqlsrchService;
            //_httpContextAccessor = httpContextAccessor;
            //_cmcurrteService = cmcurrteService;
            //_cmcurratService = cmcurratService;
            //_configuration = configuration;
        }
        [Authorize]
        [HttpPost("search")]
        public async Task<IActionResult> GetConsultaDatos(SqlsrchDTO parametros)
        {
            SqlsrchDTO consulta = new SqlsrchDTO();
            consulta =await _sqlsrchService.F_Buscar(parametros);
            return Ok(consulta);
        }
        [Authorize]
        [HttpPost("searchers")]
        public async Task<IActionResult> GetConsultaBuscadores(SqlsrchDTO parametros)
        {
            var consulta = await _sqlsrchService.F_ListarBuscadores(parametros);
            return Ok(consulta);
        }
    }
}
