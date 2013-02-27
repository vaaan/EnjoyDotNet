using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vaaan.SouFun.AutoFill.App.Utilities;

namespace Vaaan.SouFun.AutoFill.App.DingTouProduct
{
    public partial class DingTouProductManagerListForm : Form
    {
        public DingTouProductManagerListForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.填写ToolStripMenuItem_Click(null, null);
        }

        public void LoadExcel()
        {
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                base.Hide();
            }
            else
            {
                this.dataGridView1.AutoGenerateColumns = true;
                this.dataGridView1.DataSource = ExcelDataFetcher.Fetch(this.openFileDialog1.FileName, "Sheet1", true);
            }
        }

        private void ZyExpertListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            base.Hide();
        }

        private void 去除首条ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.dataGridView1.DataSource == null) || ((this.dataGridView1.DataSource as DataTable).Rows.Count == 0))
            {
                MessageBox.Show("已经无用户再可用于自动填写");
                base.Hide();
            }
            else if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中任何行");
            }
            else
            {
                (this.dataGridView1.DataSource as DataTable).Rows.Remove((this.dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row);
            }
        }

        private void 填写ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.dataGridView1.DataSource == null) || ((this.dataGridView1.DataSource as DataTable).Rows.Count == 0))
            {
                MessageBox.Show("已经无用户再可用于自动填写");
                base.Hide();
            }
            else if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中任何行");
            }
            else if (this.OnManagerInformationSelected != null)
            {
                DataRow drExport = (this.dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row;
                DingTouProductManagerInformation expert = new DingTouProductManagerInformation
                {
                    Managerid = drExport[0].ToString(),
                    AddMoney = drExport[1].ToString(),
                    ContractId = drExport[2].ToString()
                };
                this.OnManagerInformationSelected(expert);
            }
        }

        // Nested Types
        public delegate void ManagerInformationSelectedHandler(DingTouProductManagerInformation expert);

    }
}
