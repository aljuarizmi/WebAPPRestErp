using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class ApvenextDTO
    {
        [Column("Código")]
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string DOI { get; set; }
        public string Contacto { get; set; }
        public string Correo { get; set; }
        [Column("Teléfono")]
        public string Telefono { get; set; }
        [Column("Dirección")]
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        [Column("País")]
        public string Pais { get; set; }
        public string Moneda { get; set; }
        [Column("Tarifa Imp.")]
        public string TarifaImp { get; set; }
        [Column("Tipo Prov.")]
        public string TipoProv { get; set; }
        [Column("Tipo Documento")]
        public string TipoDocumento { get; set; }
        public string Ubigeo { get; set; }
        public string Retenedor { get; set; }
        public string SPOT { get; set; }
        [Column("País Sunat")]
        public string PaisSunat { get; set; }
        public string Convenio { get; set; }
    }
}
