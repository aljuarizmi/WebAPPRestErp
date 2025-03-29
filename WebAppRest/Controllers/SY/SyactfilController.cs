using BusinessLogic.Services;
using Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppRest.Controllers.SY
{
    [Route("api/sy/accounts")]
    [ApiController]
    public class SyactfilController : ControllerBase
    {
        private readonly SyactfilService _syactfilService;
        public SyactfilController(SyactfilService syactfilService){
            _syactfilService = syactfilService;
        }
        [Authorize]
        [HttpGet("{mnNo}/{sbNo}/{dpNo}")]
        public async Task<IActionResult> GetCuenta(string mnNo, string sbNo, string dpNo)
        {
            SyactfilTDO parametros = new SyactfilTDO();
            parametros.MnNo = mnNo;
            parametros.SbNo = sbNo;
            parametros.DpNo = dpNo;
            var consulta = await _syactfilService.F_ListarCuenta(parametros);
            return Ok(consulta);
        }
    }
}
