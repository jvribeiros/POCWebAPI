using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using POCWebAPI.Domain.Models;
using POCWebAPI.Service.HubConfig;


namespace RealTimeNotifications.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hub;

        public NotificationController(IHubContext<NotificationHub> hub)
        {
            _hub = hub;
        }

        [HttpGet("NotificationBroadcast")]
        public IActionResult Get(string name, string message)
        {
            NotificationModel notification = new NotificationModel()
            {
                name = name,
                message = message
            };

            _hub.Clients.All.SendAsync("broadcastnotification", notification);
            return Ok(notification);
        }
    }
}
