using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace EnjoyWebApplication.TexasHoldem.Manage.Entity
{
    public class Room
    {
        private int currentGameRound = 0;

        public int CurrentGameRound
        {
            get { return currentGameRound; }
        }

        public string Name { set; get; }
        public string Password { set; get; }
        public string CurrentToken { set; get; }

        private List<Card> commonCardList = new List<Card>();

        public Card[] CommonCards
        {
            get
            {
                return commonCardList.ToArray();
            }
        }

        private Dictionary<string, Poker> pokerNameDic = new Dictionary<string, Poker>();

        public void AddPoker(Poker poker)
        {
            if (poker == null || String.IsNullOrWhiteSpace(poker.NickName)) return;
            lock (pokerNameDic)
            {
                if (pokerNameDic.ContainsKey(poker.NickName)) pokerNameDic[poker.NickName] = poker;
                else pokerNameDic.Add(poker.NickName, poker);
            }
        }

        public Poker GetPoker(string nickName)
        {
            if (!pokerNameDic.ContainsKey(nickName)) return null;
            return pokerNameDic[nickName];
        }

        private List<AutoResetEvent> notifyChangeSignalList = new List<AutoResetEvent>();

        public void AddNotifySignal(AutoResetEvent signal)
        {
            if (signal == null) return;
            lock (notifyChangeSignalList)
            {
                notifyChangeSignalList.Add(signal);
            }
        }

        public void RemoveNotifySignal(AutoResetEvent signal)
        {
            if (signal == null) return;
            lock (notifyChangeSignalList)
            {
                notifyChangeSignalList.Remove(signal);
            }
        }

        private void NotifyAllSignal()
        {
            lock (notifyChangeSignalList)
            {
                foreach (var item in notifyChangeSignalList)
                {
                    item.Set();
                }
            }
        }

        private List<Card> allUsedCards = new List<Card>();

        public void RestartGame()
        {
            if (pokerNameDic.Count == 0) return;
            allUsedCards.Clear();
            commonCardList.Clear();
            var allCardList = new List<int>();
            for (int i = 0; i < 51; i++)
            {
                allCardList.Add(i);
            }
            // 一共需要人数*2 + 5张牌
            var sumCardNumber = pokerNameDic.Count * 2 + 5;
            Random cardRdm = new Random();
            for (int i = 0; i < sumCardNumber; i++)
            {
                int index = cardRdm.Next(allCardList.Count);
                var cardCode=allCardList[index];
                allUsedCards.Add(new Card { ColorType = (CardColorType)(cardCode / 13), Number = cardCode % 13 + 1 });
                allCardList.RemoveAt(index);
            }
            // 发牌给玩家
            for (int i = 0; i < pokerNameDic.Count; i++)
            {
                pokerNameDic.ElementAt(i).Value.Card1 = allUsedCards[0];
                allUsedCards.RemoveAt(0);
                pokerNameDic.ElementAt(i).Value.Card2 = allUsedCards[0];
                allUsedCards.RemoveAt(0);
            }
            currentGameRound++;
            CurrentToken = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            NotifyAllSignal();
        }

        public void FlopNextCommonCards()
        {
            if (commonCardList.Count == 0)
            {
                if (allUsedCards.Count < 3) return;
                for (int i = 0; i < 3; i++)
                {
                    commonCardList.Add(allUsedCards[0]);
                    allUsedCards.RemoveAt(0);
                }
                CurrentToken = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                NotifyAllSignal();
                return;
            }
            if (allUsedCards.Count < 1) return;
            commonCardList.Add(allUsedCards[0]);
            allUsedCards.RemoveAt(0);
            CurrentToken = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            NotifyAllSignal();
        }
    }
}