using System.Xml.Serialization;

namespace Common.ViewModels
{
    [XmlType("SYGENACSBE")]
    public class SygenacsDTO
    {
        [XmlElement("sy_user")]
        public string SyUser { get; set; } = "";
        [XmlElement("sy_company")]
        public string SyCompany { get; set; } = "";
        [XmlElement("sy_menu_code")]
        public string SyMenuCode { get; set; } = "";
        public string SyMenuState { get; set; } = "";
        public string SyOpcActive { get; set; } = "";
        public string DatosXml { get; set; } = "";
        public List<SygenacsDTO> Accesos { get; set; }= new List<SygenacsDTO>();
        public List<SygenacsDTO> Empresas { get; set; } = new List<SygenacsDTO>();
    }
    [XmlRoot("ArrayOfSYGENACSBE")]
    public class SygenacsList : List<SygenacsDTO> { }
}
