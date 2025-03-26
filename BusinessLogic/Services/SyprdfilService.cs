using BusinessData.Interfaces;
using BusinessEntity.Data.Models;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class SyprdfilService: ISyprdfilService
    {
        private readonly ISyprdfilRepository _repository;
        public SyprdfilService(ISyprdfilRepository repository)
        {
            _repository = repository;
        }
        public async Task<SyprdfilSql> F_ListarUno(SyprdfilSql parametros) => await _repository.F_ListarUno(parametros);
        public async Task<bool> F_InsertarPeriodo(SyprdfilSql parametros) => await _repository.F_InsertarPeriodo(parametros);
        public async Task<bool> F_ActualizarPeriodo(SyprdfilSql parametros) => await _repository.F_ActualizarPeriodo(parametros);
    }
}
