using BusinessLogic.Services;
using Common.Services;
using Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace WebAppRest.Controllers.SY
{
    [Route("api/[controller]")]
    [ApiController]
    public class SygenopcController : ControllerBase
    {
        private readonly ConnectionManager _connectionmanager;
        private readonly SygenopcService _sygenopcService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CmcurrteService _cmcurrteService;
        private readonly CmcurratService _cmcurratService;
        private readonly IConfiguration _configuration;
        public SygenopcController(ConnectionManager connectionmanager, SygenopcService sygenopcService, IHttpContextAccessor httpContextAccessor, CmcurrteService cmcurrteService, CmcurratService cmcurratService, IConfiguration configuration)
        {
            _connectionmanager = connectionmanager;
            _sygenopcService = sygenopcService;
            _httpContextAccessor = httpContextAccessor;
            _cmcurrteService = cmcurrteService;
            _cmcurratService = cmcurratService;
            _configuration = configuration;
        }
        [Authorize]
        [HttpPost("accesos")]
        public async Task<IActionResult> GetOpcionesMenu(SygenacsDTO parametros){
            IEnumerable<IDictionary<string, object>> opciones = new List<IDictionary<string, object>>();
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            _connectionmanager.SERVER_NAME = identity?.Claims.FirstOrDefault(c => c.Type == "SERVER_NAME")?.Value;
            parametros.SyUser = identity?.Claims.FirstOrDefault(c => c.Type == "USER_ID")?.Value;
            parametros.SyCompany = identity?.Claims.FirstOrDefault(c => c.Type == "DB_NUMBER")?.Value;
            opciones = await _sygenopcService.F_ListarMenu(parametros, _connectionmanager);
            CmcurrteDTO cmcurrte = new CmcurrteDTO();
            CmcurratDTO cmcurrat = new CmcurratDTO();
            cmcurrte.RateExtEfe = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
            cmcurrte.RateExtCode = _configuration["CONFIG:TCMONOBLI"];
            cmcurrat.CurrRtEffDt = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
            cmcurrat.CurrCd = _configuration["CONFIG:TCMONOBLI"];
            cmcurrte =await _cmcurrteService.F_ListarTipoCambio(cmcurrte);
            cmcurrat = await _cmcurratService.F_ListarTipoCambio(cmcurrat);
            List<SygenopcDTO> nodos = await _sygenopcService.F_ArmarMenu(opciones, cmcurrte, cmcurrat);
            return Ok(nodos);
        }
    }
}
