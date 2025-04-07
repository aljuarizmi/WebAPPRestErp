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
    public class SygenusrService: ISygenusrService
    {
        private readonly ISygenusrRepository _repository;
        public SygenusrService(ISygenusrRepository repository){
            _repository = repository;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarUsuarioGrupo(SygenusrDTO parametros, ConnectionManager objConexion) => await _repository.F_ListarUsuarioGrupo(parametros, objConexion);

        public List<SygenusrDTO> MapearSygenusrDTO(IEnumerable<IDictionary<string, object>> data)
        {
            List<SygenusrDTO> result = new List<SygenusrDTO>();

            foreach (var item in data)
            {
                SygenusrDTO dto = new SygenusrDTO
                {
                    BizGrpId = item.ContainsKey("biz_grp_id") ? item["biz_grp_id"] as int? : null,
                    SyUser = item.ContainsKey("sy_user") ? item["sy_user"] as string : null,
                    SyUserPsc = item.ContainsKey("sy_user_psc") ? item["sy_user_psc"] as string : null,
                    SyUserGroup = item.ContainsKey("sy_user_group") ? item["sy_user_group"] as string : null,
                    SyUserType = item.ContainsKey("sy_user_type") ? item["sy_user_type"] as string : null
                };

                result.Add(dto);
            }

            return result;
        }

    }
}
