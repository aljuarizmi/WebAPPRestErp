using BusinessEntity.Data.Models;
using BusinessLogic.Services;
using Common.Services;
using Common.ViewModels;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebAppRest.Controllers.SY
{
    [Route("api/sy/companies")]
    [ApiController]
    public class CompfileController : ControllerBase
    {
        private readonly CompfileService _compfileService;
        public CompfileController(CompfileService compfileService){
            _compfileService = compfileService;
        }
        /// <summary>
        /// Lista la configuracion de la compañía/empresa
        /// </summary>
        /// <param name="CompKey1"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{CompKey1}")]
        public async Task<IActionResult> GetCompania(string CompKey1){
            CompfileSql parametros = new CompfileSql();
            parametros.CompKey1 = CompKey1;
            var consulta = await _compfileService.F_ListarUno(parametros);
            return Ok(consulta);
        }
        /// <summary>
        /// Actualiza los datos de configuración de la compañía/empresa
        /// </summary>
        /// <param name="CompKey1"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{CompKey1}")]
        public async Task<IActionResult> UpdCompania(string CompKey1, [FromBody]CompfileSql parametros){
            parametros.CompKey1 = CompKey1;
            bool consulta = await _compfileService.F_Actualizar(parametros);
            return Ok(consulta);
        }
    }
}
