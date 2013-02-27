using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnjoyWebApplication.TexasHoldem.Manage.Entity
{
    public class Poker
    {
        public string NickName { set; get; }
        public Card Card1 { set; get; }
        public Card Card2 { set; get; }
        public bool IsRoomAdmin { set; get; }
    }
}