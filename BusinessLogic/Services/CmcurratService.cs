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
    public class CmcurratService: ICmcurratService
    {
        private readonly ICmcurratRepository _repository;
        public CmcurratService(ICmcurratRepository repository)
        {
            _repository = repository;
        }
        public async Task<CmcurratDTO> F_ListarTipoCambio(CmcurratDTO parametros) => await _repository.F_ListarTipoCambio(parametros);
    }
}
