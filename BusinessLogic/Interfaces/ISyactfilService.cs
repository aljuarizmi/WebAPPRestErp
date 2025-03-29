using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    internal interface ISyactfilService
    {
        Task<SyactfilTDO> F_ListarCuentaPlan(SyactfilTDO parametros);
        Task<SyactfilTDO> F_ListarCuenta(SyactfilTDO parametros);
    }
}
