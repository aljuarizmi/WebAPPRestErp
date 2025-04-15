using BusinessData.Interfaces;
using BusinessLogic.Interfaces;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CmcurrteService: ICmcurrteService
    {
        private readonly ICmcurrteRepository _repository;
        public CmcurrteService(ICmcurrteRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarTipoCambio(CmcurrteDTO parametros) => await _repository.F_ListarTipoCambio(parametros);
        public async Task<bool> F_AgregarTipoCambio(CmcurrteDTO parametros) => await _repository.F_AgregarTipoCambio(parametros);
        public async Task<bool> F_ActualizarTipoCambio(CmcurrteDTO parametros) => await _repository.F_ActualizarTipoCambio(parametros);
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarTiposCambio(CmcurrteDTO parametros) => await _repository.F_ListarTiposCambio(parametros);
        public List<CmcurrteDTO> MapearCmcurrteDTO(IEnumerable<IDictionary<string, object>> data)
        {
            List<CmcurrteDTO> result = new List<CmcurrteDTO>();
            foreach (var item in data)
            {
                CmcurrteDTO dto = new CmcurrteDTO
                {
                    RateExtCode = item.ContainsKey("rate_ext_code") ? item["rate_ext_code"] as string : null,
                    RateExtEfe = item.ContainsKey("rate_ext_efe") ? item["rate_ext_efe"] as int? : null,
                    RateVenDia = item.ContainsKey("rate_ven_dia") ? item["rate_ven_dia"] as decimal? : null,
                    RateComPub = item.ContainsKey("rate_com_pub") ? item["rate_com_pub"] as decimal? : null,
                    RateVenPub = item.ContainsKey("rate_ven_pub") ? item["rate_ven_pub"] as decimal? : null,
                    RateComPro = item.ContainsKey("rate_com_pro") ? item["rate_com_pro"] as decimal? : null,
                    RateVenPro = item.ContainsKey("rate_ven_pro") ? item["rate_ven_pro"] as decimal? : null,
                    RateComCanc = item.ContainsKey("rate_com_canc") ? item["rate_com_canc"] as decimal? : null,
                    RateVenCanc = item.ContainsKey("rate_ven_canc") ? item["rate_ven_canc"] as decimal? : null,
                    CurrRt = item.ContainsKey("curr_rt") ? item["curr_rt"] as decimal? : null,
                    CurrCd = item.ContainsKey("curr_cd") ? item["curr_cd"] as string : null,
                    CurrRtEffDt = item.ContainsKey("curr_rt_eff_dt") ? item["curr_rt_eff_dt"] as int? : null,
                    totalReg = item.ContainsKey("totalReg") ? item["totalReg"] as int? : null
                };
                result.Add(dto);
            }
            return result;
        }
    }
}
