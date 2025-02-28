namespace BusinessEntity.Data.Models;

public partial class SygenopcSql
{
    public string SyMenuCode { get; set; } = null!;

    public string? SyMenuName { get; set; }

    public string? SyMenuParent { get; set; }

    public short SyMenuLevel { get; set; }

    public string SyPkgId { get; set; } = null!;

    public string? SyOpcLiteral { get; set; }

    public string SyOpcActive { get; set; } = null!;

    public string SyOpcType { get; set; } = null!;

    public string? SyOpcExec { get; set; }

    public string? SyUrl { get; set; }

    public decimal A4glidentity { get; set; }
}
