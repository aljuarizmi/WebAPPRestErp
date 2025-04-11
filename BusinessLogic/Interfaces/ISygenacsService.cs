using Common.Services;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISygenacsService
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarEmpresasUsuario(SygenacsDTO parametros, ConnectionManager objConexion);
        Task<IEnumerable<IDictionary<string, object>>> F_ListarAccesosUsuario(SygenacsDTO parametros, ConnectionManager objConexion);
        Task<bool> F_AgregarAccesosUsuario(SygenacsDTO sygenacs, ConnectionManager objConexion);
        List<SygenacsDTO> MapearSygenacsDTO(IEnumerable<IDictionary<string, object>> data);
        string SerializarSygenacsDTO(List<SygenacsDTO> data);
    }
}
