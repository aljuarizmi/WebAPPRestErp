using Common.Services;
using Common.ViewModels;

namespace BusinessData.Interfaces
{
    public interface ISygengadRepository
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarUsuarioGrupo(SygengadDTO parametros, ConnectionManager objConexion); // Usar procedimiento almacenado
    }
}
