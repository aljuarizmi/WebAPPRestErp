using System;
using System.Collections.Generic;

namespace BusinessEntity.Data.Models;

public partial class SycshfilSql
{
    public string MnNo { get; set; } = null!;

    public string SbNo { get; set; } = null!;

    public string DpNo { get; set; } = null!;

    public string CashAcctDesc { get; set; } = null!;

    public string SearchAcctDesc { get; set; } = null!;

    public string? BankId { get; set; }

    public string? CshHomeCurrFg { get; set; }

    public string? CurrCd { get; set; }

    public string? Filler0001 { get; set; }

    public decimal? RecBalance { get; set; }

    public decimal? BankBal { get; set; }

    public string? BankName { get; set; }

    public int? NextApChk { get; set; }

    public int? NextPrChk { get; set; }

    public decimal? BankBalance { get; set; }

    public int? LastReconDt { get; set; }

    public int? LastBankUpdate { get; set; }

    public string? CashExchMnNo { get; set; }

    public string? CashExchSbNo { get; set; }

    public string? CashExchDpNo { get; set; }

    public string? Filler0002 { get; set; }

    public decimal A4glidentity { get; set; }

    public string? LetToGenerateCheckFg { get; set; }

    public string? ChkControlProcessFg { get; set; }

    public string? DcsBbFg { get; set; }

    public string? NullFg { get; set; }

    public string? NoGenerateBbFg { get; set; }
}
