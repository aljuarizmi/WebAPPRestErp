using BusinessData.Interfaces;
using BusinessLogic.Interfaces;
using Common.Services;
using Common.ViewModels;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class SygenopcService : ISygenopcService
    {
        private readonly ISygenopcRepository _repository;
        public SygenopcService(ISygenopcRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarMenu(SygenacsDTO parametros, ConnectionManager objConexion) => await _repository.F_ListarMenu(parametros, objConexion);

        public async Task<List<SygenopcDTO>> F_ArmarMenu2(IEnumerable<IDictionary<string, object>> datos, CmcurrteDTO cmcurrte, CmcurratDTO cmcurrat) {
            //Recorremos la lista generica para armar el menu
            List<SygenopcDTO> menu = new List<SygenopcDTO>();
            bool tipoCambio = true;
            if (datos.Any()){
                if (cmcurrte == null || cmcurrat == null){
                    tipoCambio = false;
                }else {
                    if (cmcurrte != null) {
                        if (cmcurrte.RateVenDia <= 0) {
                            tipoCambio = false;
                        }
                    }
                    if (cmcurrat != null){
                        if (cmcurrat.CurrRt <= 0){
                            tipoCambio = false;
                        }
                    }
                }
                //Obtenemos los modulos
                IEnumerable<IDictionary<string, object>> modulos = datos.Where(d => d.ContainsKey("sy_menu_level") && Convert.ToInt16(d["sy_menu_level"]) == 3);
                foreach (var modulo in modulos){
                    SygenopcDTO module = new SygenopcDTO();
                    //Obtenemos los submodulos
                    IEnumerable<IDictionary<string, object>> sub_modulos = datos.Where(d => d.ContainsKey("sy_menu_level") && Convert.ToInt16(d["sy_menu_level"]) == 6 && (modulo["id"].ToString() == d["id_padre"].ToString()));
                    foreach (var sub_modulo in sub_modulos){
                        SygenopcDTO sub_module = new SygenopcDTO();
                        //Obtenemos los nodos
                        IEnumerable<IDictionary<string, object>> nodos = datos.Where(d => d.ContainsKey("sy_menu_level") && Convert.ToInt16(d["sy_menu_level"]) == 9 && (sub_modulo["id"].ToString() == d["id_padre"].ToString()));
                        foreach (var nodo in nodos){
                            SygenopcDTO node = new SygenopcDTO();
                            if (nodo.ContainsKey("id") || nodo.ContainsKey("id_padre") || nodo.ContainsKey("Nombre") || nodo.ContainsKey("sy_menu_level") || nodo.ContainsKey("cod")){
                                if (!tipoCambio) {
                                    //No hay tipo de cambio
                                    string cod = nodo["cod"]?.ToString() ?? "";
                                    if ((cod.Contains("S03")==true || cod.Contains("S04") == true) && cod.Trim() != "M03S03N01") {
                                        //Revisar el Tipo de Cambio del día
                                        node.SyOpcActive = "N";
                                        node.SyMenuName = "Revise el Tipo de Cambio del día";
                                        node.Children = null;
                                    } else {
                                        node.SyMenuCode = nodo["id"]?.ToString() ?? "";
                                        node.SyMenuParent = nodo["id_padre"]?.ToString() ?? "";
                                        node.SyMenuName = nodo["Nombre"]?.ToString() ?? "";
                                        node.SyMenuLevel = Convert.ToInt32(nodo["sy_menu_level"]);
                                        node.SyOpcActive = "Y";
                                        node.Children = null;
                                    }
                                } else {
                                    //Si hay tipo de cambio
                                    node.SyMenuCode = nodo["id"]?.ToString() ?? "";
                                    node.SyMenuParent = nodo["id_padre"]?.ToString() ?? "";
                                    node.SyMenuName = nodo["Nombre"]?.ToString() ?? "";
                                    node.SyMenuLevel = Convert.ToInt32(nodo["sy_menu_level"]);
                                    node.SyOpcActive = "Y";
                                    node.Children = null;
                                }
                            }
                            sub_module.Children?.Add(node);
                        }
                        sub_module.SyMenuCode = (string)sub_modulo["id"];
                        sub_module.SyMenuParent = (string)sub_modulo["id_padre"];
                        sub_module.SyMenuName = (string)sub_modulo["Nombre"];
                        sub_module.SyMenuLevel = (Int16)sub_modulo["sy_menu_level"];
                        module.Children?.Add(sub_module);
                    }
                    module.SyMenuCode = (string)modulo["id"];
                    module.SyMenuParent = (string)modulo["id_padre"];
                    module.SyMenuName = (string)modulo["Nombre"];
                    module.SyMenuLevel = (Int16)modulo["sy_menu_level"];
                    menu.Add(module);
                }
            }
            return menu;
        }

        public List<SygenopcDTO> F_ArmarMenu(IEnumerable<IDictionary<string, object>> datos, CmcurrteDTO cmcurrte, CmcurratDTO cmcurrat){
            var menu = new List<SygenopcDTO>();
            // Evaluamos si hay tipo de cambio válido
            bool tipoCambio = cmcurrte?.RateVenDia > 0 && cmcurrat?.CurrRt > 0;
            if (!datos.Any()) return menu;
            // Agrupar los datos por nivel
            var modulos = datos.Where(d => Convert.ToInt16(d["sy_menu_level"]) == 3).ToList();
            var subModulos = datos.Where(d => Convert.ToInt16(d["sy_menu_level"]) == 6).ToLookup(d => d["id_padre"].ToString());
            var nodos = datos.Where(d => Convert.ToInt16(d["sy_menu_level"]) == 9).ToLookup(d => d["id_padre"].ToString());

            foreach (var modulo in modulos){
                var module = CrearSygenopcDTO(modulo);
                module.Children = new List<SygenopcDTO>();

                if (subModulos.Contains(modulo["id"].ToString())){
                    foreach (var subModulo in subModulos[modulo["id"].ToString()]){
                        var subModule = CrearSygenopcDTO(subModulo);
                        subModule.Children = new List<SygenopcDTO>();

                        if (nodos.Contains(subModulo["id"].ToString())){
                            foreach (var nodo in nodos[subModulo["id"].ToString()]){
                                var node = CrearSygenopcDTO(nodo);

                                if (!tipoCambio && nodo.ContainsKey("cod")){
                                    string cod = nodo["cod"]?.ToString() ?? "";
                                    if ((cod.Contains("S03") || cod.Contains("S04")) && cod.Trim() != "M03S03N01"){
                                        node.SyOpcActive = "N";
                                        node.SyMenuName = "Revise el Tipo de Cambio del día";
                                        node.SyMenuParent = null;
                                        node.SyMenuCode = null;
                                    }
                                }
                                subModule.Children.Add(node);
                            }
                        }
                        module.Children.Add(subModule);
                    }
                }
                menu.Add(module);
            }
            return menu;
        }

        // Función auxiliar para mapear objetos
        private SygenopcDTO CrearSygenopcDTO(IDictionary<string, object> datos){
            return new SygenopcDTO
            {
                SyMenuCode = datos["id"]?.ToString() ?? "",
                SyMenuParent = datos["id_padre"]?.ToString() ?? "",
                SyMenuName = datos["Nombre"]?.ToString() ?? "",
                SyMenuLevel = Convert.ToInt32(datos["sy_menu_level"]),
                SyUrl = "/principal/"+ datos["id"]?.ToString() ?? "",
                SyOpcActive = "Y",
                Children = null
            };
        }

    }
}
