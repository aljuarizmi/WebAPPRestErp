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
            List<SygenacsDTO> resultado = new List<SygenacsDTO>();
            resultado = _sygenacsService.MapearSygenacsDTO(companies);
            return Ok(resultado);
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
            opciones = await _sygenacsService.F_ListarAccesosUsuario(parametros, _connectionmanager);
            List<SygenacsDTO> resultado = new List<SygenacsDTO>();
            resultado = _sygenacsService.MapearSygenacsDTO(opciones);
            return Ok(resultado);
        }
        [Authorize]
        [HttpPost("users/{userId}/config")]
        public async Task<IActionResult> InsertarAccesosUsuario(string userId, SygenacsDTO parametros)
        {
            //IEnumerable<IDictionary<string, object>> opciones = new List<IDictionary<string, object>>();
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            _connectionmanager.SERVER_NAME = identity?.Claims.FirstOrDefault(c => c.Type == "SERVER_NAME")?.Value;
            //SygenacsDTO parametros = new SygenacsDTO();
            parametros.SyUser = userId;
            parametros.SyCompany = identity?.Claims.FirstOrDefault(c => c.Type == "DB_NUMBER")?.Value;
            //opciones = await _sygenacsService.F_ListarAccesosUsuario(parametros, _connectionmanager);
            List<SygenacsDTO> resultado = new List<SygenacsDTO>();
            parametros.DatosXml = _sygenacsService.SerializarSygenacsDTO(parametros.Accesos);
            bool proceso = await _sygenacsService.F_AgregarAccesosUsuario(parametros, _connectionmanager);
            return Ok(proceso);
        }
    }
}
