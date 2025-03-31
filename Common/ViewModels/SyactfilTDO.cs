using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public partial class SyactfilTDO
    {
        [Column("mn_no")]
        public string MnNo { get; set; }
        [Column("sb_no")]
        public string SbNo { get; set; }
        [Column("dp_no")]
        public string DpNo { get; set; }
        [Column("acct_desc")]
        public string AcctDesc { get; set; } = string.Empty;
        [Column("search_desc")]
        public string SearchDesc { get; set; } = string.Empty;
        [Column("tb_sb_tot_lev")]
        public short TbSbTotLev { get; set; } = 0;
        [Column("acct_desc_2")]
        public string AcctDesc2 { get; set; } = string.Empty;
        public short PlanYear { get; set; }
        [Column("pa_corr_03")]
        public short PaCorr03 { get; set; } = 0;
    }
}
