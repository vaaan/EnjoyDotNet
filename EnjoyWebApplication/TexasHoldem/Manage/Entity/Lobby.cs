using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnjoyWebApplication.TexasHoldem.Manage.Entity
{
    public class Lobby
    {
        private static Lobby instance = new Lobby();

        public static Lobby Instance
        {
            get { return Lobby.instance; }
        }

        private Lobby() { }

        private Dictionary<string, Room> roomNameDic = new Dictionary<string, Room>();

        public Room GetRoom(string name)
        {
            if (roomNameDic.ContainsKey(name)) return roomNameDic[name];
            lock (roomNameDic)
            {
                if (roomNameDic.ContainsKey(name)) return roomNameDic[name];
                roomNameDic.Add(name, new Room { Name = name });
                return roomNameDic[name];
            }
        }
    }

    public class EnterRoomRequest
    {
        public string UserNickName { get; set; }
        public string RoomName { get; set; }
        public string RoomPassword { get; set; }
    }
}