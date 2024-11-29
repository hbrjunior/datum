using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Entidades;
using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlog.Infrastructure.Repositorios
{
    public class PostRepository : IPostRepository
    {
        private readonly SimpleBlogDbContext _dbContext;

        public PostRepository(SimpleBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Post post)
        {
            await _dbContext.Set<Post>().AddAsync(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Post post)
        {
            var existingPost = await _dbContext.Set<Post>().FindAsync(post.Id);
            if (existingPost == null)
                throw new KeyNotFoundException($"Post with ID {post.Id} not found.");

            _dbContext.Set<Post>().Remove(existingPost);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _dbContext.Set<Post>().ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(int postId)
        {
            return await _dbContext.Set<Post>().FindAsync(postId);
        }

        public async Task UpdateAsync(Post existingPost)
        {
            var postToUpdate = await _dbContext.Set<Post>().FindAsync(existingPost.Id);
            if (postToUpdate == null)
                throw new KeyNotFoundException($"Post with ID {existingPost.Id} not found.");

            postToUpdate.Title = existingPost.Title;
            postToUpdate.Content = existingPost.Content;
            postToUpdate.Author = existingPost.Author;

            await _dbContext.SaveChangesAsync();
        }
    }
}
