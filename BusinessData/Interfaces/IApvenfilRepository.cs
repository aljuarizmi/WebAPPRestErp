using BusinessEntity.Data.Models;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Interfaces
{
    public interface IApvenfilRepository
    {
        Task<IEnumerable<ApvenfilDTO>> GetByStoredProcedureAsync(); // Usar procedimiento almacenado
        Task<int> F_InsertarProveedor(ApvenfilSql apvenfilbe, ApvenextSql apvenextbe); // Usar procedimiento almacenado
    }
}
