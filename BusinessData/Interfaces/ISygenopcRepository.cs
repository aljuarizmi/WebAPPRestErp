using Common.Services;
using Common.ViewModels;

namespace BusinessData.Interfaces
{
    public interface ISygenopcRepository
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarAccesosUsuarioSistema(SygenacsDTO parametros, ConnectionManager objConexion); // Usar procedimiento almacenado
        Task<IEnumerable<IDictionary<string, object>>> F_ListarAccesos(ConnectionManager objConexion);
        Task<IEnumerable<IDictionary<string, object>>> F_ListarAccesosUsuario(SygenacsDTO parametros, ConnectionManager objConexion);
    }
}
