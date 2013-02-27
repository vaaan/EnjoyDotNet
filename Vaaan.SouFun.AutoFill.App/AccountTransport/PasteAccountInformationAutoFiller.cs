using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vaaan.SouFun.AutoFill.App.AccountTransport
{
    class PasteAccountInformationAutoFiller : IAutoFill
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
            HtmlDocument mainFrameDocument = mainFrameWindow.Document;
            if (!mainFrameWindow.Url.ToString().StartsWith("http://kfs.agent.soufun.com/Admin/agent/agentcon/modagentcon.aspx"))
            {
                message = "必须进入经纪人权限修改页面";
                MessageBox.Show(message);
                return message;
            }
            try
            {
                mainFrameDocument.GetElementById("str_saler").SetAttribute("value", AccountInformationCache.SalemanId);
                mainFrameDocument.GetElementById("int_ispay_1").SetAttribute("checked", "True");
                mainFrameDocument.GetElementById("int_ispay_1").RaiseEvent("onclick");
                mainFrameDocument.GetElementById("DDLPayType").SetAttribute("value", AccountInformationCache.PayType);
                if (AccountInformationCache.ShopPageVersion == 1)
                {
                    mainFrameDocument.GetElementById("int_MendianVersion_0").SetAttribute("checked", "True");
                    mainFrameDocument.GetElementById("int_MendianVersion_0").RaiseEvent("onclick");
                }
                else
                {
                    mainFrameDocument.GetElementById("int_MendianVersion_1").SetAttribute("checked", "True");
                    mainFrameDocument.GetElementById("int_MendianVersion_1").RaiseEvent("onclick");
                    mainFrameDocument.GetElementById("int_isSelfHouseType").SetAttribute("checked", AccountInformationCache.OpenShopSortFunction ? "True" : "");
                }
                HtmlElement publicTypeRadioButton = mainFrameDocument.GetElementById("int_agenttype_" + AccountInformationCache.PublishType);
                if (publicTypeRadioButton != null)
                {
                    publicTypeRadioButton.SetAttribute("checked", "True");
                    publicTypeRadioButton.RaiseEvent("onclick");
                }
                mainFrameDocument.GetElementById("str_contractcode").SetAttribute("value", AccountInformationCache.ContractCode);
                mainFrameDocument.GetElementById("validdate").SetAttribute("value", AccountInformationCache.ExpireTime);
                mainFrameDocument.GetElementById("int_Houselimit").SetAttribute("value", AccountInformationCache.DayMaxPublishNumber);
                mainFrameDocument.GetElementById("int_HouseMax").SetAttribute("value", AccountInformationCache.DayMaxFactoryNumber);
                mainFrameDocument.GetElementById("int_RealHouseMax").SetAttribute("value", AccountInformationCache.SafeHouseMaxFactoryNumber);
                mainFrameDocument.GetElementById("int_NewHouseMax").SetAttribute("value", AccountInformationCache.NoRentFeeNewHouseMaxFactoryNumber);
                mainFrameDocument.GetElementById("int_czexhibit").SetAttribute("value", AccountInformationCache.RentShowHouseNumber);
                mainFrameDocument.GetElementById("int_csexhibit").SetAttribute("value", AccountInformationCache.SaleShowHouseNumber);
                HtmlElement int_isAutoGrant_1RadioBox = mainFrameDocument.GetElementById("int_isAutoGrant_1");
                int_isAutoGrant_1RadioBox.SetAttribute("checked", "True");
                int_isAutoGrant_1RadioBox.RaiseEvent("onclick");
                mainFrameDocument.GetElementById("int_UrgentTagEndDay").SetAttribute("value", AccountInformationCache.UrgentStartTime);
                mainFrameDocument.GetElementById("int_UrgentTagGrantDay").SetAttribute("selectedIndex", AccountInformationCache.UrgentStartDay);
                mainFrameDocument.GetElementById("int_UrgentTagGrantNum").SetAttribute("value", AccountInformationCache.UrgentUserTipNumber);
                mainFrameDocument.GetElementById("int_AddTagEndDay").SetAttribute("value", AccountInformationCache.NewExtendStartTime);
                mainFrameDocument.GetElementById("int_AddTagGrantDay").SetAttribute("selectedIndex", AccountInformationCache.NewExtendStartDay);
                mainFrameDocument.GetElementById("int_AddTagGrantNum").SetAttribute("value", AccountInformationCache.NewExtendUserTipNumber);
                if (AccountInformationCache.IsOpenSpecialUrgent)
                {
                    mainFrameDocument.GetElementById("int_isurgenttag_0").SetAttribute("checked", "True");
                    mainFrameDocument.GetElementById("int_isurgenttag_0").RaiseEvent("onclick");
                    mainFrameDocument.GetElementById("urgenttagvaliddate").SetAttribute("value", AccountInformationCache.OpenSpecialUrgentEndDay);
                }
                else
                {
                    mainFrameDocument.GetElementById("int_isurgenttag_1").SetAttribute("checked", "True");
                    mainFrameDocument.GetElementById("int_isurgenttag_1").RaiseEvent("onclick");
                }
                if (AccountInformationCache.IsOpenNewExtend)
                {
                    mainFrameDocument.GetElementById("int_isaddtag_0").SetAttribute("checked", "True");
                    mainFrameDocument.GetElementById("int_isaddtag_0").RaiseEvent("onclick");
                    mainFrameDocument.GetElementById("addtagvaliddate").SetAttribute("value", AccountInformationCache.OpenNewExtendDay);
                }
                else
                {
                    mainFrameDocument.GetElementById("int_isaddtag_1").SetAttribute("checked", "True");
                    mainFrameDocument.GetElementById("int_isaddtag_1").RaiseEvent("onclick");
                }
                mainFrameDocument.GetElementById("txtUrgentContractCode").SetAttribute("value", AccountInformationCache.UrgentContractCode);
                mainFrameDocument.GetElementById("txtaddContractCode").SetAttribute("value", AccountInformationCache.NewExtendContractCode);
                return "账户信息已成功粘贴";
            }
            catch
            {
                message = "请刷新网页或等待网页加载完成时再尝试粘贴功能";
                MessageBox.Show(message, "粘贴信息时出错");
                return message;
            }
        }
    }
}
