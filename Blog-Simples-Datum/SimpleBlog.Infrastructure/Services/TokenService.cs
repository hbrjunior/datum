using Microsoft.IdentityModel.Tokens;
using SimpleBlog.Domain.Entidades;
using SimpleBlog.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleBlog.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey = "HBJ29081960brujunLUPamGzi"; // Defina uma chave secreta segura
        private readonly string _issuer = "SimpleBlogApp";
        private readonly string _audience = "SimpleBlogUsers";

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                // Outras informações que você quer adicionar ao token
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
