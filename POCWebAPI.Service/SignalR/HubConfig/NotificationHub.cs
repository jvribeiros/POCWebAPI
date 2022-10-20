using Microsoft.AspNetCore.SignalR;
using POCWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCWebAPI.Service.HubConfig
{
    public class NotificationHub : Hub
    {
        public async Task BroadcastNotifications(List<NotificationModel> notification) => 
            await Clients.All.SendAsync("broadcastnotification", notification);
    }

}

