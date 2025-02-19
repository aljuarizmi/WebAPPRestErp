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
    public class ApvenfilService: IApvenfilService
    {
        private readonly IApvenfilRepository _repository;

        public ApvenfilService(IApvenfilRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ApvenfilDTO>> GetByStoredProcedureAsync() => await _repository.GetByStoredProcedureAsync();
        public async Task<int> F_InsertarProveedor(ApvenfilSql apvenfilbe, ApvenextSql apvenextbe) => await _repository.F_InsertarProveedor(apvenfilbe, apvenextbe);
    }
}
