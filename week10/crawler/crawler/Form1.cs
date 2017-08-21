using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace crawler
{
    public partial class Form1 : Form
    {
        private WebClient webClient = new WebClient();
        private Hashtable urls = new Hashtable();
        private int count = 0;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string startUrl = textBox1.Text;
            this.urls.Add(startUrl, false);

            new Thread(new ThreadStart(Crawl)).Start();
        }

        private void Crawl()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            for(int i = 1; i<=100; i++)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url])
                        continue;
                    current = url;
                    break;
                }
                if (current == null)
                    break;
                string html = Download(current);
                urls[current] = true;
                Parse(html);
            }
        }

        private string Download(string url)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Timeout = 20000;
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                byte[] buffer = StreamToMemory(response.GetResponseStream());
                string fileName = count + ".html";
               // FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
               // fs.Write(buffer, 0, buffer.Length);
                //fs.Close();
                string html = Encoding.UTF8.GetString(buffer);
                count++;
                textBox2.AppendText("爬第" + count + "个页面" + "网址: " + url + "\r\n");
                return html;
            }
            catch(WebException ex)
            {

            }
            return "";
        }

        private byte[] StreamToMemory(Stream stream)
        {
            int buffersize = 16384;
            byte[] buffer = new byte[buffersize];
            MemoryStream ms = new MemoryStream();
            while(true)
            {
                int numBytesRead = stream.Read(buffer, 0, buffersize);
                if (numBytesRead <= 0)
                    break;
                ms.Write(buffer, 0, numBytesRead);
            }
            return ms.ToArray();
        }

        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[ ]*=[ ]*[""']http[^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');
                if (strRef.Length == 0) continue;

                if (urls[strRef] == null) urls[strRef] = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
