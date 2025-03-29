﻿using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Interfaces
{
    public interface ISycshfilRepository
    {
        Task<SycshfilTDO> F_ListarCuentaPlan(SycshfilTDO parametros);
        Task<SycshfilTDO> F_ListarCuenta(SycshfilTDO parametros);
    }
}
