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
    public class SqlsrchRepository: ISqlsrchRepository
    {
        private DbConexion _contextDbConexion;
        private DbAcceso _contextDbAcceso;
        private readonly ConnectionManager _connectionmanager;
        public SqlsrchRepository(DbConexion contextDbConexion, DbAcceso contextDbAcceso, ConnectionManager connectionmanager)
        {
            this._contextDbConexion = contextDbConexion;
            this._contextDbAcceso = contextDbAcceso;
            _connectionmanager = connectionmanager;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarBuscadores(SqlsrchDTO parametros)
        {
            this._contextDbConexion = new DbConexion(_connectionmanager.F_ObtenerCredencialesSpanish());
            using var connection = _contextDbConexion.Database.GetDbConnection();
            // Definir la consulta SQL con parámetros
            string sql = "EXEC usp_sc_pro_FILESERCH @VchSEARCHID";
            // Parámetros para el procedimiento almacenado
            var parametrosSP = new
            {
                VchSEARCHID = parametros.SearchFieldId
            };
            if (connection.State == ConnectionState.Closed)
                await connection.OpenAsync();
            // Ejecutamos la consulta con Dapper y mapeamos a una lista de diccionarios
            var resultado = (await connection.QueryAsync(sql, parametrosSP))
            .Select(row =>
            {
                var expando = new ExpandoObject();
                var dict = (IDictionary<string, object?>)expando;
                foreach (var prop in (IDictionary<string, object?>)row){
                    if (prop.Key != null){
                        dict[prop.Key] = prop.Value ?? "";
                    }
                }
                return dict;
            }).ToList();
            return resultado;
        }
        public async Task<IDictionary<string, object>> F_ListarBuscador(SqlsrchDTO parametros)
        {
            this._contextDbConexion = new DbConexion(_connectionmanager.F_ObtenerCredencialesSpanish());
            using var connection = _contextDbConexion.Database.GetDbConnection();
            string sql = "EXEC usp_sc_pro_SELECT_FILESEARCH @VchSEARCH_FIELD_ID, @IntSEARCH_NO";
            var parametrosSP = new
            {
                VchSEARCH_FIELD_ID = parametros.SearchFieldId,
                IntSEARCH_NO = parametros.SearchNo
            };
            if (connection.State == ConnectionState.Closed)
                await connection.OpenAsync();
            // Ejecutamos la consulta con Dapper
            var resultado = await connection.QueryAsync(sql, parametrosSP);
            // Convertimos la primera fila en un diccionario
            var primeraFila = resultado.FirstOrDefault();
            if (primeraFila == null)
            {
                return new Dictionary<string, object>(); // Devuelve un diccionario vacío si no hay resultados
            }
            // Convertimos el objeto en un IDictionary<string, object>
            return (IDictionary<string, object>)primeraFila;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarConsulta(SqlsrchDTO parametros)
        {
            this._contextDbAcceso = new DbAcceso(_connectionmanager.F_ObtenerCredenciales());
            using var connection = _contextDbAcceso.Database.GetDbConnection();
            // Definir la consulta SQL con parámetros
            string StrQueryString = "";
            string strTablaTemporal = "";
            if (parametros.HabilitarWhere) {
                if (parametros.BusquedaConFiltro != "SI") {
                    parametros.SearchFilters = "";
                }
                if (parametros.SearchFilters == "") {
                    StrQueryString = "SELECT " +
                    parametros.SearchNumeroRegistros + " " +
                    parametros.SearchSelect +
                    parametros.SearchTable +
                    parametros.SearchJoins +
                    parametros.SearchWhere +
                    parametros.SearchWhereDefaults +
                    parametros.SearchFilters +
                    parametros.SearchOrderBy;
                } else {
                    strTablaTemporal = "#GENBUSCADORFILTRO_"+DateTime.Now.ToString("yyyyMMdd_mmHHss");
                    StrQueryString = "SELECT " +
                    parametros.SearchSelect +
                    " INTO " + strTablaTemporal + " " + parametros.SearchTable +
                    parametros.SearchJoins +
                    parametros.SearchWhere +
                    parametros.SearchWhereDefaults +
                    parametros.SearchOrderBy + "; " +
                    " SELECT " + parametros.SearchNumeroRegistros + " *  FROM " + strTablaTemporal +
                    " WHERE 1=1 " +
                    parametros.SearchFilters;
                }
            } else {
                if (!parametros.HabilitarWhere) {
                    if ((parametros.SearchWhereDefaults == null) && (parametros.SearchFilters != null)) {
                        if (parametros.SearchFilters == "") {
                            StrQueryString = "SELECT " +
                            parametros.SearchNumeroRegistros + " " +
                            parametros.SearchSelect +
                            parametros.SearchTable +
                            parametros.SearchJoins +
                            parametros.SearchWhere +
                            parametros.SearchWhereDefaults +
                            parametros.SearchFilters +
                            parametros.SearchOrderBy;
                        } else {
                            strTablaTemporal = "#GENBUSCADORFILTRO_" + DateTime.Now.ToString("yyyyMMdd_mmHHss");
                            StrQueryString = "SELECT " +
                            parametros.SearchSelect +
                            " INTO " + strTablaTemporal + " " + parametros.SearchTable +
                            parametros.SearchJoins +
                            parametros.SearchWhere +
                            parametros.SearchWhereDefaults +
                            parametros.SearchOrderBy + "; " +
                            " SELECT " + parametros.SearchNumeroRegistros + " *  FROM " + strTablaTemporal +
                            " WHERE 1=1 " +
                            parametros.SearchFilters;
                        }
                    } else {
                        if ((parametros.SearchWhereDefaults == null) && (parametros.SearchFilters != null)) {
                            if (parametros.SearchFilters == ""){
                                StrQueryString = "SELECT " +
                                parametros.SearchNumeroRegistros + " " +
                                parametros.SearchSelect +
                                parametros.SearchTable +
                                parametros.SearchJoins +
                                " WHERE 1=1 "+parametros.SearchWhere +
                                parametros.SearchWhereDefaults +
                                parametros.SearchFilters +
                                parametros.SearchOrderBy;
                            }else{
                                strTablaTemporal = "#GENBUSCADORFILTRO_" + DateTime.Now.ToString("yyyyMMdd_mmHHss");
                                StrQueryString = "SELECT " +
                                parametros.SearchSelect +
                                " INTO " + strTablaTemporal + " " + parametros.SearchTable +
                                parametros.SearchJoins +
                                " WHERE 1=1 "+parametros.SearchWhere +
                                parametros.SearchWhereDefaults +
                                parametros.SearchOrderBy + "; " +
                                " SELECT " + parametros.SearchNumeroRegistros + " *  FROM " + strTablaTemporal +
                                " WHERE 1=1 " +
                                parametros.SearchFilters;
                            }
                        } else {
                            if (parametros.SearchFilters == ""){
                                StrQueryString = "SELECT " +
                                parametros.SearchNumeroRegistros + " " +
                                parametros.SearchSelect +
                                parametros.SearchTable +
                                parametros.SearchJoins +
                                " WHERE "+parametros.SearchWhere +
                                parametros.SearchWhereDefaults +
                                parametros.SearchFilters +
                                parametros.SearchOrderBy;
                            }else{
                                strTablaTemporal = "#GENBUSCADORFILTRO_" + DateTime.Now.ToString("yyyyMMdd_mmHHss");
                                StrQueryString = "SELECT " +
                                parametros.SearchNumeroRegistros+" "+
                                parametros.SearchSelect +
                                " INTO " + strTablaTemporal + " " + parametros.SearchTable +
                                parametros.SearchJoins +
                                " WHERE "+parametros.SearchWhere +
                                parametros.SearchWhereDefaults +
                                parametros.SearchOrderBy + "; " +
                                " SELECT " + parametros.SearchNumeroRegistros + " *  FROM " + strTablaTemporal +
                                " WHERE 1=1 " +
                                parametros.SearchFilters;
                            }
                        }
                    }
                }
            }
            if (connection.State == ConnectionState.Closed)
                await connection.OpenAsync();
            // Ejecutamos la consulta con Dapper y mapeamos a una lista de diccionarios
            var resultado = (await connection.QueryAsync(StrQueryString))
            .Select(row =>
            {
                var expando = new ExpandoObject();
                var dict = (IDictionary<string, object?>)expando;
                foreach (var prop in (IDictionary<string, object?>)row){
                    if (prop.Key != null){
                        dict[prop.Key] = prop.Value ?? "";
                    }
                }
                return dict;
            }).ToList();
            return resultado;
        }
    }
}
