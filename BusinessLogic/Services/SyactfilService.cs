using BusinessData.Interfaces;
using BusinessLogic.Interfaces;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class SyactfilService: ISyactfilService
    {
        private readonly ISyactfilRepository _repository;
        public SyactfilService(ISyactfilRepository repository){
            _repository = repository;
        }
        public async Task<SyactfilTDO> F_ListarCuentaPlan(SyactfilTDO parametros) => await _repository.F_ListarCuentaPlan(parametros);
        public async Task<IDictionary<string, object>> F_ListarCuenta(SyactfilTDO parametros) => await _repository.F_ListarCuenta(parametros);
    }
}
