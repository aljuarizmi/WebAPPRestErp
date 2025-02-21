using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class TextFileService
    {
        public byte[] GenerarArchivoTexto(IEnumerable<IDictionary<string, object>> datos, Delimitador delimitador=Delimitador.Pipe)
        {
            if (datos == null || !datos.Any())
                throw new ArgumentException("No hay datos para exportar.");

            var sb = new StringBuilder();

            // Encabezados: no lleva encabezados
            //sb.AppendLine(string.Join("\t", datos.First().Keys));

            // Filas de datos
            foreach (var fila in datos)
                sb.AppendLine(string.Join(delimitador.GetDelimitador(), fila.Values));

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}
