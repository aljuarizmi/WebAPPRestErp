using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Common.Interfaces;
using Common.ViewModels;
using DocumentFormat.OpenXml.Wordprocessing;
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
        private readonly ISunatService _isunatService;

        public CmcurrteController(ICmcurrteService cmcurrteService, ISunatService isunatService)
        {
            _cmcurrteService = cmcurrteService;
            _isunatService = isunatService;
        }
        [Authorize]
        [HttpGet("exchange-rates/{periodo}")]
        public async Task<IActionResult> GetTiposCambioPeriodo(string periodo, [FromQuery] int pageSize, [FromQuery] int pageIndex, [FromQuery] string? orderColumn=null)
        {
            CmcurrteDTO parametros=new CmcurrteDTO();
            if (periodo != null) {
                if (periodo.Trim() != "") {
                    if (periodo.Trim().Length < 6) { 
                    }
                }
            }
            parametros.RateExtEfe = Convert.ToInt32(periodo);
            parametros.PageIndex = pageIndex;
            parametros.PageSize = pageSize;
            parametros.Ordercolumn = orderColumn;
            var cmcurrte = await _cmcurrteService.F_ListarTiposCambio(parametros);
            var listacmcurrte = _cmcurrteService.MapearCmcurrteDTO(cmcurrte);
            return Ok(listacmcurrte);
        }
        [Authorize]
        [HttpGet("exchange-rates/sunat/{fecha}")]
        public async Task<IActionResult> GetTipoCambioSunat(string fecha)
        {
            if (DateTime.TryParse(fecha, out DateTime fechaDate)){
                fecha = fechaDate.Year.ToString() + "-" + fechaDate.Month.ToString() + "-" + fechaDate.Day.ToString();
                var cmcurrte = await _isunatService.ConsultaSUNAT(fecha, EnumTipoDato.TipoCambio);
                return Ok(cmcurrte);
            }else { 
                return BadRequest("La fecha debe tener el formato yyyyMMdd");
            }
                
            
        }
    }
}
