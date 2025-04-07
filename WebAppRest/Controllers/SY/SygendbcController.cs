using BusinessLogic.Interfaces;
using Common.Services;
using Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAppRest.Controllers.SY
{
    [Route("api/sy/access")]
    [ApiController]
    public class SygendbcController : ControllerBase
    {
        private readonly ISygendbcService _sygendbcService;
        private readonly ConnectionManager _connectionmanager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SygendbcController(ISygendbcService sygendbcService, ConnectionManager connectionmanager, IHttpContextAccessor httpContextAccessor)
        {
            _sygendbcService = sygendbcService;
            _connectionmanager = connectionmanager;
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// Lista las empresas/compañías por servidor
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("companies")]
        public async Task<IActionResult> GetGrupoEmpresas()
        {
            IEnumerable<IDictionary<string, object>> companies = new List<IDictionary<string, object>>();
            SygendbcDTO parametros = new SygendbcDTO();
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            _connectionmanager.SERVER_NAME = identity?.Claims.FirstOrDefault(c => c.Type == "SERVER_NAME")?.Value;
            parametros.BizGrpId = Convert.ToInt32(identity?.Claims.FirstOrDefault(c => c.Type == "BIZ_GRP_ID")?.Value);
            parametros.SyCompany = null;
            parametros.PageSize = 10;
            parametros.PageIndex = -1;
            parametros.OrderColumn = "sy_company";
            List<SygendbcDTO> resultado = new List<SygendbcDTO>();
            companies = await _sygendbcService.F_ListarEmpresas(parametros, _connectionmanager);
            resultado=_sygendbcService.MapearSygendbcDTO(companies);
            return Ok(resultado);
        }
    }
}
