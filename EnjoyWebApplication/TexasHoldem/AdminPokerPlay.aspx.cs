using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnjoyWebApplication.TexasHoldem.Manage;
using EnjoyWebApplication.TexasHoldem.Manage.Entity;

namespace EnjoyWebApplication.TexasHoldem
{
    public partial class AdminPokerPlay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionController.GetRoomName(this) == null) Response.Redirect("Login.aspx");
            var room = Lobby.Instance.GetRoom(SessionController.GetRoomName(this));
            lblNickName.Text = SessionController.GetPokerName(this);
            ClearValue();
            if (room.CurrentToken != SessionController.GetToken(this))
            {
                ReSetValue(room);
                SessionController.SetToken(this, room.CurrentToken);
            }
        }

        private void ReSetValue(Room room)
        {
            var poker = room.GetPoker(SessionController.GetPokerName(this));
            if (poker == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (poker.Card1 != null)
                SetValues(poker.Card1, lblSelfColor1, lblSelfNumber1);
            if (poker.Card2 != null)
                SetValues(poker.Card2, lblSelfColor2, lblSelfNumber2);
            var commonCards = room.CommonCards;
            if (commonCards.Length > 0) SetValues(commonCards[0], lblColor1, lblNumber1);
            if (commonCards.Length > 1) SetValues(commonCards[1], lblColor2, lblNumber2);
            if (commonCards.Length > 2) SetValues(commonCards[2], lblColor3, lblNumber3);
            if (commonCards.Length > 3) SetValues(commonCards[3], lblColor4, lblNumber4);
            if (commonCards.Length > 4) SetValues(commonCards[4], lblColor5, lblNumber5);
        }

        private void SetValues(Card card, Label lblColor, Label lblNumber)
        {
            string color = card.ColorType.GetColorWordName();
            lblNumber.Text = card.DisplayNumber;
            lblNumber.CssClass = color;
            lblColor.Text = card.ColorType.GetColorSymbolName();
            lblColor.CssClass = color;
        }

        private void ClearValue()
        {
            lblColor1.Text = "&nbsp;";
            lblColor2.Text = "&nbsp;";
            lblColor3.Text = "&nbsp;";
            lblColor4.Text = "&nbsp;";
            lblColor5.Text = "&nbsp;";
            lblNumber1.Text = "&nbsp;";
            lblNumber2.Text = "&nbsp;";
            lblNumber3.Text = "&nbsp;";
            lblNumber4.Text = "&nbsp;";
            lblNumber5.Text = "&nbsp;";
            lblSelfColor1.Text = "&nbsp;";
            lblSelfColor2.Text = "&nbsp;";
            lblSelfNumber1.Text = "&nbsp;";
            lblSelfNumber2.Text = "&nbsp;";
        }

        protected void btnRestart_Click(object sender, EventArgs e)
        {
            var room = Lobby.Instance.GetRoom(SessionController.GetRoomName(this));
            room.RestartGame();
            ClearValue();
            ReSetValue(room);
        }

        protected void btnFlop_Click(object sender, EventArgs e)
        {
            var room = Lobby.Instance.GetRoom(SessionController.GetRoomName(this));
            room.FlopNextCommonCards();
            ClearValue();
            ReSetValue(room);
        }
    }
}