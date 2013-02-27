using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vaaan.SouFun.AutoFill.App.ComboPack;
using Vaaan.SouFun.AutoFill.App.DingTouProduct;
using Vaaan.SouFun.AutoFill.App.AccountTransport;
using Vaaan.SouFun.AutoFill.App.ZyExpertAutoFill;

namespace Vaaan.SouFun.AutoFill.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsmSet_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = new ComboPackAutoFiller((sender as ToolStripMenuItem).Tag.ToString()).AutoFill(this.CurrentActiveWebBrowser);
        }

        private void 定投经纪人ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = new DingTouProductAutoAdder().AutoFill(this.CurrentActiveWebBrowser);
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = new CopyAccountInformationAutoFiller().AutoFill(this.CurrentActiveWebBrowser);
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = new ClearAccountInformationAutoFiller().AutoFill(this.CurrentActiveWebBrowser);
        }

        private void 添加置业专家ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZyExpertAutoFiller.Instance.mainFormInfoLabel = this.toolStripStatusLabel1;
            this.toolStripStatusLabel1.Text = ZyExpertAutoFiller.Instance.AutoFill(this.CurrentActiveWebBrowser);
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = new PasteAccountInformationAutoFiller().AutoFill(this.CurrentActiveWebBrowser);
        }


        // Properties
        private WebBrowser CurrentActiveWebBrowser
        {
            get
            {
                return (this.tabControl1.SelectedTab.Controls[0] as WebBrowser);
            }
        }
    }
}
