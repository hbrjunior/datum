using SimpleBlog.Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlog.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task AddAsync(Post post);
        Task DeleteAsync(Post post);
        Task<List<Post>> GetAllAsync();
        Task<Post?> GetByIdAsync(int postId);
        Task UpdateAsync(Post existingPost);
    }
}
