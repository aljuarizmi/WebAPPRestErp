namespace BusinessEntity.Data.Models;

public partial class SqlsrchSql
{
    public string SearchFieldId { get; set; } = null!;

    public short SearchNo { get; set; }

    public string? PssSearchTitle { get; set; }

    public string? SearchTable { get; set; }

    public string? SearchTablePkg { get; set; }

    public string? SearchSelect { get; set; }

    public string? SearchFormats { get; set; }

    public string? SearchWhere { get; set; }

    public string? SearchJoins { get; set; }

    public string? SearchOrderBy { get; set; }

    public string? SearchRetVal { get; set; }

    public string? SearchMaintProgram { get; set; }

    public string? SearchMaintLiteral { get; set; }

    public short? SearchSegmentNum { get; set; }

    public string? SearchWhereDefaults { get; set; }

    public short? SearchReturnRows { get; set; }

    public string? SearchUsername { get; set; }

    public string? SearchGroup { get; set; }

    public string? SearchFiller { get; set; }

    public decimal A4glidentity { get; set; }

    public string? UseSessionFg { get; set; }
}
