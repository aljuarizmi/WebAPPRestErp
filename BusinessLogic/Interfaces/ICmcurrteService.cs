using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    internal interface ICmcurrteService
    {
        Task<CmcurrteDTO> F_ListarTipoCambio(CmcurrteDTO parametros); // Usar procedimiento almacenado
    }
}
