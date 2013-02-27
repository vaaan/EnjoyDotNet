using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace EnjoyWebApplication.TexasHoldem.Manage
{
    public class SessionController
    {
        private const string RoomFieldName = "Room";
        private const string PokerFieldName = "Poker";
        private const string TokenFieldName = "Token";

        private static void SetSessionFieldValue(Page page, string fieldName, string value)
        {
            if (page == null) return;
            page.Session[fieldName] = value;
        }

        private static string GetSessionFieldValue(Page page, string fieldName)
        {
            if (page == null) return null;
            if (page.Session[fieldName] == null) return null;
            return page.Session[fieldName].ToString();
        }

        public static void SetRoomName(Page page, string value)
        {
            SetSessionFieldValue(page, RoomFieldName, value);
        }

        public static string GetRoomName(Page page)
        {
            return GetSessionFieldValue(page, RoomFieldName);
        }

        public static void SetPokerName(Page page, string value)
        {
            SetSessionFieldValue(page, PokerFieldName, value);
        }

        public static string GetPokerName(Page page)
        {
            return GetSessionFieldValue(page, PokerFieldName);
        }

        public static void SetToken(Page page, string value)
        {
            SetSessionFieldValue(page, TokenFieldName, value);
        }

        public static string GetToken(Page page)
        {
            return GetSessionFieldValue(page, TokenFieldName);
        }
    }
}