<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="EnjoyWebApplication._Default" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" language="javascript">
        var i=0;
        window.setInterval("document.getElementById('tbValue').value=i.toString();i++;", 1000);
        window.setTimeout("window.location.href = 'About.aspx';", 3000);
    </script>
    <h2>
        欢迎使用 ASP.NET! <input type="text" id="tbValue" />
    </h2>
    <p>
        若要了解关于 ASP.NET 的详细信息，请访问 <a href="http://www.asp.net/cn" title="ASP.NET 网站">www.asp.net/cn</a>。
    </p>
    <p>
        您还可以找到 <a href="http://go.microsoft.com/fwlink/?LinkID=152368"
            title="MSDN ASP.NET 文档">MSDN 上有关 ASP.NET 的文档</a>。
    </p>
</asp:Content>
