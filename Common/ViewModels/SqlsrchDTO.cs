using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public partial class SqlsrchDTO
    {
        public string SearchFieldId { get; set; } = null!;
        public short SearchNo { get; set; }
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
        public List<string>? listFiltroDatoBuscar { get; set; }
        public List<string>? listFiltroTipoBuscar { get; set; }
        public List<string>? listCampos { get; set; }
        public List<object>? listColumnas { get; set; }
        public List<object>? data { get; set; }
        public string? CodigoPrincipal { get; set; }
        public string? CampoDescripcion { get; set; }
        public string? tbody { get; set; }
        public string? thead { get; set; }
        public string? table { get; set; }
    }
}
