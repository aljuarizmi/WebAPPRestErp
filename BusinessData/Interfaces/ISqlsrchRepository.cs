using Common.Services;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Interfaces
{
    public interface ISqlsrchRepository
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarBuscadores(SqlsrchDTO parametros);
        Task<IDictionary<string, object>> F_ListarBuscador(SqlsrchDTO parametros);
        Task<IEnumerable<IDictionary<string, object>>> F_ListarConsulta(SqlsrchDTO parametros);
    }
}
