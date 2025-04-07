using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Common.Services;
using Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace WebAppRest.Controllers.SY
{
    [Route("api/sy/access")]
    [ApiController]
    public class SygenopcController : ControllerBase
    {
        private readonly ConnectionManager _connectionmanager;
        private readonly ISygenopcService _sygenopcService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CmcurrteService _cmcurrteService;
        private readonly CmcurratService _cmcurratService;
        private readonly IConfiguration _configuration;
        public SygenopcController(ConnectionManager connectionmanager, ISygenopcService sygenopcService, IHttpContextAccessor httpContextAccessor, CmcurrteService cmcurrteService, CmcurratService cmcurratService, IConfiguration configuration)
        {
            _connectionmanager = connectionmanager;
            _sygenopcService = sygenopcService;
            _httpContextAccessor = httpContextAccessor;
            _cmcurrteService = cmcurrteService;
            _cmcurratService = cmcurratService;
            _configuration = configuration;
        }
        /// <summary>
        /// Lista todos los accesos disponibles en el sistema (para asignación de permisos en el administrador)
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAccesos()
        {
            IEnumerable<IDictionary<string, object>> opciones = new List<IDictionary<string, object>>();
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            _connectionmanager.SERVER_NAME = identity?.Claims.FirstOrDefault(c => c.Type == "SERVER_NAME")?.Value;
            opciones = await _sygenopcService.F_ListarAccesos(_connectionmanager);
            List<SygenopcDTO> nodos = _sygenopcService.F_ArmarMenu(opciones);
            return Ok(nodos);
        }
        /// <summary>
        /// Lista las opciones que puede usar un usuario (para el menú principal)
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("users/{userId}/menu")]
        public async Task<IActionResult> GetAccesosUsuarioSistema(string userId){
            IEnumerable<IDictionary<string, object>> opciones = new List<IDictionary<string, object>>();
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            _connectionmanager.SERVER_NAME = identity?.Claims.FirstOrDefault(c => c.Type == "SERVER_NAME")?.Value;
            SygenacsDTO parametros = new SygenacsDTO();
            parametros.SyUser = identity?.Claims.FirstOrDefault(c => c.Type == "USER_NAME")?.Value;
            parametros.SyCompany = identity?.Claims.FirstOrDefault(c => c.Type == "DB_NUMBER")?.Value;
            opciones = await _sygenopcService.F_ListarAccesosUsuarioSistema(parametros, _connectionmanager);
            CmcurrteDTO cmcurrte = new CmcurrteDTO();
            CmcurratDTO cmcurrat = new CmcurratDTO();
            cmcurrte.RateExtEfe = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
            cmcurrte.RateExtCode = _configuration["CONFIG:TCMONOBLI"];
            cmcurrat.CurrRtEffDt = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
            cmcurrat.CurrCd = _configuration["CONFIG:TCMONOBLI"];
            cmcurrte =await _cmcurrteService.F_ListarTipoCambio(cmcurrte);
            cmcurrat = await _cmcurratService.F_ListarTipoCambio(cmcurrat);
            List<SygenopcDTO> nodos = _sygenopcService.F_ArmarMenuUsuario(opciones, cmcurrte, cmcurrat);
            return Ok(nodos);
        }
        /// <summary>
        /// Lista las opciones configuradas para un usuario (para asignación de permisos en el administrador)
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("users/{userId}/config")]
        public async Task<IActionResult> GetAccesosUsuario(string userId)
        {
            IEnumerable<IDictionary<string, object>> opciones = new List<IDictionary<string, object>>();
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            _connectionmanager.SERVER_NAME = identity?.Claims.FirstOrDefault(c => c.Type == "SERVER_NAME")?.Value;
            SygenacsDTO parametros = new SygenacsDTO();
            parametros.SyUser = userId;
            parametros.SyCompany = identity?.Claims.FirstOrDefault(c => c.Type == "DB_NUMBER")?.Value;
            opciones = await _sygenopcService.F_ListarAccesosUsuario(parametros, _connectionmanager);
            return Ok(opciones);
        }
    }
}
