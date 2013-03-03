<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PokerPlay.aspx.cs" Inherits="EnjoyWebApplication.TexasHoldem.PokerPlay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .S
        {
            color: Black;
        }
        .H
        {
            color: Red;
        }
        .C
        {
            color: Green;
        }
        .D
        {
            color: Blue;
        }
    </style>
</head>
<body style="font-size: 50px; font-weight: bold;">
    <form id="form1" runat="server">
    <div>
        你好：<asp:Label ID="lblNickName" runat="server"></asp:Label>
        <br />
        <br />
        <table>
            <tr>
                <td>
                    当前公共牌:<br />
                    <table style="border-style: solid; border-width: 1px; width: 600px; background-color: #FFFF99;">
                        <tr>
                            <td colspan="3" align="center" style="background-color: #CCCCFF">
                                翻牌
                            </td>
                            <td align="center" style="background-color: #99CCFF">
                                转牌
                            </td>
                            <td align="center" style="background-color: #FF99CC">
                                河牌
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="background-color: #CCCCFF" width="20%">
                                <asp:Label ID="lblColor1" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="background-color: #CCCCFF" width="20%">
                                <asp:Label ID="lblColor2" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="background-color: #CCCCFF" width="20%">
                                <asp:Label ID="lblColor3" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="background-color: #99CCFF" width="20%">
                                <asp:Label ID="lblColor4" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="background-color: #FF99CC" width="20%">
                                <asp:Label ID="lblColor5" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="background-color: #CCCCFF">
                                <asp:Label ID="lblNumber1" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="background-color: #CCCCFF">
                                <asp:Label ID="lblNumber2" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="background-color: #CCCCFF">
                                <asp:Label ID="lblNumber3" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="background-color: #99CCFF">
                                <asp:Label ID="lblNumber4" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="background-color: #FF99CC">
                                <asp:Label ID="lblNumber5" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 40px;" />
                <td valign="top">
                    你的底牌:<br />
                    <div>
                        <table style="border-style: solid; border-width: 1px; width: 80px; background-color: #FFFF99;">
                            <tr>
                                <td align="center" style="background-color: #CCCCFF" width="20%">
                                    <asp:Label ID="lblSelfColor1" runat="server"></asp:Label>
                                </td>
                                <td align="center" style="background-color: #CCCCFF" width="20%">
                                    <asp:Label ID="lblSelfColor2" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="background-color: #CCCCFF">
                                    <asp:Label ID="lblSelfNumber1" runat="server"></asp:Label>
                                </td>
                                <td align="center" style="background-color: #CCCCFF">
                                    <asp:Label ID="lblSelfNumber2" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script type="text/javascript" language="javascript">
        window.setTimeout("window.location.href = 'PokerPlay.aspx';", 1000);
    </script>
</body>
</html>
