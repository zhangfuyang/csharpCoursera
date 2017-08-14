using System;
using System.IO;

public class Logger
{
    static void Main()
    {
        LogToFile("msg", true, true);
        //try
        //{
        //    FileStream aFile = new FileStream(@"E:\C#\coursera\week6\a.log", FileMode.OpenOrCreate);
        //    StreamWriter sw = new StreamWriter(aFile);
        //    sw.WriteLine("为今后我们之间的进一步合作，");
        //    sw.WriteLine("为我们之间日益增进的友谊，");
        //    sw.Write("为朋友们的健康幸福，");
        //    sw.Write("干杯！朋友！");
        //    sw.Close();
        //}
        //catch (IOException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    Console.ReadLine();
        //    return;
        //}
    }

    public static string LogFile = @"E:\C#\coursera\week6\c.log";

    public static void LogToFile(string str, bool bWithTime, bool bAppendLineFeed)
    {
        if (str == null) return;

        try
        {
            string fname = LogFile;

            if (fname == "" || fname == null) return;

            StreamWriter writer = new StreamWriter(fname, true, System.Text.Encoding.Default);

            if (bWithTime)
                writer.WriteLine("\r\n\r\n--------- " + DateTime.Now.ToString());

            if (bAppendLineFeed)
                writer.WriteLine(str);
            else
                writer.Write(str);

            writer.Close();
        }
        catch (Exception e)
        {
            Console.Write(e);
        }
    }
}