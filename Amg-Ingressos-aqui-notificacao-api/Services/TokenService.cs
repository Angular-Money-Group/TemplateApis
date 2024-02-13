using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Amg_Ingressos_aqui_notificacao_api.Consts;
using Amg_Ingressos_aqui_notificacao_api.Model;
using Microsoft.IdentityModel.Tokens;

namespace Amg_Ingressos_aqui_notificacao_api.Services
{
    public static class TokenService
    {
        public static string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, ""),
                    new Claim(ClaimTypes.Role, "")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}