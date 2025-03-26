using BusinessData.Interfaces;
using BusinessEntity.Data;
using BusinessEntity.Data.Models;
using Common.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Data
{
    public class SyprdfilRepository: ISyprdfilRepository
    {
        private DbConexion _context;
        private readonly ConnectionManager _connectionmanager;
        public SyprdfilRepository(DbConexion context, ConnectionManager connectionmanager)
        {
            this._context = context;
            _connectionmanager = connectionmanager;
        }
        public async Task<SyprdfilSql> F_ListarUno(SyprdfilSql syprdfilSql){
            SyprdfilSql periodo = new SyprdfilSql();
            using (var context = new DbConexion(_connectionmanager.F_ObtenerCredenciales())){
                periodo = context.SyprdfilSqls.FirstOrDefault(c => c.PrdKey == syprdfilSql.PrdKey);
            }
            if (periodo != null){
                foreach (var prop in periodo.GetType().GetProperties()){
                    if (prop.PropertyType == typeof(string)){
                        var valor = prop.GetValue(periodo) as string;
                        if (valor != null){
                            prop.SetValue(periodo, valor.Trim());
                        }
                    }
                }
            }
            return periodo;
        }
        public async Task<bool> F_InsertarPeriodo(SyprdfilSql periodo){
            bool resultado = false;
            using (var context = new DbConexion(_connectionmanager.F_ObtenerCredenciales())){
                string sql = @"INSERT INTO [SYPRDFIL_SQL] (
                [prd_key], [str_dt_1], [end_dt_1], [str_dt_2], [end_dt_2], [str_dt_3], [end_dt_3], 
                [str_dt_4], [end_dt_4], [str_dt_5], [end_dt_5], [str_dt_6], [end_dt_6], [str_dt_7], [end_dt_7],
                [str_dt_8], [end_dt_8], [str_dt_9], [end_dt_9], [str_dt_10], [end_dt_10], [str_dt_11], [end_dt_11],
                [str_dt_12], [end_dt_12], [str_dt_13], [end_dt_13], [no_of_val_prd], [def_prd_cd],
                [tmp_yr_cls_fg], [warn_or_prev], [current_prd], [wrnprv_glprd_fg_1], [wrnprv_glprd_fg_2], 
                [wrnprv_glprd_fg_3], [wrnprv_glprd_fg_4], [wrnprv_glprd_fg_5], [wrnprv_glprd_fg_6], 
                [wrnprv_glprd_fg_7], [wrnprv_glprd_fg_8], [wrnprv_glprd_fg_9], [wrnprv_glprdfg_10], 
                [wrnprv_glprdfg_11], [wrnprv_glprdfg_12], [wrnprv_glprdfg_13], [filler_0001])
            VALUES (
                @prdKey, @strDt1, @endDt1, @strDt2, @endDt2, @strDt3, @endDt3, @strDt4, @endDt4, @strDt5, @endDt5,
                @strDt6, @endDt6, @strDt7, @endDt7, @strDt8, @endDt8, @strDt9, @endDt9, @strDt10, @endDt10,
                @strDt11, @endDt11, @strDt12, @endDt12, @strDt13, @endDt13, @noOfValPrd, @defPrdCd, @tmpYrClsFg,
                @warnOrPrev, @currentPrd, @wrnprvGlprdFg1, @wrnprvGlprdFg2, @wrnprvGlprdFg3, @wrnprvGlprdFg4,
                @wrnprvGlprdFg5, @wrnprvGlprdFg6, @wrnprvGlprdFg7, @wrnprvGlprdFg8, @wrnprvGlprdFg9,
                @wrnprvGlprdfg10, @wrnprvGlprdfg11, @wrnprvGlprdfg12, @wrnprvGlprdfg13, @filler0001)";

                var parameters = new[]
                {
                    new SqlParameter("@prdKey", periodo.PrdKey),
                    new SqlParameter("@strDt1", periodo.StrDt1), new SqlParameter("@endDt1", periodo.EndDt1),
                    new SqlParameter("@strDt2", periodo.StrDt2), new SqlParameter("@endDt2", periodo.EndDt2),
                    new SqlParameter("@strDt3", periodo.StrDt3), new SqlParameter("@endDt3", periodo.EndDt3),
                    new SqlParameter("@strDt4", periodo.StrDt4), new SqlParameter("@endDt4", periodo.EndDt4),
                    new SqlParameter("@strDt5", periodo.StrDt5), new SqlParameter("@endDt5", periodo.EndDt5),
                    new SqlParameter("@strDt6", periodo.StrDt6), new SqlParameter("@endDt6", periodo.EndDt6),
                    new SqlParameter("@strDt7", periodo.StrDt7), new SqlParameter("@endDt7", periodo.EndDt7),
                    new SqlParameter("@strDt8", periodo.StrDt8), new SqlParameter("@endDt8", periodo.EndDt8),
                    new SqlParameter("@strDt9", periodo.StrDt9), new SqlParameter("@endDt9", periodo.EndDt9),
                    new SqlParameter("@strDt10", periodo.StrDt10), new SqlParameter("@endDt10", periodo.EndDt10),
                    new SqlParameter("@strDt11", periodo.StrDt11), new SqlParameter("@endDt11", periodo.EndDt11),
                    new SqlParameter("@strDt12", periodo.StrDt12), new SqlParameter("@endDt12", periodo.EndDt12),
                    new SqlParameter("@strDt13", periodo.StrDt13), new SqlParameter("@endDt13", periodo.EndDt13),
                    new SqlParameter("@noOfValPrd", periodo.NoOfValPrd), new SqlParameter("@defPrdCd", periodo.DefPrdCd),
                    new SqlParameter("@tmpYrClsFg", periodo.TmpYrClsFg), new SqlParameter("@warnOrPrev", periodo.WarnOrPrev),
                    new SqlParameter("@currentPrd", periodo.CurrentPrd),
                    new SqlParameter("@wrnprvGlprdFg1", periodo.WrnprvGlprdFg1), new SqlParameter("@wrnprvGlprdFg2", periodo.WrnprvGlprdFg2),
                    new SqlParameter("@wrnprvGlprdFg3", periodo.WrnprvGlprdFg3), new SqlParameter("@wrnprvGlprdFg4", periodo.WrnprvGlprdFg4),
                    new SqlParameter("@wrnprvGlprdFg5", periodo.WrnprvGlprdFg5), new SqlParameter("@wrnprvGlprdFg6", periodo.WrnprvGlprdFg6),
                    new SqlParameter("@wrnprvGlprdFg7", periodo.WrnprvGlprdFg7), new SqlParameter("@wrnprvGlprdFg8", periodo.WrnprvGlprdFg8),
                    new SqlParameter("@wrnprvGlprdFg9", periodo.WrnprvGlprdFg9), new SqlParameter("@wrnprvGlprdfg10", periodo.WrnprvGlprdfg10),
                    new SqlParameter("@wrnprvGlprdfg11", periodo.WrnprvGlprdfg11), new SqlParameter("@wrnprvGlprdfg12", periodo.WrnprvGlprdfg12),
                    new SqlParameter("@wrnprvGlprdfg13", periodo.WrnprvGlprdfg13), new SqlParameter("@filler0001", periodo.Filler0001)
                };
                int filasAfectadas = await context.Database.ExecuteSqlRawAsync(sql, parameters);
                resultado = filasAfectadas > 0;
            }
            return resultado;
        }
        public async Task<bool> F_ActualizarPeriodo(SyprdfilSql parametros){
            bool resultado = false;
            var parameters = new[]
            {
                new SqlParameter("@var_prd_key", parametros.PrdKey),
                new SqlParameter("@var_str_dt_1", parametros.StrDt1),
                new SqlParameter("@var_end_dt_1", parametros.EndDt1),
                new SqlParameter("@var_wrnprv_glprd_fg_1", parametros.WrnprvGlprdFg1),
                new SqlParameter("@var_str_dt_2", parametros.StrDt2),
                new SqlParameter("@var_end_dt_2", parametros.EndDt2),
                new SqlParameter("@var_wrnprv_glprd_fg_2", parametros.WrnprvGlprdFg2),
                new SqlParameter("@var_str_dt_3", parametros.StrDt3),
                new SqlParameter("@var_end_dt_3", parametros.EndDt3),
                new SqlParameter("@var_wrnprv_glprd_fg_3", parametros.WrnprvGlprdFg3),
                new SqlParameter("@var_str_dt_4", parametros.StrDt4),
                new SqlParameter("@var_end_dt_4", parametros.EndDt4),
                new SqlParameter("@var_wrnprv_glprd_fg_4", parametros.WrnprvGlprdFg4),
                new SqlParameter("@var_str_dt_5", parametros.StrDt5),
                new SqlParameter("@var_end_dt_5", parametros.EndDt5),
                new SqlParameter("@var_wrnprv_glprd_fg_5", parametros.WrnprvGlprdFg5),
                new SqlParameter("@var_str_dt_6", parametros.StrDt6),
                new SqlParameter("@var_end_dt_6", parametros.EndDt6),
                new SqlParameter("@var_wrnprv_glprd_fg_6", parametros.WrnprvGlprdFg6),
                new SqlParameter("@var_str_dt_7", parametros.StrDt7),
                new SqlParameter("@var_end_dt_7", parametros.EndDt7),
                new SqlParameter("@var_wrnprv_glprd_fg_7", parametros.WrnprvGlprdFg7),
                new SqlParameter("@var_str_dt_8", parametros.StrDt8),
                new SqlParameter("@var_end_dt_8", parametros.EndDt8),
                new SqlParameter("@var_wrnprv_glprd_fg_8", parametros.WrnprvGlprdFg8),
                new SqlParameter("@var_str_dt_9", parametros.StrDt9),
                new SqlParameter("@var_end_dt_9", parametros.EndDt9),
                new SqlParameter("@var_wrnprv_glprd_fg_9", parametros.WrnprvGlprdFg9),
                new SqlParameter("@var_str_dt_10", parametros.StrDt10),
                new SqlParameter("@var_end_dt_10", parametros.EndDt10),
                new SqlParameter("@var_wrnprv_glprdfg_10", parametros.WrnprvGlprdfg10),
                new SqlParameter("@var_str_dt_11", parametros.StrDt11),
                new SqlParameter("@var_end_dt_11", parametros.EndDt11),
                new SqlParameter("@var_wrnprv_glprdfg_11", parametros.WrnprvGlprdfg11),
                new SqlParameter("@var_str_dt_12", parametros.StrDt12),
                new SqlParameter("@var_end_dt_12", parametros.EndDt12),
                new SqlParameter("@var_wrnprv_glprdfg_12", parametros.WrnprvGlprdfg12),
                new SqlParameter("@var_str_dt_13", parametros.StrDt13),
                new SqlParameter("@var_end_dt_13", parametros.EndDt13),
                new SqlParameter("@var_wrnprv_glprdfg_13", parametros.WrnprvGlprdfg13),
                new SqlParameter("@var_no_of_val_prd", parametros.NoOfValPrd),
                new SqlParameter("@var_current_prd", parametros.CurrentPrd)
            };

            using (var context = new DbConexion(_connectionmanager.F_ObtenerCredenciales())){
                int filasAfectadas = await _context.Database.ExecuteSqlRawAsync("EXEC usp_sy_update_periodo @var_prd_key, @var_str_dt_1, @var_end_dt_1, @var_wrnprv_glprd_fg_1, @var_str_dt_2, @var_end_dt_2,"
                    +" @var_wrnprv_glprd_fg_2, @var_str_dt_3, @var_end_dt_3, @var_wrnprv_glprd_fg_3, @var_str_dt_4, @var_end_dt_4,"
                    +" @var_wrnprv_glprd_fg_4, @var_str_dt_5, @var_end_dt_5, @var_wrnprv_glprd_fg_5, @var_str_dt_6, @var_end_dt_6,"
                    +" @var_wrnprv_glprd_fg_6, @var_str_dt_7, @var_end_dt_7, @var_wrnprv_glprd_fg_7, @var_str_dt_8, @var_end_dt_8,"
                    +" @var_wrnprv_glprd_fg_8, @var_str_dt_9, @var_end_dt_9, @var_wrnprv_glprd_fg_9, @var_str_dt_10, @var_end_dt_10,"
                    +" @var_wrnprv_glprdfg_10, @var_str_dt_11, @var_end_dt_11, @var_wrnprv_glprdfg_11, @var_str_dt_12, @var_end_dt_12,"
                    +" @var_wrnprv_glprdfg_12, @var_str_dt_13, @var_end_dt_13, @var_wrnprv_glprdfg_13, @var_no_of_val_prd, @var_current_prd", parametros);
                resultado = filasAfectadas > 0;
            }
            return resultado;
        }
    }
}
