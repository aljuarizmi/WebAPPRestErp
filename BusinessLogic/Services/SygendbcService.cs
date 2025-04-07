using BusinessData.Interfaces;
using BusinessLogic.Interfaces;
using Common.Services;
using Common.ViewModels;

namespace BusinessLogic.Services
{
    public class SygendbcService : ISygendbcService
    {
        private readonly ISygendbcRepository _repository;
        public SygendbcService(ISygendbcRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarEmpresas(SygendbcDTO parametros, ConnectionManager objConexion) => await _repository.F_ListarEmpresas(parametros, objConexion);

        public List<SygendbcDTO> MapearSygendbcDTO(IEnumerable<IDictionary<string, object>> data)
        {
            List<SygendbcDTO> result = new List<SygendbcDTO>();

            foreach (var item in data)
            {
                SygendbcDTO dto = new SygendbcDTO
                {
                    SyCompanyDescr = item.ContainsKey("sy_company_descr") ? item["sy_company_descr"] as string : null,
                    SyCompany = item.ContainsKey("sy_company") ? item["sy_company"] as string : null,
                    BizGrpId = item.ContainsKey("biz_grp_id") ? item["biz_grp_id"] as int? : null,
                    SyShowLogoFg = item.ContainsKey("sy_show_logo_fg") ? item["sy_show_logo_fg"] as string : null,
                    SyCompanyLogo = item.ContainsKey("sy_company_logo") ? item["sy_company_logo"] as string : null,
                    SyDoi = item.ContainsKey("sy_doi") ? item["sy_doi"] as string : null,
                    SyShowFg = item.ContainsKey("sy_show_fg") ? item["sy_show_fg"] as string : null,
                    SyDoiFg = item.ContainsKey("sy_doi_fg") ? item["sy_doi_fg"] as string : null
                };

                result.Add(dto);
            }

            return result;
        }

    }
}
