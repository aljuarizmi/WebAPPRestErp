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
    public class CmcurrteService: ICmcurrteService
    {
        private readonly ICmcurrteRepository _repository;
        public CmcurrteService(ICmcurrteRepository repository)
        {
            _repository = repository;
        }
        public async Task<CmcurrteDTO> F_ListarTipoCambio(CmcurrteDTO parametros) => await _repository.F_ListarTipoCambio(parametros);
        public async Task<bool> F_AgregarTipoCambio(CmcurrteDTO parametros) => await _repository.F_AgregarTipoCambio(parametros);
        public async Task<bool> F_ActualizarTipoCambio(CmcurrteDTO parametros) => await _repository.F_ActualizarTipoCambio(parametros);
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarTiposCambio(CmcurrteDTO parametros) => await _repository.F_ListarTiposCambio(parametros);
    }
}
