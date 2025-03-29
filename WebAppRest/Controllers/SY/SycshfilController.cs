using BusinessEntity.Data.Models;
using BusinessLogic.Services;
using Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppRest.Controllers.SY
{
    [Route("api/sy/accounts/cash")]
    [ApiController]
    public class SycshfilController : ControllerBase
    {
        private readonly SycshfilService _sycshfilService;
        public SycshfilController(SycshfilService sycshfilService){
            _sycshfilService = sycshfilService;
        }
        [Authorize]
        [HttpGet("{mnNo}/{sbNo}/{dpNo}")]
        public async Task<IActionResult> GetCuenta(string mnNo, string sbNo, string dpNo)
        {
            SycshfilTDO parametros = new SycshfilTDO();
            parametros.MnNo = mnNo;
            parametros.SbNo = sbNo;
            parametros.DpNo = dpNo;
            var consulta = await _sycshfilService.F_ListarCuenta(parametros);
            return Ok(consulta);
        }
    }
}
