using SimpleBlog.Domain.Entidades;

namespace SimpleBlog.Domain.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
