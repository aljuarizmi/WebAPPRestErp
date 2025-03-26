using BusinessEntity.Data.Models;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppRest.Controllers.SY
{
    [Route("api/sy/periods")]
    [ApiController]
    public class SyprdfilController : ControllerBase
    {
        private readonly SyprdfilService _syprdfilService;
        public SyprdfilController(SyprdfilService syprdfilService)
        {
            _syprdfilService = syprdfilService;
        }
        [Authorize]
        [HttpGet("{PrdKey}")]
        public async Task<IActionResult> GetPeriodo(string PrdKey)
        {
            SyprdfilSql parametros = new SyprdfilSql();
            parametros.PrdKey = PrdKey;
            var consulta = await _syprdfilService.F_ListarUno(parametros);
            return Ok(consulta);
        }
        [Authorize]
        [HttpPut("{PrdKey}")]
        public async Task<IActionResult> UpdPeriodo(string PrdKey, [FromBody] SyprdfilSql parametros){
            parametros.PrdKey = PrdKey;
            bool consulta = await _syprdfilService.F_ActualizarPeriodo(parametros);
            return Ok(consulta);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> InsPeriodo([FromBody] SyprdfilSql parametros){
            bool consulta = await _syprdfilService.F_InsertarPeriodo(parametros);
            return Ok(consulta);
        }
    }
}
