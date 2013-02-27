using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vaaan.SouFun.AutoFill.App.AccountTransport
{
    class CopyAccountInformationAutoFiller : IAutoFill
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
            if (mainFrameDocument.GetElementById("int_ispay_1").GetAttribute("checked") != "True")
            {
                message = "必须是付费用户";
                MessageBox.Show(message);
                return message;
            }
            if (!mainFrameWindow.Url.ToString().StartsWith("http://kfs.agent.soufun.com/Admin/agent/agentcon/modagentcon.aspx"))
            {
                message = "必须进入经纪人权限修改页面";
                MessageBox.Show(message);
                return message;
            }
            try
            {
                AccountInformationCache.SalemanId = mainFrameDocument.GetElementById("str_saler").GetAttribute("value");
                AccountInformationCache.PayType = mainFrameDocument.GetElementById("DDLPayType").GetAttribute("value");
                AccountInformationCache.ShopPageVersion = (mainFrameDocument.GetElementById("int_MendianVersion_0").GetAttribute("checked") == "True") ? 1 : 2;
                AccountInformationCache.OpenShopSortFunction = mainFrameDocument.GetElementById("int_isSelfHouseType").GetAttribute("checked") == "True";
                if (mainFrameDocument.GetElementById("int_agenttype_1").GetAttribute("checked") == "True")
                {
                    AccountInformationCache.PublishType = 1;
                }
                else if (mainFrameDocument.GetElementById("int_agenttype_2").GetAttribute("checked") == "True")
                {
                    AccountInformationCache.PublishType = 2;
                }
                else if (mainFrameDocument.GetElementById("int_agenttype_3").GetAttribute("checked") == "True")
                {
                    AccountInformationCache.PublishType = 3;
                }
                else if (mainFrameDocument.GetElementById("int_agenttype_4").GetAttribute("checked") == "True")
                {
                    AccountInformationCache.PublishType = 4;
                }
                else
                {
                    AccountInformationCache.PublishType = 5;
                }
                AccountInformationCache.ContractCode = mainFrameDocument.GetElementById("str_contractcode").GetAttribute("value");
                AccountInformationCache.ExpireTime = mainFrameDocument.GetElementById("validdate").GetAttribute("value");
                AccountInformationCache.DayMaxPublishNumber = mainFrameDocument.GetElementById("int_Houselimit").GetAttribute("value");
                AccountInformationCache.DayMaxFactoryNumber = mainFrameDocument.GetElementById("int_HouseMax").GetAttribute("value");
                AccountInformationCache.SafeHouseMaxFactoryNumber = mainFrameDocument.GetElementById("int_RealHouseMax").GetAttribute("value");
                AccountInformationCache.NoRentFeeNewHouseMaxFactoryNumber = mainFrameDocument.GetElementById("int_NewHouseMax").GetAttribute("value");
                AccountInformationCache.RentShowHouseNumber = mainFrameDocument.GetElementById("int_czexhibit").GetAttribute("value");
                AccountInformationCache.SaleShowHouseNumber = mainFrameDocument.GetElementById("int_csexhibit").GetAttribute("value");
                AccountInformationCache.UrgentStartTime = mainFrameDocument.GetElementById("int_UrgentTagEndDay").GetAttribute("value");
                AccountInformationCache.UrgentStartDay = mainFrameDocument.GetElementById("int_UrgentTagGrantDay").GetAttribute("selectedIndex");
                AccountInformationCache.UrgentUserTipNumber = mainFrameDocument.GetElementById("int_UrgentTagGrantNum").GetAttribute("value");
                AccountInformationCache.NewExtendStartTime = mainFrameDocument.GetElementById("int_AddTagEndDay").GetAttribute("value");
                AccountInformationCache.NewExtendStartDay = mainFrameDocument.GetElementById("int_AddTagGrantDay").GetAttribute("selectedIndex");
                AccountInformationCache.NewExtendUserTipNumber = mainFrameDocument.GetElementById("int_AddTagGrantNum").GetAttribute("value");
                AccountInformationCache.IsOpenSpecialUrgent = mainFrameDocument.GetElementById("int_isurgenttag_0").GetAttribute("checked") == "True";
                AccountInformationCache.OpenSpecialUrgentEndDay = mainFrameDocument.GetElementById("urgenttagvaliddate").GetAttribute("value");
                AccountInformationCache.IsOpenNewExtend = mainFrameDocument.GetElementById("int_isaddtag_0").GetAttribute("checked") == "True";
                AccountInformationCache.OpenNewExtendDay = mainFrameDocument.GetElementById("addtagvaliddate").GetAttribute("value");
                AccountInformationCache.UrgentContractCode = mainFrameDocument.GetElementById("txtUrgentContractCode").GetAttribute("value");
                AccountInformationCache.NewExtendContractCode = mainFrameDocument.GetElementById("txtaddContractCode").GetAttribute("value");
                return "复制信息成功";
            }
            catch
            {
                message = "请刷新网页或等待网页加载完成时再尝试复制功能";
                MessageBox.Show(message, "复制信息时出错");
                return message;
            }
        }
    }
}
