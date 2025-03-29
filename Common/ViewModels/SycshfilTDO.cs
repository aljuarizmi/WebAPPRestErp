using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public partial class SycshfilTDO
    {
        public string MnNo { get; set; }
        public string SbNo { get; set; }
        public string DpNo { get; set; }
        public string AcctDesc { get; set; }=string.Empty;
        public string SearchDesc { get; set; } = string.Empty;
        public short TbSbTotLev { get; set; } = 0;
        public string AcctDesc2 { get; set; } = string.Empty;
        public short PlanYear { get; set; }
    }
}
