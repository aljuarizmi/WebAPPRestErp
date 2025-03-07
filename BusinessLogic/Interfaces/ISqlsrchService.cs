using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    internal interface ISqlsrchService
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarBuscadores(SqlsrchDTO parametros);
        Task<IDictionary<string, object>> F_ListarBuscador(SqlsrchDTO parametros);
        Task<IEnumerable<IDictionary<string, object>>> F_ListarConsulta(SqlsrchDTO parametros);
    }
}
