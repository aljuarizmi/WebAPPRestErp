using System;
using System.Collections.Generic;

namespace BusinessEntity.Data.Models;

public partial class CmcurratSql
{
    public string CurrCd { get; set; } = null!;

    public int CurrRtEffDt { get; set; }

    public decimal? CurrRt { get; set; }

    public string? CurrRtCmt { get; set; }

    public string? Filler0001 { get; set; }

    public decimal A4glidentity { get; set; }
}
