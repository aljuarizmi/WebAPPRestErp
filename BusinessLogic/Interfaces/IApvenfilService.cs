using BusinessEntity.Data.Models;
using Common.ViewModels;

namespace BusinessLogic.Interfaces
{
    internal interface IApvenfilService
    {
        Task<IEnumerable<ApvenfilDTO>> F_ListarProveedores();
        Task<int> F_InsertarProveedor(ApvenfilSql apvenfilbe, ApvenextSql apvenextbe);
    }
}
