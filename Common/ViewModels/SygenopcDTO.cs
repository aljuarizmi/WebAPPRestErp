namespace Common.ViewModels
{
    public class SygenopcDTO
    {
        public string SyMenuCode { get; set; } = string.Empty;
        public string SyMenuName { get; set; } = string.Empty;
        public string SyMenuParent { get; set; } = string.Empty;
        public int SyMenuLevel { get; set; } = 0;
        public string SyOpcActive { get; set; } = string.Empty;
        public List<SygenopcDTO>? Children { get; set; } = new List<SygenopcDTO>();
        //public string SyPkgId { get; set; } = null!;
        //public string? SyOpcLiteral { get; set; }
        public string SyUrl { get; set; } = string.Empty;
        public string SyTipoCambio { get; set; } = string.Empty;
    }
}
