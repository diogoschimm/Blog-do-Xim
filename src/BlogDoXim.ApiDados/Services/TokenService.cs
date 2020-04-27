using BlogDoXim.ApiDados.ViewModels;
using BlogDoXim.Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogDoXim.ApiDados.Services
{
    public class TokenService
    {
        public static TokenAuthentication GerarToken(Usuario usuario, string strSecretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(strSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                  new Claim(ClaimTypes.Name, usuario.Nome),
                  new Claim(ClaimTypes.NameIdentifier, usuario.Login),
                  new Claim(ClaimTypes.Sid, usuario.UsuarioId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return new TokenAuthentication
            {
                Expires = tokenDescriptor.Expires.Value,
                StrToken = tokenHandler.WriteToken(token),
                RefreshToken = Guid.NewGuid().ToString()
            };
        }
    }
}
