using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    internal interface ISycshfilService
    {
        Task<SycshfilTDO> F_ListarCuentaPlan(SycshfilTDO parametros);
        Task<SycshfilTDO> F_ListarCuenta(SycshfilTDO parametros);
    }
}
