using BusinessEntity.Data;
using Common.Services;
using Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessData.Interfaces;
using Microsoft.Data.SqlClient;

namespace BusinessData.Data
{
    public class SygenacsRepository: ISygenacsRepository
    {
        private DbAcceso _context;
        public SygenacsRepository(DbAcceso context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarEmpresasUsuario(SygenacsDTO parametros, ConnectionManager objConexion)
        {
            this._context = new DbAcceso(objConexion.F_ObtenerCredencialesConfig());
            using var connection = _context.Database.GetDbConnection();
            // Definir la consulta SQL con parámetros
            string sql = "EXEC usp_SY_LISTA_ACCESOEMPRESAS @usuario";
            // Parámetros para el procedimiento almacenado
            var parametrosSP = new
            {
                usuario = parametros.SyUser,
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
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarAccesosUsuario(SygenacsDTO parametros, ConnectionManager objConexion)
        {
            this._context = new DbAcceso(objConexion.F_ObtenerCredencialesConfig());
            using var connection = _context.Database.GetDbConnection();
            // Definir la consulta SQL con parámetros
            string sql = "EXEC usp_SY_LISTA_ACCESOMODULOS @usuario,@company";
            // Parámetros para el procedimiento almacenado
            var parametrosSP = new
            {
                usuario = parametros.SyUser,
                company = parametros.SyCompany
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
        public async Task<bool> F_AgregarAccesosUsuario(SygenacsDTO sygenacs, ConnectionManager objConexion)
        {
            bool resultado = false;
            int filasAfectadas = 0;
            this._context = new DbAcceso(objConexion.F_ObtenerCredencialesConfig());
            using var transaction = await _context.Database.BeginTransactionAsync();
            try {
                foreach (var empresa in sygenacs.Empresas) {
                    var parametros = new[]
                    {
                    new SqlParameter("@DatosXML", SqlDbType.Xml) { Value = sygenacs.DatosXml },
                    new SqlParameter("@USER", SqlDbType.VarChar) { Value = sygenacs.SyUser },
                    new SqlParameter("@COMPANY", SqlDbType.VarChar) { Value = empresa.SyCompany }
                    };
                    filasAfectadas = filasAfectadas + await _context.Database.ExecuteSqlRawAsync("EXEC USP_GEN_INS_PROPERTIES @DatosXML, @USER, @COMPANY", parametros);
                }
                resultado = filasAfectadas > 0;
                await transaction.CommitAsync();
                return resultado;
            } catch (Exception ex) {
                await transaction.RollbackAsync();
                throw new Exception("Error: "+ex);
            }
            
        }

    }
}
