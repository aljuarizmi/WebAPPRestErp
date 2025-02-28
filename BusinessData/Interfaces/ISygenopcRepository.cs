using Common.Services;
using Common.ViewModels;

namespace BusinessData.Interfaces
{
    public interface ISygenopcRepository
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarMenu(SygenacsDTO parametros, ConnectionManager objConexion); // Usar procedimiento almacenado
    }
}
