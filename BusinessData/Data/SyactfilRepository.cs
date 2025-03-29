using BusinessData.Interfaces;
using BusinessEntity.Data;
using BusinessEntity.Data.Models;
using Common.Services;
using Common.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Data
{
    public class SyactfilRepository: ISyactfilRepository
    {
        private DbConexion _context;
        private readonly ConnectionManager _connectionmanager;
        public SyactfilRepository(DbConexion context, ConnectionManager connectionmanager){
            this._context = context;
            this._connectionmanager = connectionmanager;
        }
        public async Task<SyactfilTDO> F_ListarCuentaPlan(SyactfilTDO parametros){
            this._context = new DbConexion(_connectionmanager.F_ObtenerCredenciales());
            //Si un procedimiento puede o no devolver datos, entonces usar AsEnumerable().
            var resultado = _context.Database.SqlQueryRaw<SyactfilTDO>("EXEC usp_SY_list_uno_plan_SYACTFIL_SQL @mn_no,@sb_no,@dp_no,@plan_year",
                new SqlParameter("@mn_no", parametros.MnNo),
                new SqlParameter("@sb_no", parametros.SbNo),
                new SqlParameter("@dp_no", parametros.DpNo),
                new SqlParameter("@plan_year", parametros.PlanYear)).AsEnumerable().FirstOrDefault();
            return resultado;
        }
        public async Task<SyactfilTDO> F_ListarCuenta(SyactfilTDO parametros){
            this._context = new DbConexion(_connectionmanager.F_ObtenerCredenciales());
            //Si un procedimiento puede o no devolver datos, entonces usar AsEnumerable().
            var resultado = _context.Database.SqlQueryRaw<SyactfilTDO>("EXEC usp_SY_list_uno_SYACTFIL_SQL @mn_no,@sb_no,@dp_no",
                new SqlParameter("@mn_no", parametros.MnNo),
                new SqlParameter("@sb_no", parametros.SbNo),
                new SqlParameter("@dp_no", parametros.DpNo)).AsEnumerable().FirstOrDefault();
            return resultado;
        }
    }
}
