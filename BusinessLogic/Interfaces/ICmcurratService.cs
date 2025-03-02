using Common.Services;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    internal interface ICmcurratService
    {
        Task<CmcurratDTO> F_ListarTipoCambio(CmcurratDTO parametros); // Usar procedimiento almacenado
    }
}
