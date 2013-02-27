using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnjoyWebApplication.TexasHoldem.Manage.Entity
{
    public enum CardColorType
    {
        Spade,
        Heart,
        Club,
        Diamond
    }

    public class Card
    {
        public CardColorType ColorType { set; get; }
        /// <summary>
        /// 1 for A, 13 for K
        /// </summary>
        public int Number { set; get; }

        public string DisplayNumber
        {
            get
            {
                switch (Number)
                {
                    case 1: return "A";
                    case 11: return "J";
                    case 12: return "Q";
                    case 13: return "K";
                    default: return Number.ToString();
                }
            }
        }
    }
}