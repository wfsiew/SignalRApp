using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using SignalRApp.Models;
using SignalRApp.Attributes;

namespace SignalRApp
{
    [Authorize(RequireOutgoing = true)]
    public class MyHub : Hub
    {
        [Authorize(Roles = "Admin")]
        public void CreateChatRoom(string room)
        {
            if (!ChatRooms.Exists(room))
            {
                ChatRooms.Add(room);
                Clients.All.addChatRoom(room);
            }
        }

        public void Join(string room)
        {
            if (!string.IsNullOrEmpty(Clients.Caller.currentChatRoom))
                Groups.Remove(Context.ConnectionId, Clients.Caller.currentChatRoom);

            Groups.Add(Context.ConnectionId, room);
        }

        public void Send(string message)
        {
            string room = Clients.Caller.currentChatRoom;
            Clients.Group(room).addMessage(room, message);
        }

        public override Task OnConnected()
        {
            foreach (string room in ChatRooms.GetAll())
                Clients.Caller.addChatRoom(room);

            return base.OnConnected();
        }
    }
}