using System;
using System.Collections.Generic;

namespace BusinessEntity.Data.Models;

public partial class TaxdetlSql
{
    public string? PkgId { get; set; }

    public string? TaxCd { get; set; }

    public string? AltTaxCd { get; set; }

    public string? TaxCdDesc { get; set; }

    public string? TaxMeth { get; set; }

    public decimal? TaxPct { get; set; }

    public string? MnNo { get; set; }

    public string? SbNo { get; set; }

    public string? DpNo { get; set; }

    public string? FrtFg { get; set; }

    public string? MiscChgFg { get; set; }

    public string? LowerCdsFg { get; set; }

    public decimal? TaxAmt { get; set; }

    public decimal? MinTaxAmt { get; set; }

    public decimal? MaxTaxAmt { get; set; }

    public string? ApplyMinMax { get; set; }

    public string? BaseTaxCalc { get; set; }

    public string? TaxTxblFg { get; set; }

    public decimal? SlsPtd { get; set; }

    public decimal? SlsYtd { get; set; }

    public decimal? TaxesPtd { get; set; }

    public decimal? TaxesYtd { get; set; }

    public decimal? MiscPtd { get; set; }

    public decimal? MiscYtd { get; set; }

    public string? UserDefFld1 { get; set; }

    public string? UserDefFld2 { get; set; }

    public string? UserDefFld3 { get; set; }

    public string? UserDefFld4 { get; set; }

    public string? UserDefFld5 { get; set; }

    public string? Filler0001 { get; set; }

    public decimal A4glidentity { get; set; }

    public string? DifMnNo { get; set; }

    public string? DifSbNo { get; set; }

    public string? DifDpNo { get; set; }

    public string? ExpMnNo { get; set; }

    public string? ExpSbNo { get; set; }

    public string? ExpDpNo { get; set; }

    public decimal? AmountBaseReten { get; set; }

    public decimal? RetenPct { get; set; }

    public decimal? RetenBaseAmt { get; set; }

    public string? RetMnNo { get; set; }

    public string? RetSbNo { get; set; }

    public string? RetDpNo { get; set; }

    public int? TermMonths { get; set; }
}
