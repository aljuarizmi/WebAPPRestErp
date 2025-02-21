using System;
using System.Collections.Generic;

namespace BusinessEntity.Data.Models;

public partial class SygenbzgSql
{
    public int? BizGrpId { get; set; }

    public string? BizGrpDescr { get; set; }

    public string? BizGrpDescrLong { get; set; }

    public string? BizGrpCode { get; set; }

    public string? BizGrpSpecificUrlFg { get; set; }

    public string? BizGrpUrl { get; set; }

    public string? BizGrpMainFg { get; set; }

    public int A4glidentity { get; set; }

    public string? BizIsMacFg { get; set; }
}
