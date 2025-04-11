using BusinessData.Interfaces;
using BusinessLogic.Interfaces;
using Common.Services;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLogic.Services
{
    public class SygenacsService: ISygenacsService
    {
        private readonly ISygenacsRepository _repository;
        public SygenacsService(ISygenacsRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarEmpresasUsuario(SygenacsDTO parametros, ConnectionManager objConexion) => await _repository.F_ListarEmpresasUsuario(parametros, objConexion);
        public async Task<IEnumerable<IDictionary<string, object>>> F_ListarAccesosUsuario(SygenacsDTO parametros, ConnectionManager objConexion) => await _repository.F_ListarAccesosUsuario(parametros, objConexion);
        public async Task<bool> F_AgregarAccesosUsuario(SygenacsDTO parametros, ConnectionManager objConexion) => await _repository.F_AgregarAccesosUsuario(parametros, objConexion);
        public List<SygenacsDTO> MapearSygenacsDTO(IEnumerable<IDictionary<string, object>> data)
        {
            List<SygenacsDTO> result = new List<SygenacsDTO>();
            foreach (var item in data)
            {
                SygenacsDTO dto = new SygenacsDTO
                {
                    SyUser = item.ContainsKey("sy_user") ? item["sy_user"] as string : null,
                    SyCompany = item.ContainsKey("sy_company") ? item["sy_company"] as string : null,
                    SyMenuCode = item.ContainsKey("sy_menu_code") ? item["sy_menu_code"] as string : null,
                    SyMenuState = item.ContainsKey("sy_menu_state") ? item["sy_menu_state"] as string : null,
                    SyOpcActive = item.ContainsKey("sy_opc_active") ? item["sy_opc_active"] as string : null
                };
                result.Add(dto);
            }
            return result;
        }
        public string SerializarSygenacsDTO(List<SygenacsDTO> data) {
            // Crear un StringWriter para capturar el XML serializado
            StringWriter swStringWriterActividad = new StringWriter();

            // Crear una instancia del serializador para una lista del tipo SygenacsDTO
            XmlSerializer serializerActividad = new XmlSerializer(typeof(List<SygenacsDTO>), new XmlRootAttribute("ArrayOfSYGENACSBE"));

            // Crear una lista vacía del tipo SygenacsDTO
            //List<SygenacsDTO> arrObjEntidad_BE = new List<SygenacsDTO>();

            // Serializar la lista vacía en formato XML dentro del StringWriter
            serializerActividad.Serialize(swStringWriterActividad, data);

            // Puedes ver el resultado del XML así:
            string xmlOutput = swStringWriterActividad.ToString();
            return xmlOutput;
        }
    }
}
