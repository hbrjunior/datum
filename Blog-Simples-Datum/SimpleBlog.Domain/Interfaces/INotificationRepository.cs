using SimpleBlog.Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlog.Domain.Interfaces
{
    public interface INotificationRepository
    {
        Task AddAsync(Notification notification);
        Task<List<Notification>> GetAllAsync();
        Task MarkAsReadAsync(int notificationId);
    }
}
