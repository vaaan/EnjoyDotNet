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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;

namespace Vaaan.SouFun.AutoFill.App.ZyExpertAutoFill
{
    public partial class ZyExpertListForm : Form
    {
        private DataTable _importDt;
        private WebBrowser webBrowser;

        public ZyExpertListForm(WebBrowser fillWebBrowser)
        {
            InitializeComponent();
            this.webBrowser = fillWebBrowser;
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
                _importDt = ExcelDataFetcher.Fetch(this.openFileDialog1.FileName, "Sheet1", true);
                this.dataGridView1.DataSource = _importDt;
                tbResult.Text = "";
                tabControl1.SelectedIndex = 0;
            }
        }

        private void ZyExpertListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            base.Hide();
        }

        private void 开始导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var importDataList = new List<ExpertInformation>();
            #region Check and Build Entity List

            // check data not empty
            if (_importDt == null || _importDt.Rows.Count == 0)
            {
                MessageBox.Show("没有可导入的数据");
                base.Hide();
                return;
            }
            // check data format correct
            if (!ImportDtFormatValid())
            {
                MessageBox.Show("数据格式不正确，列顺序必须是：\n经纪人编号	合同截止日期	租售类型	合同号	楼盘NC");
                base.Hide();
                return;
            }
            // check data value correct
            var numberReg = new Regex("^\\d+$");
            var dateReg = new Regex("^\\d{4}-\\d{1,2}-\\d{1,2}$");
            for (int i = 0; i < _importDt.Rows.Count; i++)
            {
                var entity = new ExpertInformation();
                var dr = _importDt.Rows[i];
                for (int j = 0; j < 5; j++)
                {
                    if (dr[j] == null || string.IsNullOrWhiteSpace(dr[j].ToString()))
                    {
                        MessageBox.Show("值不能为空");
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        return;
                    }
                }
                // agent id
                var value = dr[0].ToString().Trim();
                if (!numberReg.IsMatch(value))
                {
                    MessageBox.Show("经纪人编号格式不正确，只能是数字");
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    return;
                }
                entity.Managerid = value;
                // contact date
                value = dr[1].ToString().Trim();
                var date = new DateTime(1900, 1, 1);
                if (!numberReg.IsMatch(value) && !dateReg.IsMatch(value) && !DateTime.TryParse(value, out date))
                {
                    MessageBox.Show("合同截止日期格式不正确");
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    return;
                }
                if (dateReg.IsMatch(value))
                    entity.Contractdate = value;
                else if (numberReg.IsMatch(value))
                    entity.Contractdate = DateTime.FromOADate(Double.Parse(value)).ToString("yyyy-MM-dd");
                else
                    entity.Contractdate = date.ToString("yyyy-MM-dd");
                // rent type
                value = dr[2].ToString().Trim();
                if (value == "出租")
                    entity.RentType = RentTypes.Rent;
                else if (value == "出售")
                    entity.RentType = RentTypes.Sale;
                else if (value == "全部")
                    entity.RentType = RentTypes.Both;
                else
                {
                    MessageBox.Show("租售类型格式不正确，只能是 出租、出售、全部 中的一种");
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    return;
                }
                // contact id
                value = dr[3].ToString().Trim();
                entity.Contractid = value;
                importDataList.Add(entity);
                // building NC
                value = dr[4].ToString().Trim();
                if (!numberReg.IsMatch(value))
                {
                    MessageBox.Show("楼盘NC格式不正确，只能是数字");
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    return;
                }
                entity.BuildCode = value;
            }
            #endregion
            // import by thread
            if (MessageBox.Show("确定开始批量导入？", "确定导入", MessageBoxButtons.YesNo) == DialogResult.No) return;
            tabControl1.SelectedIndex = 1;
            this.Enabled = false;
            var cookie = webBrowser.Document.Cookie;
            Task.Factory.StartNew(
                () =>
                {
                    var error = new StringBuilder();
                    var webClient = new WebClient();
                    webClient.Headers.Add(HttpRequestHeader.Cookie, cookie);
                    var successNumber = 0;
                    for (int i = 0; i < importDataList.Count; i++)
                    {
                        var entity = importDataList[i];
                        this.Invoke(new Action(() =>
                        {
                            tbResult.Text = String.Format("正在导入{0}/{1}", i + 1, importDataList.Count);
                        }));
                        try
                        {
                            var url = String.Format(
                                "http://kfs.agent.soufun.com/Admin/agentprojad/SetAgentAdSave.aspx?action=addMagentad&agentid={0}&timeStamp=0.{1}&enddate={2}&cCode={3}&newcode={4}&saleOrRent={5}",
                                entity.Managerid, new Random().Next(0x7fffffff), entity.Contractdate, Microsoft.JScript.GlobalObject.escape(entity.Contractid), entity.BuildCode, (int)entity.RentType);
                            var requestResult = webClient.DownloadString(url);
                            if (requestResult.Contains("登录"))
                            {
                                error.Append("必须先登录客服系统");
                                break;
                            }
                            else if (requestResult == "noEro") 
                            {
                                successNumber++;
                                continue;
                            }
                            else
                            {
                                var singleError = requestResult;
                                switch (requestResult)
                                {
                                    case "Ero1": singleError = "参数传递错误"; break;
                                    case "Ero2": singleError = "到期时间应为今天之后的日期"; break;
                                    case "Ero3": singleError = "未找到相应楼盘"; break;
                                    case "Ero4": singleError = "未找到相应经纪人"; break;
                                    case "Ero5": singleError = "该楼盘已存在此置业专家"; break;
                                    case "Ero6": singleError = "您要设置的楼盘不存在或已改名,请更新楼盘信息后再添加"; break;
                                    case "Ero7": singleError = "您要设置的楼盘不存在"; break;
                                    case "insertEro": singleError = "添加失败，请重试"; break;
                                    default: break;
                                }
                                error.Append(String.Format("添加经纪人{0}至楼盘{1}时发生错误:\r\n{2}\r\n\r\n",
                                entity.Managerid, entity.BuildCode, singleError));
                            }
                        }
                        catch (Exception ex)
                        {
                            error.Append(String.Format("添加经纪人{0}至楼盘{1}时发生异常:\r\n{2}\r\n\r\n",
                                entity.Managerid, entity.BuildCode, ex));
                        }
                    }
                    this.Invoke(new Action(() =>
                    {
                        if (error.Length == 0)
                            tbResult.Text = "全部导入成功，未发生错误";
                        else
                            tbResult.Text = String.Format("成功导入{0}/{1}\r\n\r\n{2}", successNumber, importDataList.Count, error.ToString());
                        this.Enabled = true;
                    }));
                });
        }

        private bool ImportDtFormatValid()
        {
            if (_importDt.Columns.Count < 5) return false;
            if (_importDt.Columns[0].ColumnName.Trim() != "经纪人编号") return false;
            if (_importDt.Columns[1].ColumnName.Trim() != "合同截止日期") return false;
            if (_importDt.Columns[2].ColumnName.Trim() != "租售类型") return false;
            if (_importDt.Columns[3].ColumnName.Trim() != "合同号") return false;
            if (_importDt.Columns[4].ColumnName.Trim() != "楼盘NC") return false;
            return true;
        }
    }
}
