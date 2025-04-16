using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Common.Interfaces;
using Common.ViewModels;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
            if (periodo != null)
            {
                if (periodo.Trim() != "")
                {
                    if (periodo.Trim().Length == 6)
                    {
                        parametros.RateExtEfe = Convert.ToInt32(periodo);
                        parametros.PageIndex = pageIndex;
                        parametros.PageSize = pageSize;
                        parametros.Ordercolumn = orderColumn;
                        var cmcurrte = await _cmcurrteService.F_ListarTiposCambio(parametros);
                        var listacmcurrte = _cmcurrteService.MapearCmcurrteDTO(cmcurrte);
                        return Ok(listacmcurrte);
                    }
                    else
                    {
                        return BadRequest("El periodo ingresado debe tener 6 caracteres");
                    }
                }
                else
                {
                    return BadRequest("Debe ingresar el periodo");
                }
            }
            else { return BadRequest("Debe ingresar el periodo"); }
            
        }
        [Authorize]
        [HttpGet("exchange-rates/sunat/{fecha}")]
        public async Task<IActionResult> GetTipoCambioSunat(string fecha)
        {
            if (DateTime.TryParseExact(fecha,"yyyyMMdd",CultureInfo.InvariantCulture,DateTimeStyles.None, out DateTime fechaDate)){
                fecha = fechaDate.Year.ToString() + "-" + fechaDate.Month.ToString().PadLeft(2, '0') + "-" + fechaDate.Day.ToString().PadLeft(2, '0');
                var cmcurrte = await _isunatService.ConsultaSUNAT(fecha, EnumTipoDato.TipoCambio);
                return Ok(cmcurrte);
            }else { 
                return BadRequest("La fecha debe tener el formato yyyyMMdd");
            }
        }
        [Authorize]
        [HttpPost("exchange-rates")]
        public async Task<IActionResult> InsTipoCambio([FromBody] CmcurrteDTO parametros)
        {
            bool consulta = await _cmcurrteService.F_AgregarTipoCambio(parametros);
            return Ok(consulta);
        }
        [Authorize]
        [HttpPut("exchange-rates/{fecha}/{moneda}")]
        public async Task<IActionResult> UpdTipoCambio(string fecha,string moneda, [FromBody]CmcurrteDTO parametros)
        {
            bool consulta = await _cmcurrteService.F_ActualizarTipoCambio(parametros);
            return Ok(consulta);
        }
        [Authorize]
        [HttpDelete("exchange-rates/{fecha}/{moneda}")]
        public async Task<IActionResult> DelTipoCambio(string fecha, string moneda)
        {
            CmcurrteDTO parametros=new CmcurrteDTO();
            parametros.CurrCd = moneda;
            parametros.CurrRtEffDt = Convert.ToInt32(fecha);
            bool consulta = await _cmcurrteService.F_EliminarTipoCambio(parametros);
            return Ok(consulta);
        }
    }
}
