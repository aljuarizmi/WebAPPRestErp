using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public enum MimeType
    {
        Pdf,
        Json,
        Xml,
        Zip,
        Txt,
        Csv,
        Png,
        Jpeg,
        Gif,
        Bmp,
        Svg,

        Xls,  // Excel (antiguo)
        Xlsx, // Excel (nuevo)
        Doc,  // Word (antiguo)
        Docx, // Word (nuevo)
        Ppt,  // PowerPoint (antiguo)
        Pptx  // PowerPoint (nuevo)
    }

    public enum Delimitador
    {
        Coma,         // ","
        PuntoYComa,   // ";"
        Tabulacion,   // "\t"
        Pipe,         // "|"
        Espacio       // " "
    }
    public static class MimeTypeExtensions
    {
        public static string GetMimeType(this MimeType mimeType)
        {
            return mimeType switch
            {
                MimeType.Pdf => "application/pdf",
                MimeType.Json => "application/json",
                MimeType.Xml => "application/xml",
                MimeType.Zip => "application/zip",
                MimeType.Txt => "text/plain",
                MimeType.Csv => "text/csv",
                MimeType.Png => "image/png",
                MimeType.Jpeg => "image/jpeg",
                MimeType.Gif => "image/gif",
                MimeType.Bmp => "image/bmp",
                MimeType.Svg => "image/svg+xml",

                MimeType.Xls => "application/vnd.ms-excel",
                MimeType.Xlsx => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                MimeType.Doc => "application/msword",
                MimeType.Docx => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                MimeType.Ppt => "application/vnd.ms-powerpoint",
                MimeType.Pptx => "application/vnd.openxmlformats-officedocument.presentationml.presentation",

                _ => "application/octet-stream",
            };
        }

        public static string GetDelimitador(this Delimitador delimitador)
        {
            return delimitador switch
            {
                Delimitador.Coma => ",",
                Delimitador.PuntoYComa => ";",
                Delimitador.Tabulacion => "\t",
                Delimitador.Pipe => "|",
                Delimitador.Espacio => " ",
                _ => " ",
            };
        }
    }
}
