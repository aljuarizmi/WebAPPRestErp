using BusinessLogic.Interfaces;
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
    [Route("api/sy/access")]
    [ApiController]
    public class SygenusrController : ControllerBase
    {
        private readonly ISygenusrService _sygenusrService;
        private readonly ConnectionManager _connectionmanager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SygenusrController(ISygenusrService sygenusrService, ConnectionManager connectionmanager, IHttpContextAccessor httpContextAccessor)
        {
            _sygenusrService = sygenusrService;
            _connectionmanager = connectionmanager;
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// Lista de usuarios por empresa/compañía. Es la cantidad de usuarios configurados en la empresa
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("users")]
        public async Task<IActionResult> GetGrupoUsuarios()
        {
            IEnumerable<IDictionary<string, object>> companies = new List<IDictionary<string, object>>();
            SygenusrDTO parametros = new SygenusrDTO();
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            _connectionmanager.SERVER_NAME = identity?.Claims.FirstOrDefault(c => c.Type == "SERVER_NAME")?.Value;
            parametros.BizGrpId = Convert.ToInt32(identity?.Claims.FirstOrDefault(c => c.Type == "BIZ_GRP_ID")?.Value);
            companies = await _sygenusrService.F_ListarUsuarioGrupo(parametros, _connectionmanager);
            List<SygenusrDTO> resultado = new List<SygenusrDTO>();
            resultado = _sygenusrService.MapearSygenusrDTO(companies);
            return Ok(resultado);
        }
    }
}
