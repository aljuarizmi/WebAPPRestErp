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

namespace BusinessData.Data
{
    public class SygenusrRepository: ISygenusrRepository
    {
        private DbAcceso _context;
        public SygenusrRepository(DbAcceso context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarUsuarioGrupo(SygenusrDTO parametros, ConnectionManager objConexion)
        {
            this._context = new DbAcceso(objConexion.F_ObtenerCredencialesConfig());
            using var connection = _context.Database.GetDbConnection();
            // Definir la consulta SQL con parámetros
            string sql = "EXEC usp_SY_LIS_GRUPO_SQLSYUSR_SQL @biz_grp_id";
            // Parámetros para el procedimiento almacenado
            var parametrosSP = new
            {
                biz_grp_id = parametros.BizGrpId,
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
