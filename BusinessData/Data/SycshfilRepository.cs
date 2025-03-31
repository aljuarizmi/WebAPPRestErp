using BusinessData.Interfaces;
using BusinessEntity.Data;
using Common.Services;
using Common.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Data
{
    public class SycshfilRepository: ISycshfilRepository
    {
        private DbConexion _context;
        private readonly ConnectionManager _connectionmanager;
        public SycshfilRepository(DbConexion context, ConnectionManager connectionmanager)
        {
            this._context = context;
            this._connectionmanager = connectionmanager;
        }
        public async Task<SycshfilTDO> F_ListarCuentaPlan(SycshfilTDO parametros)
        {
            this._context = new DbConexion(_connectionmanager.F_ObtenerCredenciales());
            //Si un procedimiento puede o no devolver datos, entonces usar AsEnumerable().
            var resultado = _context.Database.SqlQueryRaw<SycshfilTDO>("EXEC USP_AP_M06S04N10_LIST_PLAN_SYCSHFIL_SQL @mn_no,@sb_no,@dp_no,@plan_year",
                new SqlParameter("@mn_no", parametros.MnNo),
                new SqlParameter("@sb_no", parametros.SbNo),
                new SqlParameter("@dp_no", parametros.DpNo),
                new SqlParameter("@plan_year", parametros.PlanYear)).AsEnumerable().FirstOrDefault();
            return resultado;
        }
        public async Task<IDictionary<string, object>> F_ListarCuenta(SycshfilTDO parametros)
        {
            this._context = new DbConexion(_connectionmanager.F_ObtenerCredenciales());
            using var connection = _context.Database.GetDbConnection();
            //Si un procedimiento puede o no devolver datos, entonces usar AsEnumerable().
            var parametrosSP = new
            {
                mn_no = parametros.MnNo,
                sb_no = parametros.SbNo,
                dp_no = parametros.DpNo
            };
            var resultado = await connection.QueryAsync("EXEC USP_AP_M06S04N10_LIST_SYCSHFIL_SQL @mn_no,@sb_no,@dp_no", parametrosSP);
            // Convertimos la primera fila en un diccionario
            var primeraFila = resultado.FirstOrDefault();
            var datosLimpios = new Dictionary<string, object>();
            if (primeraFila == null)
            {
                return new Dictionary<string, object>(); // Devuelve un diccionario vacío si no hay resultados
            }
            else
            {
                foreach (var kvp in (IDictionary<string, object>)primeraFila)
                {
                    // Si el valor es un string, aplicar Trim(); si no, dejarlo igual
                    datosLimpios[kvp.Key] = kvp.Value is string str ? str.Trim() : kvp.Value;
                }
            }
            // Convertimos el objeto en un IDictionary<string, object>
            return datosLimpios;
        }
    }
}
