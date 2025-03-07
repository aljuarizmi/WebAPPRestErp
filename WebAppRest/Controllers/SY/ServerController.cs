using BusinessLogic.Services;
using Common.Services;
using Common.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAppRest.Controllers.SY
{
    /// <summary>
    /// Controlador para consultar los servidores disponibles
    /// </summary>
    //[Route("api/servers")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SygendbcService _sygendbcService;
        private readonly SygengadService _sygengadService;
        private readonly ConnectionManager _connectionmanager;
        private readonly AuthService _authService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="sygendbcService"></param>
        public ServerController(IConfiguration configuration, SygendbcService sygendbcService, ConnectionManager connectionmanager, SygengadService sygengadService, AuthService authService)
        {
            _configuration = configuration;
            _sygendbcService = sygendbcService;
            _connectionmanager = connectionmanager;
            _sygengadService = sygengadService;
            _authService = authService;
        }
        /// <summary>
        /// Devuelve la lista de servidores disponibles
        /// </summary>
        /// <returns></returns>
        [Route("api/servers")]
        [HttpGet]
        public IEnumerable<ServerInfo> GetServerInfo()
        {
            string? servers = _configuration["Credenciales:Servers"];
            servers = servers == null ? "|" : servers;
            string[] data = servers.Split("|");
            List<ServerInfo> serverList = new List<ServerInfo>();
            if (data != null){
                if (data.Length > 0){
                    serverList.Add(new ServerInfo
                    {
                        server_id = Convert.ToInt32(data[0]),
                        server_name = data[1]
                    });
                }
            }
            return serverList;
        }
        /// <summary>
        /// Devuelve la lista de empresas por grupo
        /// </summary>
        /// /// <param name="server_name"></param>
        /// <param name="grp_id"></param>
        /// <returns></returns>
        [Route("api/servers/companies")]
        [HttpPost]
        public async Task<IEnumerable<IDictionary<string, object>>> GetCompanyInfo(SygendbcDTO parametros){
            IEnumerable<IDictionary<string, object>> companies = new List<IDictionary<string, object>>();
            if (parametros.BizGrpId != null){
                parametros.SyCompany = null;
                parametros.PageSize = 0;
                parametros.PageIndex = -1;
                parametros.OrderColumn = "sy_company";
                _connectionmanager.SERVER_NAME = parametros.SyServer;
                companies = await _sygendbcService.F_ListarEmpresas(parametros, _connectionmanager);
            }
            return companies;
        }
        [Route("api/auth/login")]
        [HttpPost]
        public async Task<IActionResult> Login(SygengadDTO parametros)
        {
            TokenResponse tokenJwt = new TokenResponse();
            IEnumerable<IDictionary<string, object>> _userInfo = new List<IDictionary<string, object>>();
            if (parametros.BizGrpId != null){
                _connectionmanager.SERVER_NAME = parametros.ServerName;
                _userInfo = await _sygengadService.F_ListarUsuarioGrupo(parametros, _connectionmanager);
                if (_userInfo != null){
                    if (_userInfo.Count() > 0){
                        var userData = _userInfo.FirstOrDefault();
                        string userInfo = userData["sy_user_psc"].ToString();
                        if (parametros.SyUserPsc == userInfo){
                            tokenJwt = _authService.GenerateToken(parametros.SyUser, parametros.SyUserPsc, parametros.ServerName, parametros.DataBase, parametros.SyUser, parametros.SyUser, parametros.BizGrpId.ToString());
                        }else{
                            //La contraseña es incorrecta
                            return BadRequest(new { message = "La contraseña es incorrecta. Por favor verifique sus credenciales de acceso al sistema." });
                        }
                    }else{
                        //No existe el usuario consultado
                        return BadRequest(new { message = "No existe el usuario " + parametros.SyUser + " o no pertenece al grupo empresarial" });
                    }
                }else{
                    //El resultado es nulo
                    return NotFound();
                }
            }
            return Ok(new { token=tokenJwt.Token });
        }
    }
}
