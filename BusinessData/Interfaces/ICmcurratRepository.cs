using Common.Services;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Interfaces
{
    public interface ICmcurratRepository
    {
        Task<CmcurratDTO> F_ListarTipoCambio(CmcurratDTO parametros); // Usar procedimiento almacenado
    }
}
