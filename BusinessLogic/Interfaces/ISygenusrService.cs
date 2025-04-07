using Common.Services;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISygenusrService
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarUsuarioGrupo(SygenusrDTO parametros, ConnectionManager objConexion);
        List<SygenusrDTO> MapearSygenusrDTO(IEnumerable<IDictionary<string, object>> data);
    }
}
