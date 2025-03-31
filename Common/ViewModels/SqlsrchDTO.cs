using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public partial class SqlsrchDTO
    {
        public string? SearchFieldId { get; set; }
        public short? SearchNo { get; set; }
        public string? SearchNumeroRegistros { get; set; }
        public string? SearchSelect { get; set; }
        public string? SearchTable { get; set; }
        public string? SearchJoins { get; set; }
        public string? SearchWhere { get; set; }
        public string? SearchWhereDefaults { get; set; }
        public string? SearchFilters { get; set; }
        public string? SearchOrderBy { get; set; }
        public bool HabilitarWhere { get; set; }
        public string? BusquedaConFiltro { get; set; }
        public string? SQLFILTER { get; set; }
        public List<string> listFiltroDatoBuscar { get; set; } = new List<string>();
        public List<string> listFiltroTipoBuscar { get; set; } = new List<string>();
        public List<string> listCampos { get; set; } = new List<string>();
        public List<object> listColumnas { get; set; } = new List<object>();
        public List<object> listTipos { get; set; } = new List<object>();
        public List<object> data { get; set; } = new List<object>();
        public string? CodigoPrincipal { get; set; }
        public string? CampoDescripcion { get; set; }
        public string? tbody { get; set; }
        public string? thead { get; set; }
        public string? table { get; set; }
        public object? codigo { get; set; }
        public string? selectRowDatos { get; set; }
        public string? SearchFormats { get; set; }
        public string? SearchRetVal { get; set; }
    }
}
