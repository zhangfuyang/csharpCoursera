using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Collections;
using System.IO;
using System.Web;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace homework
{
    public partial class Form1 : Form
    {
        private int count = 0;
        private Hashtable urls = new Hashtable();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://www.baidu.com/s?wd=" + System.Web.HttpUtility.UrlEncode(textbox.Text);
            webBrowser1.Navigate(url);
            
            Crawl(url);

            
        }

        async private void Crawl(string url)
        {
            urls.Clear();
            string html = await load(url);
            Parse(html);
            listBox2.Items.Clear();
            foreach(string l in urls.Keys)
            {
                this.listBox2.Items.Add(l.Replace("'", "").Replace("\"", ""));
            }
        }
        private async Task<string> load(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                Task<string> getStringTask = client.GetStringAsync(url);
                
                string html = await getStringTask;//读取数据
                return html;
            }
            catch (WebException ex)
            {

            }
            return "";
        }

        public void Parse(string html)
        {

            string strRef = @"(mu=[ ]*[""']http[^""'#>]+[""']|\s+href\s=\s[""']http://www.baidu.com[^""'#>]+link?[^""'#>]+[""'])";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');
                if (strRef.Length == 0) continue;

                if (urls[strRef] == null) urls[strRef] = false;
            }
        }

        private byte[] StreamToMemory(Stream stream)
        {
            int buffersize = 16384;
            byte[] buffer = new byte[buffersize];
            MemoryStream ms = new MemoryStream();
            while (true)
            {
                int numBytesRead = stream.Read(buffer, 0, buffersize);
                if (numBytesRead <= 0)
                    break;
                ms.Write(buffer, 0, numBytesRead);
            }
            return ms.ToArray();
        }
        public delegate void Func(string s);
        private void text_TextChanged(object sender, EventArgs e)
        {
            string t = textbox.Text;
            if (t == "")
            {
                listBox1.Items.Clear();
                return;
            }
            Func Funcdelegate = Baidu;
            Funcdelegate.BeginInvoke(t, null, Funcdelegate);
            //Baidu(t);
        }
        public static Random rand = new Random();
        private delegate void AddMsg(string msg);
        private void Baidu(string text)
        {
            string url = "http://suggestion.baidu.com/su?wd=" + myUrlEncode(text);
            url += "&rnd" + rand.Next();
            string suggest = DownLoad(url);
            string sug = System.Text.RegularExpressions.Regex.Replace(suggest, @".*,s:\[([^\]]*)\].*", "$1");
            if (sug == null || sug == "")
                return;
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new AddMsg(this.AddMsgFun), new object[] { sug });
            }
            else
            {
                this.listBox1.Items.Clear();
                string[] ary = sug.Split(',');
                for (int i = 0; i < ary.Length; i++) //填充列表
                {
                    this.listBox1.Items.Add(ary[i].Replace("'", "").Replace("\"", ""));
                }
            }
        }
        private void AddMsgFun(string msg)
        {
            this.listBox1.Items.Clear();
            string[] ary = msg.Split(',');
            for (int i = 0; i < ary.Length; i++) //填充列表
            {
                this.listBox1.Items.Add(ary[i].Replace("'", "").Replace("\"", ""));
            }
        }
        public static string myUrlEncode(string wd)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(wd);
            string res = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                res += "%" + bytes[i].ToString("X2");
            }
            return res;
        }
        private string DownLoad(string url)
        {
            System.Net.WebClient webclient = new System.Net.WebClient();
            webclient.Credentials = new System.Net.CredentialCache();
            //webclient.Headers["Cookie"]= "BAIDUID=956846E39BCCC16731356AEE5C12DF17:FG=1; BD_UTK_DVT=1; BDSTAT=6f9b617e0eaf10780a55b319ebc4b74543a98226f8fc1e178a82b9014b90d77b; MAPCITY=010,";
            webclient.Headers["Cookie"] = "BDUSS=FkcmZZckFNN1h3V0JxdDN4aWFVWmI0bDVwakpzYn5BZn5ZQ25KQkxOVGtvQlpOQVFBQUFBJCQAAAAAAAAAAApRLgtnzNkJZHN0YW5nMjAwMAAAAAAAAAAAAAAAAAAAAAAAAAAAAADAymRxAAAAAMDKZHEAAAAAuFNCAAAAAAAxMC4yMy4yNOQT70zkE";

            byte[] data = webclient.DownloadData(url);
            return System.Text.Encoding.Default.GetString(data);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0) return;

            string sug = this.listBox1.SelectedItem.ToString();
            this.textbox.Text = sug;

            this.textbox.Focus();
            this.textbox.SelectionStart = this.textbox.Text.Length;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedIndex < 0)
                return;
            string sug = this.listBox2.SelectedItem.ToString();
            this.textbox.Text = sug;

            this.textbox.Focus();
            this.textbox.SelectionStart = this.textbox.Text.Length;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsUrl(textbox.Text))
                webBrowser1.Navigate(textbox.Text);
            else
                MessageBox.Show("请输入正确的url地址");
        }
        public static bool IsUrl(string str)
        {
            try
            {
                string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
                return Regex.IsMatch(str, Url);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
