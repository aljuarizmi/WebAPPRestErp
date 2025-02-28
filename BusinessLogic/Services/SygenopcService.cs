using BusinessData.Interfaces;
using BusinessLogic.Interfaces;
using Common.Services;
using Common.ViewModels;

namespace BusinessLogic.Services
{
    public class SygenopcService : ISygenopcService
    {
        private readonly ISygenopcRepository _repository;
        public SygenopcService(ISygenopcRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarMenu(SygenacsDTO parametros, ConnectionManager objConexion) => await _repository.F_ListarMenu(parametros, objConexion);
    }
}
