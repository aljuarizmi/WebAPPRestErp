using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISycshfilService
    {
        Task<SycshfilTDO> F_ListarCuentaPlan(SycshfilTDO parametros);
        Task<IDictionary<string, object>> F_ListarCuenta(SycshfilTDO parametros);
    }
}
