using Common.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Common.Services
{
    public class ConnectionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="configuration"></param>
        public ConnectionManager(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
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
            connectionStringTemplate = connectionStringTemplate.Replace("{DB_NAME}", _configuration["Credenciales:Configuration"]);
            //Reemplazamos el usuario con privilegios
            connectionStringTemplate = connectionStringTemplate.Replace("{USER_ID}", clave[0]);
            //Reemplazamos la clave del usuario con privilegios
            connectionStringTemplate = connectionStringTemplate.Replace("{PASSWORD_ID}", clave[1]);
            //Devolvemos la conexion
            return connectionStringTemplate;
        }

        public string F_ObtenerCredenciales()
        {
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            this.SERVER_NAME = identity?.Claims.FirstOrDefault(c => c.Type == "SERVER_NAME")?.Value;
            this.DB_NAME = identity?.Claims.FirstOrDefault(c => c.Type == "DB_NAME")?.Value;
            this.USER_DB = identity?.Claims.FirstOrDefault(c => c.Type == "USER_DB")?.Value;
            this.PASSWORD_ID = identity?.Claims.FirstOrDefault(c => c.Type == "PASSWORD_ID")?.Value;
            if (string.IsNullOrEmpty(this.SERVER_NAME)){
                throw new Exception("No se encontró el servidor en el token JWT.");
            }
            if (string.IsNullOrEmpty(this.DB_NAME)){
                throw new Exception("No se encontró la base de datos en el token JWT.");
            }
            if (string.IsNullOrEmpty(this.USER_DB)){
                throw new Exception("No se encontró el usuario en el token JWT.");
            }
            if (string.IsNullOrEmpty(this.PASSWORD_ID)){
                throw new Exception("No se encontró la contraseña del usuario en el token JWT.");
            }
            //Obtenemos la plantilla de la cadena de conexion
            string connectionStringTemplate = "";
            connectionStringTemplate = _configuration["ConnectionStrings:DbTemplate"];
            //Reemplazamos el nobre del servidor
            connectionStringTemplate = connectionStringTemplate.Replace("{SERVER_NAME}", this.SERVER_NAME);
            //Reemplazamos el nombre de la BD
            connectionStringTemplate = connectionStringTemplate.Replace("{DB_NAME}", this.DB_NAME);
            //Reemplazamos el usuario
            connectionStringTemplate = connectionStringTemplate.Replace("{USER_ID}", this.USER_DB);
            //Reemplazamos la clave
            connectionStringTemplate = connectionStringTemplate.Replace("{PASSWORD_ID}", this.PASSWORD_ID);
            //Devolvemos la conexion
            return connectionStringTemplate;
        }
        public string SERVER_NAME { get; set; } = string.Empty;
        public string DB_NAME { get; set; } = string.Empty;
        public string USER_ID { get; set; } = string.Empty;
        public string USER_DB { get; set; } = string.Empty;
        public string PASSWORD_ID { get; set; } = string.Empty;
    }
}
