using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vaaan.SouFun.AutoFill.App.Utilities;

namespace Vaaan.SouFun.AutoFill.App.DingTouProduct
{
    class DingTouProductAutoAdder : IAutoFill
    {
        // Fields
        private static DingTouProductManagerListForm dingTouProductManagerListForm;
        private DingTouProductManagerInformation expert;
        private bool isNeedFillData;
        private WebBrowser webBrowser;

        // Methods
        static DingTouProductAutoAdder()
        { dingTouProductManagerListForm = null; }

        public DingTouProductAutoAdder()
        {
            this.webBrowser = null;
            this.isNeedFillData = false;
            this.expert = null;
        }
        public string AutoFill(WebBrowser fillWebBrowser)
        {
            this.webBrowser = fillWebBrowser;
            EventRemover.ClearEvent(this.webBrowser, "DocumentCompleted");
            this.webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            if (this.webBrowser.Document.Window.Frames.Count < 4)
            {
                string message = "必须成功登录并通过点击菜单进入界面";
                MessageBox.Show(message);
                return message;
            }
            HtmlWindow mainFrameWindow = this.webBrowser.Document.Window.Frames[3];
            if (dingTouProductManagerListForm == null)
            {
                dingTouProductManagerListForm = new DingTouProductManagerListForm();
                dingTouProductManagerListForm.OnManagerInformationSelected = (DingTouProductManagerListForm.ManagerInformationSelectedHandler)Delegate.Combine(dingTouProductManagerListForm.OnManagerInformationSelected, new DingTouProductManagerListForm.ManagerInformationSelectedHandler(this.dingTouProductManagerListForm_OnManagerInformationSelected));
            }
            dingTouProductManagerListForm.Show();
            dingTouProductManagerListForm.LoadExcel();
            return "已成功打开定投经纪人数据表格";
        }

        private void dingTouProductManagerListForm_OnManagerInformationSelected(DingTouProductManagerInformation expert)
        {
            this.isNeedFillData = true;
            this.expert = expert;
            this.webBrowser.Document.Window.Frames[3].Navigate(string.Format("http://kfs.agent.soufun.com/Admin/keywordad/ModifyMoney.aspx?agentid={0}", expert.Managerid));
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.isNeedFillData)
            {
                HtmlDocument mainFrameDocument = this.webBrowser.Document.Window.Frames[3].Document;
                mainFrameDocument.GetElementById("txtAddMoney").SetAttribute("value", this.expert.AddMoney);
                mainFrameDocument.GetElementById("txtContractCode").SetAttribute("value", this.expert.ContractId);
                this.isNeedFillData = false;
                mainFrameDocument.GetElementById("btn_Submit").InvokeMember("click");
            }
        }
    }
}
