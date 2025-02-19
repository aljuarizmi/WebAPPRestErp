using BusinessEntity.Data.Models;
using Common.ViewModels;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    internal interface IApvenfilService
    {
        Task<IEnumerable<ApvenfilDTO>> GetByStoredProcedureAsync();
        Task<int> F_InsertarProveedor(ApvenfilSql apvenfilbe, ApvenextSql apvenextbe);
    }
}
