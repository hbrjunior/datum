using Microsoft.AspNetCore.SignalR;
using SimpleBlog.Domain.Entidades;
using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Infrastructure.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IHubContext<NotificationHub> _hubContext;

        public PostService(IPostRepository postRepository, IHubContext<NotificationHub> hubContext)
        {
            _postRepository = postRepository;
            _hubContext = hubContext;
        }

        public async Task CreatePostAsync(Post post)
        {
            // Salva a nova postagem no repositório
            await _postRepository.AddAsync(post);

            // Notifica todos os clientes conectados
            var notificationMessage = $"Nova postagem criada: {post.Title}";
            Console.WriteLine(notificationMessage); // Apenas para fins de debug
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", notificationMessage);
        }
    }
}
