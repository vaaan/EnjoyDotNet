using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vaaan.SouFun.AutoFill.App.AccountTransport
{
    class ClearAccountInformationAutoFiller : IAutoFill
    {
        public string AutoFill(WebBrowser fillWebBrowser)
        {
            string message;
            if (fillWebBrowser.Document.Window.Frames.Count < 4)
            {
                message = "必须成功登录并通过点击菜单进入界面";
                MessageBox.Show(message);
                return message;
            }
            HtmlWindow mainFrameWindow = fillWebBrowser.Document.Window.Frames[3];
            if (!mainFrameWindow.Url.ToString().StartsWith("http://kfs.agent.soufun.com/Admin/agent/agentcon/modagentcon.aspx"))
            {
                message = "必须进入经纪人权限修改页面";
                MessageBox.Show(message);
                return message;
            }
            HtmlDocument mainFrameDocument = mainFrameWindow.Document;
            HtmlElement isPayUserCheckBox = mainFrameDocument.GetElementById("int_ispay_0");
            isPayUserCheckBox.SetAttribute("checked", "True");
            isPayUserCheckBox.RaiseEvent("onclick");
            string tempContent = "";
            HtmlElement int_UrgenttagcountInputBox = mainFrameDocument.GetElementById("int_Urgenttagcount");
            tempContent = int_UrgenttagcountInputBox.Parent.InnerText;
            tempContent = tempContent.Substring(0, tempContent.IndexOf("个")).Replace("现有", "").Trim();
            if (tempContent == "0")
            {
                int_UrgenttagcountInputBox.SetAttribute("value", "0");
            }
            else
            {
                int_UrgenttagcountInputBox.SetAttribute("value", "-" + tempContent);
            }
            HtmlElement int_AddtagcountInputBox = mainFrameDocument.GetElementById("int_Addtagcount");
            tempContent = int_AddtagcountInputBox.Parent.InnerText;
            tempContent = tempContent.Substring(0, tempContent.IndexOf("个")).Replace("现有", "").Trim();
            if (tempContent == "0")
            {
                int_AddtagcountInputBox.SetAttribute("value", "0");
            }
            else
            {
                int_AddtagcountInputBox.SetAttribute("value", "-" + tempContent);
            }
            mainFrameDocument.GetElementById("int_UrgentTagEndDay").SetAttribute("value", DateTime.Now.ToString("yyyy-MM-dd"));
            mainFrameDocument.GetElementById("int_AddTagEndDay").SetAttribute("value", DateTime.Now.ToString("yyyy-MM-dd"));
            return "账号信息已被清空";
        }
    }
}
