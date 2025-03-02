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
        public int RateExtEfe { get; set; }
        [Column("rate_ven_dia")]
        public decimal? RateVenDia { get; set; }
    }
}
