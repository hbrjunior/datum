using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Entidades;
using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Infrastructure.Persistence;
using System.Threading.Tasks;

namespace SimpleBlog.Infrastructure.Repositorios
{
    public class UserRepository : IUserRepository
    {
        private readonly SimpleBlogDbContext _dbContext;

        public UserRepository(SimpleBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Set<User>().AddAsync(user); // Adiciona o usuário ao DbSet
            await _dbContext.SaveChangesAsync(); // Salva as alterações no banco de dados
        }

        public async Task DeleteAsync(int userId)
        {
            var user = await GetByIdAsync(userId); // Busca o usuário pelo ID
            if (user != null)
            {
                _dbContext.Set<User>().Remove(user); // Remove o usuário do DbSet
                await _dbContext.SaveChangesAsync(); // Salva as alterações
            }
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email); // Busca o usuário pelo email
        }

        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _dbContext.Set<User>().FindAsync(userId); // Busca o usuário pelo ID
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Username == username); // Busca o usuário pelo username
        }

        public async Task UpdateAsync(User user)
        {
            _dbContext.Set<User>().Update(user); // Atualiza o usuário no DbSet
            await _dbContext.SaveChangesAsync(); // Salva as alterações no banco de dados
        }
    }
}
