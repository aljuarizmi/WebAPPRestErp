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
        public string VendNo { get; set; } = null!;

        public int VchrNo { get; set; }

        public string VchrChkCd { get; set; } = null!;

        public string VchrChkType { get; set; } = null!;

        public int ApOpnDt { get; set; }

        public int ApOpnTm { get; set; }

        public string AltCurrCd { get; set; } = null!;

        public string AltVendNo { get; set; } = null!;

        public string ApplyToNo { get; set; } = null!;

        public string VchrChkType1 { get; set; } = null!;

        public int TrxDt { get; set; }

        public string OpnClosCd { get; set; } = null!;

        public string Alt1CurrCd { get; set; } = null!;

        public string Alt1VendNo { get; set; } = null!;

        public string SepChkFg { get; set; } = null!;

        public string Alt1ApplyToNo { get; set; } = null!;

        public int Alt1TrxDt { get; set; }

        public string Status { get; set; } = null!;

        public string Alt3VchrCd { get; set; } = null!;

        public string CashMnNo { get; set; } = null!;

        public string CashSbNo { get; set; } = null!;

        public string CashDpNo { get; set; } = null!;

        public int ChkNo { get; set; }

        public short SeqNo { get; set; }

        public string Alt5InvCd { get; set; } = null!;

        public string Alt5CurrCd { get; set; } = null!;

        public string Alt5VendNo { get; set; } = null!;

        public string Alt5ApplyToNo { get; set; } = null!;

        public int Alt5TrxDt { get; set; }

        public int? VchrDt { get; set; }

        public string? VchrType { get; set; }

        public string? ApPoNo { get; set; }

        public string? InvNo { get; set; }

        public decimal? Amt { get; set; }

        public decimal? PayAmt { get; set; }

        public int? DueDt { get; set; }

        public int? DiscDt { get; set; }

        public int? ChkVchrNo { get; set; }

        public int? ChkDt { get; set; }

        public decimal? DiscAmt { get; set; }

        public decimal? DiscTaken { get; set; }

        public string? Reference { get; set; }

        public string? ApMnNo { get; set; }

        public string? ApSbNo { get; set; }

        public string? ApDpNo { get; set; }

        public int? FullyPaidDt { get; set; }

        public int? VoidChkDt { get; set; }

        public decimal? OrigTrxRt { get; set; }

        public decimal? CurrTrxRt { get; set; }

        public decimal? GainLossAmt { get; set; }

        public int? LastRevalDt { get; set; }

        public string? Ap1099Fg { get; set; }

        public string? CashAcctCurrCd { get; set; }

        public string? ChkPrtFg { get; set; }

        public string? Filler0001 { get; set; }

        public int? ApOpenFechaRendicion { get; set; }

        public string? ApOpenTipoReg { get; set; }

        public string? ApOpenRetenFlg { get; set; }

        public string? ApOpenCodAduana { get; set; }

        public decimal? ApOpenPercTax { get; set; }

        public string? ApOpenBaseImponi { get; set; }

        public string? ApOpenDocImport { get; set; }

        public decimal? ApOpenTcVenpub { get; set; }

        public string? ApOpenNroPoliza { get; set; }

        public decimal? ApOpenMontoFob { get; set; }

        public int? ApOpenMontoFlt { get; set; }

        public decimal? ApOpenMontoSgr { get; set; }

        public decimal? ApOpenMontoAdv { get; set; }

        public string? ApTermCode { get; set; }

        public decimal A4glidentity { get; set; }

        public decimal? OrigTrxRt2 { get; set; }

        public decimal? CurrTrxRt2 { get; set; }

        public int? LastDateProssDt { get; set; }

        public int? LastDateProssDt2 { get; set; }
        [NotMapped]
        public string? AlfCd { get; set; } = string.Empty;

        public int? FrdDt { get; set; }

        public string? SlType { get; set; }

        public string? DetracPayedBySystemFg { get; set; }

        public int? DetracGroup { get; set; }

        public string? SlInverseFg { get; set; }

        public string? VchrBank { get; set; }

        public string? VchrDetrac { get; set; }

        public string? IsExrFg { get; set; }

        public string? IsExrBaseFg { get; set; }

        public decimal? RetentionRatePct { get; set; }

        public string? IsPeFg { get; set; }

        public int? SlVchrNo { get; set; }

        public int? DebtSwapCd { get; set; }

        public string? EdCd { get; set; }

        public string? IsAdvancementFg { get; set; }

        public string? PoChgFg { get; set; }

        public string? ReferencialApplyToNo { get; set; }

        public string? ExogenousFg { get; set; }

        public int? ReferencialVchrNo { get; set; }

        public string? ReferenceSp { get; set; }

        public string? ErCd { get; set; }

        public int? RetRenNo { get; set; }

        public string? AssetTypeCd { get; set; }
        public string TipoFg { get; set; }
        public int ChkSaldo { get; set; }
        public string ChkVoid { get; set; }
        //public string VendNo { get; set; }
        public string ChkDes { get; set; }
        public string ChkHas { get; set; }
        public int TrxDtIni { get; set; }
        public int TrxDtFin { get; set; }
        public string ChkDes1 { get; set; }
        public string ChkHas1 { get; set; }
        public int DueDtIni { get; set; }
        public int DueDtFin { get; set; }
        public string ChkDes2 { get; set; }
        public string ChkHas2 { get; set; }
        public int VchrDtIni { get; set; }
        public int VchrDtFin { get; set; }
        public int DocIni { get; set; }
        public int DocFin { get; set; }
        public string AplIni { get; set; }
        public string AplFin { get; set; }
        //public string InvNo { get; set; }
        //public string ApplyToNo { get; set; }
        public string Doc1 { get; set; }
        public string Doc2 { get; set; }
        public string Doc3 { get; set; }
        public string Apl1 { get; set; }
        public string Apl2 { get; set; }
        public string Apl3 { get; set; }
        public string JnlCd { get; set; }
        //public string VchrChkCd { get; set; }
        public string JnlBatchId { get; set; }
        public string UserDefFld1 { get; set; }
        public string VendTypeCd { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderColumn { get; set; }
        //public string ReferencialApplyToNo { get; set; }
    }
}
