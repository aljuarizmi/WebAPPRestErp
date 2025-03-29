using BusinessData.Interfaces;
using BusinessEntity.Data;
using BusinessEntity.Data.Models;
using Common.Services;
using Common.ViewModels;
using Dapper;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Data
{
    public class CompfileRepository: ICompfileRepository
    {
        private DbConexion _context;
        private readonly ConnectionManager _connectionmanager;
        public CompfileRepository(DbConexion context, ConnectionManager connectionmanager){
            this._context = context;
            _connectionmanager = connectionmanager;
        }
        public async Task<bool> F_Actualizar(CompfileSql compfileSql){
            // Crear el contexto con la conexión obtenida
            bool resultado = false;
            using (var context = new DbConexion(_connectionmanager.F_ObtenerCredenciales())){
                string sql = @"UPDATE COMPFILE_SQL 
                            SET rpt_name = @RptName, display_name = @DisplayName, addr_line_1 = @AddrLine1, addr_line_2 = @AddrLine2, addr_line_3 = @AddrLine3,
                                phone_no = @PhoneNo, gl_acct_lev_1_dgts = @GlAcctLev1Dgts, gl_acct_lev_2_dgts = @GlAcctLev2Dgts, gl_acct_lev_3_dgts = @GlAcctLev3Dgts,
                                start_jnl_hist_no = @StartJnlHistNo, Type_economic_activity = @TypeEconomicActivity, employees = @Employees, ei_cus_no = @EiCusNo,
                                rate_pct_1 = @RatePct1, rate_pct_2 = @RatePct2
                            WHERE comp_key_1 = @CompKey1";
                var parameters = new[]
                {
                    new SqlParameter("@RptName", compfileSql.RptName ?? (object)DBNull.Value),
                    new SqlParameter("@DisplayName", compfileSql.DisplayName ?? (object)DBNull.Value),
                    new SqlParameter("@AddrLine1", compfileSql.AddrLine1 ?? (object)DBNull.Value),
                    new SqlParameter("@AddrLine2", compfileSql.AddrLine2 ?? (object)DBNull.Value),
                    new SqlParameter("@AddrLine3", compfileSql.AddrLine3 ?? (object)DBNull.Value),
                    new SqlParameter("@PhoneNo", compfileSql.PhoneNo ?? (object)DBNull.Value),
                    new SqlParameter("@GlAcctLev1Dgts", compfileSql.GlAcctLev1Dgts ?? (object)DBNull.Value),
                    new SqlParameter("@GlAcctLev2Dgts", compfileSql.GlAcctLev2Dgts ?? (object)DBNull.Value),
                    new SqlParameter("@GlAcctLev3Dgts", compfileSql.GlAcctLev3Dgts ?? (object)DBNull.Value),
                    new SqlParameter("@StartJnlHistNo", compfileSql.StartJnlHistNo ?? (object)DBNull.Value),
                    new SqlParameter("@TypeEconomicActivity", compfileSql.TypeEconomicActivity ?? (object)DBNull.Value),
                    new SqlParameter("@Employees", compfileSql.Employees ?? (object)DBNull.Value),
                    new SqlParameter("@EiCusNo", compfileSql.EiCusNo ?? (object)DBNull.Value),
                    new SqlParameter("@RatePct1", compfileSql.RatePct1 ?? (object)DBNull.Value),
                    new SqlParameter("@RatePct2", compfileSql.RatePct2 ?? (object)DBNull.Value),
                    new SqlParameter("@CompKey1", compfileSql.CompKey1) // La clave principal no debe ser nula
                };
                int filasAfectadas =await context.Database.ExecuteSqlRawAsync(sql, parameters);
                resultado = filasAfectadas > 0;
            }
            return resultado;
        }
        public async Task<CompfileSql> F_ListarUno(CompfileSql compfileSql){
            CompfileSql compania = new CompfileSql();
            using (var context = new DbConexion(_connectionmanager.F_ObtenerCredenciales())){
                compania = context.CompfileSqls.FirstOrDefault(c => c.CompKey1 == compfileSql.CompKey1);
            }
            if (compania != null){
                foreach (var prop in compania.GetType().GetProperties()){
                    if (prop.PropertyType == typeof(string)){
                        var valor = prop.GetValue(compania) as string;
                        if (valor != null){
                            prop.SetValue(compania, valor.Trim());
                        }
                    }
                }
            }
            return compania;
        }
        public async Task<CompfileSql> F_ListarTamaniosCuenta(CompfileSql compfileSql)
        {
            CompfileSql compania = new CompfileSql();
            this._context = new DbConexion(_connectionmanager.F_ObtenerCredenciales());
            using var connection = this._context.Database.GetDbConnection();
            // Definir la consulta SQL con parámetros
            string sql = "EXEC usp_hz_list_uno_COMPFILE_SQL @comp_key";
            // Parámetros para el procedimiento almacenado
            var parametrosSP = new
            {
                comp_key = compfileSql.CompKey1
            };
            if (connection.State == ConnectionState.Closed)
                await connection.OpenAsync();
            // Ejecutamos la consulta con Dapper y mapeamos a una lista de diccionarios
            //var resultado = (await connection.QueryAsync(sql, parametrosSP));
            var resultado = (await connection.QueryFirstOrDefaultAsync<CompfileSql>(sql, parametrosSP));
            return resultado;
        }
    }
}
