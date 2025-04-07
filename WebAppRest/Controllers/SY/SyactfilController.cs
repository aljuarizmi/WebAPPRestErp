using BusinessLogic.Interfaces;
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
        private readonly ISyactfilService _syactfilService;
        public SyactfilController(ISyactfilService syactfilService){
            _syactfilService = syactfilService;
        }
        /// <summary>
        /// Lista una cuenta contable por ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCuenta(string Id)
        {
            SyactfilTDO parametros = new SyactfilTDO();
            if (string.IsNullOrEmpty(Id)) {
                return BadRequest("El codigo de cuenta debe tener un valor");
            } else {
                if (Id.Trim().Length < 24) {
                    return BadRequest("El codigo de cuenta debe tener un valor igual a 24 caracteres");
                } else {
                    parametros.MnNo = Id.Substring(0, 8);
                    parametros.SbNo = Id.Substring(8, 8);
                    parametros.DpNo = Id.Substring(16, 8);
                }
            }
            var consulta = await _syactfilService.F_ListarCuenta(parametros);
            return Ok(consulta);
        }
    }
}
