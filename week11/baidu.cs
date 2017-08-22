using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Text.RegularExpressions;
 using System.Web;
 using System.Net;
using System.IO;
namespace baiduRobotStrim
{
    struct BaiduEntry
    {
        public string title, brief, link;
    }
    class Program
    {
        static string GetHtml(string keyword)
        {
            string url = @"http://www.baidu.com/";
            string encodedKeyword = HttpUtility.UrlEncode(keyword, Encoding.GetEncoding(936));
            //百度使用codepage 936字符编码来作为查询串，果然专注于中文搜索……
            //更不用说，还很喜欢微软
            //谷歌能正确识别UTF-8编码和codepage这两种情况，不过本身网页在HTTP头里标明是UTF-8的
            //估计谷歌也不讨厌微软（以及微软的专有规范）
            string query = "s?wd=" + encodedKeyword;

            HttpWebRequest req;
            HttpWebResponse response;
            Stream stream;
            req = (HttpWebRequest)WebRequest.Create(url + query);
            response = (HttpWebResponse)req.GetResponse();
            stream = response.GetResponseStream();
            int count = 0;
            byte[] buf = new byte[8192];
            string decodedString = null;
            StringBuilder sb = new StringBuilder();
            try
            {
                Console.WriteLine("正在读取网页{0}的内容……", url + query);
                do
                {
                    count = stream.Read(buf, 0, buf.Length);
                    if (count > 0)
                    {
                        decodedString = Encoding.GetEncoding(936).GetString(buf, 0, count);
                        sb.Append(decodedString);
                    }
                } while (count > 0);
            }
            catch
            {
                Console.WriteLine("网络连接失败，请检查网络设置。");
            }
            return sb.ToString();
        }
        static void PrintResult(List<BaiduEntry> entries)
        {
            int count = 0;
            entries.ForEach(delegate(BaiduEntry entry)
            {
                Console.WriteLine("找到了百度的第{0}条搜索结果：", count += 1);
                if (entry.link != null)
                {
                    Console.WriteLine("找到了一条链接：");
                    Console.WriteLine(entry.link);
                }
                if (entry.title != null)
                {
                    Console.WriteLine("标题为：");
                    Console.WriteLine(entry.title);
                }
                if (entry.brief != null)
                {
                    Console.WriteLine("下面是摘要：");
                    Console.WriteLine(entry.brief);
                }
                Program.Cut();
            });
        }
        static void simpleOutput()
        {
            string html = "<table><tr><td><font>test</font><a>hello</a><br></td></tr></table>";
            Console.WriteLine(RemoveSomeTags(html));
        }
        static string RemoveVoidTag(string html)
        {
            string[] filter = { "<br>" };
            foreach (string tag in filter)
            {
                html = html.Replace(tag, "");
            }
            return html;
        }
        static string ReleaseXmlTags(string html)
        {
            string[] filter = { "<a.*?>", "</a>", "<em>", "</em>", "<b>", "</b>", "<font.*?>", "</font>" };
            foreach (string tag in filter)
            {
                html = Regex.Replace(html, tag, "");
            }
            return html;
        }

        static string RemoveSomeTags(string html)
        {
            html = RemoveVoidTag(html);
            html = ReleaseXmlTags(html);
            return html;
        }
        static void Cut()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
        static void MainProc(string input)
        {
            MainProc(input, false);
        }
        static void MainProc(string input, bool tagsForBrief)
        {
            Regex r = new Regex("<table.*?</table>", RegexOptions.IgnoreCase);
            //提取出(<table>,</table>)对，并等待进一步处理。
            Match m = r.Match(input);
            List<string> collection = new List<string>();
            while (m.Success)
            {
                collection.Add(m.Value);
                //找出tagname为table的节点并存储到collection变量中
                m = m.NextMatch();
            }
            List<BaiduEntry> entries = new List<BaiduEntry>();
            collection.ForEach(delegate(string entry)
            {
                r = new Regex("<td.*?>(.*)</td>", RegexOptions.IgnoreCase);
                if(r.IsMatch(entry))
                {//从entry字符串里捕获到的就是百度里存储在每个table标签里的td标签了。
                    //现阶段中，百度页面里有几个table标签是兄弟节点的关系，
                    //第一个table标签是一个广告，剩下的table标签刚好都是搜索结果。
                    //理想状态下input字符串里只有几个由table标签组织的搜索结果项。
                    //理应使用预处理过的字符串来调用本函数
                    m = r.Match(entry);
                    string html = m.Groups[1].Value;//直接使用捕获分组1的值。
                    //html变量里存储着td节点的innerHTML，那里有真正的搜索结果
                    BaiduEntry baidu = new BaiduEntry();
                    r = new Regex("<a.*?href=\"(.*?)\".*?>", RegexOptions.IgnoreCase);
                    if (r.IsMatch(html))
                    {
                        string linkString = r.Match(html).Groups[1].Captures[0].Value;
                        baidu.link = linkString;
                    }
                    r = new Regex("<font.*</font>");
                    //td节点下有一些嵌套了2层的font标签，把这个大的font标签拿下来。
                    html = r.Match(html).Value;//现在html变量里存储着比较浓缩的信息了。

                    r = new Regex("<font.*?>(.*?)</font>");
                    Match contentMatch = r.Match(html);
                    if (contentMatch.Success)
                    {
                        string title = contentMatch.Groups[1].Captures[0].Value;
                        title = RemoveSomeTags(title);
                        baidu.title = title;
                        contentMatch = contentMatch.NextMatch();
                        if (contentMatch.Success)
                        {
                            string brief = contentMatch.Groups[1].Captures[0].Value;
                            int splitIndex = brief.IndexOf("<font");
                            if (splitIndex > -1)
                                brief = brief.Substring(0, splitIndex);
                            if (!tagsForBrief)
                                brief = RemoveSomeTags(brief);
                            //如果不需要带有HTML格式的摘要，那么就处理掉HTML标签
                            baidu.brief = brief;
                        }
                    }
                    else
                    {
                        if (html == "") return;
                        Console.WriteLine("怪了，这里没有找到任何结果。");
                        Console.WriteLine("如果百度已经更改了页面的结构那么程序需要重新设计。");
                        Console.WriteLine("Mark:");
                        Console.WriteLine(html);
                        Cut();
                        Cut();
                        Cut();
                    }
                    entries.Add(baidu);
                }
            });

            PrintResult(entries);
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("请输入一个关键字。");
            string keyword;
            keyword = Console.ReadLine();
            Console.WriteLine("正在从百度上获取结果，请稍等……");
            string input;
            input = GetHtml(keyword);
            Regex r = new Regex("<table.*class=\"result\"[\\s\\S]*</table>", RegexOptions.IgnoreCase);
            input = r.Match(input).Value;
            MainProc(input);
            Console.ReadKey(true);
        }
    }
}