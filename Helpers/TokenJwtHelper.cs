using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.Helpers
{
    public class TokenJwtHelper
    {
        private IConfiguration _configuration;
        public TokenJwtHelper(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        /// <summary>
        /// Genera un token JWT basado en la informacion del usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>El token JWT generado como una cadena.</returns>
        public string GenerateToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("Cuil",usuario.Cuil.ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),  //Tiempo de duracion del Token
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);

        }
    }
}
