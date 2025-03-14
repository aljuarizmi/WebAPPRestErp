using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessData.Interfaces;
using BusinessLogic.Interfaces;
using Common.Services;
using Common.ViewModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;

namespace BusinessLogic.Services
{
    public class SqlsrchService: ISqlsrchService
    {
        private readonly ISqlsrchRepository _repository;
        public SqlsrchService(ISqlsrchRepository repository)
        {
            _repository = repository;
        }
        public enum EnumWhereDefault
        {
            NombreCampo = 1,
            TipoDato = 2,
            TamanioCadena = 3,
            ValorCampo = 4
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarBuscadores(SqlsrchDTO parametros) => await _repository.F_ListarBuscadores(parametros);
        public async Task<IDictionary<string, object>> F_ListarBuscador(SqlsrchDTO parametros) => await _repository.F_ListarBuscador(parametros);
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarConsulta(SqlsrchDTO parametros) => await _repository.F_ListarConsulta(parametros);
        public string BuildFilter(List<string> listFiltroDatoBuscar, List<string> listFiltroTipoBuscar, List<string> listCampos){
            string strFiltroAux = "";
            //listFiltroDatoBuscar: contiene el dato a buscar
            //listFiltroTipoBuscar: contiene el tipo de busqueda que se va a realizar. Siempre es cero
            //listCampos: contiene el nombre del campo sobre el cual se va buscar el dato
            if (listFiltroDatoBuscar != null){
                for (int i = 0; i < listFiltroDatoBuscar.Count; i++){
                    if (!string.IsNullOrEmpty(listFiltroDatoBuscar[i])){
                        if (!string.IsNullOrEmpty(strFiltroAux)){
                            strFiltroAux += " AND ";
                        }
                        switch (listFiltroTipoBuscar[i]){
                            case "0":
                                strFiltroAux += listCampos[i] + " LIKE '" + listFiltroDatoBuscar[i].Replace("'", "''") + "%' ";
                                break;
                            case "1":
                                strFiltroAux += listCampos[i] + " = '" + listFiltroDatoBuscar[i].Replace("'", "''") + "' ";
                                break;
                            case "2":
                                strFiltroAux += listCampos[i] + " LIKE '%" + listFiltroDatoBuscar[i].Replace("'", "''") + "%' ";
                                break;
                        }
                    }
                }
            }
            return strFiltroAux;
        }
        public void F_Armar_SQLFILTER(ref SqlsrchDTO objSearchEstructuraBE){
            string[] arrSQLFilter = null;
            int intMaxSQLFilter = 0;
            string strWhere = null;
            string[,] arrBiSQLFilter = null;
            int intPosInicial = 0;
            // Trabajar con el objeto recibido
            if (objSearchEstructuraBE != null){
                // SQLFILTER
                arrSQLFilter = objSearchEstructuraBE.SearchWhereDefaults?.Split(',');
                if (arrSQLFilter != null && arrSQLFilter.Length > 0){
                    intMaxSQLFilter = ((arrSQLFilter.Length + 1) / 3) - 1;
                    arrBiSQLFilter = new string[intMaxSQLFilter + 1, 5];
                    for (int n = 0; n <= intMaxSQLFilter; n++){
                        arrBiSQLFilter[n, (int)EnumWhereDefault.NombreCampo] = arrSQLFilter[n * 3];
                        arrBiSQLFilter[n, (int)EnumWhereDefault.TipoDato] = arrSQLFilter[(n * 3) + 1];
                        arrBiSQLFilter[n, (int)EnumWhereDefault.TamanioCadena] = arrSQLFilter[(n * 3) + 2];
                        if (arrBiSQLFilter[n, 2].Trim() == "A"){
                            if (int.Parse(arrBiSQLFilter[n, (int)EnumWhereDefault.TamanioCadena]) > objSearchEstructuraBE.SQLFILTER.Length){
                                throw new Exception($"El tamaño del valor del filtro ({objSearchEstructuraBE.SQLFILTER.Length}) es menor a lo estipulado ({arrBiSQLFilter[n, (int)EnumWhereDefault.TamanioCadena]})");
                            }
                            arrBiSQLFilter[n, (int)EnumWhereDefault.ValorCampo] = "'" + objSearchEstructuraBE.SQLFILTER.Substring(intPosInicial, int.Parse(arrBiSQLFilter[n, (int)EnumWhereDefault.TamanioCadena])) + "'";
                        }else{
                            if (int.Parse(arrBiSQLFilter[n, (int)EnumWhereDefault.TamanioCadena]) > objSearchEstructuraBE.SQLFILTER.Length){
                                arrBiSQLFilter[n, (int)EnumWhereDefault.ValorCampo] = objSearchEstructuraBE.SQLFILTER;
                            }else{
                                arrBiSQLFilter[n, (int)EnumWhereDefault.ValorCampo] = objSearchEstructuraBE.SQLFILTER.Substring(intPosInicial, int.Parse(arrBiSQLFilter[n, (int)EnumWhereDefault.TamanioCadena]));
                            }
                        }
                        intPosInicial += int.Parse(arrSQLFilter[(n * 3) + 2]);
                    }
                    if (arrBiSQLFilter.Length > 0){
                        for (int n = 0; n <= intMaxSQLFilter; n++){
                            if (!string.IsNullOrEmpty(objSearchEstructuraBE.SearchWhere)){
                                if (objSearchEstructuraBE.SearchWhere.Trim().Length > 5){
                                    strWhere += " AND " + arrBiSQLFilter[n, (int)EnumWhereDefault.NombreCampo] + " = " + arrBiSQLFilter[n, (int)EnumWhereDefault.ValorCampo];
                                }else{
                                    strWhere += (n == 0 ? " " : " AND ") + arrBiSQLFilter[n, (int)EnumWhereDefault.NombreCampo] + " = " + arrBiSQLFilter[n, (int)EnumWhereDefault.ValorCampo];
                                }
                            }else{
                                strWhere += (n == 0 ? " " : " AND ") + arrBiSQLFilter[n, (int)EnumWhereDefault.NombreCampo] + " = " + arrBiSQLFilter[n, (int)EnumWhereDefault.ValorCampo];
                            }
                        }
                    }
                }
                objSearchEstructuraBE.SearchWhereDefaults = strWhere;
                // Se agrego la siguiente condición al If
                if (!string.IsNullOrEmpty(objSearchEstructuraBE.SearchFilters)){
                    objSearchEstructuraBE.SearchFilters = "AND " + objSearchEstructuraBE.SearchFilters;
                }else{
                    objSearchEstructuraBE.SearchFilters = null;
                }
                // Número de Registros
                if (!string.IsNullOrEmpty(objSearchEstructuraBE.SearchNumeroRegistros)){
                    if (int.TryParse(objSearchEstructuraBE.SearchNumeroRegistros, out _)){
                        objSearchEstructuraBE.SearchNumeroRegistros = " TOP " + objSearchEstructuraBE.SearchNumeroRegistros;
                    }else{
                        objSearchEstructuraBE.SearchNumeroRegistros = "";
                    }
                }
            }
        }
        private void P_inicilizarFiltro(IEnumerable<IDictionary<string, object>> datos, ref List<string> listFiltroDatoBuscar, ref List<string> listFiltroTipoBuscar, ref List<string> listCampos, ref List<object> listColumnas,ref List<object> listTipos)
        {
            listFiltroDatoBuscar = new List<string>();
            listFiltroTipoBuscar = new List<string>();
            listCampos = new List<string>();
            listColumnas = new List<object>();
            if (!datos.Any()) return;
            var columnas = datos.First().Keys.ToList();
            foreach (var columna in columnas){
                listFiltroDatoBuscar.Add("");
                listFiltroTipoBuscar.Add("0");
                listCampos.Add(columna);
                listColumnas.Add(new { Key = columna, Label = columna });
                listTipos.Add(new { Value = "0", Label = "Empieza con" });
            }
        }
        public SqlsrchDTO P_ContruirGrilla(IEnumerable<IDictionary<string, object>> datos, string BusquedaConFiltro, ref List<string> listFiltroDatoBuscar, ref List<string> listFiltroTipoBuscar, ref List<string> listCampos, string CodigoPrincipal, string CampoDescripcion, ref List<object> listColumnas,ref List<object> listTipos)
        {
            var objParResultado = new SqlsrchDTO();
            List<object>? data = new List<object>();
            var i = 0;
            string thead = "", tbody = "", tr1 = "", tr2 = "", trfile = "", tdfile = "", table = "", script, codigo = "", descripcion = "";
            if (!datos.Any()) return objParResultado;
            // Construcción de la cabecera de la grilla
            var columnas = datos.First().Keys.ToList();
            foreach (var columna in columnas){
                tr1 += @$"<th class=""column-title"" data-align=""center"">{columna}</th>";
                tr2 += BusquedaConFiltro == "NO" ?
                //@$"<td><input id=""txtDatoBus{i}"" type=text class=""form-control-custom"" onkeypress=""F_onKeyPressBusquedaEnter('{i}')"" onchange=""F_GuardarFiltro('{i}')""/></td>" :
                //@$"<td><input id=""txtDatoBus{i}"" type=text class=""form-control-custom"" onkeypress=""F_onKeyPressBusquedaEnter('{i}')"" onchange=""F_GuardarFiltro('{i}')"" value=""{(listFiltroDatoBuscar?.ElementAtOrDefault(i) ?? "")}""/></td>";
                @$"<td><input id=""txtDatoBus{i}"" type=text class=""form-control-custom"" (keypress)=""F_onKeyPressBusquedaEnter('{i}')"" (change)=""F_GuardarFiltro('{i}')""/></td>" :
                @$"<td><input id=""txtDatoBus{i}"" type=text class=""form-control-custom"" (keypress)=""F_onKeyPressBusquedaEnter('{i}')"" (change)=""F_GuardarFiltro('{i}')"" value=""{(listFiltroDatoBuscar?.ElementAtOrDefault(i) ?? "")}""/></td>";
                i++;
            }

            i = 0;
            foreach (var fila in datos){
                codigo = fila.ContainsKey(CodigoPrincipal) ? fila[CodigoPrincipal]?.ToString() ?? "" : "";
                descripcion = fila.ContainsKey(CampoDescripcion) ? fila[CampoDescripcion]?.ToString() ?? "" : "";
                script = i % 2 == 0 ?
                    //$"onclick=\"javascript:SelectFileclick('dgvSearchData_{i}','NORMAL');F_SelectFileclick_iframe('{codigo.Replace("'", "").Trim()}','{descripcion.Replace("'", "").Trim()}');\"" :
                    //$"onclick=\"javascript:SelectFileclick('dgvSearchData_{i}','ALTERNATIVA');F_SelectFileclick_iframe('{codigo.Replace("'", "").Trim()}','{descripcion.Replace("'", "").Trim()}');\"";
                    $"(click)=\"SelectFileclick();F_SelectFileclick_iframe();\"" :
                    $"(click)=\"SelectFileclick();F_SelectFileclick_iframe();\"";
                trfile += $"<tr id=\"dgvSearchData_{i}\" {script} style=\"font-size: x-small; cursor: pointer;\">";
                tdfile = string.Join("", columnas.Select(col => $"<td>{fila[col]?.ToString().Trim() ?? ""}</td>"));
                trfile += tdfile + "</tr>";

                var obj = new Dictionary<string, object>(fila);
                data.Add(obj);
                i++;
            }
            thead = @$"<thead><tr class=""headings"">{tr1}</tr><tr class=""headings"">{tr2}</tr></thead>";
            tbody = $"<tbody>{trfile}</tbody>";
            table = @$"<table class=""table-custom table-bordered table-striped table-hover"" id=""tblSerieLote"" data-row-style=""rowStyle"">{thead}{tbody}</table>";
            if (BusquedaConFiltro == "NO"){
                P_inicilizarFiltro(datos, ref listFiltroDatoBuscar, ref listFiltroTipoBuscar, ref listCampos, ref listColumnas,ref listTipos);
            }
            //objParResultado.tbody = tbody;
            //objParResultado.thead = thead;
            objParResultado.table = table;
            objParResultado.data = data;
            return objParResultado;
        }
        public async Task<SqlsrchDTO> F_Buscar(SqlsrchDTO parametros) {
            SqlsrchDTO resultado = new SqlsrchDTO();
            IEnumerable<IDictionary<string, object>> busqueda = null;
            IDictionary<string, object> buscador = await _repository.F_ListarBuscador(parametros);
            if (buscador != null) {
                if (buscador.Any()) {
                    //var elementoSearch = buscador.First();
                    parametros.SearchSelect = buscador["SELECT"]?.ToString();
                    parametros.SearchTable = buscador["FROM"]?.ToString();
                    parametros.SearchJoins = buscador["INNER_JOIN"]?.ToString();
                    parametros.SearchWhere = buscador["WHERE"]?.ToString();
                    parametros.SearchWhereDefaults = buscador["WHERE_DEFAULT"]?.ToString();
                    parametros.SearchOrderBy = buscador["ORDER_BY"]?.ToString();
                    if (parametros.SearchNumeroRegistros.IsNullOrEmpty()) {
                        parametros.SearchNumeroRegistros = "10";
                    }
                    //parametros.SearchSelect = buscador["SEARCH_FORMATS"]?.ToString();
                    //parametros.SearchSelect = buscador["SEARCH_RET_VAL"]?.ToString();
                    if (!parametros.BusquedaConFiltro.IsNullOrEmpty()) {
                        if ((parametros.BusquedaConFiltro != "SI")&& (parametros.BusquedaConFiltro != "NO")) {
                            parametros.BusquedaConFiltro = "NO";
                        }
                    } else {
                        parametros.BusquedaConFiltro = "NO";
                    }
                    if (parametros.BusquedaConFiltro == "SI"){
                        parametros.SearchFilters = BuildFilter(parametros.listFiltroDatoBuscar, parametros.listFiltroTipoBuscar, parametros.listCampos);
                    }else{
                        parametros.SearchFilters = "1=1";
                    }
                    if (parametros.SearchFieldId == "SY-ACCOUNT" || parametros.SearchFieldId == "SY-ACCOUNT-OPER" || parametros.SearchFieldId == "SY-ACC-GRP-002" || parametros.SearchFieldId == "SY-ACCOUNT-GRP" || parametros.SearchFieldId == "SY-CASH-ACCOUNT"){
                        if (parametros.SQLFILTER?.Trim() != ""){
                            if (parametros.SQLFILTER?.Trim().Length >= 10) {
                                string fecha = "";
                                string loc = "";
                                string[] locs = null;
                                if (parametros.SQLFILTER?.Trim().Length == 10) {
                                    fecha = parametros.SQLFILTER?.Trim();
                                } else {
                                    fecha = parametros.SQLFILTER?.Substring(0, 10).Trim();
                                    loc = parametros.SQLFILTER?.Substring(0, parametros.SQLFILTER.Trim().Length - 10).Trim();
                                }
                                if (DateTime.TryParse(fecha, out DateTime fechaDate)){
                                    string plan_year = fechaDate.Year.ToString();
                                    DateTime.TryParse(parametros.SQLFILTER?.Trim(), out _);
                                    parametros.SearchWhere += " AND (plan_id=0 OR plan_id in(SELECT plan_id FROM SYACTPLN_SQL WHERE " + plan_year + " BETWEEN plan_year_start AND plan_year_end)) ";
                                }
                                if (parametros.SearchFieldId == "SY-CASH-ACCOUNT"){
                                    string sqlquery = "";
                                    if (!string.IsNullOrWhiteSpace(loc)){
                                        locs = loc.Split(',');
                                        if (locs.Length > 0){
                                            for (int i = 0; i < locs.Length; i++){
                                                sqlquery += (string.IsNullOrWhiteSpace(sqlquery) ? "" : ",") + "'" + locs[i] + "'";
                                            }
                                            parametros.SearchWhere += " AND loc IN(" + sqlquery + ")";
                                        }
                                    }
                                }
                            }
                        }
                        //Armamos los filtros
                        F_Armar_SQLFILTER(ref parametros);
                        //Realizamos la consulta
                        busqueda = await _repository.F_ListarConsulta(parametros);
                    }else{
                        //Armamos los filtros
                        F_Armar_SQLFILTER(ref parametros);
                        //Realizamos la consulta
                        busqueda = await _repository.F_ListarConsulta(parametros);
                    }
                    List<string> listFiltroDatoBuscar = parametros.listFiltroDatoBuscar;
                    List<string> listFiltroTipoBuscar = parametros.listFiltroTipoBuscar;
                    List<string> listCampos = parametros.listCampos;
                    List<object> listColumnas = parametros.listColumnas;
                    List<object> listTipos = parametros.listTipos;
                    resultado = P_ContruirGrilla(busqueda, parametros.BusquedaConFiltro, ref listFiltroDatoBuscar, ref listFiltroTipoBuscar, ref listCampos, parametros.CodigoPrincipal, parametros.CampoDescripcion, ref listColumnas, ref listTipos);
                    resultado.listCampos = listCampos;
                    resultado.listFiltroDatoBuscar = listFiltroDatoBuscar;
                    resultado.listFiltroTipoBuscar = listFiltroTipoBuscar;
                    resultado.listColumnas = listColumnas;
                    resultado.listTipos = listTipos;
                }
            }
            return resultado;
        }
        public async Task<IDictionary<string, object>> F_BuscarCodigo(SqlsrchDTO parametros)
        {
            IDictionary<string, object> resultado=null;
            IEnumerable<IDictionary<string, object>> busqueda = null;
            IDictionary<string, object> buscador = await _repository.F_ListarBuscador(parametros);
            if (buscador != null) {
                if (buscador.Any()) {
                    parametros.SearchSelect = buscador["SELECT"]?.ToString();
                    parametros.SearchTable = buscador["FROM"]?.ToString();
                    parametros.SearchJoins = buscador["INNER_JOIN"]?.ToString();
                    parametros.SearchWhere = buscador["WHERE"]?.ToString();
                    parametros.SearchWhere = DeterminarFiltroPrincipal(parametros);
                    parametros.SearchSelect = F_PulirSelect(parametros);
                    parametros.SearchWhereDefaults = buscador["WHERE_DEFAULT"]?.ToString();
                    parametros.SearchOrderBy = buscador["ORDER_BY"]?.ToString();
                    parametros.SearchNumeroRegistros = "1";
                    F_Armar_SQLFILTER(ref parametros);
                    busqueda = await _repository.F_ListarConsulta(parametros);
                    if (busqueda != null) {
                        if (busqueda.Any()) {
                            resultado = busqueda.FirstOrDefault();
                        }
                    }
                }
            }
            return resultado;
        }
        public string DeterminarFiltroPrincipal(SqlsrchDTO parametros){
            string strTabla = parametros.SearchTable.ToUpper().Replace("FROM ", "");
            string strWhere = parametros.SearchWhere;
            string strCodigo = parametros.codigo.ToString().Trim();
            strWhere = (strWhere.Trim().ToUpper() != "WHERE" ? strWhere + " AND " : strWhere) +
                       strTabla + "." + parametros.CodigoPrincipal + " = '" + strCodigo.Replace("'", "''") + "'";
            return strWhere;
        }
        public string F_PulirSelect(SqlsrchDTO parametros){
            if (!string.IsNullOrEmpty(parametros.selectRowDatos)){
                string[] ArrSelect = parametros.selectRowDatos.Split(',');
                string StrSelect = parametros.SearchSelect;
                string StrTabla = parametros.SearchTable.ToUpper().Replace("FROM ", "");
                foreach (string item in ArrSelect){
                    if (!StrSelect.Contains(item)){
                        StrSelect += "," + StrTabla + "." + item;
                    }
                }
                return StrSelect;
            }else{
                return parametros.SearchSelect;
            }
        }
        public string F_CalcularFiltro(string filtro){
            string[] arrFiltro;
            string strEspaciosVacios = new string(' ', 60); // Espacios en blanco
            filtro = filtro.Replace("'", "");
            arrFiltro = filtro.Split('|');
            int longitud = arrFiltro.Length;
            if (longitud <= 0)
                throw new Exception("Error en el filtro en estructura");
            if ((longitud % 2) != 0)
                throw new Exception("Error en el filtro no par");
            int longitudFor = longitud / 2;
            int intVacios;
            string strValor = "";
            for (int i = 0; i < longitudFor; i++){
                strValor = arrFiltro[i * 2].Trim();
                intVacios = int.Parse(arrFiltro[(i * 2) + 1]);
                if (strValor.Length > intVacios){
                    return strValor;
                }
                if ((strValor.Length - intVacios) < 0){
                    strValor = strValor + strEspaciosVacios.Substring(0, intVacios - strValor.Length);
                }else{
                    strValor = strValor + strEspaciosVacios.Substring(0, strValor.Length - intVacios);
                }
                return strValor;
            }
            return ""; // Retorno por defecto en caso de que el loop no entre
        }

    }
}
