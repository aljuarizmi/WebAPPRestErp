namespace Common.ViewModels
{
    public class SygendbcDTO
    {
        public string? SyCompany { get; set; }
        public string? SyCompanyDescr { get; set; }
        public int? BizGrpId { get; set; }
        public string SyServer { get; set; } = string.Empty;
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderColumn { get; set; } = string.Empty;
        public string? SyShowLogoFg { get; set; }
        public string? SyCompanyLogo { get; set; }
        public string? SyDoi { get; set; }
        public string? SyShowFg { get; set; }
        public string? SyDoiFg { get; set; }
    }
}
