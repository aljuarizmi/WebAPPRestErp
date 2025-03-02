using BusinessData.Interfaces;
using BusinessEntity.Data;
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
    public class CmcurratRepository: ICmcurratRepository
    {
        private DbConexion _context;
        private readonly ConnectionManager _connectionmanager;
        public CmcurratRepository(DbConexion context, ConnectionManager connectionmanager)
        {
            this._context = context;
            _connectionmanager = connectionmanager;
        }
        public async Task<CmcurratDTO> F_ListarTipoCambio(CmcurratDTO parametros)
        {
            this._context = new DbConexion(_connectionmanager.F_ObtenerCredenciales());
            //Si un procedimiento puede o no devolver datos, entonces usar AsEnumerable().
            var resultado = _context.Database.SqlQueryRaw<CmcurratDTO>("EXEC USP_SY_LEE_CMCURRAT_SQL @FECHA,@TIPOCAMBIO",
                new SqlParameter("@FECHA", parametros.CurrRtEffDt),
                new SqlParameter("@TIPOCAMBIO", parametros.CurrCd)).AsEnumerable().FirstOrDefault();
            return resultado;
        }
    }
}
