using Common.ViewModels;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLogic.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration){
            _configuration = configuration;
        }
        public TokenResponse GenerateToken(string username, string password, string server, string database,string user_id,string user_role, string? biz_grp_id)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            double minutes = 60;
            var expirationTime = DateTimeOffset.UtcNow.AddMinutes(minutes); //DateTime.Now.AddMinutes(minutes);
            long expirationTimestamp = GetUnixTimestamp(expirationTime);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user_id),// ID del usuario
                new Claim(ClaimTypes.NameIdentifier, username),// Nombre de usuario
                new Claim(JwtRegisteredClaimNames.UniqueName, username),// ID único del token
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64), // Fecha de emisión
                new Claim(JwtRegisteredClaimNames.Exp, expirationTime.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64), // Expira en 2 horas
                new Claim(ClaimTypes.Role, user_role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // ID único del token
                new Claim("SERVER_NAME", server),
                new Claim("DB_NAME", "DATA_"+database),
                new Claim("DB_NUMBER", database),
                new Claim("USER_ID", username+"_SQL"),
                new Claim("USER_NAME", username),
                new Claim("PASSWORD_ID", password),
                new Claim("COMPANY", database),
                new Claim("BIZ_GRP_ID", biz_grp_id)
            };
            var token = new JwtSecurityToken(
                //issuer: _configuration["JWT:Issuer"],
                //audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: expirationTime.UtcDateTime,//DateTime.Now.AddMinutes(minutes), // Token válido por 1 hora
                signingCredentials: credentials
            );
            return new TokenResponse { 
                Token=new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationTime= expirationTimestamp
            };
        }
        // Función para obtener el Unix timestamp en segundos
        private long GetUnixTimestamp(DateTimeOffset dateTime){
            // La fecha base Unix es 1 de enero de 1970, en UTC.
            DateTimeOffset unixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            // Calcular la diferencia en segundos entre la fecha dada y la fecha base
            TimeSpan elapsedTime = dateTime.ToUniversalTime() - unixEpoch;
            // Retornar el número de segundos como el Unix timestamp
            return (long)elapsedTime.TotalSeconds;
        }
    }
}
