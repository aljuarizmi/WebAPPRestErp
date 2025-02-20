using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    internal interface IApopnfilService
    {
        Task<IEnumerable<ApopnfilDTO>> F_ListarDocumentos(ApopnfilDTO parametros);
        Task<IEnumerable<IDictionary<string, object>>> F_ListarDocumentosDapper(ApopnfilDTO parametros);
    }
}
