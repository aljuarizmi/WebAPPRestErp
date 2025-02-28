using Common.Services;
using Common.ViewModels;

namespace BusinessData.Interfaces
{
    public interface ISygendbcRepository
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarEmpresas(SygendbcDTO parametros, ConnectionManager objConexion); // Usar procedimiento almacenado
    }
}
