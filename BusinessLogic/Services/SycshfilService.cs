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
    public class SycshfilService: ISycshfilService
    {
        private readonly ISycshfilRepository _repository;
        public SycshfilService(ISycshfilRepository repository){
            _repository = repository;
        }
        public async Task<SycshfilTDO> F_ListarCuentaPlan(SycshfilTDO parametros) => await _repository.F_ListarCuentaPlan(parametros);
        public async Task<IDictionary<string, object>> F_ListarCuenta(SycshfilTDO parametros) => await _repository.F_ListarCuenta(parametros);
    }
}
