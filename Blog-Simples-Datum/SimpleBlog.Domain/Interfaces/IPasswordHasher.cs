using System.Threading.Tasks;

namespace SimpleBlog.Domain.Interfaces
{
    public interface IPasswordHasher
    {
        Task<string> HashPasswordAsync(string password); // Método assíncrono para criar hash
        Task<bool> VerifyPasswordAsync(string hashedPassword, string providedPassword); // Método assíncrono para verificar senha
    }
}
