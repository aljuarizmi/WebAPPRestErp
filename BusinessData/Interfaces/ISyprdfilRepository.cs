using BusinessEntity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Interfaces
{
    public interface ISyprdfilRepository
    {
        Task<SyprdfilSql> F_ListarUno(SyprdfilSql parametros);
        Task<bool> F_InsertarPeriodo(SyprdfilSql parametros);
        Task<bool> F_ActualizarPeriodo(SyprdfilSql parametros);
    }
}
