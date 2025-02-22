using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.ViewModels;
using BusinessLogic.Services;
using Common.Services;

namespace WebAppRest.Controllers.SY
{
    /// <summary>
    /// Controlador para consultar los servidores disponibles
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SygendbcService _sygendbcService;
        private readonly ConnectionManager _connectionmanager;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="sygendbcService"></param>
        public ServerController(IConfiguration configuration, SygendbcService sygendbcService, ConnectionManager connectionmanager) {
            _configuration = configuration;
            _sygendbcService = sygendbcService;
            _connectionmanager = connectionmanager;
        }
        /// <summary>
        /// Devuelve la lista de servidores disponibles
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IEnumerable<ServerInfo>> GetServerInfo() {
            string? servers = _configuration["Credenciales:Servers"];
            string[] data = servers.Split("|");
            List<ServerInfo> serverList = new List<ServerInfo>();
            if (data != null) {
                if (data.Length > 0) {
                    serverList.Add(new ServerInfo
                    {
                        server_id = Convert.ToInt32(data[0]),
                        server_name = data[1]
                    });
                }
            }
            //ConnectionManager objConexion = _connectionmanager;
            SygendbcDTO parametros = new SygendbcDTO();
            _connectionmanager.SERVER_NAME = data[1];
            parametros.BizGrpId =Convert.ToInt32(data[0]);
            parametros.SyCompany = null;
            parametros.PageSize = 0;
            parametros.PageIndex = -1;
            parametros.OrderColumn = "sy_company";
            serverList[0].empresas =await _sygendbcService.F_ListarEmpresas(parametros, _connectionmanager);
            return serverList;
        }
    }
}
