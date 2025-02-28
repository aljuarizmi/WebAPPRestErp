using Common.Services;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    internal interface ISygengadService
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarUsuarioGrupo(SygengadDTO parametros, ConnectionManager objConexion); // Usar procedimiento almacenado
    }
}
