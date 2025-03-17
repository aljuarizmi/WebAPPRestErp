using BusinessData.Interfaces;
using BusinessEntity.Data.Models;
using BusinessLogic.Interfaces;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CompfileService: ICompfileService
    {
        private readonly ICompfileRepository _repository;
        public CompfileService(ICompfileRepository repository) {
            _repository = repository;
        }
        public async Task<bool> F_Actualizar(CompfileSql parametros) => await _repository.F_Actualizar(parametros);
        public async Task<CompfileSql> F_ListarUno(CompfileSql parametros) => await _repository.F_ListarUno(parametros);
    }
}
