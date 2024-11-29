using SimpleBlog.Domain.Entidades;
using System.Threading.Tasks;

namespace SimpleBlog.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int userId);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int userId);
        Task<User?> GetUserByUsernameAsync(string username);
    }
}
