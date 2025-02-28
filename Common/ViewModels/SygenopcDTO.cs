using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class SygenopcDTO
    {
        public string SyMenuCode { get; set; } = null!;
        public string? SyMenuName { get; set; }
        public string? SyMenuParent { get; set; }
        public short SyMenuLevel { get; set; }
        public string SyPkgId { get; set; } = null!;
        public string? SyOpcLiteral { get; set; }
        public string? SyUrl { get; set; }
    }
}
