using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using mshtml;

namespace Get利用百度搜索引擎
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Encoding gb2312 = Encoding.GetEncoding("GB2312");
            string uri = "http://baidu.com/s?wd=" + System.Web.HttpUtility.UrlEncode(txtKeyword.Text);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                richTextBoxCode.Text = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            webBrowserContent.DocumentText = richTextBoxCode.Text;
            webBrowserContent.ScriptErrorsSuppressed = true; //屏蔽脚本错误

        }

        private void btnGoogleSearch_Click(object sender, EventArgs e)
        {

            Encoding gb2312 = Encoding.GetEncoding("GB2312");
            string uri = "http://www.google.com.hk/search?lr=lang_zh-CN&safe=strict&q=" + System.Web.HttpUtility.UrlEncode(txtKeyword.Text,gb2312);
            HttpWebRequest request =(HttpWebRequest) WebRequest.Create(uri);
        //    string htmlString=string.Empty;
            using(HttpWebResponse response=(HttpWebResponse)request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.Default);
                richTextBoxCode.Text = reader.ReadToEnd();
                stream.Close();
                reader.Close();
                stream.Close();
            }
            webBrowserContent.DocumentText = richTextBoxCode.Text;
            webBrowserContent.ScriptErrorsSuppressed = true;
        }
    }
}
