using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System;
namespace Vaaan.SouFun.AutoFill.App.DingTouProduct
{
    partial class DingTouProductManagerListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        public ManagerInformationSelectedHandler OnManagerInformationSelected;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem 去除首条ToolStripMenuItem;
        private ToolStripMenuItem 填写ToolStripMenuItem;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.填写ToolStripMenuItem = new ToolStripMenuItem();
            this.去除首条ToolStripMenuItem = new ToolStripMenuItem();
            this.dataGridView1 = new DataGridView();
            this.openFileDialog1 = new OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((ISupportInitialize)this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.填写ToolStripMenuItem, this.去除首条ToolStripMenuItem });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(0x124, 0x18);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.填写ToolStripMenuItem.Name = "填写ToolStripMenuItem";
            this.填写ToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F;
            this.填写ToolStripMenuItem.Size = new Size(0x29, 20);
            this.填写ToolStripMenuItem.Text = "填写";
            this.填写ToolStripMenuItem.Click += new EventHandler(this.填写ToolStripMenuItem_Click);
            this.去除首条ToolStripMenuItem.Name = "去除首条ToolStripMenuItem";
            this.去除首条ToolStripMenuItem.Size = new Size(0x29, 20);
            this.去除首条ToolStripMenuItem.Text = "去除";
            this.去除首条ToolStripMenuItem.Click += new EventHandler(this.去除首条ToolStripMenuItem_Click);
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.Location = new Point(0, 0x18);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 0x17;
            this.dataGridView1.Size = new Size(0x124, 0xf9);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.MouseDoubleClick += new MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel文件|*.xls";
            this.openFileDialog1.InitialDirectory = @"C:\";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x124, 0x111);
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.menuStrip1);
            base.MainMenuStrip = this.menuStrip1;
            base.Name = "DingTouProductManagerListForm";
            this.Text = "定投专家列表";
            base.FormClosing += new FormClosingEventHandler(this.ZyExpertListForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((ISupportInitialize)this.dataGridView1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}