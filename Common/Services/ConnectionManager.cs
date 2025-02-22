using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Common.Utils;

namespace Common.Services
{
    public class ConnectionManager
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public ConnectionManager(/*IHttpContextAccessor httpContextAccessor,*/ IConfiguration configuration){
            //_httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        /// <summary>
        /// Generamos la conexion para traer las empresas disponibles para el grupo. No se necesita acceso previo ya que es la primera consulta del cliente/usuario
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string F_ObtenerCredencialesConfig()
        {
            //var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            //var baseDeDatos = identity?.Claims.FirstOrDefault(c => c.Type == "BaseDeDatos")?.Value;
            //if (string.IsNullOrEmpty(baseDeDatos)){
            //    throw new Exception("No se encontró la base de datos en el token JWT.");
            //}
            // Obtenemos los datos de acceso del usuario con privilegios para la primera conexion
            string[] clave = CryptoService.Decrypt(_configuration["Credenciales:SU_Clave"]).Split("|");
            //var connectionStringServer = _configuration["ConnectionStrings:DbTemplate"];
            //Obtenemos la plantilla de la cadena de conexion
            string connectionStringTemplate = "";
            connectionStringTemplate = _configuration["ConnectionStrings:DbTemplate"];
            //Reemplazamos el nobre del servidor
            connectionStringTemplate = connectionStringTemplate.Replace("{SERVER_NAME}", this.SERVER_NAME);
            //Reemplazamos el nombre de la BD de configuracion
            connectionStringTemplate =connectionStringTemplate.Replace("{DB_NAME}", _configuration["Credenciales:Configuration"]);
            //Reemplazamos el usuario con privilegios
            connectionStringTemplate = connectionStringTemplate.Replace("{USER_ID}", clave[0]);
            //Reemplazamos la clave del usuario con privilegios
            connectionStringTemplate = connectionStringTemplate.Replace("{PASSWORD_ID}", clave[1]);
            //Devolvemos la conexion
            return connectionStringTemplate;
        }
        public string SERVER_NAME { get; set; }
        public string DB_NAME { get; set; }
        public string USER_ID { get; set; }
        public string PASSWORD_ID { get; set; }
    }
}
