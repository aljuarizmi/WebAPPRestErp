using BusinessEntity.Data.Models;
using Common.ViewModels;

namespace BusinessData.Interfaces
{
    public interface IApvenfilRepository
    {
        Task<IEnumerable<ApvenfilDTO>> F_ListarProveedores(); // Usar procedimiento almacenado
        Task<int> F_InsertarProveedor(ApvenfilSql apvenfilbe, ApvenextSql apvenextbe); // Usar procedimiento almacenado
    }
}
