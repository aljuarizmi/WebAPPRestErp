using BusinessData.Interfaces;
using BusinessLogic.Interfaces;
using Common.Services;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class SygenacsService: ISygenacsService
    {
        private readonly ISygenacsRepository _repository;
        public SygenacsService(ISygenacsRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarEmpresasUsuario(SygenacsDTO parametros, ConnectionManager objConexion) => await _repository.F_ListarEmpresasUsuario(parametros, objConexion);
    }
}
