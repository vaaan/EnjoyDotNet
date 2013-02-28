using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnjoyWebApplication.TexasHoldem.Manage.Entity;

namespace EnjoyWebApplication.TexasHoldem.Manage
{
    public static class Extensions
    {
        public static string GetColorWordName(this CardColorType type)
        {
            switch (type)
            {
                case CardColorType.Spade: return "S";
                case CardColorType.Heart: return "H";
                case CardColorType.Club: return "C";
                default: return "D";
            }
        }

        public static string GetColorSymbolName(this CardColorType type)
        {
            switch (type)
            {
                case CardColorType.Spade: return "♠";
                case CardColorType.Heart: return "♥";
                case CardColorType.Club: return "♣";
                default: return "♦";
            }
        }
    }
}