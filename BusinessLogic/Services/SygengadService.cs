using BusinessData.Interfaces;
using BusinessLogic.Interfaces;
using Common.Services;
using Common.ViewModels;

namespace BusinessLogic.Services
{
    public class SygengadService : ISygengadService
    {
        private readonly ISygengadRepository _repository;
        public SygengadService(ISygengadRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarUsuarioGrupo(SygengadDTO parametros, ConnectionManager objConexion) => await _repository.F_ListarUsuarioGrupo(parametros, objConexion);
    }
}
