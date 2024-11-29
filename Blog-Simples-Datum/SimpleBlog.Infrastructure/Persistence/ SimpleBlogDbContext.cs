using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Entidades;

namespace SimpleBlog.Infrastructure.Persistence
{
    public class SimpleBlogDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;

        public SimpleBlogDbContext(DbContextOptions<SimpleBlogDbContext> options) : base(options)
        {
        }
    }
}
