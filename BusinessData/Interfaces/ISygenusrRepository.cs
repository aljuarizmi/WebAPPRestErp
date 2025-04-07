using Common.Services;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Interfaces
{
    public interface ISygenusrRepository
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarUsuarioGrupo(SygenusrDTO parametros, ConnectionManager objConexion);
    }
}
