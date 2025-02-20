using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class ApopnfilDTO
    {
        public string TipoFg { get; set; } = string.Empty;
        public int ChkSaldo { get; set; } = 1;
        public string ChkVoid { get; set; } = "0";
        public string VendNo { get; set; } = string.Empty;
        public string ChkDes { get; set; } = "0";
        public string ChkHas { get; set; } = "0";
        public int TrxDtIni { get; set; } = 0;
        public int TrxDtFin { get; set; } = 0;
        public string ChkDes1 { get; set; } = "0";
        public string ChkHas1 { get; set; } = "0";
        public int DueDtIni { get; set; } = 0;
        public int DueDtFin { get; set; } = 0;
        public string ChkDes2 { get; set; } = "0";
        public string ChkHas2 { get; set; } = "0";
        public int VchrDtIni { get; set; } = 0;
        public int VchrDtFin { get; set; } = 0;
        public int DocIni { get; set; } = 0;
        public int DocFin { get; set; } = 0;
        public string AplIni { get; set; } = string.Empty;
        public string AplFin { get; set; } = string.Empty;
        public string InvNo { get; set; } = string.Empty;
        public string ApplyToNo { get; set; } = string.Empty;
        public string Doc1 { get; set; } = string.Empty;
        public string Doc2 { get; set; } = string.Empty;
        public string Doc3 { get; set; } = string.Empty;
        public string Apl1 { get; set; } = string.Empty;
        public string Apl2 { get; set; } = string.Empty;
        public string Apl3 { get; set; } = string.Empty;
        public string JnlCd { get; set; } = string.Empty;
        public string VchrChkCd { get; set; } = string.Empty;
        public string JnlBatchId { get; set; } = string.Empty;
        public string UserDefFld1 { get; set; } = string.Empty;
        public string VendTypeCd { get; set; } = string.Empty;
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderColumn { get; set; } = string.Empty;
        public string ReferencialApplyToNo { get; set; } = string.Empty;
    }
}
