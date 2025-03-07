using BusinessData.Interfaces;
using BusinessEntity.Data;
using Common.Services;
using Common.ViewModels;
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
    public class CmcurrteRepository: ICmcurrteRepository
    {
        private DbConexion _context;
        private readonly ConnectionManager _connectionmanager;
        public CmcurrteRepository(DbConexion context, ConnectionManager connectionmanager)
        {
            this._context = context;
            _connectionmanager = connectionmanager;
        }
        public async Task<CmcurrteDTO> F_ListarTipoCambio(CmcurrteDTO parametros)
        {
            this._context = new DbConexion(_connectionmanager.F_ObtenerCredenciales());
            var sqlParams = new[]
            {
                new SqlParameter("@FECHA", parametros.RateExtEfe),
                new SqlParameter("@TIPOCAMBIO", parametros.RateExtCode)
            };
            var resultado = _context.Database.SqlQueryRaw<CmcurrteDTO>(
                "EXEC USP_SY_LEER_CMCURRTE_SQL @FECHA, @TIPOCAMBIO",sqlParams).AsEnumerable().FirstOrDefault();
            return resultado;
        }
    }
}
