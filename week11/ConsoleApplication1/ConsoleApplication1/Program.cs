using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace ConsoleDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            BaiduSearch baidu = new BaiduSearch();
            Console.WriteLine("请输入单词：");
            //string word = Console.ReadLine();//"腾讯 抄袭";
            string word = "software";
            string html = baidu.Search(word);
            if (!string.IsNullOrEmpty(html))
            {
                int count = baidu.GetSearchCount(html);
                Console.WriteLine(string.Format("word:{0} count:{1}", word, count));
                if (count > 0)
                {
                    List<Keyword> keywords = baidu.GetKeywords(html, word);
                    foreach (Keyword item in keywords)
                    {
                        Console.WriteLine(item.Title + " " + item.Link);
                    }
                }
            }

            Console.ReadLine();
        }
    }

    class BaiduSearch
    {
        protected string uri = "http://www.baidu.com/s?wd=";
        //protected string uri = "http://www.baidu.com/s?wd=software&pn=10&usm=2"; // 第二页
        protected Encoding queryEncoding = Encoding.GetEncoding("gb2312");
        protected Encoding pageEncoding = Encoding.GetEncoding("gb2312");
        protected string resultPattern = @"(?<=找到相关结果[约]?)[0-9,]*?(?=个)";

        public string Search(string word)
        {
            string html = string.Empty;
            //string uriString = uri + System.Web.HttpUtility.UrlEncode(word, queryEncoding);
            string uriString = uri + word;
            try
            {
                html = WebFunc.GetHtml(uriString, pageEncoding);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return html;
        }

        public int GetSearchCount(string html)
        {
            int result = 0;
            string searchcount = string.Empty;

            Regex regex = new Regex(resultPattern);
            Match match = regex.Match(html);

            if (match.Success)
            {
                searchcount = match.Value;
            }
            else
            {
                searchcount = "0";
            }

            if (searchcount.IndexOf(",") > 0)
            {
                searchcount = searchcount.Replace(",", string.Empty);
            }

            int.TryParse(searchcount, out result);

            return result;
        }

        public List<Keyword> GetKeywords(string html, string word)
        {
            List<Keyword> keywords = new List<Keyword>();

            Regex regTable = new Regex(@"(?is)<table[^>]*?id=(['""]?)(\d{1}|10)\1[^>]*>(?><table[^>]*>(?<o>)|</table>(?<-o>)|(?:(?!</?table\b).)*)*(?(o)(?!))</table>", RegexOptions.IgnoreCase);
            //Regex regTable = new Regex(@"(?is)<table[^>]*?id=(['""]?)(\d{2})\1[^>]*>(?><table[^>]*>(?<o>)|</table>(?<-o>)|(?:(?!</?table\b).)*)*(?(o)(?!))</table>", RegexOptions.IgnoreCase);
            Regex regA = new Regex(@"(?is)<a\b[^>]*?href=(['""]?)(?<link>[^'""\s>]+)\1[^>]*>(?<title>.*?)</a>", RegexOptions.IgnoreCase);

            MatchCollection mcTable = regTable.Matches(html);
            foreach (Match mTable in mcTable)
            {
                if (mTable.Success)
                {
                    Match mA = regA.Match(mTable.Value);
                    if (mA.Success)
                    {
                        Keyword keyword = new Keyword();
                        keyword.Link = mA.Groups["link"].Value;
                        keyword.Title = mA.Groups["title"].Value;
                        keywords.Add(keyword);
                    }
                }
            }

            return keywords;
        }
    }

    class Keyword
    {
        public string Title { get; set; }
        public string Link { get; set; }
        //private string title;
        //public string Title { get { return title; } set { title = value; } }
        //private string link;
        //public string Link { get { return link; } set { link = value; } }
    }

    static class WebFunc
    {
        public static string GetHtml(string url)
        {
            return GetHtml(url, Encoding.UTF8);
        }

        public static string GetHtml(string url, Encoding encoding)
        {
            WebRequest request;
            request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response;
            response = request.GetResponse();
            return new StreamReader(response.GetResponseStream(), encoding).ReadToEnd();
        }
    }
}