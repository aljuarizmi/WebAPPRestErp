using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Interfaces
{
    public interface ISyactfilRepository
    {
        Task<SyactfilTDO> F_ListarCuentaPlan(SyactfilTDO parametros);
        Task<SyactfilTDO> F_ListarCuenta(SyactfilTDO parametros);
    }
}
