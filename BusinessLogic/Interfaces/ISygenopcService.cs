using Common.Services;
using Common.ViewModels;

namespace BusinessLogic.Interfaces
{
    public interface ISygenopcService
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarAccesosUsuarioSistema(SygenacsDTO parametros, ConnectionManager objConexion); // Usar procedimiento almacenado
        Task<IEnumerable<IDictionary<string, object>>> F_ListarAccesos(ConnectionManager objConexion);
        Task<IEnumerable<IDictionary<string, object>>> F_ListarAccesosUsuario(SygenacsDTO parametros, ConnectionManager objConexion);
        List<SygenopcDTO> F_ArmarMenuUsuario(IEnumerable<IDictionary<string, object>> datos, CmcurrteDTO cmcurrte, CmcurratDTO cmcurrat);
        List<SygenopcDTO> F_ArmarMenu(IEnumerable<IDictionary<string, object>> datos);
    }
}
