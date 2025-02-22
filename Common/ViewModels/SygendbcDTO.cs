using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class SygendbcDTO
    {
        public string? SyCompany { get; set; }
        public string? SyCompanyDescr { get; set; }
        public int? BizGrpId { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderColumn { get; set; } = string.Empty;
    }
}
