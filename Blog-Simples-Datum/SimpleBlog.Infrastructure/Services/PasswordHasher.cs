using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Domain.Entidades;

namespace SimpleBlog.Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<object> _passwordHasher = new PasswordHasher<object>();

        public Task<string> HashPasswordAsync(string password)
        {
            var user = new IdentityUser(); // Instância de um usuário fictício ou vazio
            return Task.FromResult(_passwordHasher.HashPassword(user, password));
        }

        public Task<bool> VerifyPasswordAsync(string hashedPassword, string providedPassword)
        {
            var user = new IdentityUser(); // Instância de um usuário fictício ou vazio
            // Verifica o hash da senha
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
            return Task.FromResult(result == PasswordVerificationResult.Success);
        }
    }
}
