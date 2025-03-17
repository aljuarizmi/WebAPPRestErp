using BusinessEntity.Data.Models;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Interfaces
{
    public interface ICompfileRepository
    {
        Task<bool> F_Actualizar(CompfileSql parametros);
        Task<CompfileSql> F_ListarUno(CompfileSql parametros);
    }
}
