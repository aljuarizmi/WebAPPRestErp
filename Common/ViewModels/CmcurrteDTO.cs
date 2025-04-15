using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public partial class CmcurrteDTO
    {
        [Column("rate_ext_code")]
        public string RateExtCode { get; set; } = null!;
        [Column("rate_ext_efe")]
        public int? RateExtEfe { get; set; }
        [Column("rate_ven_dia")]
        public decimal? RateVenDia { get; set; }
        [Column("rate_com_pub")]
        public decimal? RateComPub { get; set; }
        [Column("rate_ven_pub")]
        public decimal? RateVenPub { get; set; }
        [Column("rate_com_pro")]
        public decimal? RateComPro { get; set; }
        [Column("rate_ven_pro")]
        public decimal? RateVenPro { get; set; }
        public string? Filler { get; set; }
        [Column("rate_com_canc")]
        public decimal? RateComCanc { get; set; }
        [Column("rate_ven_canc")]
        public decimal? RateVenCanc { get; set; }
        [Column("curr_rt")]
        public decimal? CurrRt { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public string? Ordercolumn { get; set; }
        [Column("curr_cd")]
        public string? CurrCd { get; set; }
        [Column("curr_rt_eff_dt")]
        public int? CurrRtEffDt { get; set; }
        public int? totalReg { get; set; }
    }
}
