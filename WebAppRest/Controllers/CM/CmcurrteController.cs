using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppRest.Controllers.CM
{
    [Route("api/cm")]
    [ApiController]
    public class CmcurrteController : ControllerBase
    {
        private readonly ICmcurrteService _cmcurrteService;

        public CmcurrteController(ICmcurrteService cmcurrteService)
        {
            _cmcurrteService = cmcurrteService;
        }
        [Authorize]
        [HttpPost("currency")]
        public async Task<IActionResult> GetTiposCambioPeriodo(CmcurrteDTO parametros)
        {
            var cmcurrte = await _cmcurrteService.F_ListarTiposCambio(parametros);
            return Ok(cmcurrte);
        }
    }
}
