using Gulsevanya.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gulsevanya.Hubs
{
    public class LobbyHub : Hub
    {
        public Task SendMessage(LobbyMessage chatMessage)
        {
            return Clients.All.InvokeAsync("Send", chatMessage);
        }
    }
}
