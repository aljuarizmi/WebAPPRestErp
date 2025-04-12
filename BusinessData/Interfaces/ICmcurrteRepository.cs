using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Interfaces
{
    public interface ICmcurrteRepository
    {
        Task<CmcurrteDTO> F_ListarTipoCambio(CmcurrteDTO parametros); // Usar procedimiento almacenado
        Task<bool> F_AgregarTipoCambio(CmcurrteDTO parametros);
        Task<bool> F_ActualizarTipoCambio(CmcurrteDTO parametros);
        Task<IEnumerable<IDictionary<string, object>>> F_ListarTiposCambio(CmcurrteDTO parametros);
    }
}
