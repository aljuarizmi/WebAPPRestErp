using BusinessData.Interfaces;
using BusinessLogic.Interfaces;
using Common.Services;
using Common.ViewModels;

namespace BusinessLogic.Services
{
    public class SygendbcService : ISygendbcService
    {
        private readonly ISygendbcRepository _repository;
        public SygendbcService(ISygendbcRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarEmpresas(SygendbcDTO parametros, ConnectionManager objConexion) => await _repository.F_ListarEmpresas(parametros, objConexion);
    }
}
