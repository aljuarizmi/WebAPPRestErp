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

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string username, string password, string server, string database,string user_id,string user_role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            double minutes = 60;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user_id),// ID del usuario
                new Claim(ClaimTypes.NameIdentifier, username),// Nombre de usuario
                new Claim(JwtRegisteredClaimNames.UniqueName, username),// ID único del token
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64), // Fecha de emisión
                new Claim(JwtRegisteredClaimNames.Exp, DateTimeOffset.Now.AddMinutes(minutes).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64), // Expira en 2 horas
                new Claim(ClaimTypes.Role, user_role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // ID único del token
                new Claim("SERVER_NAME", server),
                new Claim("DB_NAME", "DATA_"+database),
                new Claim("DB_NUMBER", database),
                new Claim("USER_ID", username),
                new Claim("USER_DB", username+"_SQL"),
                new Claim("PASSWORD_ID", password),
                new Claim("COMPANY", database)
            };
            var token = new JwtSecurityToken(
                //issuer: _configuration["JWT:Issuer"],
                //audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(minutes), // Token válido por 1 hora
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
