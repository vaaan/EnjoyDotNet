<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EnjoyWebApplication.TexasHoldem.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>德州扑克登录</title>
</head>
<body style="font-size: 16px; font-weight: bold;">
    <script type="text/javascript" language="javascript">
        function checkValue() {
            if (document.getElementById("tbNickName").value == "" || document.getElementById("tbRoomName").value == "") {
                alert("昵称和房间名称不可为空");
                return false;
            }
            return true;
        }
    </script>
    <form id="form1" runat="server">
    <div>
        德州扑克登录<br />
        <br />
        昵称：<asp:TextBox ID="tbNickName" runat="server" ClientIDMode="Static"></asp:TextBox>
        &nbsp; 房间名：<asp:TextBox ID="tbRoomName" runat="server" ClientIDMode="Static"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnLogin" runat="server" Text="进 入" 
            OnClientClick="javascript:return checkValue();" onclick="btnLogin_Click" />
        <br />
        <br />
        房间密码（输入则以管理员身份登录）：<asp:TextBox ID="tbRoomPwd" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    </form>
</body>
</html>
