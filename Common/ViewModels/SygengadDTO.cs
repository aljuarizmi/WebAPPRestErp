using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class SygengadDTO
    {
        public string SyUser { get; set; } = string.Empty;
        public int? BizGrpId { get; set; }
        public string ServerName { get; set; } = string.Empty;
        public string DataBase { get; set; } = string.Empty;
        public string SyUserPsc { get; set; } = string.Empty;
    }
}
