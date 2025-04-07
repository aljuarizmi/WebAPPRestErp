using Common.Services;
using Common.ViewModels;

namespace BusinessLogic.Interfaces
{
    public interface ISygengadService
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarUsuarioGrupo(SygengadDTO parametros, ConnectionManager objConexion); // Usar procedimiento almacenado
    }
}
