using BusinessEntity.Data.Models;
using BusinessLogic.Interfaces;
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
        private readonly ISycshfilService _sycshfilService;
        public SycshfilController(ISycshfilService sycshfilService){
            _sycshfilService = sycshfilService;
        }
        [Authorize]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCuenta(string Id)
        {
            SycshfilTDO parametros = new SycshfilTDO();
            if (string.IsNullOrEmpty(Id))
            {
                return BadRequest("El codigo de cuenta debe tener un valor");
            }
            else
            {
                if (Id.Trim().Length < 24)
                {
                    return BadRequest("El codigo de cuenta debe tener un valor igual a 24 caracteres");
                }
                else
                {
                    parametros.MnNo = Id.Substring(0, 8);
                    parametros.SbNo = Id.Substring(8, 8);
                    parametros.DpNo = Id.Substring(16, 8);
                }
            }
            var consulta = await _sycshfilService.F_ListarCuenta(parametros);
            return Ok(consulta);
        }
    }
}
