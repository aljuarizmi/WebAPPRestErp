using BusinessEntity.Data.Models;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Interfaces
{
    public interface IApopnfilRepository
    {
        /// <summary>
        /// Lista los documentos usando filtros de consulta
        /// </summary>
        /// <param name="parametros">Parámetro que contiene los filtros de consulta</param>
        /// <returns>Retorna una lista generica del tipo IEnumerable<ApopnfilDTO> con los datos de la consulta</returns>
        Task<IEnumerable<ApopnfilDTO>> F_ListarDocumentos(ApopnfilDTO parametros); // Usar procedimiento almacenado
    }
}
