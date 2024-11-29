using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Entidades;

namespace SimpleBlog.Infrastructure.Repositorios
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SimpleBlogDbContext _context;

        public AuthRepository(SimpleBlogDbContext context)
        {
            _context = context;
        }

        // Método para adicionar um novo usuário no banco de dados
        public async Task AddUserAsync(User user)
        {
            // Adiciona o usuário à tabela de usuários
            await _context.Users.AddAsync(user);
            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();
        }

        // Método para buscar um usuário pelo ID
        public async Task<User> GetUserByIdAsync(int userId)
        {
            User? user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        // Método para buscar um usuário pelo nome de usuário
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users
                                 .FirstOrDefaultAsync(u => u.Username == username);
            if (user == null) { 
               return null;
            }
            return user;
        }
    }
}
