using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleBlog.Infrastructure.Persistence
{
    public class SimpleBlogDbContextFactory : IDesignTimeDbContextFactory<SimpleBlogDbContext>
    {
        public SimpleBlogDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SimpleBlogDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-HBRJUNI;Database=BlogDB;User Id=BlogUser;Password=blog1234;Trusted_Connection=True;TrustServerCertificate=True;");

            return new SimpleBlogDbContext(optionsBuilder.Options);
        }
    }
}
