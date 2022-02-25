using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebTetrisScoreSystem.Data;

namespace WebTetrisScoreSystem.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly UserManager<Player> userManager;

        public ChatHub(UserManager<Player> userManager)
        {
            this.userManager = userManager;
        }

        public async Task SendMessage(string message)
        {
            var userId = Context.UserIdentifier;
            var player = await userManager.FindByIdAsync(userId);
            if (message != string.Empty)
            {
                await Clients.All.SendAsync("ReceiveMessage", player.UserName, message);
            }
        }
    }
}
