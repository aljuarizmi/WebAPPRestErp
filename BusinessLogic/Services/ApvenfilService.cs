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

        /// <summary>
        /// Funcion que devuelve la lista completa de las tablas APVENFIL, APVENEXT.
        /// Se devuelve una lista de tipo IEnumerable porque se entiende que los datos no seran modificados.
        /// </summary>
        public async Task<IEnumerable<ApvenfilDTO>> F_ListarProveedores() => await _repository.F_ListarProveedores();
        public async Task<int> F_InsertarProveedor(ApvenfilSql apvenfilbe, ApvenextSql apvenextbe) => await _repository.F_InsertarProveedor(apvenfilbe, apvenextbe);
    }
}
