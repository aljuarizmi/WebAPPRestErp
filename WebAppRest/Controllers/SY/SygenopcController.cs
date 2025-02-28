using BusinessLogic.Services;
using Common.Services;
using Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public SygenopcController(ConnectionManager connectionmanager, SygenopcService sygenopcService, IHttpContextAccessor httpContextAccessor)
        {
            _connectionmanager = connectionmanager;
            _sygenopcService = sygenopcService;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize]
        [HttpPost("accesos")]
        public async Task<IEnumerable<IDictionary<string, object>>> GetOpcionesMenu(SygenacsDTO parametros)
        {
            IEnumerable<IDictionary<string, object>> opciones = new List<IDictionary<string, object>>();
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            //SygenopcDTO parametros = new SygenopcDTO();
            //parametros.BizGrpId = grp_id;
            //parametros.SyCompany = null;
            //parametros.PageSize = 0;
            //parametros.PageIndex = -1;
            //parametros.OrderColumn = "sy_company";
            _connectionmanager.SERVER_NAME = identity?.Claims.FirstOrDefault(c => c.Type == "SERVER_NAME")?.Value; ;
            opciones = await _sygenopcService.F_ListarMenu(parametros, _connectionmanager);
            return opciones;
        }
    }
}
