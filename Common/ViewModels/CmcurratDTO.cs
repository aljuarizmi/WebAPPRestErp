using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public partial class CmcurratDTO
    {
        [Column("curr_cd")]
        public string CurrCd { get; set; } = null!;
        [Column("curr_rt_eff_dt")]
        public int? CurrRtEffDt { get; set; }
        [Column("curr_rt")]
        public decimal? CurrRt { get; set; }
    }
}
