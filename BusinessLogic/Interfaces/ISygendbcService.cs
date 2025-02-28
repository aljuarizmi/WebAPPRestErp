using Common.Services;
using Common.ViewModels;

namespace BusinessLogic.Interfaces
{
    internal interface ISygendbcService
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarEmpresas(SygendbcDTO parametros, ConnectionManager objConexion); // Usar procedimiento almacenado
    }
}
