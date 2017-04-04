using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 获取网页标题
{
    /// <summary>
    /// 结构：用于组织网址、标题、状态数据以及所对应的ListViewItem
    /// </summary>
    public struct MyData
    {
        public string URL;
        public string Title;
        public string State;

        private ListViewItem _lvwItem;
        public ListViewItem LvwItem
        {
            get
            {
                if (_lvwItem == null)
                    _lvwItem = new ListViewItem(new string[] { URL, Title, State });
                else
                    UpdateItem();
                return _lvwItem;
            }
        }

        /// <summary>
        /// 将ListViewItem的内容更新为最新
        /// </summary>
        public void UpdateItem()
        {
            if (_lvwItem != null)
            {
                _lvwItem.SubItems[0].Text = URL;
                _lvwItem.SubItems[1].Text = Title;
                _lvwItem.SubItems[2].Text = State;
            }
        }
    }


    public partial class Form1 : Form
    {
        /// <summary>
        /// 事件：解决“未能为 SSL/TLS 安全通道建立信任关系”问题
        /// </summary>
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }


        /// <summary>
        /// 构造函数：主窗体
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate; //解决：“未能为 SSL/TLS 安全通道建立信任关系”
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; //解决：“请求被终止：未能创建SSL/TLS安全通道”

            ValidateIP();
            RefreshProgressBar();
            toolStripStatusLabelMe.Text = string.Format("Version {0} By JiangChao", version);
        }


        private ListViewColumnSorter lvwSorter = new ListViewColumnSorter();

        private int totleTask = 0;
        private int completeTask = 0;

        private const string version = "1.1";

        /// <summary>
        /// 方法：将一个ListView中的数据保存到指定路径的CSV文件中
        /// </summary>
        private void SaveListViewToCSV(ListView lvw, string fullPath)
        {
            FileInfo fi = new FileInfo(fullPath);
            if (!fi.Directory.Exists)
                fi.Directory.Create();
            using (FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    string data;
                    //写入列名
                    data = "";
                    for (int i = 0; i < lvw.Columns.Count; i++)
                    {
                        //CSV文件格式为双引号括住每一个单元格，双引号用两次双引号转义，逗号分隔单元格，换行表示换行
                        data += "\"" + lvw.Columns[i].Text.Replace("\"", "\"\"") + "\"";
                        if (i < lvw.Columns.Count - 1)
                            data += ",";
                    }
                    sw.WriteLine(data);

                    //写入数据
                    for (int i = 0; i < lvw.Items.Count; i++)
                    {
                        data = "";
                        for (int j = 0; j < lvw.Items[i].SubItems.Count; j++)
                        {
                            data += "\"" + lvw.Items[i].SubItems[j].Text.Replace("\"", "\"\"") + "\"";
                            if (j < lvw.Items[i].SubItems.Count - 1)
                                data += ",";
                        }
                        sw.WriteLine(data);
                    }
                }
            }
        }


        /// <summary>
        /// 方法：点分十进制的IP地址转换成十进制整数
        /// </summary>
        private int IpToInt(string b1, string b2, string b3, string b4)
        {
            return Convert.ToInt32(b1) * 256 * 256 * 256 + Convert.ToInt32(b2) * 256 * 256 + Convert.ToInt32(b3) * 256 + Convert.ToInt32(b4);
        }


        /// <summary>
        /// 方法：十进制整数转换成点分十进制的IP地址
        /// </summary>
        private string IntToIp(int ip)
        {
            string b1 = ((ip >> 24) & 0xFF).ToString();
            string b2 = ((ip >> 16) & 0xFF).ToString();
            string b3 = ((ip >> 8) & 0xFF).ToString();
            string b4 = (ip & 0xFF).ToString();
            return b1 + "." + b2 + "." + b3 + "." + b4;
        }


        /// <summary>
        /// 方法：验证输入的IP地址是否合法，并修改按钮的有效性
        /// </summary>
        private bool ValidateIP()
        {
            string ipBegin = txtB1.Text + "." + txtB2.Text + "." + txtB3.Text + "." + txtB4.Text;
            string ipEnd = txtE1.Text + "." + txtE2.Text + "." + txtE3.Text + "." + txtE4.Text;
            string pattern = @"^((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.){3}(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])$";  //匹配IP:"[字符串开头][0-255].[0-255].[0-255].[0-255][字符串结尾]"的正则表达式
            if (Regex.IsMatch(ipBegin, pattern) && Regex.IsMatch(ipEnd, pattern) && (IpToInt(txtB1.Text, txtB2.Text, txtB3.Text, txtB4.Text) <= IpToInt(txtE1.Text, txtE2.Text, txtE3.Text, txtE4.Text)))
                return btnGet.Enabled = true;
            else
                return btnGet.Enabled = false;
        }


        /// <summary>
        /// 方法：通过网址获取网页标题
        /// </summary>
        private string GetWebTitle(string url)
        {
            /*
             * 获取网页源码方案:
             * 1、用WebClient设置好Encoding直接DownloadString()
             * 2、用WebClient的DownloadData()下载字节数组，然后用Encoding.GetString()方法
             * 3、用WebBrowser
             * 4、用WebRequest和WebResponse，得到源码的网络流，然后使用StreamReader的ReadToEnd()读取流
             * 5、用WebRequest和WebResponse，得到源码的网络流，然后转换成内存流，然后转换成字节数组，然后用Encoding.GetString()方法
            */

            #region 使用WebClient的方案，由于无法处理采用压缩技术的网页，所以淘汰
            //WebClient myWebClient = new WebClient();
            //myWebClient.Encoding = Encoding.GetEncoding("utf-8");
            //string pageHtml = myWebClient.DownloadString(url);
            ////如果编码是GBK则使用GBK编码重新下载网页
            ////正则的含义：以【<meta】开头，之后重复若干个不是【>】的字符但尽可能少重复（即保证取第一个匹配到的charset），之后是【charset】，之后是零个或若干个空格，之后是零个或一个【"】，之后是零个或若干个空格，之后匹配长度大于一的“字母、数字、减号”字符串并添加到charset组中，之后是情况1或者情况2，情况1：一个不是“字母数字减号和【>】”的字符，之后是若干个不是【>】的字符，之后是一个【>】；情况2：直接跟一个【>】
            //string charset = Regex.Match(pageHtml, @"<meta[^>]*?charset\s*=\s*""?\s*(?'charset'[a-zA-Z0-9-]+)([^a-zA-Z0-9>-][^>]*>|>)", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture).Groups["charset"].ToString();
            //if (Regex.IsMatch(charset, @"gbk|gb2312|gb18030", RegexOptions.IgnoreCase))
            //{
            //    myWebClient.Encoding = Encoding.GetEncoding("GB18030");
            //    pageHtml = myWebClient.DownloadString(url);
            //}
            //string title = Regex.Match(pageHtml, @"<title>(?'title'[\s\S]*?)</title>", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture).Groups["title"].ToString();
            //return title;
            #endregion

            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string pageHtml;
            string charset;
            string title;
            using (Stream pageStream = response.GetResponseStream())
            {
                byte[] pageData;
                //将网络流转换成内存流，然后再转换成字节数组。网络流不支持查询长度，所以要转换
                byte[] buffer = new byte[1024];
                int actual = 0;
                using (MemoryStream pageMemoryStream = new MemoryStream())
                {
                    while ((actual = pageStream.Read(buffer, 0, buffer.Length)) > 0)
                        pageMemoryStream.Write(buffer, 0, actual);
                    pageData = pageMemoryStream.ToArray();
                }
                pageHtml = Encoding.GetEncoding("utf-8").GetString(pageData);
                //如果编码是GBK则使用GBK编码读取流
                //正则的含义：以【<meta】开头，之后重复若干个不是【>】的字符但尽可能少重复（即保证取第一个匹配到的charset），之后是【charset】，之后是零个或若干个空格，之后是零个或一个【"】，之后是零个或若干个空格，之后匹配长度大于一的“字母、数字、减号”字符串并添加到charset组中，之后是情况1或者情况2，情况1：一个不是“字母数字减号和【>】”的字符，之后是若干个不是【>】的字符，之后是一个【>】；情况2：直接跟一个【>】
                charset = Regex.Match(pageHtml, @"<meta[^>]*?charset\s*=\s*""?\s*(?'charset'[a-zA-Z0-9-]+)([^a-zA-Z0-9>-][^>]*>|>)", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture).Groups["charset"].ToString();
                if (Regex.IsMatch(charset, @"gbk|gb2312|gb18030", RegexOptions.IgnoreCase))
                    pageHtml = Encoding.GetEncoding("GB18030").GetString(pageData);
                title = Regex.Match(pageHtml, @"<title>(?'title'[\s\S]*?)</title>", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture).Groups["title"].ToString();
            }
            response.Close();
            return title;
        }


        /// <summary>
        /// 方法：异步获取网页标题，立即在列表中显示，并在异步任务完成后更新结果
        /// </summary>
        private BackgroundWorker GetWebTitleAsync(string url)
        {
            MyData data = new MyData();
            data.URL = url;
            data.State = "正在查询";
            lvwResult.Items.Add(data.LvwItem);
            totleTask++;
            RefreshProgressBar();

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            bw.RunWorkerAsync(data);
            return bw;
        }


        /// <summary>
        /// 方法：刷新进度条
        /// </summary>
        private void RefreshProgressBar()
        {
            if (toolStripProgressBar.IsDisposed)
                return;
            if (totleTask != 0)
                toolStripProgressBar.Value = (int)((float)completeTask / totleTask * 1000);
            else
                toolStripProgressBar.Value = 0;
            toolStripStatusLabelProgress.Text = "完成进度：" + completeTask + "/" + totleTask;
        }


        /// <summary>
        /// 事件：BackgroundWorker异步操作完成
        /// </summary>
        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((MyData)e.Result).UpdateItem();
            completeTask++;
            RefreshProgressBar();
        }


        /// <summary>
        /// 事件：BackgroundWorker异步操作开始
        /// </summary>
        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            MyData data = (MyData)e.Argument;
            try
            {
                data.Title = GetWebTitle(data.URL);
                data.State = "OK";
            }
            catch (WebException ex)
            {
                data.State = ex.Message;
            }
            catch (Exception ex)
            {
                data.State = ex.Message;
            }
            finally
            {
                e.Result = data;
            }
        }


        /// <summary>
        /// 事件：IP文本框的TextChanged事件
        /// </summary>
        private void txtIP_TextChanged(object sender, EventArgs e)
        {
            txtE1.Text = txtB1.Text;
            txtE2.Text = txtB2.Text;
            ValidateIP();
        }


        /// <summary>
        /// 事件：IP文本框的KeyPress事件
        /// </summary>
        private void txtIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0123456789\b".IndexOf(e.KeyChar) < 0)
                e.Handled = true;
        }


        /// <summary>
        /// 事件：ListView的列头点击事件，只在点击时排序Add项目不排序
        /// </summary>
        private void lvwResult_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // 检查点击的列是不是现在的排序列.
            if (e.Column == lvwSorter.SortColumn)
            {
                // 重新设置此列的排序方法.
                if (lvwSorter.Order == SortOrder.Ascending)
                    lvwSorter.Order = SortOrder.Descending;
                else
                    lvwSorter.Order = SortOrder.Ascending;
            }
            else
            {
                // 设置排序列，默认为正向排序
                lvwSorter.SortColumn = e.Column;
                lvwSorter.Order = SortOrder.Ascending;
            }
            // 用新的排序方法对ListView排序
            lvwResult.ListViewItemSorter = lvwSorter;
            lvwResult.ListViewItemSorter = null;
        }


        /// <summary>
        /// 按钮：通过IP地址循环获取
        /// </summary>
        private void btnGet_Click(object sender, EventArgs e)
        {
            Stopwatch swRemainTime = new Stopwatch();
            swRemainTime.Start();

            //lvwResult.BeginUpdate();
            //lvwResult.SuspendLayout();
            int begin = IpToInt(txtB1.Text, txtB2.Text, txtB3.Text, txtB4.Text);
            int end = IpToInt(txtE1.Text, txtE2.Text, txtE3.Text, txtE4.Text);
            string isHTTPS = chkIsHTTPS.Checked ? @"https://" : @"http://";
            int doEventCount = 0;
            int remainTimeCount = 0;
            toolStripStatusLabelTotle.Text = "(" + (end - begin + 1 + totleTask) + ")";
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            btnStop.Visible = true;
            for (; begin <= end; begin++)
            {
                GetWebTitleAsync(isHTTPS + IntToIp(begin));

                if (++remainTimeCount >= 1000)
                {
                    TimeSpan ts = TimeSpan.FromSeconds(swRemainTime.Elapsed.TotalSeconds / 1000 * (end - begin + 1));
                    toolStripStatusLabelRemainTime.Text = "预计剩余添加时间：" + ts.Minutes + "分" + ts.Seconds + "秒";
                    swRemainTime.Restart();
                    remainTimeCount = 0;
                }

                if (++doEventCount >= 100)
                {
                    Application.DoEvents();
                    doEventCount = 0;
                    if (btnStop.Visible == false)
                        break;
                }
            }
            btnStop.Visible = false;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            toolStripStatusLabelTotle.Text = "";
            toolStripStatusLabelRemainTime.Text = "";
            //lvwResult.EndUpdate();
            //lvwResult.ResumeLayout();
        }


        /// <summary>
        /// 按钮：通过网址循环获取
        /// </summary>
        private void btnAddressGet_Click(object sender, EventArgs e)
        {
            Stopwatch swRemainTime = new Stopwatch();
            swRemainTime.Start();

            //lvwResult.BeginUpdate();
            //lvwResult.SuspendLayout();
            string[] urls = txtURL.Lines;
            int doEventCount = 0;
            int remainTimeCount = 0;
            toolStripStatusLabelTotle.Text = "(" + (urls.Length + totleTask) + ")";
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            btnStop.Visible = true;
            for (int i = 0; i < urls.Length; i++)
            {
                GetWebTitleAsync(urls[i]);

                if (++remainTimeCount >= 1000)
                {
                    TimeSpan ts = TimeSpan.FromSeconds(swRemainTime.Elapsed.TotalSeconds / 1000 * (urls.Length - i));
                    toolStripStatusLabelRemainTime.Text = "预计剩余添加时间：" + ts.Minutes + "分" + ts.Seconds + "秒";
                    swRemainTime.Restart();
                    remainTimeCount = 0;
                }

                if (++doEventCount >= 100)
                {
                    Application.DoEvents();
                    doEventCount = 0;
                    if (btnStop.Visible == false)
                        break;
                }
            }
            btnStop.Visible = false;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            toolStripStatusLabelTotle.Text = "";
            toolStripStatusLabelRemainTime.Text = "";
            //lvwResult.EndUpdate();
            //lvwResult.ResumeLayout();
        }


        /// <summary>
        /// 按钮：打开网址
        /// </summary>
        private void 打开网址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwResult.SelectedItems)
            {
                if (Regex.IsMatch(item.Text, @"\A\s*https?://"))
                {
                    try
                    {
                        Process.Start(item.Text);
                    }
                    catch { }
                }
            }
        }


        /// <summary>
        /// 按钮：保存结果
        /// </summary>
        private void 保存结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveListViewToCSV(lvwResult, saveFileDialogCSV.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "发生错误，保存文件失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// 按钮：停止
        /// </summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Visible = false;
        }


        /// <summary>
        /// 按钮：左键双击Version发送反馈,右键双击Version显示或隐藏测试按钮
        /// </summary>
        private void toolStripStatusLabelMe_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                try
                {
                    Process.Start(string.Format(@"mailto:jiangchao@inspur.com?subject=【反馈】获取网页标题V{0}", version));
                }
                catch { }
            }
            else if (e.Clicks == 2 && e.Button == MouseButtons.Right)
            {
                btnTest.Visible = !btnTest.Visible;
            }
        }


        /// <summary>
        /// 按钮：测试
        /// </summary>
        private void btnTest_Click(object sender, EventArgs e)
        {
            #region 另一种获取网页源码的方法
            //HttpWebRequest request = WebRequest.CreateHttp(txtURL.Text);
            //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //string pageHtml;
            //using (Stream pageStream = response.GetResponseStream())
            //{
            //    using (StreamReader sr = new StreamReader(pageStream, Encoding.GetEncoding("utf-8")))
            //        pageHtml = sr.ReadToEnd();
            //    string title = Regex.Match(pageHtml, @"<title>(?'title'[\s\S]*?)</title>", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture).Groups["title"].ToString();
            //}
            #endregion
        }

    }
}
