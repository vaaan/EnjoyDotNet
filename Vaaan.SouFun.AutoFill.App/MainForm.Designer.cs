using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System;
namespace Vaaan.SouFun.AutoFill.App
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private TabControl tabControl1;
        private TableLayoutPanel tableLayoutPanel1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem tsm120Set;
        private ToolStripMenuItem tsm180Set;
        private ToolStripMenuItem tsm300Set;
        private ToolStripMenuItem tsm60Set;
        private WebBrowser webBrowser1;
        private WebBrowser webBrowser2;
        private ToolStripMenuItem 导入专家信息ExcelToolStripMenuItem;
        private ToolStripMenuItem 定投经纪人ToolStripMenuItem;
        private ToolStripMenuItem 复制ToolStripMenuItem;
        private ToolStripMenuItem 个人套餐ToolStripMenuItem;
        private ToolStripMenuItem 清空ToolStripMenuItem;
        private ToolStripMenuItem 粘贴ToolStripMenuItem;
        private ToolStripMenuItem 账户转移ToolStripMenuItem;
        private ToolStripMenuItem 置业专家ToolStripMenuItem;


        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.个人套餐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm60Set = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm120Set = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm180Set = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm300Set = new System.Windows.Forms.ToolStripMenuItem();
            this.置业专家ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入专家信息ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.账户转移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.定投经纪人ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人套餐ToolStripMenuItem,
            this.置业专家ToolStripMenuItem,
            this.账户转移ToolStripMenuItem,
            this.定投经纪人ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 个人套餐ToolStripMenuItem
            // 
            this.个人套餐ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm60Set,
            this.tsm120Set,
            this.tsm180Set,
            this.tsm300Set});
            this.个人套餐ToolStripMenuItem.Name = "个人套餐ToolStripMenuItem";
            this.个人套餐ToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.个人套餐ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.个人套餐ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.个人套餐ToolStripMenuItem.Text = "个人套餐(P)";
            // 
            // tsm60Set
            // 
            this.tsm60Set.Name = "tsm60Set";
            this.tsm60Set.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.tsm60Set.Size = new System.Drawing.Size(153, 22);
            this.tsm60Set.Tag = "60";
            this.tsm60Set.Text = "A套餐60";
            this.tsm60Set.Click += new System.EventHandler(this.tsmSet_Click);
            // 
            // tsm120Set
            // 
            this.tsm120Set.Name = "tsm120Set";
            this.tsm120Set.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.tsm120Set.Size = new System.Drawing.Size(153, 22);
            this.tsm120Set.Tag = "120";
            this.tsm120Set.Text = "B套餐120";
            this.tsm120Set.Click += new System.EventHandler(this.tsmSet_Click);
            // 
            // tsm180Set
            // 
            this.tsm180Set.Name = "tsm180Set";
            this.tsm180Set.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.tsm180Set.Size = new System.Drawing.Size(153, 22);
            this.tsm180Set.Tag = "180";
            this.tsm180Set.Text = "C套餐180";
            this.tsm180Set.Click += new System.EventHandler(this.tsmSet_Click);
            // 
            // tsm300Set
            // 
            this.tsm300Set.Name = "tsm300Set";
            this.tsm300Set.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
            this.tsm300Set.Size = new System.Drawing.Size(153, 22);
            this.tsm300Set.Tag = "300";
            this.tsm300Set.Text = "D套餐300";
            this.tsm300Set.Click += new System.EventHandler(this.tsmSet_Click);
            // 
            // 置业专家ToolStripMenuItem
            // 
            this.置业专家ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入专家信息ExcelToolStripMenuItem});
            this.置业专家ToolStripMenuItem.Name = "置业专家ToolStripMenuItem";
            this.置业专家ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.置业专家ToolStripMenuItem.Text = "置业专家";
            // 
            // 导入专家信息ExcelToolStripMenuItem
            // 
            this.导入专家信息ExcelToolStripMenuItem.Name = "导入专家信息ExcelToolStripMenuItem";
            this.导入专家信息ExcelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.导入专家信息ExcelToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.导入专家信息ExcelToolStripMenuItem.Text = "添加置业专家";
            this.导入专家信息ExcelToolStripMenuItem.Click += new System.EventHandler(this.添加置业专家ToolStripMenuItem_Click);
            // 
            // 账户转移ToolStripMenuItem
            // 
            this.账户转移ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.清空ToolStripMenuItem});
            this.账户转移ToolStripMenuItem.Name = "账户转移ToolStripMenuItem";
            this.账户转移ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.账户转移ToolStripMenuItem.Text = "账户转移";
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // 定投经纪人ToolStripMenuItem
            // 
            this.定投经纪人ToolStripMenuItem.Name = "定投经纪人ToolStripMenuItem";
            this.定投经纪人ToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.定投经纪人ToolStripMenuItem.Text = "定投经纪人";
            this.定投经纪人ToolStripMenuItem.Click += new System.EventHandler(this.定投经纪人ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(23, 17);
            this.toolStripStatusLabel1.Text = "   ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 527);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(786, 521);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webBrowser1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(778, 495);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "界面1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(772, 489);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.Url = new System.Uri("http://kfs.agent.soufun.com/", System.UriKind.Absolute);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(778, 495);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "界面2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(3, 3);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(772, 489);
            this.webBrowser2.TabIndex = 3;
            this.webBrowser2.Url = new System.Uri("http://kfs.agent.soufun.com/", System.UriKind.Absolute);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "搜房帮自动管理";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

