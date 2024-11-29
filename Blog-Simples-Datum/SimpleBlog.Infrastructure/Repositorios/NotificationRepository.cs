using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Entidades;
using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlog.Infrastructure.Repositorios
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly SimpleBlogDbContext _dbContext;

        public NotificationRepository(SimpleBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Notification notification)
        {
            await _dbContext.Set<Notification>().AddAsync(notification);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Notification>> GetAllAsync()
        {
            return await _dbContext.Set<Notification>().ToListAsync();
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            var notification = await _dbContext.Set<Notification>().FindAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
