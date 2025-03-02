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
    }
}
