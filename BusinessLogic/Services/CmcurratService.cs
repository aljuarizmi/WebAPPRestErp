using BusinessData.Interfaces;
using BusinessLogic.Interfaces;
using Common.Services;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CmcurratService: ICmcurratService
    {
        private readonly ICmcurratRepository _repository;
        public CmcurratService(ICmcurratRepository repository)
        {
            _repository = repository;
        }
        public async Task<CmcurratDTO> F_ListarTipoCambio(CmcurratDTO parametros) => await _repository.F_ListarTipoCambio(parametros);
        public List<CmcurratDTO> MapearCmcurratDTO(IEnumerable<IDictionary<string, object>> data)
        {
            List<CmcurratDTO> result = new List<CmcurratDTO>();
            foreach (var item in data)
            {
                CmcurratDTO dto = new CmcurratDTO
                {
                    CurrCd = item.ContainsKey("curr_cd") ? item["curr_cd"] as string : null,
                    CurrRtEffDt = item.ContainsKey("curr_rt_eff_dt") ? item["curr_rt_eff_dt"] as int? : null,
                    CurrRt = item.ContainsKey("curr_rt") ? item["curr_rt"] as decimal? : null
                };
                result.Add(dto);
            }
            return result;
        }
    }
}
