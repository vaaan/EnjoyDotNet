using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vaaan.SouFun.AutoFill.App.ZyExpertAutoFill
{
    class ZyExpertAutoFiller : IAutoFill
    {
        // Fields
        private static ZyExpertAutoFiller instance;
        public ToolStripStatusLabel mainFormInfoLabel;
        private WebBrowser webBrowser;
        private static ZyExpertListForm zyExportListForm;

        // Methods
        static ZyExpertAutoFiller()
        {
            instance = new ZyExpertAutoFiller();
            zyExportListForm = null;
        }

        private ZyExpertAutoFiller()
        {
            this.webBrowser = null;
        }

        public string AutoFill(WebBrowser fillWebBrowser)
        {
            this.webBrowser = fillWebBrowser;
            if (this.webBrowser.Document.Window.Frames.Count < 4)
            {
                string message = "必须成功登录并通过点击菜单进入界面";
                MessageBox.Show(message);
                return message;
            }
            HtmlWindow mainFrameWindow = this.webBrowser.Document.Window.Frames[3];
            if (zyExportListForm == null)
            {
                zyExportListForm = new ZyExpertListForm();
                zyExportListForm.OnExpertInformationSelected += new ZyExpertListForm.ExpertInformationSelectedHandler(this.zyExportListForm_OnExpertInformationSelected);
                zyExportListForm.OnBuildingIdDoubleClicked += new ZyExpertListForm.BuildingIdDoubleClickedHandler(this.zyExportListForm_OnBuildingIdDoubleClicked);
            }
            zyExportListForm.Show();
            zyExportListForm.LoadExcel();
            return "已成功打开置业专家数据表格";
        }

        private void zyExportListForm_OnBuildingIdDoubleClicked(string buildingId)
        {
            if (this.webBrowser.Document.Window.Frames.Count < 4)
            {
                MessageBox.Show("必须成功登录并通过点击菜单进入界面");
            }
            else
            {
                this.webBrowser.Document.Window.Frames[3].Navigate(string.Format("http://kfs.agent.soufun.com/Admin/agentprojad/setAgentAdSave.aspx?action=synach&isNoSame=false&newcode={0}&rc=abc", buildingId));
            }
        }

        private void zyExportListForm_OnExpertInformationSelected(ExpertInformation expert)
        {
            this.webBrowser.Document.Window.Frames[3].Navigate(string.Format("http://kfs.agent.soufun.com/Admin/agentprojad/SetAgentAdSave.aspx?action=addMagentad&agentid={0}&timeStamp={1}&enddate={2}&cCode={3}&newcode={4}", new object[] { expert.Managerid, new Random().Next(0x7fffffff), expert.Contractdate, expert.Contractid, expert.BuildCode }));
            this.mainFormInfoLabel.Text = string.Format("已执行ID为【{0}】的经纪人置业专家操作", expert.Managerid);
        }

        // Properties
        public static ZyExpertAutoFiller Instance
        {
            get
            {
                return instance;
            }
        }

    }
}
