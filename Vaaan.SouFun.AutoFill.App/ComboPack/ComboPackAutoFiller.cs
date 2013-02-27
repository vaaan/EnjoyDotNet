using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vaaan.SouFun.AutoFill.App.ComboPack
{
    class ComboPackAutoFiller : IAutoFill
    {
        // Fields
        private string comboPackNumber;

        public ComboPackAutoFiller(string comboPackNumber)
        {
            this.comboPackNumber = comboPackNumber;
        }

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
            HtmlElement isPayUserCheckBox = mainFrameDocument.GetElementById("int_ispay_1");
            if (isPayUserCheckBox.GetAttribute("checked") != "True")
            {
                message = "必须选择付费用户";
                MessageBox.Show(message);
                isPayUserCheckBox.Focus();
                isPayUserCheckBox.ScrollIntoView(true);
                return message;
            }
            HtmlElement contractcodeInputBox = mainFrameDocument.GetElementById("str_contractcode");
            if (contractcodeInputBox.GetAttribute("value").Trim() == "")
            {
                message = "必须填写合同编号";
                MessageBox.Show(message);
                contractcodeInputBox.Focus();
                contractcodeInputBox.ScrollIntoView(true);
                return message;
            }
            HtmlElement validdateInputBox = mainFrameDocument.GetElementById("validdate");
            if (validdateInputBox.GetAttribute("value").Trim() == "")
            {
                message = "必须填写到期时间";
                MessageBox.Show(message);
                validdateInputBox.Focus();
                validdateInputBox.ScrollIntoView(true);
                return message;
            }
            DateTime validate = DateTime.Parse(validdateInputBox.GetAttribute("value"));
            int houseMaxInputNumber = 40;
            int tagNumber = 10;
            switch (this.comboPackNumber)
            {
                case "60":
                    houseMaxInputNumber = 40;
                    tagNumber = 10;
                    break;

                case "120":
                    houseMaxInputNumber = 80;
                    tagNumber = 15;
                    break;

                case "180":
                    houseMaxInputNumber = 100;
                    tagNumber = 20;
                    break;

                case "300":
                    houseMaxInputNumber = 100;
                    tagNumber = 0x19;
                    break;
            }
            mainFrameDocument.GetElementById("int_Houselimit").SetAttribute("value", this.comboPackNumber);
            mainFrameDocument.GetElementById("int_HouseMax").SetAttribute("value", houseMaxInputNumber.ToString());
            HtmlElement int_isAutoGrant_1RadioBox = mainFrameDocument.GetElementById("int_isAutoGrant_1");
            int_isAutoGrant_1RadioBox.SetAttribute("checked", "True");
            int_isAutoGrant_1RadioBox.RaiseEvent("onclick");
            mainFrameDocument.GetElementById("int_UrgentTagEndDay").SetAttribute("value", validate.ToString("yyyy-MM-dd"));
            mainFrameDocument.GetElementById("int_UrgentTagGrantDay").SetAttribute("selectedIndex", (validate.Day >= 0x1c) ? "0" : validate.Day.ToString());
            mainFrameDocument.GetElementById("int_UrgentTagGrantNum").SetAttribute("value", tagNumber.ToString());
            mainFrameDocument.GetElementById("int_AddTagEndDay").SetAttribute("value", validate.ToString("yyyy-MM-dd"));
            mainFrameDocument.GetElementById("int_AddTagGrantDay").SetAttribute("selectedIndex", (validate.Day >= 0x1c) ? "0" : validate.Day.ToString());
            mainFrameDocument.GetElementById("int_AddTagGrantNum").SetAttribute("value", tagNumber.ToString());
            mainFrameDocument.GetElementById("txtUrgentContractCode").SetAttribute("value", contractcodeInputBox.GetAttribute("value"));
            mainFrameDocument.GetElementById("txtaddContractCode").SetAttribute("value", contractcodeInputBox.GetAttribute("value"));
            return string.Format("已成功设置为{0}套餐", this.comboPackNumber);
        }

    }
}
