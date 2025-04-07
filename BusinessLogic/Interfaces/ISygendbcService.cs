using Common.Services;
using Common.ViewModels;

namespace BusinessLogic.Interfaces
{
    public interface ISygendbcService
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarEmpresas(SygendbcDTO parametros, ConnectionManager objConexion); // Usar procedimiento almacenado
        List<SygendbcDTO> MapearSygendbcDTO(IEnumerable<IDictionary<string, object>> data);
    }
}
