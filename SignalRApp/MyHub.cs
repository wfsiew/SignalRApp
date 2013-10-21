using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using SignalRApp.Models;

namespace SignalRApp
{
    public class MyHub : Hub
    {
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
            Groups.Add(Context.ConnectionId, room);
        }

        public void Send(string room, string message)
        {
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