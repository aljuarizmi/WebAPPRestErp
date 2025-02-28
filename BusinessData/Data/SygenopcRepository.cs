using BusinessData.Interfaces;
using BusinessEntity.Data;
using Common.Services;
using Common.ViewModels;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Dynamic;

namespace BusinessData.Data
{
    public class SygenopcRepository : ISygenopcRepository
    {
        private DbAcceso _context;
        public SygenopcRepository(DbAcceso context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarMenu(SygenacsDTO parametros, ConnectionManager objConexion)
        {
            this._context = new DbAcceso(objConexion.F_ObtenerCredencialesConfig());
            using var connection = _context.Database.GetDbConnection();
            // Definir la consulta SQL con parámetros
            string sql = "EXEC Menu_Test5 @VerSoloERP,@VerOrdenado,@sy_user,@sy_company";
            // Parámetros para el procedimiento almacenado
            var parametrosSP = new
            {
                VerSoloERP = 0,
                VerOrdenado = 1,
                sy_user = parametros.SyUser,
                sy_company = parametros.SyCompany
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
