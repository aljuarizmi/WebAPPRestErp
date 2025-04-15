﻿using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICmcurrteService
    {
        Task<IEnumerable<IDictionary<string, object>>> F_ListarTipoCambio(CmcurrteDTO parametros); // Usar procedimiento almacenado
        Task<bool> F_AgregarTipoCambio(CmcurrteDTO parametros);
        Task<bool> F_ActualizarTipoCambio(CmcurrteDTO parametros);
        Task<IEnumerable<IDictionary<string, object>>> F_ListarTiposCambio(CmcurrteDTO parametros);
        List<CmcurrteDTO> MapearCmcurrteDTO(IEnumerable<IDictionary<string, object>> data);
    }
}
