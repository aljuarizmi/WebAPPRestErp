﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.ViewModels;
using BusinessLogic.Services;
using Common.Services;

namespace WebAppRest.Controllers.SY
{
    /// <summary>
    /// Controlador para consultar los servidores disponibles
    /// </summary>
    [Route("api/servers")]
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
        [HttpGet]
        public IEnumerable<ServerInfo> GetServerInfo() {
            string? servers = _configuration["Credenciales:Servers"];
            servers = servers == null ? "|" : servers;
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
            return serverList;
        }
        /// <summary>
        /// Devuelve la lista de empresas por grupo
        /// </summary>
        /// <param name="grp_id"></param>
        /// <returns></returns>
        [HttpGet("{grp_id}/companies")]
        public async Task<IEnumerable<IDictionary<string, object>>> GetCompanyInfo(int? grp_id)
        {
            IEnumerable<IDictionary<string, object>> companies = new List<IDictionary<string, object>>();
            if (grp_id != null) {
                SygendbcDTO parametros = new SygendbcDTO();
                parametros.BizGrpId = grp_id;
                parametros.SyCompany = null;
                parametros.PageSize = 0;
                parametros.PageIndex = -1;
                parametros.OrderColumn = "sy_company";
                companies = await _sygendbcService.F_ListarEmpresas(parametros, _connectionmanager);
            }
            return companies;
        }
    }
}
