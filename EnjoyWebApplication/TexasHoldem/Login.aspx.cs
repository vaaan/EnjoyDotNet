using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnjoyWebApplication.TexasHoldem.Manage.Entity;
using EnjoyWebApplication.TexasHoldem.Manage;

namespace EnjoyWebApplication.TexasHoldem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var room = Lobby.Instance.GetRoom(tbRoomName.Text);
            var poker = room.GetPoker(tbNickName.Text);
            if (poker == null) poker = new Poker { NickName = tbNickName.Text };
            if (!String.IsNullOrEmpty(tbRoomPwd.Text))
            {
                if (!String.IsNullOrEmpty(room.Password) && room.Password != tbRoomPwd.Text)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Login), "", "alert('房间密码不正确\\n无法作为管理员登录')", true);
                    return;
                }
                room.Password = tbRoomPwd.Text;
                poker.IsRoomAdmin = true;
            }
            room.AddPoker(poker);
            SessionController.SetRoomName(this, room.Name);
            SessionController.SetPokerName(this, poker.NickName);
            SessionController.SetToken(this, "");
            if (poker.IsRoomAdmin) Response.Redirect("AdminPokerPlay.aspx");
            else Response.Redirect("PokerPlay.aspx");
        }
    }
}