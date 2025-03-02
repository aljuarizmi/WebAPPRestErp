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

        public async Task<List<SygenopcDTO>> F_ArmarMenu(IEnumerable<IDictionary<string, object>> datos, CmcurrteDTO cmcurrte, CmcurratDTO cmcurrat) {
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
            }else { 
            
            }
            return menu;
        }
    }
}
