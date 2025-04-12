using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels;

namespace Common.Interfaces
{
    public interface ISunatService
    {
        Task<SunatTDO> ConsultaSUNAT(string dato, EnumTipoDato tipo);
    }
}
