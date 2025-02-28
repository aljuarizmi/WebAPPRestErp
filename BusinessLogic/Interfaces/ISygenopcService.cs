using Common.Services;
using Common.ViewModels;

namespace BusinessLogic.Interfaces
{
    internal interface ISygenopcService
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarMenu(SygenacsDTO parametros, ConnectionManager objConexion); // Usar procedimiento almacenado
    }
}
