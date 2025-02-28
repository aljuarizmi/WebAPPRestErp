using Common.ViewModels;

namespace BusinessLogic.Interfaces
{
    internal interface IApopnfilService
    {
        Task<IEnumerable<ApopnfilDTO>> F_ListarDocumentos(ApopnfilDTO parametros);
        Task<IEnumerable<IDictionary<string, object>>> F_ListarDocumentosDapper(ApopnfilDTO parametros);
    }
}
