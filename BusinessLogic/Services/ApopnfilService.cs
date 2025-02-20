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
    public class ApopnfilService: IApopnfilService
    {
        private readonly IApopnfilRepository _repository;

        public ApopnfilService(IApopnfilRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Lista los documentos usando filtros de consulta
        /// </summary>
        /// <param name="parametros">Parámetro que contiene los filtros de consulta</param>
        /// <returns>Retorna una lista generica del tipo IEnumerable<ApopnfilDTO> con los datos de la consulta</returns>
        public async Task<IEnumerable<ApopnfilDTO>> F_ListarDocumentos(ApopnfilDTO parametros) => await _repository.F_ListarDocumentos(parametros);

        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarDocumentosDapper(ApopnfilDTO parametros) => await _repository.F_ListarDocumentosDapper(parametros);
    }
}
