using BusinessData.Interfaces;
using BusinessEntity.Data;
using Common.ViewModels;
using DocumentFormat.OpenXml.InkML;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Data
{
    public class ApopnfilRepository: IApopnfilRepository
    {
        private readonly DbConexion _context;
        public ApopnfilRepository(DbConexion context)
        {
            _context = context;
        }
        /// <summary>
        /// Lista los documentos usando filtros de consulta
        /// </summary>
        /// <param name="parametros">Parámetro que contiene los filtros de consulta</param>
        /// <returns>Retorna una lista generica del tipo IEnumerable<ApopnfilDTO> con los datos de la consulta</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<ApopnfilDTO>> F_ListarDocumentos(ApopnfilDTO parametros){
            Type tipoModelo = typeof(ApopnfilDTO);
            bool tieneAtributos = tipoModelo.GetProperties(BindingFlags.Public | BindingFlags.Instance).Any();
            if (tieneAtributos){
                var resultado = await _context.Database
                .SqlQueryRaw<ApopnfilDTO>("EXEC USP_AP_M06S02N07_LISTAR_APOPNFIL_APOPNHST_SQL @tipo_fg,@chkSaldo,@chkVoid,@vend_no,@chkDes,@chkHas,@trx_dt_ini,@trx_dt_fin,@chkDes1,@chkHas1,"+
                "@due_dt_ini,@due_dt_fin,@chkDes2,@chkHas2,@vchr_dt_ini,@vchr_dt_fin,@DocIni,@DocFin,@AplIni,@AplFin,"+
                "@Inv_no,@Apply_to_no,@Doc1,@Doc2,@Doc3,@Apl1,@Apl2,@Apl3,@jnl_cd,@vchr_chk_cd,"+
                "@jnl_batch_id,@user_def_fld_1,@vend_type_cd,@pageSize,@pageIndex,@orderColumn,@referencial_apply_to_no",
                new SqlParameter("@tipo_fg", parametros.TipoFg),
                new SqlParameter("@chkSaldo", parametros.ChkSaldo),
                new SqlParameter("@chkVoid", parametros.ChkVoid),
                new SqlParameter("@vend_no", parametros.VendNo),
                new SqlParameter("@chkDes", parametros.ChkDes),
                new SqlParameter("@chkHas", parametros.ChkHas),
                new SqlParameter("@trx_dt_ini", parametros.TrxDtIni),
                new SqlParameter("@trx_dt_fin", parametros.TrxDtFin),
                new SqlParameter("@chkDes1", parametros.ChkDes1),
                new SqlParameter("@chkHas1", parametros.ChkHas1),
                new SqlParameter("@due_dt_ini", parametros.DueDtIni),
                new SqlParameter("@due_dt_fin", parametros.DueDtFin),
                new SqlParameter("@chkDes2", parametros.ChkDes2),
                new SqlParameter("@chkHas2", parametros.ChkHas2),
                new SqlParameter("@vchr_dt_ini", parametros.VchrDtIni),
                new SqlParameter("@vchr_dt_fin", parametros.VchrDtFin),
                new SqlParameter("@DocIni", parametros.DocIni),
                new SqlParameter("@DocFin", parametros.DocFin),
                new SqlParameter("@AplIni", parametros.AplIni),
                new SqlParameter("@AplFin", parametros.AplFin),
                new SqlParameter("@Inv_no", parametros.InvNo),
                new SqlParameter("@Apply_to_no", parametros.ApplyToNo),
                new SqlParameter("@Doc1", parametros.Doc1),
                new SqlParameter("@Doc2", parametros.Doc2),
                new SqlParameter("@Doc3", parametros.Doc3),
                new SqlParameter("@Apl1", parametros.Apl1),
                new SqlParameter("@Apl2", parametros.Apl2),
                new SqlParameter("@Apl3", parametros.Apl3),
                new SqlParameter("@jnl_cd", parametros.JnlCd),
                new SqlParameter("@vchr_chk_cd", parametros.VchrChkCd),
                new SqlParameter("@jnl_batch_id", parametros.JnlBatchId),
                new SqlParameter("@user_def_fld_1", parametros.UserDefFld1),
                new SqlParameter("@vend_type_cd", parametros.VendTypeCd),
                new SqlParameter("@pageSize", parametros.PageSize),
                new SqlParameter("@pageIndex", parametros.PageIndex),
                new SqlParameter("@orderColumn", parametros.OrderColumn),
                new SqlParameter("@referencial_apply_to_no", parametros.ReferencialApplyToNo)
                )
                .ToListAsync();
                return resultado;
            }else{
                throw new Exception("El modelo ApopnfilDTO no tiene atributos definidos. No se puede ejecutar la consulta de los datos.");
            }
        }
    }
}
