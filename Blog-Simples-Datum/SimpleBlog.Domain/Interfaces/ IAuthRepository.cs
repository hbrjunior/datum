using SimpleBlog.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByIdAsync(int userId);
        Task<User?> GetUserByUsernameAsync(string username);
        // Adicione outros métodos necessários
    }
}
