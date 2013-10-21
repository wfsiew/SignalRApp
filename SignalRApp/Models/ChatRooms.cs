using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Web;

namespace SignalRApp.Models
{
    public class ChatRooms
    {
        static ConcurrentBag<string> rooms = new ConcurrentBag<string>();

        static ChatRooms()
        {
            rooms.Add("Lobby");
        }

        public static void Add(string name)
        {
            rooms.Add(name);
        }

        public static bool Exists(string name)
        {
            return rooms.Contains(name);
        }

        public static IEnumerable<string> GetAll()
        {
            return rooms;
        }
    }
}