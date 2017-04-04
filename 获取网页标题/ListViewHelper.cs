using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 获取网页标题
{
    /// <summary>
    /// 对ListView点击列标题自动排序功能
    /// </summary>
    public static class ListViewHelper
    {
        /// <summary>
        /// 事件：将此事件添加到ListView控件的ColumnClick事件中
        /// </summary>
        public static void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lvw = sender as ListView;
            ListViewColumnSorter lvwSorter = lvw.ListViewItemSorter as ListViewColumnSorter;
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
            lvw.Sort();
        }
    }


    /// <summary>
    /// 开启双缓冲特性的ListView
    /// </summary>
    public class DoubleBufferListView : ListView
    {
        public DoubleBufferListView()
        {
            //方法一：
            DoubleBuffered = true;

            //方法二：(ControlStyles.DoubleBuffer已经过时了，被弃用；方法二和方法一等效，MSDN推荐方法一)
            //SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            //UpdateStyles();
        }
    }


    /// <summary>
    /// 继承自IComparer，用该类的实例设置ListView控件的ListViewItemSorter属性
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {

        /// <summary>
        /// 属性：获取或设置按照哪一列排序.
        /// </summary>
        public int SortColumn { get; set; }

        /// <summary>
        /// 属性：获取或设置排序方式.
        /// </summary>
        public SortOrder Order { get; set; }

        /// <summary>
        /// 声明CaseInsensitiveComparer类对象
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ListViewColumnSorter()
        {
            // 默认按第一列排序
            SortColumn = 0;

            // 排序方式为不排序
            Order = SortOrder.None;

            // 初始化CaseInsensitiveComparer类对象
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// 重写IComparer接口.
        /// </summary>
        /// <param name="x">要比较的第一个对象</param>
        /// <param name="y">要比较的第二个对象</param>
        /// <returns>比较的结果.如果相等返回0，如果x大于y返回1，如果x小于y返回-1</returns>
        public int Compare(object x, object y)
        {
            // 如果不排序，则直接返回0
            if (Order == SortOrder.None)
                return 0;

            int compareResult;

            // 将比较对象转换为ListViewItem对象
            ListViewItem listviewX = (ListViewItem)x;
            ListViewItem listviewY = (ListViewItem)y;

            string xText = listviewX.SubItems[SortColumn].Text;
            string yText = listviewY.SubItems[SortColumn].Text;

            int xInt, yInt;

            // 比较,如果值为IP地址，则根据IP地址的规则排序。
            if (IsIP(xText) && IsIP(yText))
            {
                // 匹配IP:"[0-255].[0-255].[0-255].[0-255][字符串结尾]"的正则表达式
                string pattern = @"((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.){3}(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])$";
                string xIp = Regex.Match(xText, pattern).ToString();
                string yIp = Regex.Match(yText, pattern).ToString();
                compareResult = CompareIp(xIp, yIp);
            }
            else if (int.TryParse(xText, out xInt) && int.TryParse(yText, out yInt)) //是否全为数字
            {
                //比较数字
                compareResult = CompareInt(xInt, yInt);
            }
            else
            {
                //比较对象
                compareResult = ObjectCompare.Compare(xText, yText);
            }

            // 根据上面的比较结果返回正确的比较结果
            if (Order == SortOrder.Ascending)
            {
                // 因为是正序排序，所以直接返回结果
                return compareResult;
            }
            else if (Order == SortOrder.Descending)
            {
                // 如果是反序排序，所以要取负值再返回
                return (-compareResult);
            }
            else
            {
                // 如果既不是正序也不是反序，即不排序则返回0
                return 0;
            }
        }

        /// <summary>
        /// 判断是否为正确的IP地址，格式为：[字符串开头][空或http://或https://][0-255].[0-255].[0-255].[0-255][字符串结尾]
        /// </summary>
        /// <param name="ip">需验证的IP地址</param>
        /// <returns></returns>
        private bool IsIP(string ip)
        {
            // 匹配IP:"[字符串开头][空或http://或https://][0-255].[0-255].[0-255].[0-255][字符串结尾]"的正则表达式
            string pattern = @"^(http://|https://)?((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.){3}(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])/?$";
            return Regex.IsMatch(ip, pattern);
        }

        /// <summary>
        /// 比较两个数字的大小
        /// </summary>
        /// <param name="ipx">要比较的第一个对象</param>
        /// <param name="ipy">要比较的第二个对象</param>
        /// <returns>比较的结果.如果相等返回0，如果x大于y返回1，如果x小于y返回-1</returns>
        private int CompareInt(int x, int y)
        {
            if (x > y)
                return 1;
            else if (x < y)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// 比较两个IP地址的大小
        /// </summary>
        /// <param name="ipx">要比较的第一个对象</param>
        /// <param name="ipy">要比较的第二个对象</param>
        /// <returns>比较的结果.如果相等返回0，如果x大于y返回1，如果x小于y返回-1</returns>
        private int CompareIp(string ipx, string ipy)
        {
            string[] ipxs = ipx.Split('.');
            string[] ipys = ipy.Split('.');

            for (int i = 0; i < 4; i++)
            {
                if (Convert.ToInt32(ipxs[i]) > Convert.ToInt32(ipys[i]))
                    return 1;
                else if (Convert.ToInt32(ipxs[i]) < Convert.ToInt32(ipys[i]))
                    return -1;
            }
            return 0;
        }
    }
}