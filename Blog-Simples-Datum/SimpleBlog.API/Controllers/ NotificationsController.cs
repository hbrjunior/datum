using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Domain.Entidades;
using SimpleBlog.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationsController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Notification>>> GetAll()
        {
            var notifications = await _notificationRepository.GetAllAsync();
            return Ok(notifications);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Notification notification)
        {
            if (notification == null)
                return BadRequest("Invalid notification data.");

            await _notificationRepository.AddAsync(notification);
            return CreatedAtAction(nameof(GetById), new { id = notification.Id }, notification);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetById(int id)
        {
            var notification = await _notificationRepository.GetAllAsync();
            if (notification == null)
                return NotFound($"Notification with ID {id} not found.");

            return Ok(notification);
        }

        [HttpPut("{id}/mark-as-read")]
        public async Task<ActionResult> MarkAsRead(int id)
        {
            await _notificationRepository.MarkAsReadAsync(id);
            return NoContent();
        }
    }
}
