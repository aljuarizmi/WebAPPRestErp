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
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarAccesosUsuarioSistema(SygenacsDTO parametros, ConnectionManager objConexion) => await _repository.F_ListarAccesosUsuarioSistema(parametros, objConexion);
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarAccesos(ConnectionManager objConexion) => await _repository.F_ListarAccesos(objConexion);
        public List<SygenopcDTO> F_ArmarMenu(IEnumerable<IDictionary<string, object>> datos) {
            var menu = new List<SygenopcDTO>();
            if (!datos.Any()) return menu;
            // Agrupar los datos por nivel
            var modulos = datos.Where(d => Convert.ToInt16(d["sy_menu_level"]) == 3).ToList();
            var subModulos = datos.Where(d => Convert.ToInt16(d["sy_menu_level"]) == 6).ToLookup(d => d["sy_menu_parent"].ToString());
            var nodos = datos.Where(d => Convert.ToInt16(d["sy_menu_level"]) == 9).ToLookup(d => d["sy_menu_parent"].ToString());
            foreach (var modulo in modulos){
                var module = MapearAccesoDTO(modulo);
                module.Children = new List<SygenopcDTO>();
                if (subModulos.Contains(modulo["sy_menu_code"].ToString())){
                    foreach (var subModulo in subModulos[modulo["sy_menu_code"].ToString()]){
                        var subModule = MapearAccesoDTO(subModulo);
                        subModule.Children = new List<SygenopcDTO>();
                        if (nodos.Contains(subModulo["sy_menu_code"].ToString())){
                            foreach (var nodo in nodos[subModulo["sy_menu_code"].ToString()]){
                                var node = MapearAccesoDTO(nodo);
                                subModule.Children.Add(node);
                            }
                        }
                        if (subModule.Children.Count > 0){
                            module.Children.Add(subModule);
                        }
                    }
                }
                menu.Add(module);
            }
            return menu;
        }

        public List<SygenopcDTO> F_ArmarMenuUsuario(IEnumerable<IDictionary<string, object>> datos, CmcurrteDTO cmcurrte, CmcurratDTO cmcurrat){
            var menu = new List<SygenopcDTO>();
            // Evaluamos si hay tipo de cambio válido
            bool tipoCambio = cmcurrte?.RateVenDia > 0 && cmcurrat?.CurrRt > 0;
            if (!datos.Any()) return menu;
            // Agrupar los datos por nivel
            var modulos = datos.Where(d => Convert.ToInt16(d["sy_menu_level"]) == 3).ToList();
            var subModulos = datos.Where(d => Convert.ToInt16(d["sy_menu_level"]) == 6).ToLookup(d => d["id_padre"].ToString());
            var nodos = datos.Where(d => Convert.ToInt16(d["sy_menu_level"]) == 9).ToLookup(d => d["id_padre"].ToString());

            foreach (var modulo in modulos){
                var module = MapearAccesoUsuarioDTO(modulo);
                module.Children = new List<SygenopcDTO>();
                if (subModulos.Contains(modulo["id"].ToString())){
                    foreach (var subModulo in subModulos[modulo["id"].ToString()]){
                        var subModule = MapearAccesoUsuarioDTO(subModulo);
                        subModule.Children = new List<SygenopcDTO>();
                        if (nodos.Contains(subModulo["id"].ToString())){
                            foreach (var nodo in nodos[subModulo["id"].ToString()]){
                                var node = MapearAccesoUsuarioDTO(nodo);
                                if (!tipoCambio && nodo.ContainsKey("cod")){
                                    string cod = nodo["cod"]?.ToString() ?? "";
                                    if ((cod.Contains("S03") || cod.Contains("S04")) && cod.Trim() != "M03S03N01"){
                                        node.SyOpcActive = "N";
                                        node.SyMenuParent = null;
                                        node.SyMenuCode = null;
                                        node.SyTipoCambio = "N";
                                    }
                                }
                                subModule.Children.Add(node);
                            }
                        }
                        if (subModule.Children.Count > 0) {
                            module.Children.Add(subModule);
                        }
                    }
                }
                menu.Add(module);
            }
            return menu;
        }

        // Función auxiliar para mapear objetos
        private SygenopcDTO MapearAccesoUsuarioDTO(IDictionary<string, object> datos){
            return new SygenopcDTO
            {
                SyMenuCode = datos["id"]?.ToString() ?? "",
                SyMenuParent = datos["id_padre"]?.ToString() ?? "",
                SyMenuName = datos["Nombre"]?.ToString() ?? "",
                SyMenuLevel = Convert.ToInt32(datos["sy_menu_level"]),
                SyUrl = "/principal/"+ datos["id"]?.ToString() ?? "",
                SyOpcActive = "Y",
                Children = null,
                SyTipoCambio = "Y",
            };
        }
        private SygenopcDTO MapearAccesoDTO(IDictionary<string, object> datos)
        {
            return new SygenopcDTO
            {
                SyMenuCode = datos["sy_menu_code"]?.ToString() ?? "",
                SyMenuParent = datos["sy_menu_parent"]?.ToString() ?? "",
                SyMenuName = datos["sy_menu_name"]?.ToString() ?? "",
                //SyMenuLevel = Convert.ToInt32(datos["sy_menu_level"]),
                SyUrl = "/principal/" + datos["sy_menu_code"]?.ToString() ?? "",
                SyOpcActive = datos["sy_opc_active"]?.ToString() ?? "",
                Children = null
            };
        }
    }
}
