using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public enum EnumTipoDato
    {
        RUC = 1,
        DNI = 2,
        TipoCambio = 3
    }
    public class SunatTDO
    {
        /*public string? mensaje { get; set; }
        public int out_band { get; set; }*/
        public decimal compra { get; set; }
        public decimal venta { get; set; }
        public string origen { get; set; }
        public string moneda { get; set; }
        public string fecha { get; set; }
    }
}
