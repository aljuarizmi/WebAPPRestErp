using System;
using System.Collections.Generic;

namespace BusinessEntity.Data.Models;

public partial class SygenusrSql
{
    public string SyUser { get; set; } = null!;

    public string SyUserPsc { get; set; } = null!;

    public string SyUserGroup { get; set; } = null!;

    public string SyUserType { get; set; } = null!;

    public decimal A4glidentity { get; set; }

    public string? SyUserDoiFg { get; set; }
}
