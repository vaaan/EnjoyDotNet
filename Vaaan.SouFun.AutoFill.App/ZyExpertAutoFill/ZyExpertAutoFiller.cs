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
            if (zyExportListForm == null)
                zyExportListForm = new ZyExpertListForm(fillWebBrowser);
            zyExportListForm.Show();
            zyExportListForm.LoadExcel();
            return "已成功打开置业专家数据表格";
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
