using BusinessLogic.Interfaces;
using BusinessLogic.Services;
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
    public class SygenacsController : ControllerBase
    {
        private readonly ISygenacsService _sygenacsService;
        private readonly ConnectionManager _connectionmanager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SygenacsController(ISygenacsService sygenacsService, ConnectionManager connectionmanager, IHttpContextAccessor httpContextAccessor)
        {
            _sygenacsService = sygenacsService;
            _connectionmanager = connectionmanager;
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// Lista las empresas/compañías por usuario. Es la cantidad de empresas a la que puede acceder un usuario
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("users/{userId}/companies")]
        public async Task<IActionResult> GetEmpresasUsuario(string userId)
        {
            IEnumerable<IDictionary<string, object>> companies = new List<IDictionary<string, object>>();
            SygenacsDTO parametros = new SygenacsDTO();
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            _connectionmanager.SERVER_NAME = identity?.Claims.FirstOrDefault(c => c.Type == "SERVER_NAME")?.Value;
            parametros.SyUser = userId;
            companies = await _sygenacsService.F_ListarEmpresasUsuario(parametros, _connectionmanager);
            return Ok(companies);
        }
    }
}
