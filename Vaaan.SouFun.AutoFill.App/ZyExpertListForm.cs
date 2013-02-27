using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vaaan.SouFun.AutoFill.App.Utilities;
using Vaaan.SouFun.AutoFill.App.ZyExpertAutoFill;

namespace Vaaan.SouFun.AutoFill.App
{
    public partial class ZyExpertListForm : Form
    {
        public ZyExpertListForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((this.dataGridView1.SelectedRows.Count == 0) && (this.dataGridView1.SelectedCells[0].ColumnIndex == 3))
            {
                if (this.OnBuildingIdDoubleClicked != null)
                {
                    this.OnBuildingIdDoubleClicked(this.dataGridView1.SelectedCells[0].Value.ToString());
                }
            }
            else
            {
                this.填写ToolStripMenuItem_Click(null, null);
            }
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
            else if (this.OnExpertInformationSelected != null)
            {
                DataRow drExport = (this.dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row;
                ExpertInformation expert = new ExpertInformation
                {
                    Managerid = drExport[0].ToString(),
                    Contractdate = drExport[1].ToString(),
                    Contractid = drExport[2].ToString(),
                    BuildCode = drExport[3].ToString()
                };
                this.OnExpertInformationSelected(expert);
            }
        }
    }
}
