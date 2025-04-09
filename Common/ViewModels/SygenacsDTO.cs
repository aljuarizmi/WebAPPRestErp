namespace Common.ViewModels
{
    public class SygenacsDTO
    {
        public string SyUser { get; set; } = null!;
        public string SyCompany { get; set; } = null!;
        public string? SyMenuCode { get; set; }
        public string? SyMenuState { get; set; }
        public string? SyOpcActive { get; set; }
    }
}
