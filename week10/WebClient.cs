using System;
using System.Net;
using System.Text;

class Test
{
	static void Main()
	{
		string url = @"http://www.baidu.com";
		WebClient client = new WebClient();
		byte[] pageData = client.DownloadData(url);
		string pageHtml = Encoding.Default.GetString(pageData);
		Console.WriteLine(pageHtml);
	}

}