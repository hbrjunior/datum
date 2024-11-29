using SimpleBlog.Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlog.Domain.Interfaces
{
    public interface IPostService
    {
        // Método para criar um novo post
        Task CreatePostAsync(Post post);
    }
}
