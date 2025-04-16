using BusinessData.Interfaces;
using BusinessEntity.Data;
using Common.Services;
using Common.ViewModels;
using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
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
        /// <summary>
        /// Lista un tipo de cambio segun la fecha y moneda ingresada
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarTipoCambio(CmcurrteDTO parametros)
        {
            /*this._context = new DbConexion(_connectionmanager.F_ObtenerCredenciales());
            var sqlParams = new[]
            {
                new SqlParameter("@FECHA", parametros.RateExtEfe),
                new SqlParameter("@TIPOCAMBIO", parametros.RateExtCode)
            };
            var resultado = _context.Database.SqlQueryRaw<CmcurrteDTO>("EXEC USP_SY_LEER_CMCURRTE_SQL @FECHA, @TIPOCAMBIO",sqlParams).AsEnumerable().FirstOrDefault();
            return resultado;*/
            this._context = new DbConexion(_connectionmanager.F_ObtenerCredenciales());
            using var connection = _context.Database.GetDbConnection();
            // Definir la consulta SQL con parámetros
            string sql = "EXEC USP_SY_LEER_CMCURRTE_SQL @FECHA, @TIPOCAMBIO";
            // Parámetros para el procedimiento almacenado
            var parametrosSP = new
            {
                FECHA = parametros.RateExtEfe,
                TIPOCAMBIO = parametros.RateExtCode
            };
            if (connection.State == ConnectionState.Closed)
                await connection.OpenAsync();
            // Ejecutamos la consulta con Dapper y mapeamos a una lista de diccionarios
            var resultado = (await connection.QueryAsync(sql, parametrosSP))
            .Select(row =>
            {
                var expando = new ExpandoObject();
                var dict = (IDictionary<string, object?>)expando;
                foreach (var prop in (IDictionary<string, object?>)row)
                {
                    if (prop.Key != null)
                    {
                        if (prop.Value != null)
                        {
                            if ((prop.Value is String) || (prop.Value is string))
                            {
                                dict[prop.Key] = prop.Value.ToString().Trim();
                            }
                            else
                            {
                                dict[prop.Key] = prop.Value;
                            }
                        }
                        else
                        {
                            dict[prop.Key] = new object();
                        }
                    }
                }
                return dict;
            }).ToList();
            return resultado;
        }
        public async Task<bool> F_AgregarTipoCambio(CmcurrteDTO cmcurrte)
        {
            bool resultado = false;
            int filasAfectadas = 0;
            this._context = new DbConexion(_connectionmanager.F_ObtenerCredenciales());
            try
            {
                var parametros = new[]
                    {
                    new SqlParameter("@CodigoMoneda", SqlDbType.Char) { Value = cmcurrte.RateExtCode },
                    new SqlParameter("@FechaMoneda", SqlDbType.Int) { Value = cmcurrte.RateExtEfe },
                    new SqlParameter("@CambioCompraVig", SqlDbType.VarChar) { Value = cmcurrte.CurrRt },
                    new SqlParameter("@CambioVentaVig", SqlDbType.Decimal) { Value = cmcurrte.RateVenDia },
                    new SqlParameter("@CambioCompraPub", SqlDbType.Decimal) { Value = cmcurrte.RateComPub },
                    new SqlParameter("@CambioVentaPub", SqlDbType.Decimal) { Value = cmcurrte.RateVenPub },
                    new SqlParameter("@CambioCompraCierre", SqlDbType.Decimal) { Value = cmcurrte.RateComPro },
                    new SqlParameter("@CambioVentaCierre", SqlDbType.Decimal) { Value = cmcurrte.RateVenPro },
                    new SqlParameter("@CambioCompraCanc", SqlDbType.Decimal) { Value = cmcurrte.RateComCanc },
                    new SqlParameter("@CambioVentaCanc", SqlDbType.Decimal) { Value = cmcurrte.RateVenCanc }
                    };
                filasAfectadas = await _context.Database.ExecuteSqlRawAsync("EXEC USP_CM_M03S03N01_INS_TIPOCAMBIO @CodigoMoneda, @FechaMoneda, @CambioCompraVig, @CambioVentaVig, @CambioCompraPub, @CambioVentaPub, @CambioCompraCierre, @CambioVentaCierre, @CambioCompraCanc, @CambioVentaCanc", parametros);
                resultado = filasAfectadas > 0;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }
        public async Task<bool> F_ActualizarTipoCambio(CmcurrteDTO cmcurrte)
        {
            bool resultado = false;
            int filasAfectadas = 0;
            this._context = new DbConexion(_connectionmanager.F_ObtenerCredenciales());
            try
            {
                var parametros = new[]
                    {
                    new SqlParameter("@CodigoMoneda", SqlDbType.Char) { Value = cmcurrte.RateExtCode },
                    new SqlParameter("@FechaMoneda", SqlDbType.Int) { Value = cmcurrte.RateExtEfe },
                    new SqlParameter("@CambioCompraVig", SqlDbType.VarChar) { Value = cmcurrte.CurrRt },
                    new SqlParameter("@CambioVentaVig", SqlDbType.Decimal) { Value = cmcurrte.RateVenDia },
                    new SqlParameter("@CambioCompraPub", SqlDbType.Decimal) { Value = cmcurrte.RateComPub },
                    new SqlParameter("@CambioVentaPub", SqlDbType.Decimal) { Value = cmcurrte.RateVenPub },
                    new SqlParameter("@CambioCompraCierre", SqlDbType.Decimal) { Value = cmcurrte.RateComPro },
                    new SqlParameter("@CambioVentaCierre", SqlDbType.Decimal) { Value = cmcurrte.RateVenPro },
                    new SqlParameter("@CambioCompraCanc", SqlDbType.Decimal) { Value = cmcurrte.RateComCanc },
                    new SqlParameter("@CambioVentaCanc", SqlDbType.Decimal) { Value = cmcurrte.RateVenCanc }
                    };
                filasAfectadas = await _context.Database.ExecuteSqlRawAsync("EXEC USP_CM_M03S03N01_UPD_TIPOCAMBIO @CodigoMoneda, @FechaMoneda, @CambioCompraVig, @CambioVentaVig, @CambioCompraPub, @CambioVentaPub, @CambioCompraCierre, @CambioVentaCierre, @CambioCompraCanc, @CambioVentaCanc", parametros);
                resultado = filasAfectadas > 0;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }
        public async Task<bool> F_EliminarTipoCambio(CmcurrteDTO cmcurrte)
        {
            bool resultado = false;
            int filasAfectadas = 0;
            this._context = new DbConexion(_connectionmanager.F_ObtenerCredenciales());
            try
            {
                var parametros = new[]
                    {
                    new SqlParameter("@CodigoMoneda", SqlDbType.Char) { Value = cmcurrte.RateExtCode },
                    new SqlParameter("@FechaMoneda", SqlDbType.Int) { Value = cmcurrte.RateExtEfe }
                    };
                filasAfectadas = await _context.Database.ExecuteSqlRawAsync("EXEC USP_CM_M03S03N01_DEL_TIPOCAMBIO @CodigoMoneda, @FechaMoneda", parametros);
                resultado = filasAfectadas > 0;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }
        /// <summary>
        /// Lista todos los tipos de cambio de un periodo (año y mes)
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarTiposCambio(CmcurrteDTO parametros)
        {
            this._context = new DbConexion(_connectionmanager.F_ObtenerCredenciales());
            using var connection = _context.Database.GetDbConnection();
            // Definir la consulta SQL con parámetros
            string sql = "EXEC USP_CM_M03S03N01_LIS_TIPOCAMBIO @monedaAnio,@monedaMes,@pageSize,@pageIndex,@ordercolumn";
            // Parámetros para el procedimiento almacenado
            var parametrosSP = new
            {
                monedaAnio = parametros.RateExtEfe.ToString().Substring(0,4),
                monedaMes = parametros.RateExtEfe.ToString().Substring(4,2),
                pageSize = parametros.PageSize,
                pageIndex = parametros.PageIndex,
                ordercolumn = parametros.Ordercolumn
            };
            if (connection.State == ConnectionState.Closed)
                await connection.OpenAsync();
            // Ejecutamos la consulta con Dapper y mapeamos a una lista de diccionarios
            var resultado = (await connection.QueryAsync(sql, parametrosSP))
            .Select(row =>
            {
                var expando = new ExpandoObject();
                var dict = (IDictionary<string, object?>)expando;
                foreach (var prop in (IDictionary<string, object?>)row)
                {
                    if (prop.Key != null)
                    {
                        if (prop.Value != null)
                        {
                            if ((prop.Value is String) || (prop.Value is string))
                            {
                                dict[prop.Key] = prop.Value.ToString().Trim();
                            }
                            else
                            {
                                dict[prop.Key] = prop.Value;
                            }
                        }
                        else
                        {
                            dict[prop.Key] = new object();
                        }
                    }
                }
                return dict;
            }).ToList();
            return resultado;
        }
    }
}
